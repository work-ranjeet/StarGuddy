using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Dto
{
    public class PhoneDto
    {
        public Guid UserId { get; set; }
        public String PhoneNumber { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
