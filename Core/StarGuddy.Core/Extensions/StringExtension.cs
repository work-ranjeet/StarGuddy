
namespace System
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    using System.Linq;

    /// <summary>
    /// string Extension
    /// </summary>
    public static partial class stringExtension
    {
        /// <summary>
        /// Rights the specified length.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="Length">The length.</param>
        /// <returns>string</returns>
        public static string Right(this string expression, int length)
        {
            string result = "";

            if (string.IsNullOrEmpty(expression))
                return result;

            if (length >= expression.Length)
                return expression;

            int startPos = expression.Length - length;

            result = expression.Substring(startPos, length);

            return result;
        }

        /// <summary>
        /// To the letter.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>
        /// string Values
        /// </returns>
        public static string ToLetter(this string expression)
        {
            string result = null;

            if (expression != null)
            {
                foreach (var c in expression)
                {
                    if (Char.IsLetter(c))
                        result += c;
                }
            }

            return result;
        }

        /// <summary>
        /// To the upper ex.
        /// </summary>
        /// <param name="expressionession">The expressionless.</param>
        /// <returns>string value</returns>
        public static string ToUpperEx(this string expression)
        {
            if (string.IsNullOrEmpty(expression))
                return expression;

            return expression.ToUpper();
        }

        /// <summary>
        /// Length the ex.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static int LengthEx(this string expression)
        {
            return string.IsNullOrEmpty(expression) ? 0 : expression.Length;
        }

        /// <summary>
        /// Removes the double space.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static string RemoveDoubleSpace(this string expression)
        {
            string result = (expression + "").Trim();

            if (!string.IsNullOrEmpty(result))
            {
                while (result.IndexOf("  ") >= 0)
                    result = result.Replace("  ", " ");
            }

            return result;
        }

        /// <summary>
        /// Substrings the ex.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns></returns>
        public static string SubstringEx(this string expression, int startIndex)
        {
            if (string.IsNullOrEmpty(expression))
                return string.Empty;

            if (startIndex < expression.Length)
                return expression.Substring(startIndex);

            return string.Empty;
        }

        /// <summary>
        /// Removes the chars.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="CharsToRemove">The chars to remove.</param>
        /// <returns></returns>
        public static string RemoveChars(this string expression, Char[] CharsToRemove)
        {
            string result = expression + "";

            if (string.IsNullOrEmpty(expression))
                return result;

            if (CharsToRemove != null && !string.IsNullOrEmpty(result))
            {
                foreach (Char c in CharsToRemove)
                    result = result.Replace("" + c, "");
            }

            return result;
        }
    }
}
