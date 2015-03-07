using System;
using System.Text;

namespace Spellfire.Common
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Gets the display name for an enum value. If it has none then it returns .ToString()
        /// </summary>
        public static string GetFullMessage(this Exception ex, string separator = " ")
        {
            var sb = new StringBuilder(ex.Message);

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                sb.Append(separator).Append(ex.Message);
            }

            return sb.ToString();
        }
    }
}
