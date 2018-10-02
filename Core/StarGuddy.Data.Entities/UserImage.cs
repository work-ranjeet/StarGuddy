using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities
{
    public class UserImage: IUserImage
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string ImageUrl { get; set; }
        public long? Size { get; set; }
        public string DataUrl { get; set; }
        public int ImageType { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DttmCreated { get; set; }
        public DateTime? DttmModified { get; set; }
    }
}
