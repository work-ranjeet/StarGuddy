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
namespace StarGuddy.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using StarGuddy.Data.Entities.Interface;

    /// <summary>
    /// User Detail
    /// </summary>
    public class UserDetail: IUserDetail
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
        /// Gets or sets the about.
        /// </summary>
        /// <value>
        /// The about.
        /// </value>
        public String About { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        public Int32 Age { get; set; }

        /// <summary>
        /// Gets or sets the blood group.
        /// </summary>
        /// <value>
        /// The blood group.
        /// </value>
        public Int32 BloodGroup { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the disability.
        /// </summary>
        /// <value>
        /// The disability.
        /// </value>
        public String Disability { get; set; }

        /// <summary>
        /// Gets or sets the health information.
        /// </summary>
        /// <value>
        /// The health information.
        /// </value>
        public String HealthInfo { get; set; }

        /// <summary>
        /// Gets or sets the marital status.
        /// </summary>
        /// <value>
        /// The marital status.
        /// </value>
        public Int32 MaritalStatus { get; set; }

        /// <summary>
        /// Gets or sets the mother tongue.
        /// </summary>
        /// <value>
        /// The mother tongue.
        /// </value>
        public String MotherTongue { get; set; }

        /// <summary>
        /// Gets or sets the nickname.
        /// </summary>
        /// <value>
        /// The nickname.
        /// </value>
        public String Nickname { get; set; }

        /// <summary>
        /// Gets or sets the religion.
        /// </summary>
        /// <value>
        /// The religion.
        /// </value>
        public String Religion { get; set; }

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
