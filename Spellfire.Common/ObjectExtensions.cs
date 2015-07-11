using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace Spellfire.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static TToModify SetProperty<TToModify>(this TToModify objToModify, string propertyName, object value, bool convertValue = false)
            where TToModify : class
        {

            var objToModifyType = objToModify.GetType();

            var objToModifyPropertyInfo = objToModifyType.GetProperty(propertyName);

            if (convertValue)
            {
                var propertyToModifyType = objToModifyPropertyInfo.PropertyType;

                if (propertyToModifyType.IsGenericType && propertyToModifyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    // Property is a nullable type.  Allow for null here or convert to the nullable type.
                    value = value == null ? value : Convert.ChangeType(value, Nullable.GetUnderlyingType(propertyToModifyType));
                }
                else
                {
                    // Property is not nullable, so just convert the type.
                    value = Convert.ChangeType(value, propertyToModifyType);
                }
            }

            objToModifyPropertyInfo.SetValue(objToModify, value, null);

            return objToModify;
        }

        /// <summary>
        /// Returns the name of a property or field accessed in the given expression
        /// </summary>
        public static string GetPropertyName<TObject, TProperty>(this TObject objectWithProperty, Expression<Func<TObject, TProperty>> propertyExpression)
        {
            return GetMemberExpression(propertyExpression).Member.Name;
        }

        /// <summary>
        /// Returns the display name of a property or field accessed in the given expression
        /// </summary>
        public static string GetPropertyDisplayName<TObject, TProperty>(this TObject objectWithProperty, Expression<Func<TObject, TProperty>> propertyExpression)
        {
            var memberInfo = GetMemberExpression(propertyExpression).Member;

            var attribute = memberInfo.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

            return attribute == null ? memberInfo.Name : attribute.Name;
        }

        /// <summary>
        /// Returns the display name of a property or field accessed in the given expression
        /// </summary>
        public static string GetPropertyDisplayPrompt<TObject, TProperty>(this TObject objectWithProperty, Expression<Func<TObject, TProperty>> propertyExpression)
        {
            var memberInfo = GetMemberExpression(propertyExpression).Member;

            var attribute = memberInfo.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

            return attribute == null ? memberInfo.Name : attribute.Prompt;
        }

        /// <summary>
        /// Returns a member expression to be used for retrieving member information
        /// </summary>
        private static MemberExpression GetMemberExpression<TObject, TProperty>(Expression<Func<TObject, TProperty>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }

            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException(string.Format("Expression '{0}' does not refer to a property or field.", propertyExpression));
            }

            return memberExpression;
        }
    }
}
