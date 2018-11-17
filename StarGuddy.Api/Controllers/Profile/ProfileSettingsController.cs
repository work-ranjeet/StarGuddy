using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Constants;
using StarGuddy.Api.Models.Account;
using StarGuddy.Api.Models.ActionResult;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Common;
using StarGuddy.Business.Interface.Profile;
using StarGuddy.Core.Constants;

namespace StarGuddy.Api.Controllers.Profile
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/Profile/Setting")]
    [Authorize(Policy = Policy.JwtToken)]
    public class ProfileSettingsController : ControllerBase
    {
        private readonly IAccountManager _accountManager;
        private readonly IPasswordManager _passwordManager;
        private readonly IProfileSettingManager _profileSettingManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileSettingsController"/> class.
        /// </summary>
        /// <param name="accountManager">The account manager.</param>
        /// <param name="passwordManager">The password manager.</param>
        public ProfileSettingsController(IAccountManager accountManager, IPasswordManager passwordManager, IProfileSettingManager profileSettingManager)
        {
            this._accountManager = accountManager;
            this._passwordManager = passwordManager;
            this._profileSettingManager = profileSettingManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _profileSettingManager.GetUserSettingsAsync();
            if(result.IsNotNull())
            {
                return Ok(result);
            }
           
            return NotFound(new MessageResult
            {
                Message = ErrorMessage.NotModified,
                Code = StatusCodes.Status404NotFound
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("change/Email")]
        public async Task<IActionResult> UpdateEmail([FromBody]string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest(new MessageResult { Message = ErrorMessage.BadRequest, Code = StatusCodes.Status400BadRequest });

            if (await _profileSettingManager.UpdateEmailAsync(email))
            {
                return Ok(new { Message = "", Code = 0 });
            }

            return StatusCode(StatusCodes.Status304NotModified, new MessageResult
            {
                Message = ErrorMessage.NotModified,
                Code = StatusCodes.Status304NotModified
            });
        }

        [HttpPost]
        [ActionName("change/Mobile")]
        public async Task<IActionResult> UpdateMobile([FromBody]string mobileNumner)
        {
            if (string.IsNullOrWhiteSpace(mobileNumner))
                return BadRequest(new MessageResult { Message = ErrorMessage.BadRequest, Code = StatusCodes.Status400BadRequest });

            if (await _profileSettingManager.UpdateMobileAsync(mobileNumner))
            {
                return Ok(new MessageResult { Message = "", Code = 0 });
            }

            return StatusCode(StatusCodes.Status304NotModified, new MessageResult
            {
                Message = ErrorMessage.NotModified,
                Code = StatusCodes.Status304NotModified
            });
        }

        [HttpPost]
        [ActionName("change/Password")]
        public async Task<IActionResult> ChangePassword([FromBody]PasswordModel changePassword)
        {
            if (changePassword.IsNull() || changePassword.NewPassword != changePassword.ConfirmPassword)
            {
                return BadRequest(new MessageResult { Message = ErrorMessage.BadRequest, Code = StatusCodes.Status400BadRequest });
            }

            if (await _passwordManager.ChangePassword(changePassword))
            {
                return Ok(new { Message = "", Code = 0 });
            }

            return StatusCode(StatusCodes.Status304NotModified, new MessageResult
            {
                Message = ErrorMessage.NotModified,
                Code = StatusCodes.Status304NotModified
            });
        }


        [HttpPut]
        [ActionName("showHide/Mobile")]
        public async Task<IActionResult> ShowMobileDetails([FromBody]bool enableShowMobile)
        {
            if (await _profileSettingManager.ShowHideMobileAsync(enableShowMobile))
            {
                return Ok(new MessageResult { Message = "", Code = 0 });
            }

            return StatusCode(StatusCodes.Status304NotModified, new MessageResult
            {
                Message = ErrorMessage.NotModified,
                Code = StatusCodes.Status304NotModified
            });
        }

        [HttpPut]
        [ActionName("showHide/Email")]
        public async Task<IActionResult> ShowEmailDetails([FromBody]bool enableShowEmail)
        {
            if (await _profileSettingManager.ShowEmailDetailsAsync(enableShowEmail))
            {
                return Ok(new MessageResult { Message = "", Code = 0 });
            }

            return StatusCode(StatusCodes.Status304NotModified, new MessageResult
            {
                Message = ErrorMessage.NotModified,
                Code = StatusCodes.Status304NotModified
            });
        }

        [HttpPut]
        [ActionName("showHide/ProfilePhoto")]
        public async Task<IActionResult> ShowProfilePhoto([FromBody]bool enableShowProfilePhoto)
        {
            if (await _profileSettingManager.ShowProfilePhotoAsync(enableShowProfilePhoto))
            {
                return Ok(new MessageResult { Message = "", Code = 0 });
            }

            return StatusCode(StatusCodes.Status304NotModified, new MessageResult
            {
                Message = ErrorMessage.NotModified,
                Code = StatusCodes.Status304NotModified
            });
        }

        [HttpPut]
        [ActionName("allow/ProfileComment")]
        public async Task<IActionResult> AllowCommnetOnProfile([FromBody]bool allowCommnetOnProfile)
        {
            if (await _profileSettingManager.AllowCommnetOnProfileAsync(allowCommnetOnProfile))
            {
                return Ok(new MessageResult { Message = "", Code = 0 });
            }

            return StatusCode(StatusCodes.Status304NotModified, new MessageResult
            {
                Message = ErrorMessage.NotModified,
                Code = StatusCodes.Status304NotModified
            });
        }

        [HttpPut]
        [ActionName("enableDisable/TwoFactorAuth")]
        public async Task<IActionResult> EnableTwoFactorAuth([FromBody]bool enableTwoFactorAuth)
        {
            if (await _profileSettingManager.EnableTwoFactorAuthAsync(enableTwoFactorAuth))
            {
                return Ok(new MessageResult { Message = "", Code = 0 });
            }

            return StatusCode(StatusCodes.Status304NotModified, new MessageResult
            {
                Message = ErrorMessage.NotModified,
                Code = StatusCodes.Status304NotModified
            });
        }

        [HttpPut]
        [ActionName("SetVisibility")]
        public async Task<IActionResult> SetVisibility([FromBody]Guid visibilityGroupId)
        {
            if (await _profileSettingManager.SetVisibilityAsync(visibilityGroupId))
            {
                return Ok(new MessageResult { Message = "", Code = 0 });
            }

            return StatusCode(StatusCodes.Status304NotModified, new MessageResult
            {
                Message = ErrorMessage.NotModified,
                Code = StatusCodes.Status304NotModified
            });
        }

        
    }
}