using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StarGuddy.Core.Context;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
//using System.Net.Http.Headers;

namespace StarGuddy.Api.Controllers
{
    public abstract class BaseApiController : Controller
    {
        #region /// properties
        private string JwtToken => HttpContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.ToString();

        //public IUserContext UserContext { get; private set; }
        #endregion

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                base.OnActionExecuting(context);
                this.SetUserContext();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        #region /// Private methods
        private void SetUserContext()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(JwtToken))
                {
                    var innerJwtTokenArr = JwtToken.Split(' ');
                    if (innerJwtTokenArr.Length != 2 || !innerJwtTokenArr[0].ToLowerInvariant().Equals("bearer"))
                    {
                        throw new UnauthorizedAccessException("Invalid tokens.");
                    }

                    var jwtHandler = new JwtSecurityTokenHandler();

                    var jwtTokenInput = innerJwtTokenArr[1];
                    var readableToken = jwtHandler.CanReadToken(jwtTokenInput);

                    if (readableToken)
                    {
                        var userPayloadToken = jwtHandler.ReadJwtToken(jwtTokenInput);
                        //string userData = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == ClaimTypes.UserData).Value;

                        var userId = Guid.Parse((userPayloadToken).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Sid).Value);
                        if (userId == Guid.Empty)
                        {
                            throw new UnauthorizedAccessException("Oops! you are not suppose to here. Please login before proceed.");
                        }

                        UserContext.Current.IsAuthenticated = true;
                        UserContext.Current.UserId = userId;
                        UserContext.Current.UserName = (userPayloadToken).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Email).Value;
                        UserContext.Current.Email = (userPayloadToken).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Email).Value;

                        //var applicationUser = DecryptObject<ApplicationUser>(userData);
                        //if(applicationUser != null)
                        //{
                        //    UserContext.FirstName = applicationUser.FirstName;
                        //    UserContext.LastName = applicationUser.LastName;
                        //    UserContext.IsCastingProfessional = applicationUser.IsCastingProfessional;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
