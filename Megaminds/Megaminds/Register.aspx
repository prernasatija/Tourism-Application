<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Megaminds.Register" %>
<%@ Register TagPrefix = "myHead" TagName="header" src="HeaderUserControl.ascx" %>
<%@ Register TagPrefix = "myFoot" TagName="footer" src="FooterUserControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <myHead:header runat="server" />
    <div style="border-style: solid; height: 450px">
        <div style="margin-left: 20px;">
            <br /><br />
            &nbsp;Username: <asp:TextBox ID="user" runat="server" style="margin-left: 60px" Width="250px" Text="newuser"></asp:TextBox>
            <br /><br />
            &nbsp;Password: <asp:TextBox ID="pass" runat="server" style="margin-left: 60px" Width="250px" ></asp:TextBox>
            <br /><br />
            &nbsp;Confirm Password: <asp:TextBox ID="conPass" runat="server" style="margin-left: 5px" Width="250px" ></asp:TextBox>
            <br /><br />
            &nbsp;<asp:Image ID="Image1" runat="server" /><br />
            Enter the text shown in the above image : 
            &nbsp;<asp:TextBox ID="imagetext" runat="server"></asp:TextBox><br /><br />
            &nbsp;<asp:Button ID="submit" runat="server" Text="Sign Up" OnClick="submit_Click"/>
            <br /><br />
            &nbsp;<asp:Label ID="loginMsg" runat="server"></asp:Label>
            <br /><br /><br />
       </div>
    </div>
        <myFoot:footer runat="server" />
    </form>
</body>
</html>
