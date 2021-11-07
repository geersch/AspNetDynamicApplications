using System;
using System.Collections.Generic;
using System.Web.Security;

namespace CGeers.Web.Security
{
    internal static class FormsAuthenticationTicketExtensions
    {
        public static string GetApplicationName(this FormsAuthenticationTicket ticket)
        {
            // Check if the application name (AN=) is stored in the ticket's userdata.
            string applicationName = String.Empty;
            List<string> settings = new List<string>(ticket.UserData.Split(';'));
            foreach (string s in settings)
            {
                string setting = s.Trim();
                if (setting.StartsWith("AN="))
                {
                    int startIndex = setting.IndexOf("AN=") + 3;
                    applicationName = setting.Substring(startIndex);
                    break;
                }
            }
            return applicationName;
        }        
    }    
}
