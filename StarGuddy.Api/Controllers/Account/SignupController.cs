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
    public class SignupController : Controller
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


        [AllowAnonymous]
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

                    var emailVerificationToken = _securityManager.GetEmailVerificationCodeAsync(userResult);

                    if (await _emailManager.SendMail("StarGuddy - email verification code - expire in 24 hours", $"<h1>testing</h1><div>{emailVerificationToken}</div>", "er.ranjeetkumar@gmail.com"))
                    {
                        return Ok($"We sent you verification link to your email. Please verify it to proceed....");
                    }

                    return StatusCode(StatusCodes.Status417ExpectationFailed, "There are some error. Please try again...");
                }

            }
            catch (Exception )
            {
              
            }
            return BadRequest();
        }

        //[HttpPost("change-password")]
        //public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordModel changePasswordModel)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if(string.IsNullOrEmpty(changePasswordModel.NewPassword) && string.IsNullOrEmpty(changePasswordModel.ConfirmPassword) && changePasswordModel.NewPassword == changePasswordModel.OldPassword)
        //    {
        //        return BadRequest("The new password and confirmation password do not match.");
        //    }

        //    var userName = "er.ranjeetkumar@gmail.com";

        //    //var result = 2; // await _signUpManager.CreateAsync(changePasswordModel);
        //    //if (result > 0)
        //    //{
        //    //    var userResult = await _accountManager.PasswordSignInAsync(applicationUser.Email, applicationUser.Password, rememberMe: false, lockoutOnFailure: false);

        //    //    if (userResult.Id == Guid.Empty)
        //    //    {
        //    //        return StatusCode(StatusCodes.Status204NoContent, NotFound("email or password incorrect")); 
        //    //    }

        //    //    return Ok(_jwtPacketManager.CreateJwtPacketAsync(userResult));
        //    //}

        //    return StatusCode(StatusCodes.Status204NoContent, NotFound("email or password incorrect"));
        //}
    }
}
