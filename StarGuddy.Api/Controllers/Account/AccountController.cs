using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Business.Interface.Account;
using System.Threading.Tasks;

namespace StarGuddy.Api.Controllers.Account
{
    /// <summary>
    /// Account Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/Account")]
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="signUpManager">The sign up manager.</param>
        /// <param name="jwtPacketManager">The JWT packet manager.</param>
        public AccountController(IUserManager userManager)
        {
            this._userManager = userManager;
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