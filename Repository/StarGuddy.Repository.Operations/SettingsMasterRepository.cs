using Dapper;
using StarGuddy.Data.Entities;
using StarGuddy.Repository.Base;
using StarGuddy.Repository.Configuration;
using StarGuddy.Repository.Interface;
using StarGuddy.Repository.Opertions.Constants;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Operations
{
    public class SettingsMasterRepository : RepositoryAbstract<SettingsMaster>, ISettingsMasterRepository
    {
        public SettingsMasterRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.SettingsMaster) { }

        public async Task<SettingsMaster> GetValue(string key)
        {
            using (var conn = await Connection.OpenConnectionAsync())
            {
                var param = new { Key = key };

                return (await SqlMapper.QueryAsync<SettingsMaster>(conn, SpNames.SettingsMaaster.GetSettingsByKey, param, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            }
        }

        public async Task<string> GetSettingsValue(string key)
        {
            var settings = await GetValue(key).ConfigureAwait(false);
            if (settings.IsNotNull())
            {
                return settings.Value;
            }

            return string.Empty;
        }
    }
}
