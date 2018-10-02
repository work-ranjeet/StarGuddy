using StarGuddy.Api.Models.Interface.Profile;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Profile
{
    public class UserProfile
    {
        public IPhysicalAppearanceModal PhysicalAppearance { get; set; }

        public IEnumerable<IUserCreditModel> UserCredits { get; set; }

        public DancingModel Dancing { get; set; }

        public UserActingModel Acting { get; set; }

        public UserModelingModel Modeling { get; set; }
    }
}
