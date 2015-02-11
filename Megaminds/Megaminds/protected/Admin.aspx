<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Megaminds.Admin" %>
<%@ Register TagPrefix = "myHead" TagName="header" src="../HeaderUserControl.ascx" %>
<%@ Register TagPrefix = "myFoot" TagName="footer" src="../FooterUserControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
</head>
<body>
    <form id="form1" runat="server">
        <myHead:header runat="server" />
        <div style="border-style: solid; height: 450px">
            <div style="margin-left: 20px;">
                <asp:Panel ID="accessed" runat="server" visible="false">
                    <br /><br />
                    <asp:Label ID="welcome" runat="server"></asp:Label>
                    <br /><br />
                    &nbsp;Username: <asp:TextBox ID="user" runat="server" style="margin-left: 60px" Width="250px" Text="newuser"></asp:TextBox>
                    <br /><br />
                    &nbsp;Password: <asp:TextBox ID="pass" runat="server" style="margin-left: 60px" Width="250px" TextMode="Password"></asp:TextBox>
                    <br /><br />
                    &nbsp;Confirm Password: <asp:TextBox ID="conPass" runat="server" style="margin-left: 5px" Width="250px" TextMode="Password"></asp:TextBox>
                    <br /><br />
                    &nbsp;<asp:Button ID="staff" runat="server" Text="Add Staff" OnClick="staff_Click"/>
                    &nbsp;<asp:Button ID="manager" runat="server" Text="Add Manager" OnClick="manager_Click"/>
                    <br /><br />
                    &nbsp;<asp:Label ID="loginMsg" runat="server"></asp:Label>

                    <br />

                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Manager.aspx">Go to the Manager Page</asp:HyperLink>
                    &nbsp;&nbsp;
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Staff.aspx">Go to the Staff Page</asp:HyperLink>
                    &nbsp;&nbsp;
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="../Default.aspx">Go to the application</asp:HyperLink>
                    <br />
                    <br />
                </asp:Panel>
             </div>
        <asp:Panel ID="denied" runat="server" visible="true">
            <br/>
            <center><asp:Image ID="Image1" runat="server" ImageUrl="../Image/Access-Denied.jpg" Height="400px"/></center>
        </asp:Panel>
        </div>
        <myFoot:footer runat="server" />
    </form>
</body>
</html>
