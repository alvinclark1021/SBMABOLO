<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpAccount.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.SignUpAccount" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="ks" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <titleSign Up</title>
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
	<add tagPrefix="cc1" assembly="AjaxControlToolkit" namespace="AjaxControlToolkit"/>
	
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
    <link href="SignUpAccount/css/password.css" rel="stylesheet" type="text/css"/>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Scrip" runat="server"></asp:ScriptManager>
            <section class="w3l-form-36">
		<div class="form-36-mian section-gap">
			<div class="wrapper">
				<div class="form-inner-cont">
					<h3>Create Account</h3>
					<form action="#" method="post" class="signin-form">
                        <!--Email confirm to registed-->
                        <asp:Label ID="lblactivity" runat="server" ForeColor="White" Visible="false"  Text="Register Resident"></asp:Label>
                        <div id="divemailalreadyexistingornot" runat="server">
							<br />
                       <h5>Email Address</h5>
							
					   <div class="form-input">
							<span class="fa fa-envelope" aria-hidden="true"></span> <asp:TextBox ID="txtemail" placeholder="Email Address" runat="server" onfocus="this.type='email'" oncopy="return false" oncut="return false" onpaste="return false" required="" Height="44px" Width="288px"/>
						 </div>
							<br />
							<asp:RegularExpressionValidator ID="validategamilonly" ValidationExpression="\w+([-+.']\w+)*@(?:gmail).com" runat="server" ErrorMessage="Please input your gmail account. " ControlToValidate="txtemail" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
							<br />
							<br />
							<asp:Button ID="btnemail" OnClick="btnemail_Click" Text="Submit" class="btn theme-button" runat="server" />
							<br />
							<br />
							<h6>Republic Act No. 10173, also known as the Data Privacy Act of 2012 (DPA), aims to protect personal data in information and communications systems both in the government and the private sector. The DPA created the National Privacy Commission (NPC) which is tasked to monitor its implementation. It covers the processing of personal information and sensitive personal information and sets, as its basic premise, the grant of direct consent by a data subject before data processing of personal information be allowed.</h6>
							
                            <p class="signup">Already have an account? <a href="Login.aspx" class="signuplink">Login</a></p>
						</div>
                         <!--Email Confirmation Code-->
						<div id="divconfirmcodesemail" visible="false" runat="server">
							<h5>Please check your email to <asp:Label ID="lblresendemail" runat="server" Text="Email "></asp:Label> for Verification Code</h5>
							<br />
							<h5>Verification code</h5>
							<br />
							<br />
						<div class="form-input">
							<span class="fa fa-envelope" aria-hidden="true"></span> <asp:TextBox ID="txtactivationcode" placeholder="Verification Code" runat="server" oncopy="return false" oncut="return false" Width="100%" Height="43px" ValidationGroup="required"/>
						</div>
							<br />
							<br />
							<asp:Button ID="btnconfirmationcodeemail" OnClick="btnconfirmationcodeemail_Click"  Text="Confirm" class="btn theme-button" runat="server" />
							<br />
							<br />
							<asp:Button ID="Btnresendemail" OnClick="Btnresendemail_Click"  Text="Resend Email" class="btn theme-button" runat="server" Height="49px" Width="118px" />
							<br />
							<p class="signup"><asp:LinkButton ID="linkmeback" OnClick="linkmeback_Click" class="signuplink" Text="Back" Font-Size="Medium" runat="server"></asp:LinkButton></p>
							<br />
						    <p class="signup">Already have an account? <a href="Login.aspx" class="signuplink"> Login</a></p>
						</div>

						
                         <!--Resident Information Registed-->
						<div id="divregisterusers" visible="false" runat="server" >
							<asp:Label ID="lblactivitys" runat="server" ForeColor="White" Visible="false"  Text="Create Account but pending your registation"></asp:Label>
						<asp:Label ID="lbldate" runat="server" ForeColor="White" Visible="false"  Text="Label"></asp:Label>
							<br />
							<h5>Registration No</h5>
						<div class="form-input">
							<span class="fa fa-user-o" aria-hidden="true"></span> <asp:Label ID="lblregistationno" runat="server" Text="RegistrationNO" Font-Bold="True" Font-Size="X-Large"></asp:Label>
						</div>
							<br />
							<h5>Please keep your assigned Registration No: example "(Mabolo040102022-0)"</h5>
							<br />
							<h5>Fullname</h5>
						<div class="form-input">
							<span class="fa fa-user-o" aria-hidden="true"></span> <asp:TextBox ID="txtfullname" placeholder="Full Name" runat="server" oncopy="return false" oncut="return false" onpaste="return false" Width="100%" Height="43px" required="" />
						</div>
                            
							<br />
							<h5>Birthday</h5>
						<div class="form-input">
						 <span class="fa fa-birthday-cake" aria-hidden="true"></span><asp:TextBox ID="txtbirthday"  onkeydown="return false;" runat="server" onchange="DateSelectionChanged()" Width="100%" Height="43px" placeholder="Birthday" required=""/>
							 <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbirthday"></asp:CalendarExtender>
						</div>
                            <script type="text/javascript">
                                function DateSelectionChanged(sender, args) {
                                    var txtBirthday = document.getElementById('<%= txtbirthday.ClientID %>');
                                    txtBirthday.value = args._selectedDate.format("MM/dd/yyyy");
                                    txtBirthday.setAttribute("readonly", "readonly");
                                    var calendar = $find('<%= CalendarExtender1.ClientID %>');
                                    calendar.hide();
                                }
                            </script>
							<br />
					 
							<h5>Address</h5>
							<h5>House Number, Street, Purok</h5>
                            <div class="form-input">
							<span class="fa fa-home" aria-hidden="true"></span> <asp:TextBox ID="txtaddress" placeholder="Address" runat="server" oncopy="return false" oncut="return false" onpaste="return false" Width="100%" Height="43px" required=""/>
						</div>
							<br />
							<h5>Barangay, Municipality/City, Province</h5>
							 <div class="form-input">
							<span class="fa fa-home" aria-hidden="true"></span> <asp:TextBox ID="txtdefaultaddress" ReadOnly="true" Text="Mabolo, Malolos City Bulacan" runat="server" oncopy="return false" oncut="return false" onpaste="return false" Width="100%" Height="43px" required=""/>
						</div>
							<br />
							<h5>Sex</h5>
							<div class="form-input">
								<span class="fa fa-transgender-alt" aria-hidden="true"></span><asp:DropDownList ID="Selectedmaleorfemale" Width="100%" Height="43px" runat="server">
                                    <asp:ListItem>Select Sex</asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                         </asp:DropDownList>
							</div>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Gender" ControlToValidate="Selectedmaleorfemale" ForeColor="Red" InitialValue="Select Gender"></asp:RequiredFieldValidator>
							<br />
							<br />
							<h5>Mobile Number</h5>
							<div class="form-input">
							<span class="fa fa-phone-square" aria-hidden="true"></span><asp:TextBox ID="txtmobilenumber" placeholder="09XXXXXXXXX" runat="server" MaxLength="11" onkeypress="return this.value.length<=11" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');" pattern="[0-9]{11}" Width="100%" Height="43px" oncopy="return false" oncut="return false" onpaste="return false" required=""/>
						</div>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please input your mobile number" ControlToValidate="txtmobilenumber" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^(09|\+639)\d{9}$"></asp:RegularExpressionValidator>
							<br />
							<h5>Username</h5>
						<div class="form-input">
							<span class="fa fa-user-o" aria-hidden="true"></span> <asp:TextBox ID="txtusername" placeholder="Username" required minlength="5" runat="server" oncopy="return false" oncut="return false" onpaste="return false" Width="100%" Height="43px"/>
						</div>
							<br />
							<h5>Password</h5>
                            <div class="form-input">
                                <span class="fa fa-key" aria-hidden="true"></span>
                                <div class="password-container">
                                    <asp:TextBox ID="txtpassword" placeholder="Password" runat="server" oncopy="return false" oncut="return false" onpaste="return false" required="" minlength="6" pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$" title="Please include at least 1 uppercase character, 1 lowercase character, and 1 number." Width="100%" Height="43px" TextMode="Password" />
                                    <span class="show-hide" onclick="showHidePassword(this)"><i class="fa fa-eye"></i></span>
                                </div>
                            </div>
							<asp:PasswordStrength ID="PasswordStrength2" runat="server" TargetControlID="txtpassword" DisplayPosition="BelowLeft" StrengthIndicatorType="Text" PreferredPasswordLength="6" PrefixText="Password Strength: " TextCssClass="TextIndicator_TextBox1" MinimumNumericCharacters="1" MinimumSymbolCharacters="1" MinimumLowerCaseCharacters="1" MinimumUpperCaseCharacters="1"  RequiresUpperAndLowerCaseCharacters="true" TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent" StrengthStyles="VeryWeekStrength;WeakStrength;AverageStrength;GoodStrength;ExcellentStrength" CalculationWeightings="50;15;15;20" HelpStatusLabelID="lblStatus" HelpHandlePosition="BelowRight"> </asp:PasswordStrength>

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
							<br />
							<h5>Confirm Password</h5>
						<div class="form-input">
                                <span class="fa fa-key" aria-hidden="true"></span>
                                <div class="password-container">
                                    <asp:TextBox ID="txtconfirmpassword" placeholder="Password" runat="server" oncopy="return false" oncut="return false" onpaste="return false" required="" minlength="6" pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$" title="Please include at least 1 uppercase character, 1 lowercase character, and 1 number." Width="100%" Height="43px" TextMode="Password" />
                                    <span class="show-hide" onclick="showHidePassword(this)"><i class="fa fa-eye"></i></span>
                                </div>
                            </div>

                            <style>
                            	.form-input {
                            		position: relative;
                                    top: -19px;
                                    left: 0px;
                                    height: 49px;
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
						<asp:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="txtconfirmpassword" DisplayPosition="BelowLeft" StrengthIndicatorType="Text" PreferredPasswordLength="6" PrefixText="Password Strength: " TextCssClass="TextIndicator_TextBox1" MinimumNumericCharacters="1" MinimumSymbolCharacters="1" MinimumLowerCaseCharacters="1" MinimumUpperCaseCharacters="1"  RequiresUpperAndLowerCaseCharacters="true" TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent" StrengthStyles="VeryWeekStrength;WeakStrength;AverageStrength;GoodStrength;ExcellentStrength" CalculationWeightings="50;15;15;20" HelpStatusLabelID="lblStatus" HelpHandlePosition="BelowRight"> </asp:PasswordStrength>
							<br />
							
				         <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password and C-Password Mismatch" ControlToCompare="txtpassword" ControlToValidate="txtconfirmpassword"></asp:CompareValidator>
							<br />
							
							
							<h4>Valid Id</h4>
							<br />
							
							<h5>Make sure that the ID picture you attached here is clear and readable to present Address and your Information.</h5>
							<div class="form-input">
                               <span class="fa fa-id-card-o" aria-hidden="true"></span><asp:DropDownList ID="DropDownList1" runat="server" class="form-input" Width="100%" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    <asp:ListItem Text="Select an option" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="National Id" Value="NationalId"></asp:ListItem>
                                    <asp:ListItem Text="Driver License" Value="DriverLicense"></asp:ListItem>
								    <asp:ListItem Text="Passport" Value="Passport"></asp:ListItem>
								    <asp:ListItem Text="TIN ID" Value="TINID"></asp:ListItem>
								    <asp:ListItem Text="PAG-IBIG ID" Value="PAG-IBIGID"></asp:ListItem>
								    <asp:ListItem Text="POSTAL ID" Value="POSTALID"></asp:ListItem>
								    <asp:ListItem Text="UMID" Value="UMID"></asp:ListItem>
								    <asp:ListItem Text="PRC ID" Value="PRCID"></asp:ListItem>
								    <asp:ListItem Text="Senior Citizen ID" Value="SeniorCitizenID"></asp:ListItem>
								    <asp:ListItem Text="SSS ID" Value="SSSID"></asp:ListItem>
								   <asp:ListItem Text="GSIS ID" Value="GSISID"></asp:ListItem>
								   <asp:ListItem Text="OWWA ID" Value="OWWAID"></asp:ListItem>
								   <asp:ListItem Text="PWD ID (Persons with Disabilities)" Value="PWDIS"></asp:ListItem>
								   <asp:ListItem Text="Voter's ID" Value="Voter'sID"></asp:ListItem>
								   <asp:ListItem Text="Integrated Bar of the Philippines ID" Value="IntegratedBar"></asp:ListItem>
                                </asp:DropDownList>
								<br />
							</div>
							<br />
                            <div id="divshowfile" runat="server">
                                
                                <h5>Please input your valid ID Number: </h5>
                                <div class="form-input">
                                    <span class="fa fa-id-card-o" aria-hidden="true"></span>
                                    <asp:TextBox ID="txtidnumber" placeholder="ID No" required="" runat="server" oncopy="return false" oncut="return false" onpaste="return false" Width="100%" Height="43px" />
                                </div>
								<br />
								<h5> Please insert your valid ID: <br /> 2mb maximum image upload</h5>
                                <div class="form-input">
                                    <span class="fa fa-id-card-o" aria-hidden="true"></span>
                                    <asp:FileUpload ID="FileUpload1" class="form-input" Width="100%" runat="server" required="" />
                                </div>
                            </div>
							
							<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
                                <script>
                                    $(document).ready(function () {
                                        // Hide the file upload control on page load
                                        $("#divshowfile").hide();

                                        // Show the file upload control when the user selects a value in the dropdown
                                        $("#DropDownList1").change(function () {
                                            var selectedValue = $(this).val();

                                            if (selectedValue === "NationalId" || selectedValue === "DriverLicense" || selectedValue === "Passport" || selectedValue === "TINID" || selectedValue === "PAG-IBIGID" || selectedValue === "POSTALID" || selectedValue === "UMID" || selectedValue === "PRCID" || selectedValue === "SeniorCitizenID" || selectedValue === "SSSID" || selectedValue === "GSISID" || selectedValue === "OWWAID" || selectedValue === "PWDIS" || selectedValue === "Voter'sID" || selectedValue === "IntegratedBar") {
                                                $("#divshowfile").show();
                                            } else {
                                                $("#divshowfile").hide();
                                            }
                                        });
                                    });
                                </script>
							<br />
							<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="The file size must be less than 2MB." Display="Dynamic" OnServerValidate="CustomValidator1_ServerValidate" Font-Bold="True" ForeColor="Red" />
							<br />
							<br />
							<br />
					     
						     <asp:Button ID="btnsignup" OnClick="btnsignup_Click" OnClientClick="return confirm('Do you want to save and secure your information with permission? The Data Privacy Act of 2012 (DPA), also known as Republic Act No. 10173, aims to protect personal data in information and communications systems in both the government and the private sector. The DPA established the National Privacy Commission (NPC) which is responsible for monitoring its implementation. The DPA covers the processing of personal information and sensitive personal information, and its basic premise is the requirement for direct consent from a data subject before allowing the processing of personal information.')" Text="Sign Up" class="btn theme-button" runat="server" />                                  
                            

                            

							<br />
							</div> 
					</form>
			</div>
		</div>
	</section>
    </form>
</body>
</html>
