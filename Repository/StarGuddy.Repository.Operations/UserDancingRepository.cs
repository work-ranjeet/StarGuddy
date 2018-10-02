using Dapper;
using StarGuddy.Data.Entities;
using StarGuddy.Data.Entities.Interface;
using StarGuddy.Repository.Base;
using StarGuddy.Repository.Configuration;
using StarGuddy.Repository.Interface;
using StarGuddy.Repository.Opertions.Constants;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Operations
{
    public class UserDancingRepository : RepositoryAbstract<UserDancing>, IUserDancingRepository
    {
        public UserDancingRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserDancing) { }

        public async Task<IUserDancing> GetUserDancingAsync(Guid userId) => await FindActiveByUserIdAsync(userId);

        public async Task<IEnumerable<IDancingStyle>> GetDancingStyleAsync(Guid userId)
        {
            try
            {
                using (var conn = OpenConnectionAsync)
                {
                    var param = new
                    {
                        UserId = userId
                    };

                    return await SqlMapper.QueryAsync<DancingStyle>(conn, SpNames.DancingStyle.Select, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IDancingStyle>> GetDancingStyleSelectedAsync(Guid userId)
        {
            try
            {
                using (var conn = OpenConnectionAsync)
                {
                    var param = new
                    {
                        UserId = userId
                    };

                    return await SqlMapper.QueryAsync<DancingStyle>(conn, SpNames.DancingStyle.Select, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PerformSaveAndUpdateOperationAsync(IUserDancing userDancing, ConcurrentBag<long> danceStyleIds)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            await conn.ExecuteAsync(SpNames.UserDancingStyle.Clear, param: new { userDancing.UserId }, transaction: tran, commandType: CommandType.StoredProcedure);

                            /* @UserId UNIQUEIDENTIFIER,
                               @DanceAbilitiesId INT = 0, 
	                           @ChoreographyAbilitiesId INT = 0,
                               @AgentNeed INT = 0,
	                           @IsAttendedSchool BIT = 0,
                               @IsAgent BIT = 0, 
	                           @Experiance NVARCHAR(2000), 
	                           @UserDancingId UNIQUEIDENTIFIER OUTPUT
                               */
                            var userDancingparam = new DynamicParameters();
                            userDancingparam.Add("@UserId", userDancing.UserId, DbType.Guid, ParameterDirection.Input);
                            userDancingparam.Add("@DanceAbilitiesCode", userDancing.DanceAbilitiesCode, DbType.Int32, ParameterDirection.Input);
                            userDancingparam.Add("@ChoreographyAbilitiesCode", userDancing.ChoreographyAbilitiesCode, DbType.Int32, ParameterDirection.Input);
                            userDancingparam.Add("@AgentNeedCode", userDancing.AgentNeedCode, DbType.Int32, ParameterDirection.Input);
                            userDancingparam.Add("@IsAttendedSchool", userDancing.IsAttendedSchool, DbType.Boolean, ParameterDirection.Input);
                            userDancingparam.Add("@IsAgent", userDancing.IsAgent, DbType.Boolean, ParameterDirection.Input);
                            userDancingparam.Add("@Experiance", userDancing.Experiance, DbType.String, ParameterDirection.Input);                          

                            var mainResult = await conn.ExecuteAsync(
                                SpNames.UserDancing.SaveUpdate,
                                param: userDancingparam,
                                transaction: tran,
                                commandType: CommandType.StoredProcedure);                          

                            var creditTask = danceStyleIds.Select(async id =>
                            {
                                var param = new
                                {
                                    userDancing.UserId,
                                    DancingStyleId = id
                                };

                                return await conn.ExecuteAsync(SpNames.UserDancingStyle.Save, param: param, transaction: tran,
                                    commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                            });

                            var updatedResult = await Task.WhenAll(creditTask);
                            tran.Commit();

                            return mainResult > 0 || updatedResult.Any();
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
    }
}
