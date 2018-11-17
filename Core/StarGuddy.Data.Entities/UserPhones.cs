
namespace StarGuddy.Data.Entities
{
    using StarGuddy.Data.Entities.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserPhones : IUserPhones
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsConfirmed { get; set; }
        public int? TwoFactorCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DttmCreated { get; set; }
        public DateTime DttmModified { get; set; }
    }
}
