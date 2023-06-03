<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminForgetPassword.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.AdminForgetPassword1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forget Password</title>
	<!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="Index/img/Mabolo_Logo.png" type="image/x-icon" />
    <!-- Meta tags -->
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<meta http-equiv="X-UA-Compatible" content="ie=edge">
	 <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
	<!-- Style -->
	<link rel="stylesheet" href="Adminresetpassword/forgetpassword/css/style.css" type="text/css" media="all" />

</head>
<body>
    <form id="form1" runat="server">
        	<section class="w3l-login">
		<div class="overlay">
			<div class="wrapper">
				<div class="logo">
				</div>
				<div class="form-section">
					<h3>Recovery Account</h3>
					<form action="#" method="post" class="signin-form">
						<div class="form-input">
						<asp:TextBox ID="txtrecoveryemail" placeholder="Email" onfocus="this.type='email'" oncopy="return false" oncut="return false" onpaste="return false" required="" runat="server"></asp:TextBox>
						</div>
						<br />
						<asp:Button ID="btnsendemail" OnClick="btnsendemail_Click"  class="btn btn-primary theme-button mt-4" runat="server" Text="Submit" />
						
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
