using StarGuddy.Api.Models.Interface.Profile;
using StarGuddy.Api.Models.Profile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Interface.Profile
{
    public interface IProfileManager
    {
        Task<ProfileHeader> GetProfileHeaderByProfileUrl(string profileUrl);

        Task<UserProfile> GetUserProfile(string profileUrl);

        Task<IPhysicalAppearanceModal> GetPhysicalAppreance(string profileUrl);
        Task<IEnumerable<IUserCreditModel>> GetUserCredits(string profileUrl);
        Task<DancingModel> GetUserDancingAsync(string profileUrl);

        Task<UserActingModel> GetUserActingDetailAsync(string profileUrl);
        Task<UserModelingModel> GetUserModelingDetailAsync(string profileUrl);
    }
}
