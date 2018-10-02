using Dapper;
using StarGuddy.Data.Entities;
using StarGuddy.Repository.Base;
using StarGuddy.Repository.Configuration;
using StarGuddy.Repository.Interface;
using StarGuddy.Repository.Opertions.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Operations
{
    public class UserModelingRepository : RepositoryAbstract<UserModeling>, IUserModelingRepository
    {
        public UserModelingRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserModeling) { }

        public async Task<UserModelingDetails> GetUserModelingDetailAsync(Guid userId)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    var param = new
                    {
                        UserId = userId
                    };

                    using (var multi = await conn.QueryMultipleAsync(SpNames.UserModeling.SelectDetail, param, commandType: CommandType.StoredProcedure))
                    {
                        return new UserModelingDetails
                        {
                            UserModeling = multi.ReadSingleOrDefault<UserModeling>(),
                            ModelingRoles = multi.Read<JobSubGroup>()
                        };

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PerformSaveAndUpdateOperationAsync(UserModelingDetails userModelingDetails)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            conn.Execute(
                               SpNames.UserModeling.ClearDetail,
                               param: new { userModelingDetails.UserModeling.UserId },
                               transaction: tran,
                               commandType: CommandType.StoredProcedure);

                            /*  @UserId UNIQUEIDENTIFIER, @ExpCode INT, @WebSite NVARCHAR(350), @AgentNeedCode INT, @Experiance NVARCHAR(2000) */
                            var param = new DynamicParameters();
                            param.Add("@UserId", userModelingDetails.UserModeling.UserId, DbType.Guid, ParameterDirection.Input);
                            param.Add("@ExpCode", userModelingDetails.UserModeling.ExpCode, DbType.Int32, ParameterDirection.Input);
                            param.Add("@WebSite", userModelingDetails.UserModeling.WebSite, DbType.String, ParameterDirection.Input);
                            param.Add("@AgentNeedCode", userModelingDetails.UserModeling.AgentNeedCode, DbType.Int32, ParameterDirection.Input);
                            param.Add("@Experiance", userModelingDetails.UserModeling.Experiance, DbType.String, ParameterDirection.Input);
                            await conn.ExecuteAsync(SpNames.UserModeling.SaveUpdate, param: param, transaction: tran, commandType: CommandType.StoredProcedure);

                            // Job Group Save
                            if (userModelingDetails.ModelingRoles.Any())
                            {
                                var jobGroupTask = userModelingDetails.ModelingRoles.Select(async x =>
                                {
                                    var jobGroupParam = new
                                    {
                                        userModelingDetails.UserModeling.UserId,
                                        JobCode = x.Code
                                    };

                                    return await conn.ExecuteAsync(SpNames.UserModeling.UserModelingRolesSave, param: jobGroupParam, transaction: tran, commandType: CommandType.StoredProcedure);
                                });

                                var updatedResult = await Task.WhenAll(jobGroupTask);
                            }

                            tran.Commit();

                            return true;
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
