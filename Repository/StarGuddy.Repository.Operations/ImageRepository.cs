using Dapper;
using StarGuddy.Core.Enums;
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

        public async Task<IEnumerable<UserImage>> GetUserImagesAsync(Guid userId, ImageType imageType)
        {
            var allImages = await FindAllActiveByUserIdAsync(userId);
            allImages = allImages.Where(x => x.ImageType != ImageType.HeadShot.GetHashCode() || !string.IsNullOrWhiteSpace(x.DataUrl));

            return imageType == ImageType.AllImage ? allImages : allImages.Where(x => x.ImageType == imageType.GetHashCode());
        }

        public async Task<bool> PerformSaveAndUpdateHeadShotAsync(IUserImage userImage)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    // @UserId UNIQUEIDENTIFIER, @Name NVARCHAR(450), @Caption NVARCHAR(200), @ImageUrl NVARCHAR(1000), @Size BIGINT, @DataUrl NVARCHAR(MAX)
                    var param = new
                    {
                        userImage.UserId,
                        userImage.Name,
                        userImage.Caption,
                        userImage.ImageUrl,
                        userImage.Size,
                        userImage.DataUrl
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

        public async Task<bool> PerformSaveImageOperationAsync(IUserImage userImage)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
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

                    await SqlMapper.ExecuteAsync(conn, SpNames.UserImage.SaveImage, param, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PerformUpdateStatusAsync(Guid ImageId, ApprovalStatus Status, Guid ApprovalId)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    // @ImageId UNIQUEIDENTIFIER, @StatusCode INT, @ApprovalId UNIQUEIDENTIFIER
                    var param = new
                    {
                        ImageId,
                        StatusCode = Status.GetHashCode(),
                        ApprovalId
                    };

                    await SqlMapper.ExecuteAsync(conn, SpNames.UserImage.UpdateStatus, param, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PerformUpdateCaptionAsync(Guid ImageId, string Caption)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    // @ImageId UNIQUEIDENTIFIER, @StatusCode INT, @ApprovalId UNIQUEIDENTIFIER
                    var param = new
                    {
                        ImageId,
                        Caption
                    };

                    await SqlMapper.ExecuteAsync(conn, SpNames.UserImage.UpdateCaption, param, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PerformDeleteAsync(Guid ImageId)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    await SqlMapper.ExecuteAsync(conn, SpNames.UserImage.Delete, new { ImageId }, commandType: CommandType.StoredProcedure);

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
