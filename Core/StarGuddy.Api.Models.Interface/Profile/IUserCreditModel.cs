using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Interface.Profile
{
    public interface IUserCreditModel
    {
        Guid Id { get; set; }

        string Action { get; set; }

        Int32 WorkYear { get; set; }

        String WorkPlace { get; set; }

        String WorkDetail { get; set; }
    }
}
