
namespace StarGuddy.Core.Constants
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// App Settings
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// The security key phrase
        /// </summary>
        public const string JwtIssuer = "JwtIssuer";

        /// <summary>
        /// The JWT audience
        /// </summary>
        public const string JwtAudience = "JwtAudience";

        /// <summary>
        /// The JWT secret
        /// </summary>
        public const string JwtSecret = "JwtSecret";

        /// <summary>
        /// The JWT secret
        /// </summary>
        public const string EncryptionKey = "EncryptionKey";
    }
}
