using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities
{
    public class DancingStyle: IDancingStyle
    {
        public long Id { get; set; }

        public long Value { get; set; }

        public string Style { get; set; }

        public long? SelectedValue { get; set; }

        public string Detail { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DttmCreated { get; set; }

        public DateTime? DttmModified { get; set; }
    }
}
