using AutoMapper;
using StarGuddy.Api.Models.Account;
using StarGuddy.Business.Interface.Profile;
using StarGuddy.Core.Context;
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
        private readonly IUserPhonesRepository _userPhonesRepository;

        public ProfileSettingManager(
            IUserEmailsRepository userEmailsRepository,
            IUserSettingsRepository userSettingsRepository,
            IUserPhonesRepository userPhonesRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _userSettingsRepository = userSettingsRepository;
            _userEmailsRepository = userEmailsRepository;
            _userPhonesRepository = userPhonesRepository;
        }

        public async Task<UserSettingDto> GetUserSettingsAsync()
        {
            var result = await _userSettingsRepository.GetUsetSettingByUserIdAsync(UserContext.Current.UserId);
            if (result.IsNotNull())
            {
                return _mapper.Map<UserSettingDto>(result);
            }

            return null;
        }

        public async Task<bool> UpdateEmailAsync(string email)
        {
            return await _userEmailsRepository.UpdateEmailAsync(UserContext.Current.UserId, email);
        }

        public async Task<bool> UpdateMobileAsync(string mobileNumber)
        {
            return await _userPhonesRepository.UpdateMobileAsync(UserContext.Current.UserId, mobileNumber);
        }

        public async Task<bool> ShowHideMobileAsync(bool showHideMobile)
        {
            return await _userSettingsRepository.SetMobileVisibility(UserContext.Current.UserId, showHideMobile);
        }

        public async Task<bool> ShowEmailDetailsAsync(bool showEmailDetails)
        {
            return await _userSettingsRepository.SetEmailVisibility(UserContext.Current.UserId, showEmailDetails);
        }

        public async Task<bool> ShowProfilePhotoAsync(bool showProfilePhoto)
        {
            return await _userSettingsRepository.SetProfilePhotoVisibility(UserContext.Current.UserId, showProfilePhoto);
        }

        public async Task<bool> AllowCommnetOnProfileAsync(bool allowCommnetOnProfile)
        {
            return await _userSettingsRepository.SetEnableCommnetOnProfile(UserContext.Current.UserId, allowCommnetOnProfile);
        }

        public async Task<bool> EnableTwoFactorAuthAsync(bool enableTwoFactorAuth)
        {
            return await _userSettingsRepository.EnableTwoFactorAuth(UserContext.Current.UserId, enableTwoFactorAuth);
        }

        public async Task<bool> SetVisibilityAsync(Guid visibilityGroupId)
        {
            return await _userSettingsRepository.SetProfileVisibility(UserContext.Current.UserId, visibilityGroupId);
        }
    }
}
