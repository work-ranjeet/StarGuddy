using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Dto
{
    public class UserDetailDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string About { get; set; }

        public int Age { get; set; }

        public int BloodGroup { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Disability { get; set; }

        public string HealthInfo { get; set; }

        public int MaritalStatus { get; set; }

        public string MotherTongue { get; set; }

        public string Nickname { get; set; }

        public string ProfileAddress { get; set; }

        public string Religion { get; set; }
    }
}
