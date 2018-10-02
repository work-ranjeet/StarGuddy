using StarGuddy.Data.Entities;
using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Interface
{
    public interface IUserActingRepository
    {
        Task<UserActingDetail> GetUserActingDetailAsync(Guid userId);

        Task<bool> PerformSaveAndUpdateOperationAsync(UserActingDetail actingDetail);
    }
}
