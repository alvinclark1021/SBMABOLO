<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.ResetPassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="ks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset Password</title>
    <!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="img/Mabolo_Logo.png" type="image/x-icon" />
		
    <link href="Forgetpassword/Resetpassword/CSScreateaccount/font-awesome.css" rel="stylesheet" />
	<add tagPrefix="cc1" assembly="AjaxControlToolkit" namespace="AjaxControlToolkit"/>
    <link href="Forgetpassword/Resetpassword/CSScreateaccount/style.css" rel="stylesheet" />
	<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

      <!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="Index/img/Mabolo_Logo.png" type="image/x-icon" />
    <!-- Meta tags -->
		<meta charset="UTF-8"/>
		<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
		<meta http-equiv="X-UA-Compatible" content="ie=edge"/>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" />
     <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>

	<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
		<!-- //Meta tags -->
    <link rel="stylesheet" href="SignUpAccount/css/style.css" type="text/css" media="all" /><!-- Style-CSS -->
    <link href="SignUpAccount/css/font-awesome.css" rel="stylesheet"/> <!-- font-awesome-icons -->
    <style type="text/css">
.VeryWeekStrength
{
background: Red;
color:White;
}
.WeakStrength
{
background:orange;
color:White;
}
.AverageStrength
{
background: Gray ;
color:White;
}
.GoodStrength
{
background: blue;
color:White;
}
.ExcellentStrength
{
background: Green;
color:White;
}
.BarBorderStyle
{
padding: 2px;
border-style:solid ;
border-color:Gray;
border-width: 1px;
width: 150px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
		 <asp:ScriptManager ID="Scrip" runat="server"></asp:ScriptManager>
        <asp:Panel ID="panaelhideandshow" runat="server">
     <section class="w3l-form-36">
         <asp:Label ID="lbldate" Visible="false" runat="server" Text="Label"></asp:Label>
		<div class="form-36-mian section-gap">
			<div class="wrapper">
				<div class="form-inner-cont">
					<h3>Reset Password</h3>
					<form action="#" method="post" class="signin-form">
                        <h5>New Password</h5>
                            <div class="form-input">
                                <span class="fa fa-key" aria-hidden="true"></span>
                                <div class="password-container">
                                    <asp:TextBox ID="txtpassword" placeholder="Password" runat="server" oncopy="return false" oncut="return false" onpaste="return false" required="" minlength="6" pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$" title="Please include at least 1 uppercase character, 1 lowercase character, and 1 number." Width="100%" Height="43px" TextMode="Password" />
                                    <span class="show-hide" onclick="showHidePassword(this)"><i class="fa fa-eye"></i></span>
                                </div>
                            </div>

                            <style>
                            	.form-input {
                            		position: relative;
                            	}

                            	.password-container {
                            		position: relative;
                            		display: inline-block;
                            		width: 100%;
                            	}

                            		.password-container input[type="password"] {
                            			padding-right: 30px;
                            		}

                            		.password-container .show-hide {
                            			position: absolute;
                            			top: 50%;
                            			right: 10px;
                            			transform: translateY(-50%);
                            			cursor: pointer;
                            			font-size: 16px;
                            		}
                            </style>

                            <script>
                                function showHidePassword(target) {
                                    var input = target.parentNode.querySelector('input');
                                    if (input.type === 'password') {
                                        input.type = 'text';
                                        target.innerHTML = '<i class="fa fa-eye-slash"></i>';
                                    } else {
                                        input.type = 'password';
                                        target.innerHTML = '<i class="fa fa-eye"></i>';
                                    }
                                }
                            </script>
						<asp:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="txtpassword" DisplayPosition="BelowLeft" StrengthIndicatorType="Text" PreferredPasswordLength="6" PrefixText="Password Strength: " TextCssClass="TextIndicator_TextBox1" MinimumNumericCharacters="1" MinimumSymbolCharacters="1" MinimumLowerCaseCharacters="1" MinimumUpperCaseCharacters="1"  RequiresUpperAndLowerCaseCharacters="true" TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent" StrengthStyles="VeryWeekStrength;WeakStrength;AverageStrength;GoodStrength;ExcellentStrength" CalculationWeightings="50;15;15;20" HelpStatusLabelID="lblStatus" HelpHandlePosition="BelowRight"></asp:PasswordStrength>

                        <br />
							<h5>Confirm Password</h5>
						<div class="form-input">
                                <span class="fa fa-key" aria-hidden="true"></span>
                                <div class="password-container">
                                    <asp:TextBox ID="txtconfirmationpassword" placeholder="Password" runat="server" oncopy="return false" oncut="return false" onpaste="return false" required="" minlength="6" pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$" title="Please include at least 1 uppercase character, 1 lowercase character, and 1 number." Width="100%" Height="43px" TextMode="Password" />
                                    <span class="show-hide" onclick="showHidePassword(this)"><i class="fa fa-eye"></i></span>
                                </div>
                            </div>

                            <style>
                            	.form-input {
                            		position: relative;
                            	}

                            	.password-container {
                            		position: relative;
                            		display: inline-block;
                            		width: 100%;
                            	}

                            		.password-container input[type="password"] {
                            			padding-right: 30px;
                            		}

                            		.password-container .show-hide {
                            			position: absolute;
                            			top: 50%;
                            			right: 10px;
                            			transform: translateY(-50%);
                            			cursor: pointer;
                            			font-size: 16px;
                            		}
                            </style>

                            <script>
                                function showHidePassword(target) {
                                    var input = target.parentNode.querySelector('input');
                                    if (input.type === 'password') {
                                        input.type = 'text';
                                        target.innerHTML = '<i class="fa fa-eye-slash"></i>';
                                    } else {
                                        input.type = 'password';
                                        target.innerHTML = '<i class="fa fa-eye"></i>';
                                    }
                                }
                            </script>
						<asp:PasswordStrength ID="PasswordStrength2" runat="server" TargetControlID="txtconfirmationpassword" DisplayPosition="BelowLeft" StrengthIndicatorType="Text" PreferredPasswordLength="6" PrefixText="Password Strength: " TextCssClass="TextIndicator_TextBox1" MinimumNumericCharacters="1" MinimumSymbolCharacters="1" MinimumLowerCaseCharacters="1" MinimumUpperCaseCharacters="1"  RequiresUpperAndLowerCaseCharacters="true" TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent" StrengthStyles="VeryWeekStrength;WeakStrength;AverageStrength;GoodStrength;ExcellentStrength" CalculationWeightings="50;15;15;20" HelpStatusLabelID="lblStatus" HelpHandlePosition="BelowRight"></asp:PasswordStrength>
						<br />
							<asp:Button ID="btnresetpassword" OnClick="btnresetpassword_Click" OnClientClick="return confirm('Do you want to reset your password?')" Text="Reset" class="btn theme-button" runat="server" />
						 <p class="signup"> Already a Account?<a><asp:LinkButton ID="linklogin" OnClick="linklogin_Click" runat="server">
                        <asp:Label ID="lbllogin" runat="server">Login Account</asp:Label></asp:LinkButton></a></p>
                            </div>
					</form>
			</div>
		</div>
	</section>
        </asp:Panel>

    </form>
</body>
</html>
