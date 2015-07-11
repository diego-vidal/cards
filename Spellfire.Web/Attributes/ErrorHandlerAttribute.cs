using Spellfire.Common;
using System.Web.Mvc;

namespace Spellfire.Web.Attributes
{
    public class ErrorHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new JsonResult
            {
                Data = new { hasMessage = true, message = filterContext.Exception.GetFullMessage() },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}