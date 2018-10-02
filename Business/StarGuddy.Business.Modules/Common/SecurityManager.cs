// -------------------------------------------------------------------------------
// <copyright file="SecurityManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
using Microsoft.AspNetCore.Http;
using StarGuddy.Api.Models.Account;
using StarGuddy.Api.Models.Interface.Account;

namespace StarGuddy.Business.Modules.Common
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using StarGuddy.Api.Models.Account;
    using StarGuddy.Api.Models.Interface.Account;
    using StarGuddy.Api.Models.Security;
    using StarGuddy.Business.Interface.Common;
    using StarGuddy.Core.Constants;
    using StarGuddy.Repository.Interface;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Security Manager Class
    /// </summary>
    /// <seealso cref="StarGuddy.Business.Interface.Common.ISecurityManager" />
    public class SecurityManager : ISecurityManager
    {
        #region /// Properties

        private IConfiguration _configuration;
        private readonly ISettingsMasterRepository _settingsMaseterRepository;
        private string SeceretKey => _configuration.GetAppSettingValue(AppSettings.JwtSecret);


        #endregion

        #region /// Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityManager"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public SecurityManager(IConfiguration configuration, ISettingsMasterRepository settingsMaseterRepository)
        {
            _configuration = configuration;
            _settingsMaseterRepository = settingsMaseterRepository;
        }
        #endregion

        #region /// Settings Master
        public async Task<string> GetSettingsValue(string key)
        {
            var settings = await _settingsMaseterRepository.GetValue(key);
            if (settings.IsNotNull())
            {
                return settings.Value;
            }

            return string.Empty;
        }
        #endregion

        #region /// JWT Tokens
        /// <summary>
        /// Creates the JWT packet asynchronous.
        /// </summary>
        /// <param name="applicationUser">The user.</param>
        /// <param name="securityStamp">The security stamp.</param>
        /// <returns></returns>
        public async Task<IJwtPacket> CreateJwtPacketAsync(IApplicationUser applicationUser)
        {
            return new JwtPacket()
            {
                UserId = applicationUser.UserId.ToString(),
                Token = await GetJwtSecurityTokenAsync(applicationUser),
                FirstName = applicationUser.FirstName,
                UserName = applicationUser.UserName
            };
        }

        public async Task<string> GetEmailVerificationCodeAsync(IApplicationUser applicationUser)
        {
            return await Task.Factory.StartNew(() =>
            {
                return CryptoGraphy.EncryptObject(
                     new EmailVerification
                     {
                         UserId = applicationUser.UserId.ToString(),
                         Email = applicationUser.Email,
                         SecurityStamp = applicationUser.SecurityStamp,
                         ExpiryHour = DateTime.UtcNow
                     });
            });
        }

        /// <summary>
        /// Encrypts the JWT security token asynchronous.
        /// </summary>
        /// <param name="appUser">The application user.</param>
        /// <returns>
        /// JWT Packet
        /// </returns>
        private async Task<string> GetJwtSecurityTokenAsync(IApplicationUser appUser)
        {
            return await Task.Factory.StartNew(() =>
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SeceretKey));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sid, appUser.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, appUser.UserName)
                    //new Claim(ClaimTypes.UserData, EncryptObject(appUser))
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    SigningCredentials = signingCredentials,
                    Issuer = _configuration.GetAppSettingValue(AppSettings.JwtIssuer),
                    Audience = _configuration.GetAppSettingValue(AppSettings.JwtAudience),
                    Expires = DateTime.UtcNow.AddMinutes(30)
                };

                var jwtTokenHandler = new JwtSecurityTokenHandler();

                if (jwtTokenHandler.CanWriteToken)
                {
                    var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                    return jwtTokenHandler.WriteToken(token);
                }

                return string.Empty;
            });
        }
        #endregion

        #region /// Password Hashing
        /// <summary>
        /// Hashes the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>
        /// String Value
        /// </returns>
        public async Task<string> GetHashPassword(string password)
        {
            return await Task.Factory.StartNew(() =>
            {
                if (password == null)
                {
                    throw new ArgumentNullException(nameof(password));
                }

                return CryptoGraphy.HashPasswordInternal(password);
            });
        }

        /// <summary>
        /// Verifies the hashed password.
        /// </summary>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// String Value
        /// </returns>
        public async Task<bool> VerifyHashedPassword(string hashedPassword, string password)
        {
            return await Task.Factory.StartNew(() =>
            {
                if (hashedPassword == null)
                {
                    throw new ArgumentNullException(nameof(hashedPassword));
                }
                if (password == null)
                {
                    throw new ArgumentNullException(nameof(password));
                }

                return CryptoGraphy.VerifyHashedPasswordInternal(hashedPassword, password);
            });
        }
        #endregion
    }
}


//public static class HttpContextExtensions
//{
//    public static IUserContext UserContext(this HttpContext httpContext)
//    {
//        var userContext = httpContext.Items["UserContext"];
//        return userContext != null ? (UserContext)userContext : new UserContext();
//    }
//}



//public async Task<string> ReadJwtTokenFromHeader()
//{
//    return await Task.Run(() =>
//    {
//        var JwtToken = _httpContextAccessor.HttpContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.ToString();
//        if (string.IsNullOrWhiteSpace(JwtToken))
//        {
//            throw new Exception("Invalid Token.");
//        }

//        var innerJwtTokenArr = JwtToken.Split(' ');
//        if (innerJwtTokenArr.Length != 2 || !innerJwtTokenArr[0].ToLowerInvariant().Equals("bearer"))
//        {
//            throw new Exception("Token is missing.");
//        }

//        return innerJwtTokenArr[1];
//    });

//}

/// <summary>
/// Validates the JWT security token asynchronous.
/// </summary>
/// <param name="userId">The user identifier.</param>
/// <param name="securityStamp">The security stamp.</param>
/// <returns>string value</returns>
//public async Task<bool> ValidateJwtSecurityTokenAsync(string jwtToken, string securityStamp)
//{
//    return await Task.Factory.StartNew(() =>
//    {
//        var simplePrinciple = this.GetPrincipal(jwtToken);
//        var identity = simplePrinciple.Identity as ClaimsIdentity;
//        if (identity == null)
//            return false;

//        if (!identity.IsAuthenticated)
//            return false;

//        var userIdClaim = identity.FindFirst(ClaimTypes.Sid);


//        if (userIdClaim.IsNull())
//            return false;

//        return true;
//    });
//}

//private Task<IPrincipal> AuthenticateJwtToken(string token)
//{
//    if (await ValidateJwtSecurityTokenAsync(token, out Guid userId))
//    {

//        var claims = new List<Claim> { new Claim(ClaimTypes.Sid, userId.ToString()) };
//        var identity = new ClaimsIdentity(claims, "Jwt");
//        IPrincipal user = new ClaimsPrincipal(identity);
//        return Task.FromResult(user);
//    }
//    return Task.FromResult<IPrincipal>(null);
//}

//private ClaimsPrincipal GetPrincipal(string token)
//{
//    try
//    {
//        var tokenHandler = new JwtSecurityTokenHandler();
//        if (!(tokenHandler.ReadToken(token) is JwtSecurityToken jwtToken))
//        {
//            return null;
//        }

//        var symmetricKey = Convert.FromBase64String(this.SeceretKey);
//        var validationParameters = new TokenValidationParameters()
//        {
//            RequireExpirationTime = true,
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
//        };

//        var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);

//        return principal;
//    }
//    catch (Exception)
//    {
//        //should write log  
//        return null;
//    }
//}
