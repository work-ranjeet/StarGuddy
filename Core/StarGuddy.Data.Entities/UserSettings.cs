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
        public Guid VisibilityGroupId { get; set; }
        public bool IsProfilePhotoVisibile { get; set; }
        public bool IsProfileCommentAllowed { get; set; }
        public bool IsMobileVisible { get; set; }
        public bool IsEmailVisible { get; set; }
        public string ProfileUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsProfileDisabled { get; set; }
        public DateTime DttmCreated { get; set; }
        public DateTime DttmModified { get; set; }
    }
}
