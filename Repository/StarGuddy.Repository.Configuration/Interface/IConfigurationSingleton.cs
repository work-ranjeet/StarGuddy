namespace StarGuddy.Repository.Configuration
{

    public interface IConfigurationSingleton
    {
        /// <summary>
        /// Gets the SQL connection string.
        /// </summary>
        /// <value>
        /// The SQL connection string.
        /// </value>
        string SQLConnectionString { get; }
    }
}