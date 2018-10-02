// -------------------------------------------------------------------------------
// <copyright file="PhysicalAppearance.cs" company="StarGuddy India">
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
    /// Physical Appearance
    /// </summary>
    public class PhysicalAppearance: IPhysicalAppearance
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
        /// Gets or sets the type of the body.
        /// </summary>
        /// <value>
        /// The type of the body.
        /// </value>
        public int BodyType { get; set; }

        /// <summary>
        /// Gets or sets the chest.
        /// </summary>
        /// <value>
        /// The chest.
        /// </value>
        public int Chest { get; set; }

        /// <summary>
        /// Gets or sets the color of the eye.
        /// </summary>
        /// <value>
        /// The color of the eye.
        /// </value>
        public int EyeColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the hair.
        /// </summary>
        /// <value>
        /// The color of the hair.
        /// </value>
        public int HairColor { get; set; }

        /// <summary>
        /// Gets or sets the length of the hair.
        /// </summary>
        /// <value>
        /// The length of the hair.
        /// </value>
        public int HairLength { get; set; }

        /// <summary>
        /// Gets or sets the type of the hair.
        /// </summary>
        /// <value>
        /// The type of the hair.
        /// </value>
        public int HairType { get; set; }

        /// <summary>
        /// Gets or sets the color of the skin.
        /// </summary>
        /// <value>
        /// The color of the skin.
        /// </value>
        public int SkinColor { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets the west.
        /// </summary>
        /// <value>
        /// The west.
        /// </value>
        public int West { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance Ethnicity.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance Ethnicity; otherwise, <c>false</c>.
        /// </value>
        public int Ethnicity { get; set; }

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
