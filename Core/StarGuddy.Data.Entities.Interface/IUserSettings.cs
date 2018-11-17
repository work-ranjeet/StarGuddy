using System;
namespace StarGuddy.Data.Entities.Interface
{
    public interface IUserSettings
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        Guid VisibilityGroupId { get; set; }
        bool IsProfilePhotoVisibile { get; set; }
        bool IsProfileCommentAllowed { get; set; }
        bool IsMobileVisible { get; set; }
        bool IsEmailVisible { get; set; }
        string ProfileUrl { get; set; }
        bool IsActive { get; set; }
        bool IsProfileDisabled { get; set; }
        DateTime DttmCreated { get; set; }
        DateTime DttmModified { get; set; }
    }
}