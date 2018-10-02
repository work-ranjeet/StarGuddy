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
using System.Collections.Concurrent;
using System.Threading.Tasks.Dataflow;

namespace StarGuddy.Repository.Operations
{
    public class UserCreditsRepository : RepositoryAbstract<UserCredits>, IUserCreditsRepository
    {
        public UserCreditsRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserCredits) { }

        public async Task<IEnumerable<IUserCredits>> GetUserCreditsById(Guid userId) => await base.FindAllActiveByUserIdAsync(userId);

        public async Task<bool> PerformSaveOperation(IUserCredits userCredits)
        {
            try
            {
                using (var conn = base.OpenConnectionAsync)
                {
                    var param = new
                    {
                        userCredits.UserId,
                        userCredits.Year,
                        userCredits.WorkPlace,
                        userCredits.WorkDetail
                    };

                    return await SqlMapper.ExecuteAsync(conn, SpNames.UserCredits.UserCreditsSaveUpdate, param, commandType: CommandType.StoredProcedure) > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PerformMaultipleSaveOperation(ConcurrentBag<IUserCredits> userCredits)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            var creditTask = userCredits.Select(async credit =>
                            {
                                var param = new
                                {
                                    credit.UserId,
                                    credit.Year,
                                    credit.WorkPlace,
                                    credit.WorkDetail
                                };

                                return await conn.ExecuteAsync(SpNames.UserCredits.UserCreditsSaveUpdate, param: param, transaction:tran, commandType: CommandType.StoredProcedure);
                            });

                            var customers = await Task.WhenAll(creditTask);

                            tran.Commit();
                            return customers.Any();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PerformDeleteOperation(Guid Id)
        {
            try
            {
                return await base.SoftDelete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
