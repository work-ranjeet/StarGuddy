
namespace StarGuddy.Data.Entities.Interface
{
    using System;

    public interface IUserPhones
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        string PhoneNumber { get; set; }
        bool IsConfirmed { get; set; }
        int? TwoFactorCode { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        DateTime DttmCreated { get; set; }
        DateTime DttmModified { get; set; }
    }
}
