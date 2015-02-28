using System;
using System.ComponentModel.DataAnnotations;

namespace Spellfire.Common.Extensions
{
    /// <summary>
    /// Extension methods for enumerations
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the display name for an enum value. If it has none then it returns .ToString()
        /// </summary>
        public static string GetDisplayName(this Enum enumValue)
        {
            var displayAttributes = enumValue.GetDisplayAttributes();

            return displayAttributes.Length == 0 ? enumValue.ToString() : ((DisplayAttribute)displayAttributes[0]).Name;
        }

        /// <summary>
        /// Gets the display short name for an enum value. If it has none then it returns .ToString()
        /// </summary>
        public static string GetDisplayShortName(this Enum enumValue)
        {
            var displayAttributes = enumValue.GetDisplayAttributes();

            return displayAttributes.Length == 0 ? enumValue.ToString() : ((DisplayAttribute)displayAttributes[0]).ShortName;
        }

        /// <summary>
        /// Gets the display description for an enum value. If it has none then it returns .ToString()
        /// </summary>
        public static string GetDisplayDescription(this Enum enumValue)
        {
            var displayAttributes = enumValue.GetDisplayAttributes();

            return displayAttributes.Length == 0 ? enumValue.ToString() : ((DisplayAttribute)displayAttributes[0]).Description;
        }

        /// <summary>
        /// Gets every display attribute of an enum value
        /// </summary>
        private static object[] GetDisplayAttributes(this Enum enumValue)
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString());
            var displayAttributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

            return displayAttributes;
        }
    }
}