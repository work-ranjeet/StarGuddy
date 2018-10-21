namespace StarGuddy.Repository.Interface
{
    using StarGuddy.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserEmailsRepository
    {
        Task<UserEmails> GetCurrentActiveEmailAsync(Guid userId);

        Task<bool> UpdateEmailAsync(Guid userId, string email);

        Task<UserEmails> GetCurrentEmailAsync(Guid userId);

        Task<IEnumerable<UserEmails>> GetAllEmailAsync(Guid userId);

        Task<bool> ActivsteEmailAsync(Guid userId, string email);
    }
}
