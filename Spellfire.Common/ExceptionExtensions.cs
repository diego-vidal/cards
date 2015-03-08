using System;
using System.Text;

namespace Spellfire.Common
{
    public static class ExceptionExtensions
    {
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

        public static string GetFullStack(this Exception ex)
        {
            StringBuilder sb = new StringBuilder(ex.StackTrace);

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                sb.Append(ex.StackTrace);
            }

            return sb.ToString();
        }
    }
}
