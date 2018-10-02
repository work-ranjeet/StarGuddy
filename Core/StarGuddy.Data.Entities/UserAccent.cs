// -------------------------------------------------------------------------------
// <copyright file="UserAscent.cs" company="StarGuddy India">
// Copyright (c) 2018. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains properties of customer details.
// -------------------------------------------------------------------------------
// Author: Ranjeet Kumar
// Date Created: 01/01/2018
// -------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace StarGuddy.Data.Entities
{
    using System;
    using StarGuddy.Data.Entities.Interface;

    /// <summary>
    /// User Ascent
    /// </summary>
    public class UserAccent : IUserAccent
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the accents identifier.
        /// </summary>
        /// <value>
        /// The accents identifier.
        /// </value>
        public Int64 AccentsId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the DTTM created.
        /// </summary>
        /// <value>
        /// The DTTM created.
        /// </value>
        public DateTime DttmCreated { get; set; }

        /// <summary>
        /// Gets or sets the DTTM modified.
        /// </summary>
        /// <value>
        /// The DTTM modified.
        /// </value>
        public DateTime DttmModified { get; set; }
    }
}

