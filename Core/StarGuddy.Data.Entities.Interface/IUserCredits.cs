using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities.Interface
{
    public interface IUserCredits
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        Int32 Year { get; set; }
        String WorkPlace { get; set; }
        String WorkDetail { get; set; }
        Boolean IsActive { get; set; }
        Boolean IsDeleted { get; set; }
        DateTime DttmCreated { get; set; }
        DateTime DttmModified { get; set; }
    }
}
