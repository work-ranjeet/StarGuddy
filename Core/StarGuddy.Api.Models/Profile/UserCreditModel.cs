using StarGuddy.Api.Models.Interface.Profile;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Profile
{
    public class UserCreditModel : IUserCreditModel
    {
        public UserCreditModel()
        {
            Id = Guid.Empty;
        }
        public Guid Id { get; set; }

        public string Action { get; set; }

        public int WorkYear { get; set; }

        public string WorkPlace { get; set; }

        public string WorkDetail { get; set; }
    }

}
