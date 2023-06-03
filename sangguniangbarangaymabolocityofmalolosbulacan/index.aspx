<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="Index/img/Mabolo_Logo.png" type="image/x-icon" />
    <link href="Index/Css/Dropdownlistcss.css" rel="stylesheet" />
    

    <!-- This is the TITLE of the PAGE -->
    <title>Online Document Request - Sangguniang Barangay Mabolo, Malolos City</title>
    <!-- BOOTSTRAP CSS -->
    <link href="Index/Css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awsome Icons -->
    <link href="Index/fontawesome/css/all.min.css" rel="stylesheet" />
    <%--<link href="Index/Css/Indexbackup.css" rel="stylesheet" />--%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <!-- PureCookie -->
     <link rel="stylesheet" type="text/css" href="Index/purecookie.css" async />
    <script src="Index/purecookie.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="scripts/autoresize.js"></script>
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


</head>
<body>
    <form id="form1" runat="server">
          <script>

            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {

                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),

                    m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)

            })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');



            ga('create', 'UA-46156385-1', 'cssscript.com');

            ga('send', 'pageview');



          </script>
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
        
        <!-- This section is for the BODY of this Website-->
        <div class="container-fluid" style="margin: 0; padding: 0;">
            <div class="hero-body">

                <h1>Welcome!</h1>
                <h2>ODR is here to make your life easy.</h2>
                <br />
                
              
            </div>
            
            <!-- BARANGAY OFFICIALS -->
            <div class="container" id="team">
                <!-- This div is for BARANGAY OFFICIALS -->
                <div class="hero-team">
                   <h2 class="team"><b>Barangay Mabolo</b></h2>

                    <p style="font-size: large; text-align: center; margin-top: 3rem; margin-bottom: 3rem;">
                        Ang Barangay Mabolo ay isang istratehikong barangay sa pagitan ng mga barangay Caniogan at Bagong Bayan; sa gawing hilaga naman nito ay ang barangay ng Cofradia. Ang Diversion Road sa gawing silangan ng Mabolo ay may malaking tulong sa mga mamamayan na palabas ng Malolos patungong McArthur Hi-way. Bagama’t may malawak pang kabukiran, hindi maikakaila ang tawag ng urbanisasyon. Malaking bahagi na rin ng Mabolo ang kabahayan at patuloy na umuunlad ang mga negosyo sa lugar. Ang populasyon ng Mabolo ay umabot sa 6,391 katao mula sa may 1,391 kabahayan. Ang kabuuang sukat ng kalupaan ng Mabolo ay humigit kumulang sa anim (6) na kilometro kwadrado.</p>
                </div>

                <asp:Repeater ID="rptbarangayofficals" runat="server" >

                    <ItemTemplate>
                        <div class="col-md-3" style="margin-bottom: 3rem;">
                             
                            <img class="rounded-circle" src='BarangayOfficalsImage/<%#Eval("OfficalImages") %>' alt="" />
                            <h4><b><asp:Label Text='<%#Eval("tbl_Fullname") %>' runat="server" /></b></h4>
                            <em><asp:Label Text='<%#Eval("tbl_BarangayOfficalPosition") %>' runat="server" /></em>
                        </div>
                    </ItemTemplate>
                         </asp:Repeater>
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
            </div>
      
        <script>
            $(document).ready(function () {
                // Set the initial height of the body to the window height
                $("body").height($(window).height());

                // Whenever the window is resized, update the height of the body
                $(window).resize(function () {
                    $("body").height($(window).height());
                });
            });

        </script>
       
    </form>
    <!-- JS Script -->
     <script src="Index/js/bootstrap.bundle.min.js"></script>
</body>
</html>
