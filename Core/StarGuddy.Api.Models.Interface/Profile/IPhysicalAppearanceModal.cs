using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Interface.Profile
{
    public interface IPhysicalAppearanceModal
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the type of the body.
        /// </summary>
        /// <value>
        /// The type of the body.
        /// </value>
        int BodyType { get; set; }

        /// <summary>
        /// Gets or sets the chest.
        /// </summary>
        /// <value>
        /// The chest.
        /// </value>
        int Chest { get; set; }

        /// <summary>
        /// Gets or sets the color of the eye.
        /// </summary>
        /// <value>
        /// The color of the eye.
        /// </value>
        int EyeColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the hair.
        /// </summary>
        /// <value>
        /// The color of the hair.
        /// </value>
        int HairColor { get; set; }

        /// <summary>
        /// Gets or sets the length of the hair.
        /// </summary>
        /// <value>
        /// The length of the hair.
        /// </value>
        int HairLength { get; set; }

        /// <summary>
        /// Gets or sets the type of the hair.
        /// </summary>
        /// <value>
        /// The type of the hair.
        /// </value>
        int HairType { get; set; }

        /// <summary>
        /// Gets or sets the color of the skin.
        /// </summary>
        /// <value>
        /// The color of the skin.
        /// </value>
        int SkinColor { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        int Height { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        int Weight { get; set; }

        /// <summary>
        /// Gets or sets the west.
        /// </summary>
        /// <value>
        /// The west.
        /// </value>
        int West { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance Ethnicity.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance Ethnicity; otherwise, <c>false</c>.
        /// </value>
        int Ethnicity { get; set; }
    }
}
