// -------------------------------------------------------------------------------
// <copyright file="UserAddress.cs" company="StarGuddy India">
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
    using System.Linq;
    using System.Threading.Tasks;
    using StarGuddy.Data.Entities.Interface;

    /// <summary>
    /// User Address
    /// </summary>
    public class UserAddress : IUserAddress
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
        /// Gets or sets the name of the application or house.
        /// </summary>
        /// <value>
        /// The name of the application or house.
        /// </value>
        public String AppOrHouseName { get; set; }

        /// <summary>
        /// Gets or sets the city or town.
        /// </summary>
        /// <value>
        /// The city or town.
        /// </value>
        public String CityOrTown { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public String Country { get; set; }

        /// <summary>
        /// Gets or sets the flat.
        /// </summary>
        /// <value>
        /// The flat.
        /// </value>
        public String Flat { get; set; }

        /// <summary>
        /// Gets or sets the land mark.
        /// </summary>
        /// <value>
        /// The land mark.
        /// </value>
        public String LandMark { get; set; }

        /// <summary>
        /// Gets or sets the line one.
        /// </summary>
        /// <value>
        /// The line one.
        /// </value>
        public String LineOne { get; set; }

        /// <summary>
        /// Gets or sets the line two.
        /// </summary>
        /// <value>
        /// The line two.
        /// </value>
        public String LineTwo { get; set; }

        /// <summary>
        /// Gets or sets the state or province.
        /// </summary>
        /// <value>
        /// The state or province.
        /// </value>
        public String StateOrProvince { get; set; }

        /// <summary>
        /// Gets or sets the zip or postal code.
        /// </summary>
        /// <value>
        /// The zip or postal code.
        /// </value>
        public String ZipOrPostalCode { get; set; }

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
