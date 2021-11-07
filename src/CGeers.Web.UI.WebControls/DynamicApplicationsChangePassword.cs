using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using CGeers.Web.Security;

namespace CGeers.Web.UI.WebControls
{
    public class DynamicApplicationsChangePassword : ChangePassword
    {
        protected override void OnChangedPassword(EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (context == null)
            {
                throw new InvalidOperationException("Http context cannot be null.");
            }

            string applicationName = Membership.ApplicationName;

            base.OnChangedPassword(e);

            string userData = String.Format("AN={0};", applicationName);
            HttpCookie cookie = FormsAuthenticationHelper.StoreUserDataInAuthenticationCookie(UserName, userData, true);
            context.Response.Cookies.Add(cookie);
        }
    }
}
