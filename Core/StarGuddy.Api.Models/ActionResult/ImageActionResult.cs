// -------------------------------------------------------------------------------
// <copyright file="ImageActionResult.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Api.Models.ActionResult
{    
    #region ///Name-space
    using System;
    using System.Collections.Generic;
    using System.Text;
    using StarGuddy.Api.Models.Interface.ActionResult;
    #endregion

    /// <summary>
    /// Image Action Result
    /// </summary>
    public class ImageActionResult : IImageActionResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ImageActionResult"/> is successful.
        /// </summary>
        /// <value>
        ///   <c>true</c> if successful; otherwise, <c>false</c>.
        /// </value>
        public bool Successful { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}
