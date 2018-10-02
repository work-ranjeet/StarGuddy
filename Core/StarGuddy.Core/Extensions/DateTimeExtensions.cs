namespace System
{
    /// <summary>
    /// Date Time Extension
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// To the UNIX epoch date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>
        /// Int64 values
        /// </returns>
        public static Int64? ToUnixEpochDate(this DateTime? dateTime)
        {
            var result = dateTime.HasValue ? ToUnixEpochDate(dateTime.Value) : (Int64?)null;

            return result;
        }

        /// <summary>
        /// To the UNIX epoch date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>
        /// Int64 values
        /// </returns>
        public static Int64 ToUnixEpochDate(this DateTime dateTime)
        {
            var result = (Int64)Math.Round((dateTime.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

            return result;
        }

        /// <summary>
        /// To the UNIX epoch date.
        /// </summary>
        /// <param name="unixTime">The UNIX time.</param>
        /// <returns>
        /// Date Time
        /// </returns>
        public static DateTime ToUnixEpochDate(this Int64 unixTime)
        {
            var result = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime);

            return result;
        }

        /// <summary>
        /// To the UNIX epoch date.
        /// </summary>
        /// <param name="unixTime">The UNIX time.</param>
        /// <returns>
        /// Null able Date Time
        /// </returns>
        public static DateTime? ToUnixEpochDate(this Int64? unixTime)
        {
            var result = unixTime.HasValue ? ToUnixEpochDate(unixTime.Value) : (DateTime?)null;

            return result;
        }
    }
}