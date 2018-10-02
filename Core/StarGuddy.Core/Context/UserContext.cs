using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Core.Context
{
    public class UserContext: IUserContext
    {
        private static IUserContext userContext = null;

        public static IUserContext Current
        {
            get
            {
                if (userContext == null)
                    userContext = new UserContext();

                return userContext;
            }
        }

        private UserContext() { }
        public Guid UserId { get; set; }

        public bool IsAuthenticated { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
