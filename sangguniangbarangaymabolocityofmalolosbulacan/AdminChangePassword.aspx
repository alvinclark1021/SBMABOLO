<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="AdminChangePassword.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.AdminChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
		<link href="ChangePasswordAdmin/css/style.css" rel='stylesheet' type='text/css' />
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
		<!--webfonts-->
	<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
		<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700,800' rel='stylesheet' type='text.css'/>
		<!--//webfonts-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
		<form>
    		<h1><span>Change Password</span><lable> </lable> </h1>
  			<div class="inset">
	  			<p>
					  <asp:TextBox ID="txtcurrentpassword" placeholder="Current Password" TextMode="Password" required="" runat="server"></asp:TextBox>
				</p>
				  <p>
					  <asp:TextBox ID="txtnewpassword" placeholder="New Password" TextMode="Password" required="" runat="server"></asp:TextBox>
				</p>
  				<p>
					  <asp:TextBox ID="txtconfirmpassword" placeholder="Confirm Password" required="" TextMode="Password" runat="server"></asp:TextBox>
				</p>
				  
 			 </div>
 	 
			  <p class="p-container">
				  <asp:Button ID="btnchangepassword" OnClick="btnchangepassword_Click" runat="server" Text="Change Password" />
			    
			  </p>
		</form>
	</div> 
</asp:Content>
