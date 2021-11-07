using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Security;
using CGeers.Web.Security;

namespace CGeers.Web.UI.WebControls
{
    public class DynamicApplicationsLogin : Login
    {
        #region Fields

        private string _fullUserName;

        #endregion

        #region Properties

        private string ApplicationName
        {
            get
            {
                string[] data = base.UserName.Split(@"\".ToCharArray(), 2);
                string applicationName = (data.Length == 2) ? data[0] : String.Empty;
                return applicationName;
            }
        }

        private string BaseUserName
        {
            get
            {
                string[] data = base.UserName.Split(@"\".ToCharArray(), 2);
                string userName = (data.Length == 2) ? data[1] : base.UserName;
                return userName;
            }
        }        

        #endregion        

        protected override void OnAuthenticate(AuthenticateEventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (context == null)
            {
                throw new InvalidOperationException("Http context cannot be null.");
            }
            MembershipProvider provider = Membership.Provider;
            if (provider == null)
            {
                throw new InvalidOperationException("MembershipProvider cannot be null.");
            }
            provider = provider as DynamicApplicationsSqlMembershipProvider;
            if (provider == null)
            {
                throw new InvalidOperationException("The specified MembershipProvider must be of type DynamicApplicationsSqlMembershipProvider.");
            }

            // Store the application name in the current Http context's items collections
            context.Items["ApplicationName"] = ApplicationName;

            // Validate the user
            _fullUserName = UserName;
            UserName = BaseUserName;
            base.OnAuthenticate(e);
        }

        protected override void OnLoginError(EventArgs e)
        {
            UserName = _fullUserName;
            base.OnLoginError(e);
        }

        protected override void OnLoggedIn(EventArgs e)
        {
            UserName = _fullUserName;
            HttpContext context = HttpContext.Current;
            if (context == null)
            {
                throw new InvalidOperationException("Http context cannot be null.");
            }

            string userName = BaseUserName;
            MembershipUser user = Membership.GetUser(userName);
            if (user != null)
            {
                string userData = String.Format("AN={0};", ApplicationName);
                HttpCookie cookie = FormsAuthenticationHelper.StoreUserDataInAuthenticationCookie(userName, userData, RememberMeSet);

                // Manually add the cookie to the Cookies collection
                context.Response.Cookies.Add(cookie);
            }
        }
    }
}