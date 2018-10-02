using StarGuddy.Api.Models.Interface.Profile;
using StarGuddy.Api.Models.Profile;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarGuddy.Business.Interface.Profile
{
    public interface IProfileEditManager
    {
        Task<IPhysicalAppearanceModal> GetPhysicalAppreance();

        Task<bool> PerformSave(IPhysicalAppearanceModal physicalAppearance);

        Task<IEnumerable<IUserCreditModel>> GetUserCredits();

        Task<bool> SaveUserCredits(List<UserCreditModel> userCreditModelList);

        Task<bool> DeleteUserCredits(Guid userId);


        Task<DancingModel> GetUserDancingAsync();
        Task<bool> SaveUserDancingAsync(DancingModel dancingModel);


        Task<UserActingModel> GetUserActingDetailAsync();
        Task<bool> SaveUserActingDetailsAsync(UserActingModel userActingModel);

        Task<UserModelingModel> GetUserModelingDetailAsync();
        Task<bool> SaveUserModelingDetailsAsync(UserModelingModel userModelingModel);

        Task<UserNameModel> GetNameDetailsByUserId(Guid userId);
        Task<bool> SaveNameDetails(UserNameModel nameModel);

        Task<ProfileHeader> GetProfileHeaderByUserId(Guid userId);

        Task<UserDetailModel> GetProfileDetail();
        Task<bool> SaveUserIntro(UserDetailModel detailModel);
    }
}
