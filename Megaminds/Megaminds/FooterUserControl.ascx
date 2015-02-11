<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterUserControl.ascx.cs" Inherits="Megaminds.FooterUserControl" %>
<div id ="myFoot" style="background-color:black; color: #FFFFFF;"><center>
    <asp:Label ID="powered" runat="server" Text="Powered by Megaminds" ></asp:Label> <br />
    <asp:Label ID="course" runat="server" Text="CSE-445/598 Distributed Software Development" ></asp:Label> <br />
    <asp:Label ID="semester" runat="server" Text="semester" ></asp:Label>
    <asp:Label ID="year" runat="server" Text="year" ></asp:Label>
    <br />
    <asp:Image ID="Image1" runat="server" ImageUrl="http://upload.wikimedia.org/wikipedia/en/2/21/Arizona_State_Sun_Devils_trident_logo.png" Height="60px" />
    </center></div>