﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ResidentDashboard.Master" AutoEventWireup="true" CodeBehind="BarangayBusinessClearance.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.BarangayBusinessClearance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <title>Request Documents Business Clearance - Sangguniang Barangay Mabolo, Malolos City</title>
   <!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="Index/img/Mabolo_Logo.png" type="image/x-icon" />
    
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
     <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    

    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="Scrip" runat="server"></asp:ScriptManager>
     <body>
  <div class="se-pre-con"></div>
<section>
  <!-- sidebar menu start -->
  <div class="sidebar-menu sticky-sidebar-menu">

    <!-- logo start -->
    <div class="logo">
      <h1><a href="ResidentDashboard.aspx">Mabolo</a></h1>
    </div>

    <div class="logo-icon text-center">
      <a href="ResidentDashboard.aspx" title="logo"><img src="assets/images/logo.png" alt="logo-icon"> </a>
    </div>
    <!-- //logo end -->

    <div class="sidebar-menu-inner">
        
                    <asp:Label ID="lblensission" runat="server" Visible="false" Text="End Session" ForeColor="#033C73"></asp:Label>
                    <asp:Label ID="lbllogout" runat="server" Text="Logout" Visible="false" ForeColor="#033C73"></asp:Label>
       <!-- sidebar nav start -->
      <ul class="nav nav-pills nav-stacked custom-nav">
        <li class="active"><a href="ResidentDashboard.aspx"><i class="fa fa-tachometer"></i><span> Dashboard</span></a>
        </li>
        <li class="menu-list">
          <a href="#"><i class="fa fa-file-text"></i>
            <span>Request Documents<i class="lnr lnr-chevron-right"></i></span></a>
          <ul class="sub-menu-list">
              <li><a href="BarangayBusinessClearance.aspx">Barangay Business Clearance</a> </li>
            <li><a href="BarangayClearance.aspx">Barangay Clearance</a> </li>
            <li><a href="ExcavationCuttingPermit.aspx">Barangay Excavation Permit</a> </li>
              <li><a href="FencingPermit.aspx">Barangay Fencing Permit</a> </li>
             <%-- <li><a href="BarangayRequestDocuments.aspx">Barangay Good Moral</a> </li>--%>
              <li><a href="Certificationofindigency.aspx">Barangay Indigency</a> </li>
             <%-- <li><a href="Barangayoccupanypermit.aspx">Barangay Occupancy Permit</a> </li>--%>
               <li><a href="permittoconstruct.aspx">Barangay Permit to Construct</a> </li>
              <%--<li><a href="Cerficationofresidency.aspx">Barangay Residency</a> </li>--%>
          </ul>
        </li>
           <li class="menu-list">
          <a href="#"><i class="lnr lnr-users"></i>
            <span>Resident Settings<i class="lnr lnr-chevron-right"></i></span></a>
          <ul class="sub-menu-list">
            <li><a href="ProfileSettingsResident.aspx">Account Settings</a> </li>
              <li><a href="ResidentChangePassword.aspx">Change Password</a> </li>
            
          </ul>
        </li>
        <li><a href="transactionhistory.aspx"><i class="fa fa-history"></i> <span>History</span></a></li>
      </ul>
      <!-- //sidebar nav end -->
      <!-- toggle button start -->
      <a class="toggle-btn">
        <i class="fa fa-angle-double-left menu-collapsed__left"><span>Collapse Sidebar</span></i>
        <i class="fa fa-angle-double-right menu-collapsed__right"></i>
      </a>
      <!-- //toggle button end -->
    </div>
  </div>
  <!-- //sidebar menu end -->
  <!-- header-starts -->
  <div class="header sticky-header">

    <!-- notification menu start -->
    <div class="menu-right">
      <div class="navbar user-panel-top">
        
        <div class="user-dropdown-details d-flex">
          
          <div class="profile_details">
            <ul>
              <li class="dropdown profile_details_drop">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" id="dropdownMenu3" aria-haspopup="true"
                            aria-expanded="false">
                            <div class="profile_img">

                                <img src="assets/images/Mabolo_Logo.png" class="rounded-circle" alt="" />
                                <div class="user-active">
                                    <span></span>
                                </div>
                            </div>
                        </a>
                <ul class="dropdown-menu drp-mnu" aria-labelledby="dropdownMenu3">
                  <li class="user-info">
                    <h5 class="user-name"><asp:Label ID="lblname" runat="server" Text="fullname"></asp:Label></h5>
                    <span class="status ml-2">Username: <asp:Label ID="lblsessionlogin" runat="server" Text="Username"></asp:Label></span>
                  </li>
                  <li><asp:LinkButton ID="linkprofile" OnClick="linkprofile_Click" class="fa fa-user" runat="server"> Profile</asp:LinkButton></li>
                  <li> <asp:LinkButton ID="Linkchangepasswprd" OnClick="Linkchangepasswprd_Click" class="fa fa-lock" runat="server"> Change Password</asp:LinkButton></li>
                  <li class="logout"><asp:LinkButton ID="Linklogout" OnClick="Linklogout_Click" OnClientClick="return confirm('Are you sure you want to log out?')" class="fa fa-power-off"  runat="server"> Logout</asp:LinkButton></li>
                </ul>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
    <!--notification menu end -->
  </div>
  <!-- //header-ends -->
  <!-- main content start -->
<div class="main-content">
    <asp:Label ID="lbldate" runat="server" ForeColor="White" Visible="false"  Text="Label"></asp:Label>
    <asp:Label ID="lblactivity" runat="server" ForeColor="White" Visible="false"  Text="Logout"></asp:Label>
  <!-- content -->
  <div class="container-fluid content-top-gap">

    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="ResidentDashboard.aspx">Home</a></li>
        <li class="breadcrumb-item active" aria-current="page">Barangay Business Clearance</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4">
        
      <h1>Hi <span class="text-primary"><asp:Label ID="lblfullname" runat="server" Text=" fullname"></asp:Label></span>, Welcome back</h1>
      <h1><asp:Label ID="lbldates" runat="server" Text="Label"></asp:Label></h1>
    </div>
       <asp:Label ID="lblbarangaycef"  Visible="false" runat="server" Text="Barangay Business Clearance" ></asp:Label>
          
             <asp:Label ID="lblcontrolnumber" Visible="false" runat="server" Text="controlnumber"></asp:Label>
            
   <asp:Label ID="lblID" runat="server" Text="Label" Visible="false" ></asp:Label>
              <asp:Label ID="lbldatemenow" runat="server" Text="Label" Visible="false" ></asp:Label>
              
       <!-- forms -->
        <section class="forms">
            <!-- forms 1 -->
            <div class="card card_border py-2 mb-4">
                <div class="cards__heading">
                    <h3> Business Clearance Document<span></span></h3>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Document No</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtcontrolnumber" aria-describedby="emailHelp" class="form-control input-style" placeholder="Control Nuber" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div  id="ki" runat="server" visible="false" class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Name: </label>
                        <div class="input-group">
                         <asp:TextBox ID="txtfullname" aria-describedby="emailHelp" class="form-control input-style" placeholder="Fullname" runat="server"  ReadOnly="True"></asp:TextBox>                       

                        </div>
                    </div>
                        <div id="sa" runat="server" visible="false" class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Mobile Number</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtcontactnumber" aria-describedby="emailHelp" class="form-control input-style" placeholder="Email" runat="server"  ReadOnly="True"></asp:TextBox>
                    </div>
                            </div>
                    <div id="saa" runat="server" visible="false" class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Email: </label>
                        <div class="input-group">
                            <asp:TextBox ID="txtemail" aria-describedby="emailHelp" class="form-control input-style" placeholder="Email" runat="server"  ReadOnly="True"></asp:TextBox>               

                        </div>
                        </div>

                    <div id="saaa" runat="server" visible="false"  class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Address: </label>
                        <div class="input-group">
                            <asp:TextBox ID="txtaddress" aria-describedby="emailHelp" class="form-control input-style"  placeholder="Address" runat="server"  ReadOnly="True"></asp:TextBox>                    
                    </div>
                        </div>

                        <div class="form-group">
                            <label for="exampleInputPassword1" class="input__label">Purpose :</label>
                            <asp:DropDownList ID="Dropselection" aria-describedby="emailHelp" class="form-control input-style" runat="server">
                                
                            </asp:DropDownList>
                        </div>
                            <br />
                            <br />
                            <div class="form-group">
                                
                                <asp:RequiredFieldValidator ID="rfvpurpose" ControlToValidate="Dropselection" runat="server" InitialValue="0" ErrorMessage="Please Select Purpose" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                            
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="input__label">Business Category List  : </label>
                            <div class="input-group">
                                <br />
                                <asp:DropDownList ID="Dropselectbusinessclearance" aria-describedby="emailHelp" class="form-control input-style" runat="server">
                                    
                                </asp:DropDownList>
                                <br />

                            </div>
                        </div>
                          
                                <div class="form-group">
                                    <label for="exampleInputPassword1" class="input__label">Owner Name: </label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtbusinessownername" aria-describedby="emailHelp" class="form-control input-style" placeholder="Owner Name" required="" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label for="exampleInputPassword1" class="input__label">Business Name: </label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txtbusinessname" aria-describedby="emailHelp" class="form-control input-style" placeholder="Business Name" required=""  runat="server"></asp:TextBox>
                                        </div>

                                         <div class="form-group">
                                        <label for="exampleInputPassword1" class="input__label">Business Address: </label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txtbusinessaddress" aria-describedby="emailHelp" class="form-control input-style" placeholder="Business Address" required=""  runat="server"></asp:TextBox>
                                        </div>


                                        <br />
                                        <br />
                                             <div class="form-group">
                                                 <label for="exampleInputPassword1" class="input__label">Upload : </label>
                                                  <br />

                                                 <p>Please upload the place/location of your business:</p>
                                                 <asp:FileUpload ID="FileUpload2" aria-describedby="emailHelp" class="form-control input-style" runat="server" required=""  />
                                                 <br />
                                                 <asp:Label ID="lblvalidaaadress" Visible="false" runat="server" Text="Label"></asp:Label>
                                                 <br />
                                                 <p>File size: maximum 2 MB</p>
                                                 <p>File extension: .JPEG, .PNG</p>

                                             </div>

                                             

                                  <asp:Button ID="btnsubmit" OnClick="btnsubmit_Click" class="btn btn-primary btn-style mt-4"  runat="server" OnClientClick="return confirm('Would you like to request a document?')" Text="Submit" />
                            </form>
                        </div>
            </div>
            <!-- //forms 1 -->

        </section>
        <!-- //forms -->
  </div>
  <!-- //content -->
</div>
<!-- main content end-->
</section>
<!-- move top -->
<button onclick="topFunction()" id="movetop" class="bg-primary" title="Go to top">
  <span class="fa fa-angle-up"></span>
</button>
<script>
    // When the user scrolls down 20px from the top of the document, show the button
    window.onscroll = function () {
        scrollFunction()
    };

    function scrollFunction() {
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            document.getElementById("movetop").style.display = "block";
        } else {
            document.getElementById("movetop").style.display = "none";
        }
    }

    // When the user clicks on the button, scroll to the top of the document
    function topFunction() {
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    }
</script>
<!-- /move top -->
         <script src="ResidentInterface/assets/js/jquery-3.3.1.min.js"></script>
         <script src="ResidentInterface/assets/js/jquery-1.10.2.min.js"></script>

         <script src="ResidentInterface/assets/js/Chart.min.js"></script>
         <script src="ResidentInterface/assets/js/utils.js"></script>
         <script src="ResidentInterface/assets/js/bar.js"></script>
         <script src="ResidentInterface/assets/js/linechart.js"></script>

         <script src="ResidentInterface/assets/js/jquery.nicescroll.js"></script>
         <script src="ResidentInterface/assets/js/scripts.js"></script>

<!-- close script -->
<script>
    var closebtns = document.getElementsByClassName("close-grid");
    var i;

    for (i = 0; i < closebtns.length; i++) {
        closebtns[i].addEventListener("click", function () {
            this.parentElement.style.display = 'none';
        });
    }
</script>
<!-- //close script -->

<!-- disable body scroll when navbar is in active -->
<script>
    $(function () {
        $('.sidebar-menu-collapsed').click(function () {
            $('body').toggleClass('noscroll');
        })
    });
</script>
<!-- disable body scroll when navbar is in active -->

 <!-- loading-gif Js -->
         <script src="ResidentInterface/assets/js/modernizr.js"></script>


 <script>
     $(window).load(function () {
         // Animate loader off screen
         $(".se-pre-con").fadeOut("slow");;
     });
 </script>
 <!--// loading-gif Js -->

<!-- Bootstrap Core JavaScript -->
         <script src="ResidentInterface/assets/js/bootstrap.min.js"></script>

</body>

       
	
</asp:Content>
