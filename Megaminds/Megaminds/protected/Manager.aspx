<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="Megaminds.protected.Manager" %>
<%@ Register TagPrefix = "myHead" TagName="header" src="../HeaderUserControl.ascx" %>
<%@ Register TagPrefix = "myFoot" TagName="footer" src="../FooterUserControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manager</title>
</head>
<body>
   <form id="form1" runat="server">
        <myHead:header runat="server" />
        <div style="border-style: solid; height: 450px">
            <div style="margin-left: 20px;">
                <asp:Panel ID="accessed" runat="server" visible="false">
                    <br /><br />
                    <asp:Label ID="welcome" runat="server"></asp:Label>
                    <div runat="server" id="mydiv"></div>
                    
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../Default.aspx">Go to the application</asp:HyperLink>
                    <br /><br />
                </asp:Panel>
                <asp:Panel ID="denied" runat="server" visible="true">
                    <br/>
                    <center><asp:Image ID="Image1" runat="server" ImageUrl="../Image/Access-Denied.jpg" Height="400px"/></center>
                </asp:Panel>
            </div>
        </div>
        <myFoot:footer runat="server" />
    </form>
</body>
</html>
