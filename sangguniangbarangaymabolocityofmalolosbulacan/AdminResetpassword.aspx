<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminResetpassword.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.AdminForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recovery Account</title>
    <!-- Meta tags -->
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<meta http-equiv="X-UA-Compatible" content="ie=edge">
	<!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="Index/img/Mabolo_Logo.png" type="image/x-icon" />
	 <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
	<!-- Style -->
	<link rel="stylesheet" href="Adminresetpassword/resetpassword/css/style.css" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
	<section class="w3l-login">
		<div class="overlay">
			<div class="wrapper">
				<div class="logo">
					<a class="brand-logo" href="index.aspx">Sangguniang Barangay Mabolo</a>
				</div>
				<div class="form-section">
					<h3>Forget Password</h3>
					<form action="#" method="post" class="signin-form">
						
						<div class="form-input">
							<asp:TextBox ID="txtnewpassword" placeholder="New Password" TextMode="Password" required="" runat="server"></asp:TextBox>
						</div>
						<div class="form-input">
							<asp:TextBox ID="txtconfirmpassword" placeholder="Confirm Password" TextMode="Password" required="" runat="server"></asp:TextBox>
						</div>
						<asp:Button ID="Bbtsubitresetpassword" OnClick="Bbtsubitresetpassword_Click" class="btn btn-primary theme-button mt-4" runat="server" Text="Reset" Width="144px" />
					</form>
					<p class="signup">Already have account yet? <a href="BarangayOfficalLogin.aspx" class="signuplink">Login</a></p>
				</div>
			</div>
		</div>
		<div id='stars'></div>
		<div id='stars2'></div>
		<div id='stars3'></div>

	</section>
       
    </form>
</body>
</html>
