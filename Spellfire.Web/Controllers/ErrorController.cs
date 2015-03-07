using System.Web.Mvc;

namespace Spellfire.Web.Controllers
{
    public class ErrorController : BaseController
    {
        // The 404 action handler
        // GET: /NotFound/
        public ActionResult NotFound()
        {
            //Robots scanning the URL will still get the 404
            Response.StatusCode = 404;

            //Without this, when remote users try to navigate to an invalid URL they 
            //will see the IIS 404 error page instead of your custom page since
            //IIS tries to hijack the 404 and show its own error page
            Response.TrySkipIisCustomErrors = true;

            return View();
        }
    }
}