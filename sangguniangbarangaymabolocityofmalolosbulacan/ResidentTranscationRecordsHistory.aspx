<%@ Page Title="" Language="C#" MasterPageFile="~/ResidentDashboard.Master" AutoEventWireup="true" CodeBehind="ResidentTranscationRecordsHistory.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.ResidentTranscationRecordsHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
.mydatagrid {
width: auto;
border: solid 2px black;
min-width: 80%;
}

.header {
background-color: #646464;
font-family: Arial;
color: White;
border: none 0px transparent;
height: 25px;
text-align: left;
font-size: 16px;
}

.rows {
background-color: #fff;
font-family: Arial;
font-size: 14px;
color: #000;
min-height: 25px;
text-align: left;
border: none 0px transparent;
}

.rows:hover {
background-color: #ff8000;
font-family: Arial;
color: #fff;
text-align: left;
}

.selectedrow {
background-color: #ff8000;
font-family: Arial;
color: #fff;
font-weight: bold;
text-align: left;
}

.mydatagrid a /** FOR THE PAGING ICONS **/ {
background-color: Transparent;
padding: 5px 5px 5px 5px;
color: #fff;
text-decoration: none;
font-weight: bold;
}

.mydatagrid a:hover /** FOR THE PAGING ICONS HOVER STYLES**/ {
background-color: #000;
color: #fff;
}

.mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
background-color: #c9c9c9;
color: #000;
padding: 5px 5px 5px 5px;
}

.pager {
background-color: #646464;
font-family: Arial;
color: White;
height: 30px;
text-align: left;
}

.mydatagrid td {
padding: 5px;
}

.mydatagrid th {
padding: 5px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wrapper">
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            <div class="navbar-header">
            <asp:Label ID="lblsessionlogin" runat="server" Text="Label" ForeColor="#033C73"></asp:Label>
                <a class="navbar-brand" href="ResidentDashboard.aspx">Barangay Mabolo</a>
            </div>
            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav side-nav">
                    <li class="active"><a href="ResidentDashboard.aspx"><i class="fa fa-bullseye"></i> Dashboard</a></li>
                    <li><a href="BarangayClearance.aspx"><i class="fa fa-file-text-o"></i> Barangay Clearance</a></li>
                    <li><a href="BarangayBusinessClearance.aspx"><i class="fa fa-file-text-o"></i> Barangay Business Clearance</a></li>
                    <li><a href="Barangayoccupanypermit.aspx"><i class="fa fa-file-text-o"></i> Barangay Ocupancy Permit</a></li>
                    <li><a href="BarangayRequestDocuments.aspx"><i class="fa fa-file-text-o"></i> Certification of Good Moral</a></li>
                    <li><a href="Cerficationofresidency.aspx"><i class="fa fa-file-text-o"></i> Certification of Residency</a></li>
                    <li><a href="Certificationofindigency.aspx"><i class="fa fa-file-text-o"></i> Certification of Indigency</a></li>
                    <li><a href="ExcavationCuttingPermit.aspx"><i class="fa fa-file-text-o"></i> Certification of Excavation / Cutting Permit</a></li>
                    <li><a href="permittoconstruct.aspx"><i class="fa fa-file-text-o"></i> Certification Permit to Construct</a></li>
                    <li><a href="ResidentTranscationRecordsHistory.aspx"><i class="fa-history"></i>  Transcation History</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right navbar-user">
                    
                     <li class="dropdown user-dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"><asp:Label ID="lblfullname" runat="server" Text=" fullname"></asp:Label></i><b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><asp:LinkButton ID="Linkchangepasswprd" OnClick="Linkchangepasswprd_Click" class="fa fa-lock" runat="server"> Change Password</asp:LinkButton></li>
                            <li><asp:LinkButton ID="linkprofile" OnClick="linkprofile_Click" class="fa fa-user" runat="server"> Profile</asp:LinkButton></li>
                            <li class="divider"></li>
                             <li><asp:LinkButton ID="Linklogout" OnClick="Linklogout_Click" class="fa fa-power-off" OnClientClick="return confirm('Are you sure you want to log out?')" runat="server"> Logout</asp:LinkButton></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>

       
    </div>
     
    <br />
<br />
<asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
RowStyle-CssClass="rows" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging" />
</asp:Content>
