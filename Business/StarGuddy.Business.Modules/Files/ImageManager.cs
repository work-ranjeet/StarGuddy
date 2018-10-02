// -------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Modules.Files
{
    #region /// Name-space
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using StarGuddy.Api.Models.ActionResult;
    using StarGuddy.Api.Models.Files;
    using StarGuddy.Api.Models.Interface.ActionResult;
    using StarGuddy.Business.Interface.Files;
    using StarGuddy.Core.Context;
    using StarGuddy.Data.Entities;
    using StarGuddy.Repository.Interface;
    #endregion

    /// <summary>
    /// Image Manager
    /// </summary>
    public class ImageManager : IImageManager
    {
        private readonly IImageRepository _imageRepository;
        protected readonly IMapper _mapper;

        /// <summary>
        /// Gets or sets the working folder.
        /// </summary>
        /// <value>
        /// The working folder.
        /// </value>
        private string WorkingFolder { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageManager"/> class.
        /// </summary>
        public ImageManager(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageManager"/> class.
        /// </summary>
        /// <param name="workingFolder">The working folder.</param>
        public ImageManager(string workingFolder)
        {
            this.WorkingFolder = workingFolder;
            this.CheckTargetDirectory();
        }


        public async Task<ImageModel> GetHeadShotImageDetail()
        {
            var userImage =  await _imageRepository.GetUserHeadShotImages(UserContext.Current.UserId, 1);
            if (userImage.IsNotNull())
            {
                return _mapper.Map<ImageModel>(userImage);
            }

            return null;
        }

        public async Task<bool> SaveUpdateHeadShot(ImageModel imageModel)
        {
            imageModel.UserId = UserContext.Current.UserId;

            var userImage = _mapper.Map<UserImage>(imageModel);

            return await _imageRepository.PerformSaveAndUpdateOperationAsync(userImage);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ImageModel>> Get()
        {
            List<ImageModel> photos = new List<ImageModel>();

            DirectoryInfo photoFolder = new DirectoryInfo(this.WorkingFolder);

            await Task.Factory.StartNew(() =>
            {
                photos = photoFolder.EnumerateFiles()
                                            .Where(fi => new[] { ".jpg", ".bmp", ".png", ".gif", ".tiff" }.Contains(fi.Extension.ToLower()))
                                            .Select(fi => new ImageModel
                                            {
                                                Name = fi.Name,
                                                Size = fi.Length / 1024
                                            })
                                            .ToList();
            });

            return photos;
        }

        /// <summary>
        /// Deletes the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public async Task<IImageActionResult> Delete(string fileName)
        {
            try
            {
                var filePath = Directory.GetFiles(this.WorkingFolder, fileName)
                                .FirstOrDefault();

                await Task.Factory.StartNew(() =>
                {
                    File.Delete(filePath);
                });

                return new ImageActionResult { Successful = true, Message = fileName + "deleted successfully" };
            }
            catch (Exception ex)
            {
                return new ImageActionResult { Successful = false, Message = "error deleting fileName " + ex.GetBaseException().Message };
            }
        }

        /// <summary>
        /// Adds the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        //public async Task<IEnumerable<ImageModel>> Add(HttpRequestMessage request)
        //{
        //    var provider = new ImageMultipartFormDataStreamProvider(this.WorkingFolder);

        //    //await request.Content.ReadAsMultipartAsync(provider);

        //    var photos = new List<ImageModel>();

        //    //foreach (var file in provider.FileData)
        //    //{
        //    //    var fileInfo = new FileInfo(file.LocalFileName);

        //    //    photos.Add(new ImageModel
        //    //    {
        //    //        Name = fileInfo.Name,
        //    //        Created = fileInfo.CreationTime,
        //    //        Modified = fileInfo.LastWriteTime,
        //    //        Size = fileInfo.Length / 1024
        //    //    });
        //    //}

        //    return photos;
        //}

        /// <summary>
        /// Files the exists.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public bool FileExists(string fileName)
        {
            var file = Directory.GetFiles(this.WorkingFolder, fileName)
                                .FirstOrDefault();

            return file != null;
        }

        /// <summary>
        /// Checks the target directory.
        /// </summary>
        /// <exception cref="ArgumentException">the destination path " + this.WorkingFolder + " could not be found</exception>
        private void CheckTargetDirectory()
        {
            if (!Directory.Exists(this.WorkingFolder))
            {
                throw new ArgumentException("the destination path " + this.WorkingFolder + " could not be found");
            }
        }

        public Task<IEnumerable<ImageModel>> Add(HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }
    }
}
