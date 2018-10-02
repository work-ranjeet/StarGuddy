using System;

namespace System.Globalization
{
    /// <summary>
    /// Number Format Info Extension
    /// </summary>
    public static class NumberFormatInfoEx
    {
        /// <summary>
        /// Gets the number format information.
        /// </summary>
        /// <param name="NumberDecimalSeparator">The number decimal separator.</param>
        /// <returns>
        /// NumberFormatInfo Object
        /// </returns>
        public static NumberFormatInfo GetNumberFormatInfo(string NumberDecimalSeparator)
        {
            var numberFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = NumberDecimalSeparator,
                NumberGroupSeparator = ""
            };

            return numberFormatInfo;
        }

        /// <summary>
        /// Masks the specified digits.
        /// </summary>
        /// <param name="Digits">The digits.</param>
        /// <returns>
        /// string values
        /// </returns>
        public static string Mask(Int32 Digits)
        {
            return "0." + new String('0', Digits);
        }
    }
}
