using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities
{
    public class UserProfileHeader
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string About { get; set; }

        public string CityOrTown { get; set; }

        public string StateOrProvince { get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string DataUrl { get; set; }


        public IEnumerable<JobGroup> JobGroups { get; set; }
    }
}
