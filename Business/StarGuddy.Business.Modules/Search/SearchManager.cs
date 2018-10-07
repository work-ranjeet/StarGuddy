using AutoMapper;
using StarGuddy.Api.Models.Search;
using StarGuddy.Business.Interface.Search;
using StarGuddy.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Modules.Search
{
    public class SearchManager : ISearchManager
    {
        private readonly IMapper _mapper;
        private readonly IJobGroupRepository _jobGroupRepository;

        public SearchManager(IJobGroupRepository jobGroupRepository, IMapper mapper)
        {
            _mapper = mapper;
            _jobGroupRepository = jobGroupRepository;
        }

        public async Task<IEnumerable<TalentGroup>> GetUserGobGroup()
        {
            var result = await _jobGroupRepository.GetTalentGroup();
            if (result != null && result.Any())
            {
                return _mapper.Map<List<TalentGroup>>(result).Where(x => x.Code != 1003);
            }

            return null;
        }

        public async Task<string> GetName()
        {
            try
            {
                var result = await _jobGroupRepository.GetName();
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
