using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities
{
    public class UserSettings : IUserSettings
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Int32 Visibility { get; set; }

        public String ProfileUrl { get; set; }

        public Int32 IsCommnetAlowed { get; set; }

        public Boolean IsActive { get; set; }

        public Boolean IsDeleted { get; set; }

        public DateTime DttmCreated { get; set; }

        public DateTime DttmModified { get; set; }
    }
}
