using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using CGeers.Web.Security;

namespace CGeers.Web.UI.WebControls
{
    public class DynamicApplicationsPasswordRecovery : PasswordRecovery
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

        // The OnVerifyingUser method is called after the user submits a user name 
        // on the initial screen and before the user name is validated by the 
        // membership provider. The default implementation raises the VerifyingUser event.
        protected override void OnVerifyingUser(LoginCancelEventArgs e)
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

            _fullUserName = UserName;
            UserName = BaseUserName;

            base.OnVerifyingUser(e);
        }

        protected override void OnUserLookupError(EventArgs e)
        {
            UserName = _fullUserName;
            base.OnUserLookupError(e);
        }
    }
}
