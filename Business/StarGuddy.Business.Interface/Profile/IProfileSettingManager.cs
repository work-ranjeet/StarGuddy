using StarGuddy.Api.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Interface.Profile
{
    public interface IProfileSettingManager
    {
        Task<bool> UpdateEmailAsync(string email);

        Task<UserSettingDto> GetUserSettingsAsync();

        Task<bool> UpdateMobileAsync(string mobileNumber);

        Task<bool> ShowHideMobileAsync(bool showHideMobile);

        Task<bool> ShowEmailDetailsAsync(bool showEmailDetails);
        Task<bool> ShowProfilePhotoAsync(bool showProfilePhoto);

        Task<bool> AllowCommnetOnProfileAsync(bool allowCommnetOnProfile);

        Task<bool> EnableTwoFactorAuthAsync(bool enableTwoFactorAuth);

        Task<bool> SetVisibilityAsync(Guid visibilityGroupId);
    }
}
