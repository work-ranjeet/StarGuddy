using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities
{
    public class UserModelingDetails
    {
        public IUserModeling UserModeling { get; set; }

        public IEnumerable<JobSubGroup> ModelingRoles { get; set; }
    }
}
