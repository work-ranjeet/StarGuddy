using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Account
{
    public class UserSettingDto
    {
        Guid UserId { get; set; }

        int Visibility { get; set; }

        string ProfileUrl { get; set; }

        int IsCommnetAlowed { get; set; }

        bool IsActive { get; set; }

        bool IsDeleted { get; set; }
    }
}
