using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Core.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace StarGuddy.Api.Handler
{
    public class JwtTokenRequirement : IAuthorizationRequirement
    {
    }

    public class JwtTokenHandler : AuthorizationHandler<JwtTokenRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, JwtTokenRequirement requirement)
        {
            var httpContext = (context.Resource as ActionContext).HttpContext;
            if (httpContext.IsNotNull())
            {
                var JwtToken = httpContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.ToString();
                if (!string.IsNullOrWhiteSpace(JwtToken))
                {
                    var innerJwtTokenArr = JwtToken.Split(' ');
                    if (innerJwtTokenArr.Length == 2 && innerJwtTokenArr[0].ToLowerInvariant().Equals("bearer"))
                    {
                        // throw new UnauthorizedAccessException("Invalid tokens.");

                        var jwtHandler = new JwtSecurityTokenHandler();

                        var jwtTokenInput = innerJwtTokenArr[1];
                        var readableToken = jwtHandler.CanReadToken(jwtTokenInput);

                        if (readableToken)
                        {
                            var userPayloadToken = jwtHandler.ReadJwtToken(jwtTokenInput);
                            //string userData = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == ClaimTypes.UserData).Value;

                            var userId = Guid.Parse((userPayloadToken).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Sid).Value);
                            if (userId != Guid.Empty)
                            {
                                //throw new UnauthorizedAccessException("Oops! you are not suppose to here. Please login before proceed.");

                                UserContext.Current.IsAuthenticated = true;
                                UserContext.Current.UserId = userId;
                                //UserContext.Current.UserName = (userPayloadToken).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Email).Value;
                                UserContext.Current.Email = (userPayloadToken).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Email).Value;

                                context.Succeed(requirement);
                            }
                        }
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
