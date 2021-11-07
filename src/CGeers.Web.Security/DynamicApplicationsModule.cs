using System;
using System.Web;
using System.Web.Security;

namespace CGeers.Web.Security
{
    public class DynamicApplicationsModule : IHttpModule 
    {
        #region Fields

        private const string ApplicationNameSetting = "ApplicationName";

        #endregion

        #region IHttpModule Members

        public void Dispose()
        { }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += DetermineApplicationName;
        }        

        #endregion

        private static void DetermineApplicationName(object sender, EventArgs e)
        {
            // Access the current Http application.
            HttpApplication application = sender as HttpApplication;
            if (application == null)
            {
                throw new InvalidOperationException("Http application cannot be null.");
            }

            // Get the HttpContext for the current request.
            HttpContext context = application.Context;
            if (context == null)
            {
                throw new InvalidOperationException("Http context cannot be null.");
            }

            // Read the application name stored in the FormsAuthenticationTicket
            string applicationName = String.Empty;
            if (context.Request.IsAuthenticated)
            {
                FormsIdentity identity = context.User.Identity as FormsIdentity;
                if (identity != null)
                {
                    FormsAuthenticationTicket ticket = identity.Ticket;
                    if (ticket != null)
                    {
                        applicationName = ticket.GetApplicationName();
                    }
                }
            }

            // Store the application name in the Items collection of the per-request http context.
            // Storing it in the session state is not an option as the session is not available at this
            // time. It is only available when the Http application triggers the AcquireRequestState event.
            context.Items[ApplicationNameSetting] = applicationName;
        }
    }
}
