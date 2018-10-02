using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace StarGuddy.Core.Context
{
    public interface IUserContext
    {
        Guid UserId { get; set; }

        bool IsAuthenticated { get; set; }

        string UserName { get; set; }

        string Email { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}
