using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Interface
{
    public interface IUserCreditsRepository
    {
        Task<bool> PerformSaveOperation(IUserCredits userCredits);

        Task<IEnumerable<IUserCredits>> GetUserCreditsById(Guid userId);

        Task<bool> PerformMaultipleSaveOperation(ConcurrentBag<IUserCredits> userCredits);
        Task<bool> PerformDeleteOperation(Guid Id);
    }
}
