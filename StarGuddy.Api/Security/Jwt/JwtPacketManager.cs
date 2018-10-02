// -------------------------------------------------------------------------------
// <copyright file="JwtPacketManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains properties of customer details.
// -------------------------------------------------------------------------------
// Author: Ranjeet Kumar
// Date Created: 01/01/2018
// -------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace StarGuddy.Api.Security.Jwt
{
    #region MyRegion
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using StarGuddy.Api.Models.Account;
    using StarGuddy.Api.Models.Interface.Account;
    using StarGuddy.Business.Interface.Common;
    #endregion

    /// <summary>
    /// JWT Packet Manager
    /// </summary>
    public class JwtPacketManager : IJwtPacketManager
    {
        private ISecurityManager _securityManager;
        public JwtPacketManager(ISecurityManager securityManager)
        {
            this._securityManager = securityManager;
        }

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
                Token = await this._securityManager.GetJwtSecurityTokenAsync(applicationUser),
                FirstName = applicationUser.FirstName,
                UserName = applicationUser.UserName
            };
        }
    }

    /// <summary>
    /// JWT Packet Manager
    /// </summary>
    public interface IJwtPacketManager
    {
        /// <summary>
        /// Creates the JWT packet asynchronous.
        /// </summary>
        /// <param name="applicationUser">The application user.</param>
        /// <returns></returns>
        Task<IJwtPacket> CreateJwtPacketAsync(IApplicationUser applicationUser);
    }
}
