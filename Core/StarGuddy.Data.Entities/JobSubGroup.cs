using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities
{
    public class JobSubGroup : IJobSubGroup
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int SelectedCode { get; set; }
        public string Detail { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DttmCreated { get; set; }
        public DateTime? DttmModified { get; set; }
    }
}
