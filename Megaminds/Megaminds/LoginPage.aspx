<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Megaminds.LoginPage" %>
<%@ Register TagPrefix = "myHead" TagName="header" src="HeaderUserControl.ascx" %>
<%@ Register TagPrefix = "myFoot" TagName="footer" src="FooterUserControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <myHead:header runat="server" />
    <div style="border-style: solid; height: 450px">
        <div style="margin-left: 20px;">
            <br />Welcome to the login page!!!<br />
            <br />
            <br />
            &nbsp;Username: <asp:TextBox ID="user" runat="server" style="margin-left: 20px" Width="250px" Text="Megamind"></asp:TextBox>
            <br /><br />
            &nbsp;Password: <asp:TextBox ID="pass" runat="server" style="margin-left: 20px" Width="250px" ></asp:TextBox>
            <br /><br />
            &nbsp;<asp:Button ID="member" runat="server" Text="Member Login" OnClick="member_Click"/>
            &nbsp;<asp:Button ID="staff" runat="server" Text="Staff Login" OnClick="staff_Click"/>
            &nbsp;<asp:Button ID="manager" runat="server" Text="Manager Login" OnClick="manager_Click"/>
            &nbsp;<asp:Button ID="admin" runat="server" Text="Admin Login" OnClick="admin_Click"/>
            &nbsp;&nbsp;&nbsp;<asp:CheckBox ID="persistent" runat="server" Text="Remember me" />
            <br /><br />
            &nbsp;<asp:Label ID="loginMsg" runat="server"></asp:Label>
            <br /><br /><br />
        </div>
    </div>
        <myFoot:footer runat="server" />
    </form>
</body>
</html>
