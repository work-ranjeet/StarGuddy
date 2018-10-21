namespace StarGuddy.Repository.Operations
{
    using Dapper;
    using StarGuddy.Data.Entities;
    using StarGuddy.Data.Entities.Interface;
    using StarGuddy.Repository.Base;
    using StarGuddy.Repository.Configuration;
    using StarGuddy.Repository.Interface;
    using StarGuddy.Repository.Opertions.Constants;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using System.Threading.Tasks;

    public class UserEmailsRepository : RepositoryAbstract<UserEmails>, IUserEmailsRepository
    {
        public UserEmailsRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserEmails) { }

        public async Task<UserEmails> GetCurrentActiveEmailAsync(Guid userId) => await FindActiveByUserIdAsync(userId);

        public async Task<IEnumerable<UserEmails>> GetAllEmailAsync(Guid userId) => (await FindAllByUserIdAsync(userId)).OrderByDescending(x => x.DttmCreated);

        public async Task<UserEmails> GetCurrentEmailAsync(Guid userId) => (await FindAllByUserIdAsync(userId)).OrderByDescending(x => x.DttmCreated).FirstOrDefault();

        
        public async Task<bool> UpdateEmailAsync(Guid userId, string email)
        {
            try
            {
                using (var conn = base.OpenConnectionAsync)
                {
                    var param = new { UserId = userId, UserEmail = email };
                    var result = await SqlMapper.QueryAsync<IUserEmails>(conn, SpNames.UserEmails.UpdateEmail, param, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ActivsteEmailAsync(Guid userId, string email)
        {
            try
            {
                using (var conn = base.OpenConnectionAsync)
                {
                    var param = new { UserId = userId, UserEmail = email };
                    var result = await SqlMapper.QueryAsync<IUserEmails>(conn, SpNames.UserEmails.ActivateEmail, param, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
