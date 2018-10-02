using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities
{
    public class UserActing : IUserActing
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Int32 ActingExperianceCode { get; set; }

        public String ActingExperiance { get; set; }

        public Int32 AgentNeedCode { get; set; }

        public String AgentNeed { get; set; }

        public String Experiance { get; set; }

        public Boolean IsActive { get; set; }

        public Boolean IsDeleted { get; set; }

        public DateTime? DttmCreated { get; set; }

        public DateTime? DttmModified { get; set; }

    }
}
