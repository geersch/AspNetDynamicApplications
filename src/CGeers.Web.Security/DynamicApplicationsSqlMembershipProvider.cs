using System;
using System.Web;
using System.Web.Security;

namespace CGeers.Web.Security
{
    public class DynamicApplicationsSqlMembershipProvider : SqlMembershipProvider
    {
        #region Fields

        private const string ApplicationNameSetting = "ApplicationName";

        #endregion

        public override string ApplicationName
        {
            get
            {                
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    throw new InvalidOperationException("Http context cannot be null.");
                }

                string applicationName = String.Empty;
                if (context.Items.Contains(ApplicationNameSetting))
                {
                    if (!String.IsNullOrEmpty((string)context.Items[ApplicationNameSetting]))
                    {
                        applicationName = (string)context.Items[ApplicationNameSetting];
                    }
                }                
                return applicationName;
            }
            set
            {
                base.ApplicationName = value;
            }
        }
    }
}
