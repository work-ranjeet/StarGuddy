using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Security
{
    [Serializable]
    public class EmailVerification
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public string SecurityStamp { get; set; }

        public DateTime ExpiryHour { get; set; }
    }
}
