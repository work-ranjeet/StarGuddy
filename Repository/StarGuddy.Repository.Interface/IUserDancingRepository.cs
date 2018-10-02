using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Interface
{
    public interface IUserDancingRepository
    {
        Task<IUserDancing> GetUserDancingAsync(Guid userId);

        Task<IEnumerable<IDancingStyle>> GetDancingStyleAsync(Guid userId);

        Task<IEnumerable<IDancingStyle>> GetDancingStyleSelectedAsync(Guid userId);

        Task<bool> PerformSaveAndUpdateOperationAsync(IUserDancing userDancing, ConcurrentBag<long> danceStyleIds);
    }
}
