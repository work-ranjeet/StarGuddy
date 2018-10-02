using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Repository.Configuration
{
    /// <summary>
    /// Configuration Singleton
    /// </summary>
    /// <seealso cref="StarGuddy.Repository.Configuration.IConfigurationSingleton" />
    public class ConfigurationSingleton : IConfigurationSingleton
    {
        private IConfiguration Configuration { get; set; }

        private string ConnectionStringName => this.Configuration.GetAppSettingValue("ConnectionName");

        public ConfigurationSingleton(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }       

       
        public string SQLConnectionString => this.Configuration.GetConnectionString(ConnectionStringName);         
    }
}
