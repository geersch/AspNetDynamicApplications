using System;
using System.Web;
using System.Web.Security;

namespace CGeers.Web.Security
{
    public static class FormsAuthenticationHelper
    {
        public static HttpCookie StoreUserDataInAuthenticationCookie(string userName, string userData, bool persistent)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new InvalidOperationException("UserName cannot be null or empty.");
            }
            if (String.IsNullOrEmpty(userData))
            {
                throw new InvalidOperationException("User data cannot be null or empty.");
            }

            // Create the cookie that contains the forms authentication ticket
            HttpCookie cookie = FormsAuthentication.GetAuthCookie(userName, persistent);

            // Get the FormsAuthenticationTicket out of the encrypted cookie
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

            // Create a new FormsAuthenticationTicket that includes our custom user data
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version,
                                                                                ticket.Name,
                                                                                ticket.IssueDate,
                                                                                ticket.Expiration,
                                                                                persistent,
                                                                                userData);

            // Update the cookie's value to use the encrypted version of our new ticket
            cookie.Value = FormsAuthentication.Encrypt(newTicket);

            // Return the cookie
            return cookie;
        }
    }
}
