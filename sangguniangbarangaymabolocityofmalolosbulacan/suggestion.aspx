<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="suggestion.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.suggestion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Suggestion</title>
    <!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="Index/img/Mabolo_Logo.png" type="image/x-icon" />

    <!-- Meta tag Keywords -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="UTF-8" />
    <meta name="keywords"
        content="Slot Coming Soon Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, Smartphone Compatible web template" />
    <!-- //Meta tag Keywords -->
    <link href="//fonts.googleapis.com/css2?family=Hind:wght@400;600;700&display=swap" rel="stylesheet">
    <link href="//fonts.googleapis.com/css2?family=Pacifico&display=swap" rel="stylesheet">
    <!--/Style-CSS -->
    <link rel="stylesheet" href="Sugessionform/css/style.css" type="text/css" media="all" />
    <!--//Style-CSS -->
    <link rel="stylesheet" href="Sugessionform/css/font-awesome.min.css" type="text/css" media="all" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" />
     <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>

	<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/2.9.3/umd/popper.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.0.2/js/bootstrap.min.js"></script>

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
</head>
<body>
    <form id="form1" runat="server">
          
   <!-- Navigation Bar -->
<header>
    <nav class="navbar navbar-expand-lg fixed-top bg-light shadow-lg">

        <!-- This div is for LOGO -->
        <div class="container">

            <!-- This div is for TEXT & IMAGE LOGO -->
            <div class="head">

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

       

        <div id="block" class="w3lvide-content" data-vide-bg="Sugessionform/images/Videome.mp4" data-vide-options="position: 0% 50%">
             <br />
        <br />
        <br />
             <br />
        <br />
        <br />
            <div class="wrapper">
            <div class="workinghny-form-grid">
                <div class="slot-w3l-comingsoon">
                    <div class="slot-w3content">
                        <h3>Sangguniang Barangay Mabolo</h3>
                        <h1>Our New website <br>is on its way</h1>
                        <%--<p class="text-5 text-light mb-3">Get notified when we launch.</p>
                        
                            <form action="#" method="post" class="w3hny-subscribe-form">
                                <input type="email" name="subscribe-form-email" class="form-control required" required="" placeholder="Enter Your Email Here..">
                                <button class="btn btn-primary" type="submit"><i class="fa fa-paper-plane" aria-hidden="true"></i></button>
                            </form>--%>
                        
                    </div>
                </div>
                <style>
                    .content-wthree form {
                        display: flex;
                        flex-direction: column;
                        align-items: center;
                    }
                </style>
                <!-- /form -->
                <div class="main-hotair">
                    <div class="content-wthree">
                        <asp:Label ID="lbldate" Visible="false" runat="server" Text="Label"></asp:Label>
                        <h2>Contact Us</h2>
                        <form action="https://sendmail.w3layouts.com/submitForm" method="post" class="signin-form">
                            <div class="input-grids">
                                <h5>Email Address</h5>
                                <asp:TextBox ID="txtemail" placeholder="Email" class="contact-input" autofocus onfocus="this.type='email'" oncopy="return false" oncut="return false" onpaste="return false" required=""  runat="server" Width="306px"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="validategamilonly" ValidationExpression="\w+([-+.']\w+)*@(?:gmail).com" runat="server" ErrorMessage="Please input your gmail . " ControlToValidate="txtemail" ForeColor="Red" SetFocusOnError="True" Font-Names="Algerian"></asp:RegularExpressionValidator>
                                <br />
                               <h5>Fullname</h5>
                              <asp:TextBox ID="txtname" placeholder="Name" class="contact-input" autofocus  required=""  runat="server" Width="306px"></asp:TextBox>
                                <br />
                                <br />
                                <h5>Contact No</h5>
                                 <asp:TextBox ID="txtcontactnumber" placeholder="Mobile Number" class="contact-input" MaxLength="11" onkeypress="return this.value.length<=11" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');" pattern="[0-9]{11}" Width="306px" Height="49px" oncopy="return false" oncut="return false" onpaste="return false" autofocus required=""  runat="server"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please input your +63 number" ControlToValidate="txtcontactnumber" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^(09|\+639)\d{9}$" Font-Names="Algerian"></asp:RegularExpressionValidator>
                                <br />
                              
                                <h5>Concern Message</h5>
                                <asp:TextBox ID="txtmessagebox" placeholder="Please your Message concern" Enabled="true" runat="server" Height="200px" TextMode="MultiLine" Width="307px"></asp:TextBox>
                        </div>
                            
                        </form>
                      
                    </div>
                    <div style="text-align: center;">
                                <asp:Button ID="Btnsubmitme" OnClick="Btnsubmitme_Click" class="WeakStrength" runat="server" Text="Submit concern" Font-Bold="True" ForeColor="#FF9900" BackColor="#CCFF99" Font-Names="Algerian"   BorderColor="Black" Height="63px" Width="328px" />
                               
                              </div>

                </div>
                <!-- //form -->
            </div>
           
        </div>
            <br />
        <br />
        <br />
             <br />
        <br />
        <br />
         </div>
        
         <!-- Footer of this Website -->
        <footer>
            <div class="container-fluid" id="footer">
                <div class="row row-cols-3" id="footnote">
                    <div class="footer1">
                        <h4>Online Document Request</h4>
                        <em>Copyright ⓒ 2023 Sangguniang Barangay Mabolo</em>
                    </div>

                    <div class="footer2">
                        <h6>CONTACT DETAILS</h6>
                        <div class="col border-top">
                            <br />
                            <p><i class="fas fa-location-dot icon"></i>Lucero Street Purok 1, Barangay Mabolo, City of Malolos, Bulacan</p>
                            <p><i class="fas fa-phone icon"></i>+63 (44) 760 4456</p>
                        </div>
                    </div>

                    <div class="footer3">
                        <h6>QUICK LINKS</h6>
                        <div class="col border-top">
                            <br />
                            <p><a class="nav-link" href="index.aspx">Home</a></p>
                            <p><a class="nav-link" href="ourteam.aspx"></> Team</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </footer>    
        
    </form>
    <script src="Sugessionform/js/jquery.min.js"></script>
    <script src="Sugessionform/js/jquery.vide.js"></script>
     <script>
        //    $(document).ready(function () {
        //        $("#block").vide("video/ocean"); // Non declarative initialization
        //
        //        var instance = $("#block").data("vide"); // Get instance
        //        var video = instance.getVideoObject(); // Get video object
        //        instance.destroy(); // Destroy instance
        //    });
     </script>
</body>
</html>
