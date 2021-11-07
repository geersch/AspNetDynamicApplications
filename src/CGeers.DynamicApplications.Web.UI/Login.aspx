<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CGeers.DynamicApplications.Web.UI.Login" %>

<%@ Register assembly="CGeers.Web.UI.WebControls" namespace="CGeers.Web.UI.WebControls" tagprefix="cgwc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <cgwc:DynamicApplicationsLogin ID="DynamicApplicationsLogin1" runat="server">
        </cgwc:DynamicApplicationsLogin>    
        <br />
        <br />
        <asp:HyperLink ID="linkPasswordRecovery" runat="server" NavigateUrl="~/PasswordRecovery.aspx" Text="Forgot your password?" />
    </div>
    </form>
</body>
</html>
