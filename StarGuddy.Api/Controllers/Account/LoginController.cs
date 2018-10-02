using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Models.Account;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Common;
using StarGuddy.Business.Interface.Network;
using System;
using System.Threading.Tasks;

namespace StarGuddy.Api.Controllers.Account
{
    [Route("api/Account")]
    [Produces("application/json")]
    public class LoginController : Controller
    {
        private readonly ISignupManager _signUpManager;
        private readonly ISecurityManager _securityManager;
        private readonly IEmailManager _emailManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="signUpManager">The sign up manager.</param>
        /// <param name="jwtPacketManager">The JWT packet manager.</param>
        public LoginController(ISignupManager signUpManager, ISecurityManager securityManager, IEmailManager emailManager)
        {
            _signUpManager = signUpManager;
            _securityManager = securityManager;
            _emailManager = emailManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginData loginData)
        {
            try
            {
                if (loginData.IsNull() || string.IsNullOrWhiteSpace(loginData.UserName) || string.IsNullOrWhiteSpace(loginData.Password))
                {
                    return BadRequest();
                }

                var userResult = await _signUpManager.PasswordSignInAsync(loginData.UserName, loginData.Password, rememberMe: false, lockoutOnFailure: false);
                if (userResult.IsNull())
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "Oops! Invalid entry. Please try again.");
                }

                return Ok(await _securityManager.CreateJwtPacketAsync(userResult));
            }
            catch (Exception)
            {
                //logger ex;
            }

            return StatusCode(StatusCodes.Status401Unauthorized, "Oops! Invalid entry. Please try again.");
        }
    }
}
