using AutoMapper;
using StarGuddy.Api.Models.Account;
using StarGuddy.Business.Interface.Profile;
using StarGuddy.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Modules.Profile
{
    public class ProfileSettingManager : IProfileSettingManager
    {
        private readonly IMapper _mapper;
        private readonly IUserSettingsRepository _userSettingsRepository;
        private readonly IUserEmailsRepository _userEmailsRepository;

        public ProfileSettingManager(IUserEmailsRepository userEmailsRepository, IUserSettingsRepository userSettingsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userSettingsRepository = userSettingsRepository;
            _userEmailsRepository = userEmailsRepository;
        }

        public async Task<bool> UpdateEmail(Guid userId, string email)
        {
            return await this._userEmailsRepository.UpdateEmailAsync(userId, email);
        }

        public async Task<UserSettingDto> GetUserSettings(Guid userId)
        {
            var result = await _userSettingsRepository.GetUsetSettingByUserIdAsync(userId);
            if (result.IsNotNull())
            {
                return _mapper.Map<UserSettingDto>(result);
            }

            return null;
        }
    }
}
