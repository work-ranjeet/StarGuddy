using StarGuddy.Data.Entities;
using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Interface
{
    public interface IJobGroupRepository
    {
       
        Task<IEnumerable<JobGroup>> GetUserJobGroupByUserIdAsync(Guid userId);

        Task<bool> PerformSaveAndUpdateOperationAsync(Guid userId, IEnumerable<JobGroup> jobGroups);

        Task<IEnumerable<IJobGroup>> GetTalentGroup();

        Task<string> GetName();
    }
}
