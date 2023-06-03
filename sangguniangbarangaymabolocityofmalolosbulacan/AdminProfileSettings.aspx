<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="AdminProfileSettings.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.AdminProfileSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AdminImageProfile/js/jquery-1.11.0.min.js"></script>
	<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
<!-- Custom Theme files -->
<link href="AdminImageProfile/css/style.css" rel="stylesheet" type="text/css" media="all"/>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
<meta name="keywords" content="Signin Account Form Responsive, Login form web template, Sign up Web Templates, Flat Web Templates, Login signup Responsive web template, Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
<!--google fonts-->
<link href='//fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900' rel='stylesheet' type='text/css'>
<!--close effect -->
<script>$(document).ready(function (c) {
        $('.log-close').on('click', function (c) {
            $('.login-bottom').fadeOut('slow', function (c) {
                $('.login-bottom').remove();
            });
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<br />
	<br />
	<br />
	<br />
	<br />
	<br />
	<br />
    <h1>Profile</h1>
	<div class="login">
	 <div class="rib"> </div>
		<h2>Barangay Offical Information</h2>
		<div>
			<asp:TextBox ID="txtfullname" placeholder="Fullname" runat="server" required=""></asp:TextBox>
			<br />
			<asp:TextBox ID="txtemail" placeholder="Email" runat="server" required="" ReadOnly="True"></asp:TextBox>
			<br />
			<asp:TextBox ID="txtposition" placeholder="Barangay Position" runat="server" required="" ReadOnly="True"></asp:TextBox>
			<br />
			
			<asp:TextBox ID="txtmobilenumber" placeholder="Mobile Number" required="" runat="server" ReadOnly="True" ></asp:TextBox>
			<br />
			<asp:TextBox ID="txtbirthday" placeholder="Birthady" Width="93%" Height="33px" TextMode="Date" runat="server" required=""></asp:TextBox>
			<br />
			<br />
			<asp:DropDownList ID="DropDownList1" Width="92%" Height="30px" runat="server">
                <asp:ListItem>Select Gender</asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
			<br />
			<asp:TextBox ID="txtaddress" placeholder="Address" runat="server" required=""></asp:TextBox>

        </div>
		
        <div class="remember">
			
			<div class="send">
				<asp:Button ID="btnupdateinformation" OnClick="btnupdateinformation_Click" runat="server" Text="Update" Width="182px" />
				
			</div>
			<br />
			<div class="send">
				<br />
				<asp:Button ID="Bntcancel" OnClick="Bntcancel_Click"  runat="server" Text="Cancel" Width="182px" />
				
			</div>
		  <div class="clear"> </div>
	</div>
</div>	
</asp:Content>
