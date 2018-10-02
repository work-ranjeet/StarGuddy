using StarGuddy.Api.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Interface.Profile
{
    public interface IProfileSettingManager
    {
        Task<bool> UpdateEmail(Guid userId, string email);

        Task<UserSettingDto> GetUserSettings(Guid userId);
    }
}
