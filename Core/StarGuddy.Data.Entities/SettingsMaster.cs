using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities
{
    public class SettingsMaster
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public DateTime DttmCreated { get; set; }
        public DateTime DttmModified { get; set; }
    }
}
