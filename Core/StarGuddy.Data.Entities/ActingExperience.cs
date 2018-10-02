using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities
{
    public class Experience : IExperience
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public Int32 Code { get; set; }
        public int ExpTypeCode { get; set; }
        public String Detail { get; set; }
        public Int32 DisplayOrder { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime? DttmCreated { get; set; }
        public DateTime? DttmModified { get; set; }
    }
}
