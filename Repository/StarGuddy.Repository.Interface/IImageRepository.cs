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

        Task<bool> PerformSaveAndUpdateOperationAsync(IUserImage userImage);
    }
}
