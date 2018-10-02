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
    public class UserDetailRepository : RepositoryAbstract<UserDetail>, IUserDetailRepository
    {
        public UserDetailRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserDetail) { }

        public async Task<UserDetail> GetUserDetailByUserId(Guid userId) => await FindActiveByUserIdAsync(userId);

        public async Task<bool> UpdateAboutIntro(string profileUrl, IUserDetail userDetail)
        {
            using (var conn = await Connection.OpenConnectionAsync())
            {
                var param = new { userDetail.UserId, userDetail.About, ProfileAddress = profileUrl };

                await SqlMapper.ExecuteAsync(conn, SpNames.UserDetail.UpdateAboutAndProfileAddress, param, commandType: CommandType.StoredProcedure);

                return true;
            }
        }
    }
}
