using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Models.Account;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Common;
using StarGuddy.Business.Interface.Network;
using StarGuddy.Core.Context;
using System;
using System.Threading.Tasks;

namespace StarGuddy.Api.Controllers.Account
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/Account")]
    [Produces("application/json")]
    public class SignupController : ControllerBase
    {
        private readonly ISignupManager _signUpManager;
        private readonly IUserManager _userManager;
        private readonly IPasswordManager _passwordManager;
        private readonly ISecurityManager _securityManager;
        private readonly IEmailManager _emailManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignupController"/> class.
        /// </summary>
        /// <param name="signupManager">The signup manager.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="passwordManager">The password manager.</param>
        /// <param name="ISecurityManager">The JWT packet manager.</param>
        public SignupController(ISignupManager signupManager, IUserManager userManager, IPasswordManager passwordManager, ISecurityManager securityManager, IEmailManager emailManager)
        {
            _signUpManager = signupManager;
            _userManager = userManager;
            _passwordManager = passwordManager;
            _securityManager = securityManager;
            _emailManager = emailManager;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]ApplicationUser applicationUser)
        {
            try
            {
                if (applicationUser.IsNull())
                {
                    return BadRequest();
                }

                if (applicationUser.Password != applicationUser.CnfPassword)
                {
                    return StatusCode(StatusCodes.Status204NoContent, NotFound("Password and Confirm password is not matching."));
                }

                var existUser = await _userManager.FindByUserNameAsync(applicationUser.Email);
                if (existUser.IsNotNull())
                {
                    return StatusCode(StatusCodes.Status409Conflict, BadRequest("User name already register with us."));
                }

                string password = applicationUser.Password;
                applicationUser.UserName = applicationUser.Email;
                applicationUser.Password = await _passwordManager.GetHashedPassword(password);

                if (await _userManager.CreateAsync(applicationUser))
                {
                    var userResult = await _signUpManager.PasswordSignInAsync(applicationUser.UserName, password, rememberMe: false, lockoutOnFailure: false);
                    try
                    {
                        var emailVerificationToken = await _securityManager.GetEmailVerificationCodeAsync(userResult);
                        await _emailManager.SendMail("StarGuddy - email verification code - expire in 24 hours", $"<h1>testing</h1><div>{emailVerificationToken}</div>", userResult.Email);
                    }
                    catch { }

                    return Ok($"Welcome! {userResult.FirstName}.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(Guid userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Oops! {userId} is invalid. Please try again.");
            }
            // var result = await _userManager.ConfirmEmailAsync(user, code);
            return Ok();
        }

        //[HttpGet]      
        //public async Task<IActionResult> ConfirmEmailSent()
        //{
        //    return await Task.Run(() => View());
        //}


    }
}
