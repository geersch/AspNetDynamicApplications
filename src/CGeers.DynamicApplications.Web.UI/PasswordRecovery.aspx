<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="CGeers.DynamicApplications.Web.UI.PasswordRecovery" %>

<%@ Register assembly="CGeers.Web.UI.WebControls" namespace="CGeers.Web.UI.WebControls" tagprefix="cgwc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cgwc:DynamicApplicationsPasswordRecovery ID="DynamicApplicationsPasswordRecovery1" runat="server">
        </cgwc:DynamicApplicationsPasswordRecovery>
        <br />
        <br />
        <asp:HyperLink ID="linkPasswordRecovery" runat="server" NavigateUrl="~/Login.aspx" Text="Login" />    
    </div>
    </form>
</body>
</html>
