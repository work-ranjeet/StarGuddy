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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Operations
{
    public class JobGroupRepository : RepositoryAbstract<JobGroup>, IJobGroupRepository
    {
        public JobGroupRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.JobGroup) { }


        public async Task<IEnumerable<IJobGroup>> GetActiveJobGroupAsync() => await GetAllAsync();

        public async Task<IEnumerable<JobGroup>> GetUserJobGroupByUserIdAsync(Guid userId)
        {
            using (var conn = await Connection.OpenConnectionAsync())
            {
                var param = new
                {
                    UserId = userId
                };

                return await SqlMapper.QueryAsync<JobGroup>(conn, SpNames.JobGroup.UserJobGroup, param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> PerformSaveAndUpdateOperationAsync(Guid userId, IEnumerable<JobGroup> jobGroups)
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
                               SpNames.JobGroup.ClearJobGroups,
                               param: new { userId },
                               transaction: tran,
                               commandType: CommandType.StoredProcedure);

                            var jobGroupTask = jobGroups.Select(async x =>
                            {
                                var jobGroupParam = new
                                {
                                    UserId = userId,
                                    JobGroupId = x.Id
                                };

                                return await conn.ExecuteAsync(SpNames.JobGroup.UserJobGroupSave, param: jobGroupParam, transaction: tran, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                            });

                            var jobGroupResult = await Task.WhenAll(jobGroupTask);
                           
                            if (jobGroupResult.Any())
                            {
                                tran.Commit();
                                return true;
                            }

                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IJobGroup>> GetTalentGroup()
        {
            using (var conn = await Connection.OpenConnectionAsync())
            {
                return await SqlMapper.QueryAsync<JobGroup>(conn, SpNames.JobGroup.GetTalentGroup, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<string> GetName()
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    var userObj = await conn.ExecuteScalarAsync<string>("SELECT top 1 Name FROM JobGroup").ConfigureAwait(false);
                    return userObj;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

    }
}
