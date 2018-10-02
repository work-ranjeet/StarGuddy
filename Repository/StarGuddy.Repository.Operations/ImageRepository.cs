using Dapper;
using StarGuddy.Data.Entities;
using StarGuddy.Data.Entities.Interface;
using StarGuddy.Repository.Base;
using StarGuddy.Repository.Configuration;
using StarGuddy.Repository.Interface;
using StarGuddy.Repository.Opertions.Constants;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Operations
{
    public class ImageRepository : RepositoryAbstract<UserImage>, IImageRepository
    {
        public ImageRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserImage) { }

        public async Task<IUserImage> GetUserImageAsync(Guid userId) => await FindActiveByUserIdAsync(userId);

        public async Task<UserImage> GetUserHeadShotImages(Guid userId, int imageType)
        {
            var allImages = await FindAllActiveByUserIdAsync(userId);

            return allImages.FirstOrDefault(x => x.ImageType == imageType);
       }

        public async Task<bool> PerformSaveAndUpdateOperationAsync(IUserImage userImage)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    // @UserId UNIQUEIDENTIFIER, @Name NVARCHAR(450), @Caption NVARCHAR(200), @ImageUrl NVARCHAR(1000), @Size BIGINT, @DataUrl NVARCHAR(MAX), @ImageType INT
                    var param = new
                    {
                        userImage.UserId,
                        userImage.Name,
                        userImage.Caption,
                        userImage.ImageUrl,
                        userImage.Size,
                        userImage.DataUrl,
                        userImage.ImageType
                    };

                    await SqlMapper.ExecuteAsync(conn, SpNames.UserImage.HeadShotImageSaveUpdate, param, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
