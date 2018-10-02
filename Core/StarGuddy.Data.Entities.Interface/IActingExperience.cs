using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities.Interface
{
    public interface IExperience
    {
        long Id { get; set; }
        string Name { get; set; }
        int Code { get; set; }
        int ExpTypeCode { get; set; }
        string Detail { get; set; }
        int DisplayOrder { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        DateTime? DttmCreated { get; set; }
        DateTime? DttmModified { get; set; }
    }
}
