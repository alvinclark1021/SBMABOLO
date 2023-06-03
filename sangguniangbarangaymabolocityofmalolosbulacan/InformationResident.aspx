<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformationResident.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.InformationResident" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Information Resident</title>
	<!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="img/Mabolo_Logo.png" type="image/x-icon" />
    <!-- Meta tag Keywords -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Classy Register Form Responsive Widget,Login form widgets, Sign up Web forms , Login signup Responsive web form,Flat Pricing table,Flat Drop downs,Registration Forms,News letter Forms,Elements" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- Meta tag Keywords -->
<!-- css files -->
<link href="Editresident/css/style.css" rel="stylesheet" type="text/css" media="all">
<!-- //css files -->
<!-- online-fonts -->
<link href="//fonts.googleapis.com/css?family=Cuprum:400,400i,700,700i&amp;subset=cyrillic,cyrillic-ext,latin-ext,vietnamese" rel="stylesheet">
<!--//online-fonts -->
</head>
<body>
    <form id="form1" runat="server">
		 <asp:ScriptManager ID="Scrip" runat="server"></asp:ScriptManager>
		<asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbirthday"></asp:CalendarExtender>
        <div class="header">
	<h1>Barangay Resident Register Form</h1>
</div>
<div class="w3-main">
	<!-- Main -->
	<div class="about-bottom main-agile book-form">
		<div class="alert-close"> </div>
		<h2 class="tittle">Register Here</h2>
		<form action="#" method="post">
			<div class="form-date-w3-agileits">
				<asp:Label ID="lbldate" runat="server" Visible="false" Text="Label"></asp:Label>
				<label> Registration No </label>
				<asp:TextBox ID="txtregistationno" placeholder="Registattion No" ReadOnly="true" required="" runat="server"></asp:TextBox>
				<label> Name </label>
				<asp:TextBox ID="txtfullname" placeholder="Your Name" required="" runat="server"></asp:TextBox>
				<label> Email </label>
				<asp:TextBox ID="txtemail" placeholder="Email" ReadOnly="true" required="" runat="server"></asp:TextBox>
				<label> Mobile Number </label>
			     <asp:TextBox ID="txtmobileno" placeholder="Mobile No" MaxLength="11" onkeypress="return this.value.length<=11" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');" pattern="[0-9]{11}"  required="" runat="server"></asp:TextBox>
				<label>Birthday</label>
				<asp:TextBox ID="txtbirthday" placeholder="Birthday" required="" runat="server"></asp:TextBox>
				<br />
				<asp:RangeValidator ID="valrDate" runat="server" ControlToValidate="txtbirthday" MinimumValue="12/31/1950" MaximumValue="12/31/4000" Type="Date" text="Invalid Date" Display="Dynamic" ForeColor="White"/>
				<br />
				<asp:CompareValidator ErrorMessage="Please Valid Date Format (mm/dd/yyyy)" Display="Dynamic" ID="valcDate" ControlToValidate="txtbirthday" Operator="DataTypeCheck" Type="Date" runat="server" ForeColor="White"></asp:CompareValidator>           
				<br />
				<label>Gender</label>
				<asp:DropDownList ID="Selectedmaleorfemale" Width="100%" Height="43px" runat="server">
                                    <asp:ListItem>Select Gender</asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                         </asp:DropDownList>
				<br />
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Gender" ControlToValidate="Selectedmaleorfemale" ForeColor="Red" InitialValue="Select Gender"></asp:RequiredFieldValidator>
							<br />
				<label>Address</label>
				<asp:TextBox ID="txtaddress" placeholder="Address" required="" runat="server"></asp:TextBox>
				<label>Voter Register in Barangay Mabolo</label>
				<asp:DropDownList ID="Dropselectede" Width="100%" Height="43px" class="form-input" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Yes </asp:ListItem>
                                    <asp:ListItem>No </asp:ListItem>
                 </asp:DropDownList>
				<br />
				<asp:RequiredFieldValidator ID="Requiredselect" runat="server" Display="Dynamic" ErrorMessage="Please Select" ControlToValidate="Dropselectede" ForeColor="White" InitialValue="Select"></asp:RequiredFieldValidator>

				<label>Valid Valid</label>
				<label><h3>Note if you want reupload id make sure clear your picture</h3></label>
				<asp:FileUpload ID="FileUpload1" Width="188px" Height="29px" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Black" />
				<br />
				<asp:Label ID="lblimages" runat="server" Visible="false" Text="Label"></asp:Label>
				<br />


			</div>
			<div class="make wow shake">
				<br />
				<br />
				  <asp:Button ID="Bntsubmitinformation" OnClick="Bntsubmitinformation_Click" Width="170px" Height="70px" runat="server" Text="Submit" Font-Bold="True" OnClientClick="return confirm('Do you want information are correct?')" Font-Names="Algerian" Font-Size="X-Large" />
			</div>
			
		</form>
	</div>
	<!-- //Main -->
</div>

<!-- js-scripts-->
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
		<script type="text/javascript" src="Editresident/js/jquery-2.1.4.min.js"></script>
		<script>$(document).ready(function(c) {
		$('.alert-close').on('click', function(c){
			$('.main-agile').fadeOut('slow', function(c){
				$('.main-agile').remove();
			});
		});	  
	});
        </script>
<!-- //js-scripts-->
    </form>
</body>
</html>
