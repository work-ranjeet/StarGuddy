using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities
{
    public class UserDancingStyle
    {
        public Guid Id { get; set; }
        public Guid UserDancingId { get; set; }
        public Int64 DancingStyleId { get; set; }
    }
}
