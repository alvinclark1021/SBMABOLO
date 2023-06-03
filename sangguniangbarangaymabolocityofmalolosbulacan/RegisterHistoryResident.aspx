<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="RegisterHistoryResident.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.RegisterHistoryResident" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Record%20History/CSS/Recordhistory.css" rel="stylesheet" />
<style>
body {
width: 100%;
margin: 5px;
}

.table-condensed tr th {
border: 0px solid #6e7bd9;
color: white;
background-color: #6e7bd9;
}

.table-condensed, .table-condensed tr td {
border: 0px solid #000;
}

tr:nth-child(even) {
background: #f8f7ff
}

tr:nth-child(odd) {
background: #fff;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<h2>ASP.NET GridView CSS/Design using Bootstrap CSS</h2>

<br />
<br />
<asp:GridView runat="server" AutoGenerateColumns="False" ID="databaserecords"  CssClass="table table-condensed table-hover" Width="99%" CellPadding="4" ForeColor="#333333" GridLines="None" Height="244px" OnSelectedIndexChanged="datagrid1_SelectedIndexChanged" >
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
        <asp:BoundField DataField="Fullname" HeaderText="FullName" ReadOnly="True" SortExpression="Fullname" />
        <asp:BoundField DataField="ContactNumber" HeaderText="ContactNumber" ReadOnly="True" SortExpression="ContactNumber" />
        <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username" />
    </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <SortedAscendingCellStyle BackColor="#FDF5AC" />
    <SortedAscendingHeaderStyle BackColor="#4D0000" />
    <SortedDescendingCellStyle BackColor="#FCF6C0" />
    <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
</div>
</asp:Content>
