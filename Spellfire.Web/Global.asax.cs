using Spellfire.Logging;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Spellfire.Web
{
    //// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    //// visit http://go.microsoft.com/?LinkId=9394801

    public class Global : HttpApplication
    {
        private static string version;

        /// <summary>
        /// The current version of the application
        /// </summary>
        public static string Version
        {
            get { return version; }
        }

        #region Application Event Handlers

        /// <summary>
        /// Handler that runs when the application is initialized
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // Autofac (IoC) registration
            var container = AutofacConfig.Register(GlobalConfiguration.Configuration);

            version = typeof(Global).Assembly.GetName().Version.ToString();
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

            // Get the exception object.
            Exception ex = Server.GetLastError();

            // Handle HTTP errors
            if (ex.GetType() == typeof(HttpException))
            {
                // The Complete Error Handling Example generates
                // some errors using URLs with "NoCatch" in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.
                if (ex.Message.Contains("NoCatch") || ex.Message.Contains("maxUrlLength"))
                    return;

                //Redirect HTTP errors to HttpError page
                Server.Transfer("HttpErrorPage.aspx");
            }

            string username = HttpContext.Current.User.Identity.Name; 
            // Log the exception and notify system operators
            Logger.Write(username, ex);
            // TODO: Email erros

            // For other kinds of errors give the user some information
            // but stay on the default page
            Response.Write("<div class=\"alert alert-danger\">Error: " + ex.Message + "</div>");

            // Clear the error from the server
            Server.ClearError();
        }

        /// <summary>
        /// Handler that runs at the beginning of each request
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">event arguments</param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (string.Equals(Request.HttpMethod, "POST", StringComparison.CurrentCultureIgnoreCase))
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
            }

            // Suppress forms auth redirect for AJAX requests
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                Response.SuppressFormsAuthenticationRedirect = true;
            }
        }

        #endregion
    }
}