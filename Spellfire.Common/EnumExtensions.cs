using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Spellfire.Common.Extensions
{
    /// <summary>
    /// Extension methods for enumerations
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the display name for an enum. If it has none then it returns .ToString()
        /// </summary>
        /// <param name="enumValue">an enum value</param>
        /// <returns>the display name for the given enum value or ToString() if no display name is available</returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString());
            var displayAttributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

            if (displayAttributes.Length == 0)
            {
                return enumValue.ToString();
            }

            var displayName =  ((DisplayAttribute)displayAttributes[0]).Name;

            return string.IsNullOrWhiteSpace(displayName) ? enumValue.ToString() : displayName;
        }
    }
}