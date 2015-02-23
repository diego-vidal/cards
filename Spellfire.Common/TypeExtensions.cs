using System;
using System.Linq;

namespace Spellfire.Common.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="Type"/> class
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Tests whether or not the type contains a public property with the given name
        /// </summary>
        /// <param name="type">the type to test</param>
        /// <param name="propertyName">the name of the property</param>
        /// <returns>true if the type contains a property with the given name; otherwise false</returns>
        public static bool HasProperty(this Type type, string propertyName)
        {
            return type.GetProperty(propertyName) != null;
        }

        /// <summary>
        /// Tests whether or not the type implements a given open generic type (a generic type w/o any type parameters, such as <c>IList&lt;&gt;</c>)
        /// </summary>
        /// <param name="type">the type to test</param>
        /// <param name="openGenericInterface">An open generic interface</param>
        /// <returns>true if the type implements the given open generic interface</returns>
        /// <remarks>
        /// This method is not intended for use with closed generic types, such as <c>IList&lt;String&gt;</c>.
        /// To test if a type implements a closed generic type, see the <see cref="Type.IsAssignableFrom"/> method.
        /// </remarks>
        public static bool ImplementsOpenGenericInterface(this Type type, Type openGenericInterface)
        {
            var interfaces = type.GetInterfaces();

            return interfaces.Any(t => t.IsGenericType && (t.GetGenericTypeDefinition() == openGenericInterface));
        }
    }
}
