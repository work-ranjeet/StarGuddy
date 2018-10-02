using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities
{
    public class UserModeling : IUserModeling
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int ExpCode { get; set; }
        public string ExpText { get; set; }
        public int AgentNeedCode { get; set; }
        public string WebSite { get; set; }
        public string Experiance { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DttmCreated { get; set; }
        public DateTime? DttmModified { get; set; }
    }
}
