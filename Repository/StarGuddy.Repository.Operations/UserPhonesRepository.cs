using StarGuddy.Data.Entities;
using StarGuddy.Repository.Base;
using StarGuddy.Repository.Configuration;
using StarGuddy.Repository.Interface;
using StarGuddy.Repository.Opertions.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Operations
{
    public class UserPhonesRepository : RepositoryAbstract<UserPhones>, IUserPhonesRepository
    {
        public UserPhonesRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserPhones) { }

        public async Task<UserPhones> GetUserPhoneDetailByUserId(Guid userId) => await FindActiveByUserIdAsync(userId);
    }
}