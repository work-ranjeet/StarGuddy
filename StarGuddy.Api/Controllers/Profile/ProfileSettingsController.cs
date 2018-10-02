using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Models.Account;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Common;
using StarGuddy.Business.Interface.Profile;

namespace StarGuddy.Api.Controllers.Profile
{
    [Produces("application/json")]
    [Route("api/Profile/Setting")]
    public class ProfileSettingsController : Controller
    {
        /// <summary>
        /// The account manager
        /// </summary>
        private readonly IAccountManager _accountManager;

        /// <summary>
        /// The password manager
        /// </summary>
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

        [HttpPost]
        [ActionName("UpdateEmail")]
        public async Task<bool> UpdateEmail(Guid userId, string email)
        {
            return await this._profileSettingManager.UpdateEmail(userId, email);
        }

        [HttpPost]
        [ActionName("ChangePassword")]
        public async Task<bool> ChangePassword(PasswordModel changePassword)
        {
            return await this._passwordManager.ChangePassword(changePassword);
        }


    }
}