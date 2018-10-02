using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities.Interface
{
    public interface IUserModeling
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        int ExpCode { get; set; }
        string ExpText { get; set; }
        int AgentNeedCode { get; set; }
        string WebSite { get; set; }
        string Experiance { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        DateTime? DttmCreated { get; set; }
        DateTime? DttmModified { get; set; }
    }
}
