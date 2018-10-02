using StarGuddy.Api.Models.Interface.Profile;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Profile
{
    public class PhysicalAppearanceModal : IPhysicalAppearanceModal
    {
        public Guid UserId { get; set; }
        public int BodyType { get; set; }
        public int Chest { get; set; }
        public int EyeColor { get; set; }
        public int HairColor { get; set; }
        public int HairLength { get; set; }
        public int HairType { get; set; }
        public int SkinColor { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int West { get; set; }
        public int Ethnicity { get; set; }
    }
}
