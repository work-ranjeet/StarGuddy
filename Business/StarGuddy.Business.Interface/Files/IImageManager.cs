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
    #endregion

    /// <summary>
    /// Image Manager Interface
    /// </summary>
    public interface IImageManager
    {

        Task<ImageModel> GetHeadShotImageDetail();

        Task<bool> SaveUpdateHeadShot(ImageModel imageModel);

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        //Task<IEnumerable<ImageModel>> Get();

        /// <summary>
        /// Deletes the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        Task<IImageActionResult> Delete(string fileName);

        /// <summary>
        /// Adds the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        //Task<IEnumerable<ImageModel>> Add(HttpRequestMessage request);

        /// <summary>
        /// Files the exists.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        bool FileExists(string fileName);
    }
}
