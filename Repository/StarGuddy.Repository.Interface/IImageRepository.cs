using StarGuddy.Core.Enums;
using StarGuddy.Data.Entities;
using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Interface
{
    public interface IImageRepository
    {
        Task<IUserImage> GetUserImageAsync(Guid userId);

        Task<UserImage> GetUserHeadShotImages(Guid userId, int imageType);

        Task<IEnumerable<UserImage>> GetUserImagesAsync(Guid userId, ImageType imageType);

        Task<bool> PerformSaveAndUpdateHeadShotAsync(IUserImage userImage);

        Task<bool> PerformSaveImageOperationAsync(IUserImage userImage);

        Task<bool> PerformUpdateStatusAsync(Guid ImageId, ApprovalStatus Status, Guid ApprovalId);

        Task<bool> PerformUpdateCaptionAsync(Guid ImageId, string Caption);

        Task<bool> PerformDeleteAsync(Guid ImageId);
    }
}
