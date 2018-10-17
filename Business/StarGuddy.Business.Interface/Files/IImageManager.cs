// -------------------------------------------------------------------------------
// <copyright file="IImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Interface.Files
{    
    #region name-space
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using StarGuddy.Api.Models.Files;
    using StarGuddy.Api.Models.Interface.ActionResult;
    using StarGuddy.Api.Models.Profile;
    #endregion

    /// <summary>
    /// Image Manager Interface
    /// </summary>
    public interface IImageManager
    {

        Task<ImageModel> GetHeadShotImageDetail();

        Task<bool> SaveUpdateHeadShotAsync(ImageModel imageModel);

        Task<IEnumerable<UserImageModel>> GetAllImagesAsync();

        Task<bool> SaveImageAsync(UserImageModel imageModel);

        Task<bool> DeleteImageAsync(Guid ImageId);

    }
}
