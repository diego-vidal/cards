using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
//using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

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

            // Autofac (IoC) registration
            var container = AutofacConfig.Register(GlobalConfiguration.Configuration);

            version = typeof(Global).Assembly.GetName().Version.ToString();
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