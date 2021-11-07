<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CGeers.DynamicApplications.Web.UI._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LoginName ID="LoginName" runat="server" />
        <asp:LoginStatus ID="LoginStatus" runat="server" />   
        <asp:Label ID="lblApplicationName" runat="server" />
        <br /><br />
        <asp:HyperLink ID="linkChangePassword" runat="server" Text="Change password" NavigateUrl="~/ChangePassword.aspx" />
    </div>
    </form>
</body>
</html>
