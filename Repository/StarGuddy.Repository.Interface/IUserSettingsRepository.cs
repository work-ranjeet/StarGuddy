using StarGuddy.Data.Entities;
using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Interface
{
    public interface IUserSettingsRepository
    {
        Task<UserSettings> GetUsetSettingByUserIdAsync(Guid userId);

        Task<Guid> GetUserIdByProfilUrl(string profileUrl);

        Task<bool> SetMobileVisibility(Guid userId, bool status);

        Task<bool> SetEmailVisibility(Guid userId, bool status);

        Task<bool> SetProfilePhotoVisibility(Guid userId, bool status);

        Task<bool> SetEnableCommnetOnProfile(Guid userId, bool status);

        Task<bool> EnableTwoFactorAuth(Guid userId, bool status);

        Task<bool> SetProfileVisibility(Guid userId, Guid visibilityGroupId);

        Task<IEnumerable<VisibilityGroup>> GetVisibilityGroupByUserIdAsync(Guid userId);
    }
}
