using StarGuddy.Data.Entities;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Interface
{
    public interface ISettingsMasterRepository
    {
        Task<string> GetSettingsValue(string key);

        Task<SettingsMaster> GetValue(string key);
    }
}
