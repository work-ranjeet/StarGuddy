namespace StarGuddy.Repository.Interface
{
    using StarGuddy.Data.Entities;
    using System;
    using System.Threading.Tasks;

    public interface IUserEmailsRepository
    {
        Task<UserEmails> GetUserEmailAsync(Guid userId);

        Task<bool> UpdateEmailAsync(Guid userId, string email);
    }
}
