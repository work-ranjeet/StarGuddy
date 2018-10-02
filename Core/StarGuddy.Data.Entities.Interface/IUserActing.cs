using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities.Interface
{
    public interface IUserActing
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        Int32 ActingExperianceCode { get; set; }
        String ActingExperiance { get; set; }
        Int32 AgentNeedCode { get; set; }
        String Experiance { get; set; }
        Boolean IsActive { get; set; }
        Boolean IsDeleted { get; set; }
        DateTime? DttmCreated { get; set; }
        DateTime? DttmModified { get; set; }
    }
}
