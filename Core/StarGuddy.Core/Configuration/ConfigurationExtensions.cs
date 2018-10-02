
namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// Configuration Extensions
    /// </summary>
    public static class ConfigurationExtensions
    {
        public static string GetAppSettingValue(this IConfiguration configuration, string key)
        {
            var appSettings = configuration.GetSection("AppSettings");
            if (appSettings == null)
            {
                return string.Empty;
            }

            var result = appSettings[key];
            return string.IsNullOrEmpty(result) ? string.Empty : result;
        }
    }
}
