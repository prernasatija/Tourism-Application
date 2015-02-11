<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Megaminds.Default" %>
<%@ Register TagPrefix = "myHead" TagName="header" src="HeaderUserControl.ascx" %>
<%@ Register TagPrefix = "myFoot" TagName="footer" src="FooterUserControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome!!</title>
</head>
<body>
    <form id="form1" runat="server">
        <myHead:header runat="server" />
    <div style="border-style: solid; min-height: 450px">
        <div style="margin-left: 20px;">
            <br />
            &quot;Travel with Megaminds&quot; is a travel guide application that provides its members information about any place entered by the user. The information about the city could be anything from weather and time zone to tourist attractions of the city and upcoming events.
            <br />
            This application is controlled by an admin who has access to all the pages. To use the services of this application, you must be a member and logged in.<br />
        <br />
        <asp:Label ID="current" runat="server"></asp:Label><br/><br />
        <asp:Button ID="logout" runat="server" Text="Logout" Visible="false" style="float: right;margin-right: 30px;" OnClick="logout_Click"/>
        <asp:Button ID="login" runat="server" Text="Login" Visible="true" OnClick="login_Click"/>&nbsp;
        <asp:Button ID="register" runat="server" Text="Register" Visible="true" OnClick="register_Click"/>

        <asp:Panel ID="mainpanel" runat="server">
            Place to Visit: <asp:TextBox ID="cityname" runat="server" Width="200px"></asp:TextBox><br />
            <hr />
            <asp:Button ID="news" runat="server" Text="NEWS and Weather" Width="200px" OnClick="news_Click"/>&nbsp;&nbsp;
            <asp:Button ID="events" runat="server" Text="Attractions and Events" Width="200px" OnClick="events_Click"/>&nbsp;&nbsp;
            <asp:Button ID="nearest" runat="server" Text="Yellow Pages" Width="200px" OnClick="nearest_Click"/>&nbsp;&nbsp;
            <asp:Button ID="cities" runat="server" Text="Nearby Cities" Width="200px" OnClick="cities_Click"/>&nbsp;&nbsp;
            <asp:Button ID="emergency" runat="server" Text="Emergency" Width="200px" OnClick="emergency_Click"/><br /><br /><br />
            <asp:Label ID="statusbuttonclick" runat="server" style="padding-left: 400px;"></asp:Label>
            
            <asp:Panel ID="newspanel" runat="server" >
                <asp:Label ID="timezone" runat="server"></asp:Label><br />
                <asp:Label ID="sunrise" runat="server"></asp:Label><br />
                <asp:Label ID="sunset" runat="server"></asp:Label>
                <asp:Label ID="statusnews" runat="server"></asp:Label><br /><br />
                <asp:Table ID="newstable" runat="server" BorderStyle="Solid" GridLines="Both"></asp:Table><br />
                <asp:Label ID="statusweather" runat="server"></asp:Label><br /><br />
                <asp:Table ID="weathertable" runat="server" BorderStyle="Solid" GridLines="Both"></asp:Table><br /><br /><br />
            </asp:Panel>

            <asp:Panel ID="eventspanel" runat="server">
                <asp:Label ID="statusattraction" runat="server"></asp:Label><br /><br />
                <asp:Table ID="attractionstable" runat="server" BorderStyle="Solid" GridLines="Both"></asp:Table><br />
                <asp:Label ID="statusevent" runat="server"></asp:Label><br /><br />
                <asp:Table ID="eventstable" runat="server" BorderStyle="Solid" GridLines="Both"></asp:Table><br /><br /><br />
            </asp:Panel>

            <asp:Panel ID="nearestpanel" runat="server">
                &nbsp;Store Type<asp:DropDownList ID="storeType"  style="margin-left: 10px" Width="150px" runat="server">
                    <asp:ListItem Value="food">Resturants</asp:ListItem>
                    <asp:ListItem Value="drinks">Bars</asp:ListItem>
                    <asp:ListItem Value="coffee">Coffee Shops</asp:ListItem>
                    <asp:ListItem Value="arts">Arts</asp:ListItem>
                    <asp:ListItem Value="outdoors">Outdoors</asp:ListItem>
                    <asp:ListItem Value="gas_station">Gas Station</asp:ListItem>
                    <asp:ListItem Value="train_station">Train Station</asp:ListItem>
                    <asp:ListItem Value="subway_station">Subway Station</asp:ListItem>
                    <asp:ListItem Value="beauty_salon">Beauty Salon</asp:ListItem>
                    <asp:ListItem Value="spa">Spa</asp:ListItem>
                    <asp:ListItem Value="hair_care">Hair Care</asp:ListItem>
                    <asp:ListItem Value="atm">ATM</asp:ListItem>
                    <asp:ListItem Value="bank">Bank</asp:ListItem>
                    <asp:ListItem Value="others">Others</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:TextBox ID="storeName" runat="server" Width="150px"></asp:TextBox>
                &nbsp;<asp:Button ID="searchButton" runat="server" Text="Search" Width="200px" OnClick="searchButton_Click"/>
                <br />
                <br />
                <asp:Label ID="searchResults" runat="server"></asp:Label>
                <asp:Table ID="bankatmtable" runat="server" BorderStyle="Solid" GridLines="Both"></asp:Table><br /><br /><br />
                <br />
                <br />
            </asp:Panel>

            <asp:Panel ID="citiespanel" runat="server">
                <asp:Label ID="citiesResults" runat="server"></asp:Label>
            </asp:Panel>

            <asp:Panel ID="emergencypanel" runat="server">
                &nbsp;Emergency Type<asp:DropDownList ID="emergencyType"  style="margin-left: 10px" Width="150px" runat="server">
                    <asp:ListItem Value="hospital">Hospital</asp:ListItem>
                    <asp:ListItem Value="pharmacy">Pharmacy</asp:ListItem>
                    <asp:ListItem Value="fire_station">Fire Station</asp:ListItem>
                    <asp:ListItem Value="doctor">Doctor</asp:ListItem>
                    <asp:ListItem Value="police">Police Station</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:Button ID="emergencyButton" runat="server" Text="Find Emergency Services" Width="200px" OnClick="emergencyButton_Click"/>
                <br />
                <br />
                <asp:Label ID="emergencyResults" runat="server"></asp:Label>
                <br />
                <br />
            </asp:Panel>


        </asp:Panel>
       </div>
    </div>
        <myFoot:footer runat="server" />
    </form>
</body>
</html>
