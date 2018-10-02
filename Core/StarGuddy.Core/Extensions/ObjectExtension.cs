namespace System
{
    public static partial class ObjectExtension
    {
        /// <summary>
        /// Check if null or DbNull
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>
        /// boolean value
        /// </returns>
        public static bool IsNull(this Object expression)
        {
            return (expression == null || expression == DBNull.Value);
        }

        /// <summary>
        /// Check if not null or DbNull
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>
        /// boolean value
        /// </returns>
        public static bool IsNotNull(this Object expression)
        {
            return (expression != null);
        }
        
        /// <summary>
        /// To the int32 nullable.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static int? ToInt32Nullable(this Object expression)
        {
            if (expression.IsNull())
                return null;

            return expression is Enum ? (int)expression : Convert.ToInt32(expression);
        }

        /// <summary>
        /// To the int32.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static int ToInt32(this Object expression, int defaultValue = 0)
        {
            return expression is Enum ? (int)expression : ToInt32Nullable(expression) ?? defaultValue;
        }

    }
}
