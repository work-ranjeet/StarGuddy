using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Interface
{
    public interface IUserSettingsRepository
    {
        Task<IUserSettings> GetUsetSettingByUserIdAsync(Guid userId);

        Task<Guid> GetUserIdByProfilUrl(string profileUrl);
    }
}
