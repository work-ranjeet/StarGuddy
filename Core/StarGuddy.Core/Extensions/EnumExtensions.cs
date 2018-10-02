namespace System
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// ENUM Extension
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// To the description.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>
        /// ENUM Values
        /// </returns>
        public static string ToDescription(this Enum instance)
        {
            var fieldInfo = instance.GetType().GetField(instance.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes != null && attributes.Length > 0 ? attributes[0].Description : instance.ToString();
        }

        /// <summary>
        /// Determines whether [is NULLABLE ENUM].
        /// </summary>
        /// <param name="T">The t.</param>
        /// <returns>
        ///   <c>true</c> if [is NULLABLE ENUM] [the specified t]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullableEnum(this Type T)
        {
            Type type = Nullable.GetUnderlyingType(T);

            return (type != null) && type.GetTypeInfo().IsEnum;
        }

        /// <summary>
        /// Determines whether [is character ENUM].
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>
        ///   <c>true</c> if [is character ENUM] [the specified instance]; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsCharEnum(this Enum instance)
        {
            return IsCharEnum(instance.GetType());
        }

        /// <summary>
        /// Determines whether [is character ENUM] [the specified t].
        /// </summary>
        /// <param name="T">The t.</param>
        /// <returns>
        ///   <c>true</c> if [is character ENUM] [the specified t]; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsCharEnum(Type T)
        {
            Type enumType = T.IsNullableEnum() ? Nullable.GetUnderlyingType(T) : T;

            if (!enumType.GetTypeInfo().IsEnum)
                return false;

            try
            {
                return ((Int32[])Enum.GetValues(enumType)).All(i => Char.IsLetter((Char)i));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// To the ENUM list.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>
        /// ENUM Values
        /// </returns>
        public static List<Enum> ToEnumList(this Enum instance)
        {
            return Enum.GetValues(instance.GetType()).Cast<Enum>().ToList();
        }

        /// <summary>
        /// Determines whether [is in set] [the specified items].
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="items">The items.</param>
        /// <returns>
        ///   <c>true</c> if [is in set] [the specified items]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInSet(this Enum instance, params Enum[] items)
        {
            var result = false;
            foreach (Enum item in items)
            {
                if (instance.ToString() == item.ToString())
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// To the ENUM list.
        /// </summary>
        /// <param name="enumType">Type of the ENUM.</param>
        /// <returns>
        /// ENUM Values
        /// </returns>
        public static List<Enum> ToEnumList(this Type enumType)
        {
            if (!enumType.GetTypeInfo().IsEnum)
                throw new Exception(String.Format("{0} must be an enum type", enumType));

            return ((Enum)Activator.CreateInstance(enumType)).ToEnumList();
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// ENUM Values
        /// </returns>
        public static TEnum Parse<TEnum>(String value) where TEnum : struct
        {
            TEnum result;

            if (value.Length == 1)
                result = Parse<TEnum>(Char.Parse(value));
            else
                result = (TEnum)Enum.Parse(typeof(TEnum), value, true);

            return result;
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// ENUM Values
        /// </returns>
        public static TEnum Parse<TEnum>(Char value) where TEnum : struct
        {
            return (TEnum)Enum.ToObject(typeof(TEnum), value);
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// ENUM Values
        /// </returns>
        public static TEnum Parse<TEnum>(Int32 value) where TEnum : struct
        {
            return (TEnum)Enum.ToObject(typeof(TEnum), value);
        }
    }
}