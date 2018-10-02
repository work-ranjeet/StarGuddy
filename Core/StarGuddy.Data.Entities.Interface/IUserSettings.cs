using System;
namespace StarGuddy.Data.Entities.Interface
{
    public interface IUserSettings
    {
        Guid Id { get; set; }

        Guid UserId { get; set; }

        Int32 Visibility { get; set; }

        String ProfileUrl { get; set; }

        Int32 IsCommnetAlowed { get; set; }

        Boolean IsActive { get; set; }

        Boolean IsDeleted { get; set; }

        DateTime DttmCreated { get; set; }

        DateTime DttmModified { get; set; }
    }
}