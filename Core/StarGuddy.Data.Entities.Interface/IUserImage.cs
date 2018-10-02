using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities.Interface
{
    public interface IUserImage
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        string Name { get; set; }
        string Caption { get; set; }
        string ImageUrl { get; set; }
        long? Size { get; set; }
        string DataUrl { get; set; }
        int ImageType { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        DateTime? DttmCreated { get; set; }
        DateTime? DttmModified { get; set; }
    }
}
