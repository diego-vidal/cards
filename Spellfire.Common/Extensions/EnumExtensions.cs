using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QGenda.Common.Extensions
{
    /// <summary>
    /// Extension methods for enumerations
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the description, specified by the <see cref="DescriptionAttribute"/>, for a given enum value
        /// </summary>
        /// <param name="enumValue">an enum value</param>
        /// <returns>the description for the given enum value, or null if no description is available</returns>
        /// <remarks>
        /// If multiple descriptions are provided, only one will be returned, and there is no guarantee
        /// as to which one it will be. Therefore, it is not recommended to use this extension method
        /// in cases where multiple descriptions may be present.
        /// </remarks>
        public static string GetDescription(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var memberInfo = type.GetMember(enumValue.ToString());
            var descriptions = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptions.Length == 0)
                return enumValue.ToString();

            return ((DescriptionAttribute)descriptions[0]).Description;
        }

        /// <summary>
        /// Gets the display name for an enum. If it has none then it returns .ToString()
        /// </summary>
        /// <param name="enumValue">an enum value</param>
        /// <returns>the display name for the given enum value, or ToString() if no display name is available</returns>
        public static string GetDisplayName(this Enum enumValue, bool isShortName = false)
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString());
            var displayAttributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

            if (displayAttributes.Length == 0)
            {
                return enumValue.ToString();
            }

            // It is possible that the Display Attribute exists, but does not have the appropriate properties set.  Return enum.ToString() if it is missing.
            var attribute =  ((DisplayAttribute)displayAttributes[0]);
            var returnValue = isShortName ? attribute.ShortName : attribute.Name;

            return string.IsNullOrWhiteSpace(returnValue) ? enumValue.ToString() : returnValue;
        }

        /// <summary>
        /// Gets the display order for an enum
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static int GetDisplayOrder(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var memberInfo = type.GetMember(enumValue.ToString());
            var displayAttributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

            if (displayAttributes.Length == 0)
                throw new ArgumentException(string.Format("Display attribute must be specified for {0}", enumValue));

            var order = ((DisplayAttribute)displayAttributes[0]).GetOrder() ?? 0;

            return order;
        }
    }
}