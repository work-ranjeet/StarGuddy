using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities.Interface
{
    public interface IAuditionsAndJobs
    {
        Int64 Id { get; set; }

        String Name { get; set; }

        Int32 Code { get; set; }

        String Detail { get; set; }

        Int32 DisplayOrder { get; set; }

        Boolean IsActive { get; set; }

        Boolean IsDeleted { get; set; }

        DateTime? DttmCreated { get; set; }

        DateTime? DttmModified { get; set; }
    }
}
