using AutoMapper;
using StarGuddy.Api.Models.UserJobs;
using StarGuddy.Business.Interface.UserJobs;
using StarGuddy.Core.Context;
using StarGuddy.Data.Entities;
using StarGuddy.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Modules.UserJobs
{
    public class JobManager : IJobManager
    {
        private readonly IMapper _mapper;
        private readonly IJobGroupRepository _jobGroupRepository;

        public JobManager(IJobGroupRepository jobGroupRepository, IMapper mapper)
        {
            _mapper = mapper;
            _jobGroupRepository = jobGroupRepository;
        }

        public async Task<IEnumerable<JobGroupModel>> GetUserGobGroup()
        {
            var result = await _jobGroupRepository.GetUserJobGroupByUserIdAsync(UserContext.Current.UserId);
            if (result != null && result.Any())
            {
                return _mapper.Map<List<JobGroupModel>>(result.ToList());
            }

            return null;
        }

        public async Task<bool> SaveUserGobGroup(List<JobGroupModel> JobGroup)
        {
            var jobGroupList = _mapper.Map<List<JobGroup>>(JobGroup).Where(x => x.SelectedCode != 0);

            return await _jobGroupRepository.PerformSaveAndUpdateOperationAsync(UserContext.Current.UserId, jobGroupList);
        }
    }
}
