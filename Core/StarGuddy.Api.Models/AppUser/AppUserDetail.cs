using StarGuddy.Api.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.AppUser
{
    public class AppUserDetail
    {
        public AppUserDto ApplicationUser { get; set; }

        public AddressDto CurrentAddress { get; set; }

        public UserDetailDto UserDetails { get; set; }

        public PhoneDto Phone { get; set; }

        public EmailDto Email { get; set; }
    }
}
