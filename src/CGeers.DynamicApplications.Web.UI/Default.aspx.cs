using System;
using System.Web.UI;
using System.Web.Security;

namespace CGeers.DynamicApplications.Web.UI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblApplicationName.Text = Membership.ApplicationName;
        }
    }
}
