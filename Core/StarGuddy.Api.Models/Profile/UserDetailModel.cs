using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Profile
{
    public class UserDetailModel
    {
        public Guid UserId { get; set; }

        public string About { get; set; }

        public string ProfileAddress { get; set; }

        public Int32 Age { get; set; }

        public Int32 BloodGroup { get; set; }

        public DateTime DateOfBirth { get; set; }

        public String Disability { get; set; }

        public String HealthInfo { get; set; }

        public Int32 MaritalStatus { get; set; }

        public String MotherTongue { get; set; }

        public String Nickname { get; set; }

        public String Religion { get; set; }
    }
}
