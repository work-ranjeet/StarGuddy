// -------------------------------------------------------------------------------
// <copyright file="IImageActionResult.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Api.Models.Interface.ActionResult
{
    #region /// Name-space
    using System;
    using System.Collections.Generic;
    using System.Text;
    #endregion

    /// <summary>
    /// Image Action Result Interface
    /// </summary>
    public interface IImageActionResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ImageActionResult"/> is successful.
        /// </summary>
        /// <value>
        ///   <c>true</c> if successful; otherwise, <c>false</c>.
        /// </value>
        bool Successful { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; set; }
    }
}
