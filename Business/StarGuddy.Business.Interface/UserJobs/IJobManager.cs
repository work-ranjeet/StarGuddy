using StarGuddy.Api.Models.UserJobs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Interface.UserJobs
{
    public interface IJobManager
    {
        Task<IEnumerable<JobGroupModel>> GetUserGobGroup();

        Task<bool> SaveUserGobGroup(List<JobGroupModel> jobGroups);
    }
}
