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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmailSent()
        {
            return await Task.Run(() => View());
        }
    }
}