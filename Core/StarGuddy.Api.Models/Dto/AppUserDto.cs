using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Dto
{
    public class AppUserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string OrgName { get; set; }
        public string OrgWebsite { get; set; }
        public bool IsCastingProfessional { get; set; }
    }
}
