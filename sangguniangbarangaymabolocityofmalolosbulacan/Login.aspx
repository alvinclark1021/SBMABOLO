﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Sangguniang Barangay Mabolo, Malolos City</title>
    <!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="Index/img/Mabolo_Logo.png" type="image/x-icon" />

    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="keywords" content="Art Sign Up Form Responsive Widget, Audio and Video players, Login Form Web Template, Flat Pricing Tables, Flat Drop-Downs, Sign-Up Web Templates, 
		Flat Web Templates, Login Sign-up Responsive Web Template, Smartphone Compatible Web Template, Free Web Designs for Nokia, Samsung, LG, Sony Ericsson, Motorola Web Design"
    />
    <!-- /meta tags -->
    <!-- custom style sheet -->

    <link href="Login/css/style.css" rel="stylesheet" type="text/css" />
    <!-- /custom style sheet -->
    <!-- fontawesome css -->
    <link href="Login/css/fontawesome-all.css" rel="stylesheet" />
    <!-- /fontawesome css -->
    <!-- google fonts-->
    <link href="//fonts.googleapis.com/css?family=Raleway:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">
    <!-- /google fonts-->
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/2.9.3/umd/popper.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.0.2/js/bootstrap.min.js"></script>

    <!-- Meta tag Keywords -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta charset="UTF-8">
<meta name="keywords" content="taped login form Widget a Flat Responsive Widget,Login form widgets, Sign up Web forms , Login signup Responsive web form,Flat Pricing table,Flat Drop downs,Registration Forms,News letter Forms,Elements" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- Meta tag Keywords -->
    <link href="Login/css/style.css" rel="stylesheet" type="text/css" media="all" />
<link rel="stylesheet" href="css/font-awesome.css" type="text/css" media="all" />
<link href="//fonts.googleapis.com/css?family=Snippet" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Barlow" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Titillium+Web" rel="stylesheet">

    <script>
        $(document).ready(function () {
            $("#checkmeshowandhidepassword").click(function () {
                $("#txtpassword").attr('type', $(this).is(':checked') ? 'text' : 'password'); S
            });
        });
    </script>
    <script src="Login/javascript/button.js"></script>
   
     <style>
        body {
            color: #4E0707;
        }

        header .head {
            display: flex;
            align-items: center;
            font-family: sans-serif, serif, 'Segoe Script', Verdana, Geneva, Tahoma, sans-serif;
        }

            header .head .nav button span {
                color: #4E0707;
            }

            header .head .image-logo {
                display: flex;
                align-items: center;
                justify-content: center;
                margin-right: 6.5px;
            }

                header .head .image-logo .image img {
                    width: 75px;
                    height: 75px;
                }

            header .head .text-logo {
                display: flex;
                flex-direction: column;
            }

            header .head .name {
                margin-top: -8px;
                font-size: 25px;
                font-weight: 600;
                color: #4E0707 !important;
            }

            header .head .topname {
                font-size: 16px;
                margin-top: 2px;
                display: block;
                color: #4E0707 !important;
            }

        header .nav-link {
            color: #4e0707;
            font-weight: 500;
            font-size: 20px;
            text-decoration: none;
            border-radius: 5px;
            justify-content: space-between;
        }

            header .nav-link:hover {
                color: #fff;
                background-color: #4E0707;
                border-radius: 5px;
                transition: .25s ease;
            }


        /*For footer design*/
        #footer {
            background-color: #4E0707;
            color: #fff;
            /*height: 200px;*/
            font-family: sans-serif, serif, 'Segoe Script', Verdana, Geneva, Tahoma, sans-serif;
        }

        footer #footnote {
            padding-top: 2rem;
            padding-bottom: 3rem;
            color: white !important;
        }

            footer #footnote .footer1 {
                padding-top: 3rem;
                text-align: center;
            }

            footer #footnote .footer2 h6, .footer3 h6 {
                text-align: center;
            }

            footer #footnote .footer2 i, .footer3 i {
                padding-right: 1rem;
                font-size: 20px;
            }

            footer #footnote .footer2 p {
                align-items: center;
            }


        /*For body design*/
        .hero-body {
            width: 100%;
            height: 55%;
            margin-top: 90px;
            padding: 50px;
            letter-spacing: 1.5px;
            color: #4E0707;
            background-color: /*#d4d4d4*/ #E4E9F7;
        }

            .hero-body h1 {
                font-family: 'Times New Roman', Times, serif;
                font-size: 150px;
                text-shadow: 5px 5px 5px #333;
            }

            .hero-body h2 {
                text-decoration: none;
                color: #4E0707;
                font-family: 'Times New Roman', Times, serif;
                display: block;
                margin-left: 60px;
                margin-bottom: 40px;
                margin-top: -20px;
            }

            .hero-body .btn {
                margin-right: 50px;
                margin-left: 60px;
            }

            .hero-body a {
                text-align: center;
                text-decoration: none;
                padding: .7rem;
                font-size: medium;
                font-weight: 700;
                font-family: sans-serif, 'Times New Roman', Times, serif;
                border: 2px solid #4E0707;
                background-color: #fff;
                color: #4E0707;
                width: 200px;
            }

                .hero-body a:hover {
                    color: #fff;
                    background-color: #4E0707;
                    border: 2px solid #fff;
                    transition: .25s ease;
                    box-shadow: rgba(0,0,0,0.4) 4px 4px 5px;
                }

        @media (max-width: 600px) {
            .hero-body h1 {
                text-align: center;
                font-size: 90px;
            }

            .hero-body h2 {
                margin-left: 6px;
                text-align: center;
            }

            .hero-body a {
                width: 100px;
                padding: .5rem;
                font-size: medium;
                width: 200px;
            }

            .navbar-nav {
                margin: 10px;
                padding: 10px;
                justify-content: center;
            }

                .navbar-nav a {
                    text-align: center;
                }
        }

        /*HERO TEAM*/
        .container .hero-team img {
            width: 150px;
            height: 150px;
            margin-top: 2rem;
            margin-bottom: 1rem;
            border: 2px solid #4E0707;
        }

            .container .hero-team img:hover {
                transform: scale(1.1);
                transition: .25s ease;
            }

        .container .hero-team h2 {
            margin-top: 2.5rem;
        }

        .container .hero-team h2,
        .hero-team .row {
            text-align: center;
        }

        .container .hero-team #row2 {
            margin-top: 2rem;
            margin-bottom: 2rem;
        }

            .container .hero-team #row2 a {
                text-align: center;
                padding: .7rem;
                font-size: x-large;
                font-weight: 500;
                font-family: 'Times New Roman', Times, serif;
                border: solid #4E0707;
                color: #4E0707;
            }

                .container .hero-team #row2 a:hover {
                    color: #fff;
                    border: solid #fff;
                    background-color: #4E0707;
                    transition: .25s ease;
                    box-shadow: rgba(0,0,0,0.4) 4px 4px 5px;
                }

        /* Default style */
        #dpdown .dropdown-menu {
            left: 0;
            right: 0;
            width: auto;
        }

        /* Adjust for medium screens */
        @media (min-width: 768px) {
            #dpdown .dropdown-menu {
                left: auto;
                right: auto;
            }
        }
    </style>

    <link href="Index/Css/Dropdownlistcss.css" rel="stylesheet" />
    <!-- BOOTSTRAP CSS -->
    <link href="Index/Css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awsome Icons -->
    <link href="Index/fontawesome/css/all.min.css" rel="stylesheet" />

    <style>
        /* Style for screens with a maximum width of 600px */
        @media screen and (max-width: 600px) {
            body {
                font-size: 14px;
            }
        }

        /* Style for screens with a minimum width of 601px */
        @media screen and (min-width: 601px) {
            body {
                font-size: 16px;
            }
        }

        .myButton {
            background-color: #CCFF99;
            border: none;
            color: #FF9900;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            font-family: Algerian;
            font-weight: bold;
            cursor: pointer;
            border-radius: 5px;
        }

            .myButton:hover {
                background-color: #FF9900;
                color: #CCFF99;
            }
    </style>

       
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Index/Css/Dropdownlistcss.css" rel="stylesheet" />
    <!-- BOOTSTRAP CSS -->
    <link href="Index/Css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awsome Icons -->
    <link href="Index/fontawesome/css/all.min.css" rel="stylesheet" />

    <%--<link href="Index/Css/Indexbackup.css" rel="stylesheet" />--%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <!-- PureCookie -->
     <link rel="stylesheet" type="text/css" href="Index/purecookie.css" async />
    <script src="Index/purecookie.js"></script>

</head>
<body>
    <form id="form1" runat="server">

        <!-- This div is for TEXT & IMAGE LOGO -->
<div class="head d-flex align-items-center">
  <header>
    <nav class="navbar navbar-expand-lg fixed-top bg-light shadow-lg">

        <!-- This div is for LOGO -->
        <div class="container">

            <!-- This div is for TEXT & IMAGE LOGO -->
            <div class="head">
                <asp:Label ID="lblactivity" runat="server" Visible="false" Text="Login"></asp:Label>
        <asp:Label ID="lbldate" runat="server" Visible="false" Text="Label"></asp:Label>
                <!-- This div is for IMAGE LOGO only-->
                <div class="image-logo">
                    <span class="image">
                        <a href="index.aspx">
                            <img src="Index/img/Mabolo_Logo.png" alt="" class="rounded-circle" /></a>
                    </span>
                </div>

                <!-- This div is for TEXT LOGO only-->
                <div class="text-logo">
                    <span class="topname">Sangguniang Barangay Mabolo</span>
                    <span class="name">Online Document Request</span>
                </div>

            </div>

            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="true" aria-label="Toggle navigation">
                <span id="toggler-icon" class="navbar-toggler-icon"></span>
            </button>

             <!-- This div is for NAVIGATION MENU-->
            <div class="collapse navbar-collapse justify-content-center" id="navbarSupportedContent">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="index.aspx">Home</a>
                    </li>
                    <li class="nav-item" id="dpdown">
                        <a id="serv" class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Services</a>
                        <ul class="dropdown-menu" style="padding: .5rem;">
                            <li><a class="nav-link dropdown-item" href="Login.aspx">Barangay Residents</a></li>
                            <li><a class="nav-link dropdown-item" href="BarangayOfficalLogin.aspx">Barangay Officials</a></li>
                            <li><a class="nav-link dropdown-item" href="suggestion.aspx">Contact Us</a></li>
                        </ul>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ourteam.aspx">Team</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</header>

<style>
    /* Default styles for desktop */
    body {
        font-size: 16px;
    }

    /* Styles for tablet */
    @media (max-width: 768px) {
        body {
            font-size: 14px;
        }
    }

    /* Styles for mobile */
    @media (max-width: 576px) {
        body {
            font-size: 12px;
        }
    }

    body {
    height: 100vh;
}

    body {
    width: 100vw;
}

</style>
</div>

   <!-- Navigation Bar -->


        
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
     <div class=" w3l-login-form">
                <h1>Login Here</h1>
                <form action="#" method="POST">

                    <div class="w3l-form-group">
                        <label>Username or Email Address:</label>
                        <div class="group">
                            <i class="fas fa-user"></i>
                            <asp:TextBox ID="txtusername" placeholder="Username or Email Address" runat="server" onkeyup="checkTextbox();" required="" />
                        </div>
                    </div>
                    <div class="w3l-form-group">
                        <label>Password:</label>
                        <div class="group">
                            <i class="fas fa-unlock"></i>
                            <asp:TextBox ID="txtpassword" placeholder="Password" TextMode="Password" runat="server" onkeyup="checkTextbox();" required=""></asp:TextBox>
                            <span class="show-password">
                                <i class="far fa-eye" onclick="togglePasswordVisibility()"></i>
                            </span>
                        </div>
                    </div>


                    <script type="text/javascript">
                        function checkTextbox() {
                            var textbox1 = document.getElementById('<%= txtusername.ClientID %>').value;
        var textbox2 = document.getElementById('<%= txtpassword.ClientID %>').value;
        var button = document.getElementById('<%= btnlogin.ClientID %>');

                            if (textbox1 != '' && textbox2 != '') {
                                button.disabled = false;
                            } else {
                                button.disabled = true;
                            }
                        }
                    </script>


                    <script>
                        function togglePasswordVisibility() {
                            var passwordField = document.getElementById('<%=txtpassword.ClientID%>');
                            var passwordIcon = document.querySelector('.show-password i');
                            if (passwordField.type === 'password') {
                                passwordField.type = 'text';
                                passwordIcon.classList.remove('fa-eye');
                                passwordIcon.classList.add('fa-eye-slash');
                            } else {
                                passwordField.type = 'password';
                                passwordIcon.classList.remove('fa-eye-slash');
                                passwordIcon.classList.add('fa-eye');
                            }
                        }
                    </script>
                    <script type="text/javascript">
                        function checkTextbox() {
                            var textbox1 = document.getElementById('<%= txtusername.ClientID %>').value;
                            var textbox2 = document.getElementById('<%= txtpassword.ClientID %>').value;
                            var button = document.getElementById('<%= btnlogin.ClientID %>');

                            if (textbox1 != '' && textbox2 != '') {
                                button.disabled = false;
                            } else {
                                button.disabled = true;
                            }
                        }
                    </script>
                    <div class="forgot">
                        
                        <p>
                            <asp:CheckBox ID="checkme" runat="server" />Remember Me</p>
                    </div>
                      <asp:Button ID="btnlogin" OnClick="btnlogin_Click" Text="LOGIN" runat="server" class="btn btn-primary btn-block" Enabled="false" Height="60px" Width="410px" />

                </form>
                <p class=" w3l-register-p">Don't have an account?<a href="SignUpAccount.aspx" class="register"  style="text-decoration:underline;"> Register Here</a></p>
                <p class=" w3l-register-p"><a href="Forgetpassword.aspx" class="register"> Forget Password</a></p>
            </div>
            
             <!-- Footer of this Website -->
        
       
    </form>
</body>
</html>
