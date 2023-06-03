<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OurTeam.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.OurTeam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="Index/img/Mabolo_Logo.png" type="image/x-icon" />
    <link href="outteam/Css/Dropdownlistcss.css" rel="stylesheet" />
    <!-- BOOTSTRAP CSS -->
    <link href="outteam/Css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awsome Icons -->
    <link href="Index/fontawesome/css/all.min.css" rel="stylesheet" />
    <link href="Index/Css/Indexbackup.css" rel="stylesheet" />

    <!-- This is the TITLE of the PAGE -->
    <title>Our Team - Online Document Request</title>

    <style>
        body {
            background-color: #E4E9F7;
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
        .container .hero-team {
            margin-top: 10rem;
        }

            .container .hero-team .team {
                margin-bottom: 4rem;
            }

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

            .container .hero-team .row p {
                font-size: small;
            }

            .container .hero-team .row #tams,
            .container .hero-team .row #aye,
            .container .hero-team .row #vin,
            .container .hero-team .row #arvs {
                margin-bottom: 4rem;
                padding-left: 1rem;
                padding-right: 1rem;
                padding-bottom: 1rem;
            }

                .container .hero-team .row #tams a,
                .container .hero-team .row #aye a,
                .container .hero-team .row #vin a,
                .container .hero-team .row #arvs a {
                    font-size: 20px;
                    color: #fff;
                    background-color: #4E0707;
                }

                .container .hero-team .row #tams:hover,
                .container .hero-team .row #tams:hover a {
                    transition: .25s ease;
                    background-color: #4E0707;
                    color: #fff;
                    border-radius: 10px;
                    border: 1px solid #fff;
                    box-shadow: rgba(0,0,0,0.4) 4px 4px 5px;
                }

            .container .hero-team .row .ayecol:hover,
            .container .hero-team .row .ayecol:hover a {
                transition: .25s ease;
                background-color: #4E0707;
                color: #fff;
                border-radius: 10px;
                border: 1px solid #fff;
                box-shadow: rgba(0,0,0,0.4) 4px 4px 5px;
            }

            .container .hero-team .row .vincol:hover,
            .container .hero-team .row .vincol:hover a {
                transition: .25s ease;
                background-color: #4E0707;
                color: #fff;
                border-radius: 10px;
                border: 1px solid #fff;
                box-shadow: rgba(0,0,0,0.4) 4px 4px 5px;
            }

            .container .hero-team .row .arvscol:hover,
            .container .hero-team .row .arvscol:hover a {
                transition: .25s ease;
                background-color: #4E0707;
                color: #fff;
                border-radius: 10px;
                border: 1px solid #fff;
                box-shadow: rgba(0,0,0,0.4) 4px 4px 5px;
            }

        @media (max-width: 600px) {
            .navbar-nav {
                margin: 10px;
                padding: 10px;
                justify-content: center;
            }

                .navbar-nav a {
                    text-align: center;
                }
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
    </style>

    <script>
  // Get the services dropdown element by its id
  const servicesDropdown = document.getElementById('services-dropdown');

  // Add a mouseover event listener to the "Services" link
  document.getElementById('serv').addEventListener('mouseover', () => {
    // Scroll the services dropdown element into view
    servicesDropdown.scrollIntoView({
      behavior: 'smooth', // Use smooth scrolling animation
      block: 'start', // Scroll to the top of the element
      inline: 'nearest' // Scroll to the closest edge of the element
    });
  });
    </script>
    <link rel="stylesheet" type="text/css" href="Index/purecookie.css" async />
    <script src="Index/purecookie.js"></script>
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
        <!-- This div is for OUR TEAM INFORMATION-->
        <div class="container">
            <div class="hero-team">
                <h2 class="team"><b>Our Team</b></h2>
                <div class="row">
                    <!-- Thesis Adviser Info -->
                    <div class="col-sm-4">
                        <!-- Column 1 Empty -->
                    </div>

                    <div class="col-sm-4" id="tams">
                        <img class="rounded-circle" src="Index/img/SirTams.png" alt="" />
                        <h4><b>Ferdinand Tamayo</b></h4>
                        <em>Thesis Adviser</em>
                        <br />
                        <br />
                        
                    </div>

                    <div class="col-sm-4">
                        <!-- Column 3 Empty -->
                    </div>

                    <!-- System Analyst Info -->
                    <div class="col-sm-4 ayecol" id="aye">
                        <img class="rounded-circle" src="Index/img/MarahiaAyessaPalacio.png" alt="" />
                        <h4><b>Marahia Ayessa Revellame</b></h4>
                        <em>System Analyst & Programmer</em>
                        <br />
                       
                    </div>

                    <!-- Programmer Info -->
                    <div class="col-sm-4 vincol" id="vin">
                        <img class="rounded-circle" src="Index/img/AlvinCLarkPalacio.png" alt="" />
                        <h4><b>Alvin Clark Palacio</b></h4>
                        <em>Programmer & System Analyst</em>
                        <br />
                       
                    </div>

                    <!-- Technical Writer Info -->
                    <div class="col-sm-4 arvscol" id="arvs">
                        <img class="rounded-circle" src="Index/img/ArvieValderas.png" alt="" />
                        <h4><b>Arvie Valderas</b></h4>
                        <em>Technical Writer & System Analyst</em>
                       
                    </div>
                </div>

                <!-- End of Row -->
            </div>
            <!-- End of Hero Team -->
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
                            <p><a class="nav-link" href="OurTeam.aspx"></> Team</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    </form>
    <script src="outteam/js/bootstrap.bundle.min.js"></script>
</body>
</html>
