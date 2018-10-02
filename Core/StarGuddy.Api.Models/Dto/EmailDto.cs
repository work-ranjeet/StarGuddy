using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Dto
{
    public class EmailDto
    {
        public Guid UserId { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
