using Dapper;
using StarGuddy.Data.Entities;
using StarGuddy.Data.Entities.Interface;
using StarGuddy.Repository.Base;
using StarGuddy.Repository.Configuration;
using StarGuddy.Repository.Interface;
using StarGuddy.Repository.Opertions.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Operations
{
    public class UserSettingsRepository : RepositoryAbstract<UserSettings>, IUserSettingsRepository
    {
        public UserSettingsRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserSettings)
        {
        }

        public async Task<IUserSettings> GetUsetSettingByUserIdAsync(Guid userId)
        {
            return await base.FindActiveByUserIdAsync(userId);
        }

        public async Task<Guid> GetUserIdByProfilUrl(string profileUrl)
        {
            using (var conn = await Connection.OpenConnectionAsync())
            {
                var param = new { ProfileUrl = profileUrl };

                return await SqlMapper.ExecuteScalarAsync<Guid>(conn, SpNames.UserSettings.GetProfileUserId, param, commandType: CommandType.StoredProcedure);                
            }

        }

        public async Task<bool> SetMobileVisibility(Guid userId, bool status)
        {
            using (var conn = await Connection.OpenConnectionAsync())
            {
                var param = new { UserId = userId, Status = status };

                await SqlMapper.ExecuteAsync(conn, SpNames.UserSettings.ShowHideMobile, param, commandType: CommandType.StoredProcedure);

                return true;
            }

        }

        public async Task<bool> SetEmailVisibility(Guid userId, bool status)
        {
            using (var conn = await Connection.OpenConnectionAsync())
            {
                var param = new { UserId = userId, Status = status };

                await SqlMapper.ExecuteAsync(conn, SpNames.UserSettings.ShowHideEmail, param, commandType: CommandType.StoredProcedure);

                return true;
            }
        }

        public async Task<bool> SetProfilePhotoVisibility(Guid userId, bool status)
        {
            using (var conn = await Connection.OpenConnectionAsync())
            {
                var param = new { UserId = userId, Status = status };

                await SqlMapper.ExecuteAsync(conn, SpNames.UserSettings.ShowHideProfilePhoto, param, commandType: CommandType.StoredProcedure);

                return true;
            }
        }

        public async Task<bool> SetEnableCommnetOnProfile(Guid userId, bool status)
        {
            using (var conn = await Connection.OpenConnectionAsync())
            {
                var param = new { UserId = userId, Status = status };

                await SqlMapper.ExecuteAsync(conn, SpNames.UserSettings.AllowProfileComment, param, commandType: CommandType.StoredProcedure);

                return true;
            }
        }

        public async Task<bool> EnableTwoFactorAuth(Guid userId, bool status)
        {
            using (var conn = await Connection.OpenConnectionAsync())
            {
                var param = new { UserId = userId, Status = status };

                await SqlMapper.ExecuteAsync(conn, SpNames.User.EnableDisableTowFactor, param, commandType: CommandType.StoredProcedure);

                return true;
            }
        }

        public async Task<bool> SetProfileVisibility(Guid userId, Guid visibilityGroupId)
        {
            using (var conn = await Connection.OpenConnectionAsync())
            {
                var param = new { UserId = userId, VisibilityGroupId = visibilityGroupId };

                await SqlMapper.ExecuteAsync(conn, SpNames.UserSettings.SetVisibility, param, commandType: CommandType.StoredProcedure);

                return true;
            }
        }



    }
}
