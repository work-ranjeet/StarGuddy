using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities.Interface
{
    public interface IDancingStyle
    {        
        long Id { get; set; }

        long Value { get; set; }

        string Style { get; set; }

        long? SelectedValue { get; set; }

        string Detail { get; set; }

        bool IsActive { get; set; }

        bool IsDeleted { get; set; }

        DateTime? DttmCreated { get; set; }

        DateTime? DttmModified { get; set; }
    }
}
