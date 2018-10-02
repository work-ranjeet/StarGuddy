using AutoMapper;
using StarGuddy.Api.Models.Dto;
using StarGuddy.Api.Models.Interface.Profile;
using StarGuddy.Api.Models.Profile;
using StarGuddy.Api.Models.UserJobs;
using StarGuddy.Business.Interface.Profile;
using StarGuddy.Core.Constants;
using StarGuddy.Core.Context;
using StarGuddy.Core.Enums;
using StarGuddy.Repository.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Modules.Profile
{
    public class ProfileManager : ProfileAbstract, IProfileManager
    {
        public ProfileManager(
            IUserRepository userRepository,
            IUserDetailRepository userDetailRepository,
            IUserSettingsRepository userSettingsRepository,
            IPhysicalAppearanceRepository physicalAppearanceRepository,
            IUserCreditsRepository userCreditsRepository,
            IUserDancingRepository userDancingRepository,
            IUserActingRepository userActingRepository,
            IUserModelingRepository userModelingRepository,
            IMapper mapper) : base(
                userRepository,
                userDetailRepository,
                userSettingsRepository,
                physicalAppearanceRepository,
                userCreditsRepository,
                userDancingRepository,
                userActingRepository,
                userModelingRepository,
                mapper)
        { }

        #region /// Profile
        public async Task<ProfileHeader> GetProfileHeaderByProfileUrl(string profileUrl)
        {
            try
            {
                var result = await _userRepository.GetUserProfileHeaderByProfilUrl(profileUrl);

                if (result.IsNotNull())
                {
                    var profileHeader = _mapper.Map<ProfileHeader>(result);
                    profileHeader.JobGroups = _mapper.Map<List<JobGroupModel>>(result.JobGroups).Where(x => x.Code == x.SelectedCode);

                    return profileHeader.IsNull() ? null : profileHeader;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<UserProfile> GetUserProfile(string profileUrl)
        {
            var userId = await _userSettingsRepository.GetUserIdByProfilUrl(profileUrl);
            if (userId != Guid.Empty)
            {
                var physic = FetchPhysicalAppreance(userId);
                var credits = FetchUserCredits(userId);
                var dancing = FetchUserDancingAsync(userId);
                var acting = FetchUserActingDetailAsync(userId);
                var modeling = FetchUserModelingDetailAsync(userId);
                var taskResult = Task.WhenAll(physic, credits, dancing, acting, modeling);

                try
                {
                    await taskResult.ConfigureAwait(false);
                    if (taskResult.IsCompletedSuccessfully)
                    {
                        return new UserProfile
                        {
                            Acting = await acting,
                            Dancing = await dancing,
                            Modeling = await modeling,
                            UserCredits = await credits,
                            PhysicalAppearance = await physic
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return null;
        }
        #endregion

        #region /// details
        public async Task<IPhysicalAppearanceModal> GetPhysicalAppreance(string profileUrl)
        {
            var userId = await _userSettingsRepository.GetUserIdByProfilUrl(profileUrl);
            if (userId != Guid.Empty)
            {
                var result =  await FetchPhysicalAppreance(userId);
                if (result.IsNotNull()) { return result; }
            }

            return null;
        }

        public async Task<IEnumerable<IUserCreditModel>> GetUserCredits(string profileUrl)
        {
            var userId = await _userSettingsRepository.GetUserIdByProfilUrl(profileUrl);
            if (userId != Guid.Empty)
            {
                var result =  await FetchUserCredits(userId);
                if (result.IsNotNull()) { return result; }
            }

            return null;
        }
        public async Task<DancingModel> GetUserDancingAsync(string profileUrl)
        {
            var userId = await _userSettingsRepository.GetUserIdByProfilUrl(profileUrl);
            if (userId != Guid.Empty)
            {
                var result = await FetchUserDancingAsync(userId);
                if (result.IsNotNull()) { return result; }
            }

            return null;
        }

        public async Task<UserActingModel> GetUserActingDetailAsync(string profileUrl)
        {
            var userId = await _userSettingsRepository.GetUserIdByProfilUrl(profileUrl);
            if (userId != Guid.Empty)
            {
                var result =  await FetchUserActingDetailAsync(userId);
                if (result.IsNotNull()) { return result; }
            }

            return null;
        }

        public async Task<UserModelingModel> GetUserModelingDetailAsync(string profileUrl)
        {
            var userId = await _userSettingsRepository.GetUserIdByProfilUrl(profileUrl);
            if (userId != Guid.Empty)
            {
                var result = await FetchUserModelingDetailAsync(userId);
                if (result.IsNotNull()) { return result; }
            }

            return null;
        }
        #endregion       
    }
}
