using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Profile
{
    public class UserNameModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string OrgName { get; set; }
    }
}
