// -------------------------------------------------------------------------------
// <copyright file="ImageModel.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Api.Models.Files
{

    #region name-space
    using System;
    #endregion

    /// <summary>
    /// Image Model
    /// </summary>
    public class ImageModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Caption { get; set; }

        public string ImageUrl { get; set; }

        public string DataUrl { get; set; }

        public string ImageType { get; set; }

        public long Size { get; set; }
    }
}
