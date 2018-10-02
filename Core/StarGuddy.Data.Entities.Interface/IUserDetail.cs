// -------------------------------------------------------------------------------
// <copyright file="UserDetail.cs" company="StarGuddy India">
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
namespace StarGuddy.Data.Entities.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// User Detail
    /// </summary>
    public interface IUserDetail
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the about.
        /// </summary>
        /// <value>
        /// The about.
        /// </value>
        String About { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        Int32 Age { get; set; }

        /// <summary>
        /// Gets or sets the blood group.
        /// </summary>
        /// <value>
        /// The blood group.
        /// </value>
        Int32 BloodGroup { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the disability.
        /// </summary>
        /// <value>
        /// The disability.
        /// </value>
        String Disability { get; set; }

        /// <summary>
        /// Gets or sets the health information.
        /// </summary>
        /// <value>
        /// The health information.
        /// </value>
        String HealthInfo { get; set; }

        /// <summary>
        /// Gets or sets the marital status.
        /// </summary>
        /// <value>
        /// The marital status.
        /// </value>
        Int32 MaritalStatus { get; set; }

        /// <summary>
        /// Gets or sets the mother tongue.
        /// </summary>
        /// <value>
        /// The mother tongue.
        /// </value>
        String MotherTongue { get; set; }

        /// <summary>
        /// Gets or sets the nickname.
        /// </summary>
        /// <value>
        /// The nickname.
        /// </value>
        String Nickname { get; set; }

        /// <summary>
        /// Gets or sets the religion.
        /// </summary>
        /// <value>
        /// The religion.
        /// </value>
        String Religion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        Boolean IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        Boolean IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the DTTM created.
        /// </summary>
        /// <value>
        /// The DTTM created.
        /// </value>
        DateTime DttmCreated { get; set; }

        /// <summary>
        /// Gets or sets the DTTM modified.
        /// </summary>
        /// <value>
        /// The DTTM modified.
        /// </value>
        DateTime DttmModified { get; set; }
    }

}
