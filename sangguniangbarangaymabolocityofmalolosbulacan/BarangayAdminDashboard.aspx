<%@ Page Title="" Language="C#" MasterPageFile="~/BarangayAdminDashboard.Master" AutoEventWireup="true" CodeBehind="BarangayAdminDashboard.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.BarangayAdminDashboard1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Dashboard- Sangguniang Barangay Mabolo, Malolos City</title>
   <!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="Index/img/Mabolo_Logo.png" type="image/x-icon" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
<body>
  <div class="se-pre-con"></div>
<section>
  <!-- sidebar menu start -->
  <div class="sidebar-menu sticky-sidebar-menu">

    <!-- logo start -->
    <div class="logo">
      <h1><a href="BarangayAdminDashboard.aspx">Mabolo</a></h1>
    </div>

    <div class="logo-icon text-center">
      <a href="BarangayAdminDashboard.aspx" title="logo"><img src="assets/images/logo.png" alt="logo-icon"> </a>
    </div>
    <!-- //logo end -->

    <div class="sidebar-menu-inner">
        <asp:Label ID="lblsessionlogin" runat="server" Visible="false" Text="Label" ForeColor="#033C73"></asp:Label>
                    <asp:Label ID="lblensission" runat="server" Visible="false" Text="End Session" ForeColor="#033C73"></asp:Label>
                    <asp:Label ID="lbllogout" runat="server" Text="Logout" Visible="false" ForeColor="#033C73"></asp:Label>
        <!-- sidebar nav start -->
      <ul class="nav nav-pills nav-stacked custom-nav">
        <li class="active"><a href="BarangayAdminDashboard.aspx"><i class="fa fa-tachometer"></i><span> Dashboard</span></a>
        </li>
          <!--Barangay Clearance-->
        <li class="menu-list">
          <a href="#"><i class="lnr lnr-file-add"></i>
            <span>Barangay Clearance<i class="lnr lnr-chevron-right"></i></span></a>
          <ul class="sub-menu-list">
              
            <li><a href="BarangayRequestDocument.aspx">Pending</a> </li>
              <li><a href="ClaimDocumentsRequest.aspx">Ready For Pickup</a> </li>
              <li><a href="ClaimRequestedDocument.aspx">Claimed</a> </li>
          </ul>
        </li>
          
          <!--Barangay Fencing Permit-->
          <li class="menu-list">
          <a href="#"><i class="lnr lnr-file-add"></i>
            <span>Barangay Fencing Permit<i class="lnr lnr-chevron-right"></i></span></a>
          <ul class="sub-menu-list">
            <li><a href="FencingPermitPending.aspx">Pending</a> </li>
              <li><a href="Fencingpermitreadyforpickup.aspx">Ready For Pickup</a> </li>
              <li><a href="FencingPermitClaimDocuments.aspx">Claimed</a> </li>
          </ul>
        </li>

          <!--Excavation Cutting Permit-->
          <li class="menu-list">
          <a href="#"><i class="lnr lnr-file-add"></i>
            <span>Excavation Cutting Permit<i class="lnr lnr-chevron-right"></i></span></a>
          <ul class="sub-menu-list">
            <li><a href="excavationcuttingpermitpending.aspx">Pending</a> </li>
              <li><a href="excavationcuttingpermitreadytopickup.aspx">Ready To Pickup</a> </li>
              <li><a href="excavationcuttingpermitclaim.aspx">Claimed</a> </li>
          </ul>
        </li>

           <!--Barangay Indigency-->
          <li class="menu-list">
          <a href="#"><i class="lnr lnr-file-add"></i>
            <span>Barangay Indigency<i class="lnr lnr-chevron-right"></i></span></a>
          <ul class="sub-menu-list">
            <li><a href="barangayindigencyPending.aspx">Pending</a> </li>
              <li><a href="barangayindigencyreadytopickup.aspx">Ready To Pickup</a> </li>
              <li><a href="barangayindigencyClaim.aspx">Claimed</a> </li>
          </ul>
        </li>
          
          <!--Barangay Business Clearance-->
          <li class="menu-list">
          <a href="#"><i class="lnr lnr-file-add"></i>
            <span>Business Clearance<i class="lnr lnr-chevron-right"></i></span></a>
          <ul class="sub-menu-list">
            
             <li><a href="barangayclearanceunregistered.aspx">Pending </a> </li>
              <li><a href="BarangayBusinessClearanceRegistered.aspx">Approved</a> </li>
               <li><a href="BarangayBusinessClearanceDisapproved.aspx">Denied  </a> </li>
              <li><a href="ReadytopicupBusinessClearance.aspx">Ready To Pickup</a> </li>
              <li><a href="ClaimdocumentsBusinessClearance.aspx">Claim Documents</a> </li>
              
          </ul>
        </li>
          <!--Barangay Permit to Contruct-->
           <li class="menu-list">
          <a href="#"><i class="lnr lnr-file-add"></i>
            <span>Permit To Construct<i class="lnr lnr-chevron-right"></i></span></a>
          <ul class="sub-menu-list">
            
            <li><a href="PermitoConstrucPending.aspx">Pending </a> </li>
               <li><a href="PermittocontrustReadytopicup.aspx">Ready To Pickup </a> </li>
              <li><a href="PermittoconstrucClaim.aspx">Claimed</a> </li>
            
              
          </ul>
        </li>
           <li class="menu-list">
          <a href="#"><i class="lnr lnr-users"></i>
            <span>Users<i class="lnr lnr-chevron-right"></i></span></a>
          <ul class="sub-menu-list">
            <li><a href="BarangayResidentPendingRegister.aspx">Pending</a> </li>
              <li><a href="DisApprovedApplicationRegisterResident.aspx">Denied</a> </li>
            <li><a href="BarangayRegisterResident.aspx">Registered </a> </li>
          </ul>
        </li>
          <li><a href="BarangayAdminRegister.aspx"><i class="lnr lnr-users"></i> <span>Add account barangay mabolo officals</span></a></li>
        <li><a href="ConcernsMessageUser.aspx"><i class="lnr lnr-envelope"></i> <span>Concern Message</span></a></li>
        <li><a href="History.aspx"><i class="fa fa-history"></i> <span>History</span></a></li>
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
                    <h5 class="user-name"><asp:Label ID="lblnameofoffical" runat="server" Text=" fullname"></asp:Label></h5>
                    <span class="status ml-2"><asp:Label ID="lblbarangayofficals" runat="server" Text="Barangay Position"></asp:Label></span>
                  </li>
                  <li><asp:LinkButton ID="linkprofile" OnClick="linkprofile_Click" class="fa fa-user" runat="server"><tb>My Profile</tb> </asp:LinkButton> </li>
                  <li> <asp:LinkButton ID="Linkchangepasswprd" OnClick="Linkchangepasswprd_Click" class="fa fa-lock" runat="server"> Change Password</asp:LinkButton> </li>
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
        <li class="breadcrumb-item"><a href="BarangayAdminDashboard.aspx">Home</a></li>
        <li class="breadcrumb-item active" aria-current="page">Dashboard</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4">
        
      <h1>Hi <span class="text-primary"><asp:Label ID="lblfullname" runat="server" Text=" fullname"></asp:Label></span> Welcome back</h1>
      <h1><asp:Label ID="lbldates" runat="server" Text="Label"></asp:Label></h1>
    </div>

    <!-- statistics data -->
    <div class="statistics">
        <h1>Users</h1>
        <br />
       
      <div class="row">
        <div class="col-xl-6 pr-xl-2">
          <div class="row">
               <!--Register Users-->
            <div class="col-sm-6 pr-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
              <a href="BarangayRegisterResident.aspx"><i class="lnr lnr-users"></i></a>
                <h3 class="text-primary number"><asp:Label ID="lblnewaccount" runat="server" Text="Label"></asp:Label></h3>
                <p class="stat-text">Registered Users</p>
                  
              </div>
            </div>
              <!--Denied Users-->
            <div class="col-sm-6 pl-sm-2 statistics-grid">
                 <div class="card card_border border-primary-top p-4">
                  <a href="DisApprovedApplicationRegisterResident.aspx"><i class="lnr lnr-users"> </i></a>
                <h3 class="text-primary number"><asp:Label ID="lbldenineregisterusers" runat="server" Text="Label"></asp:Label></h3>
                  <br />
                <p class="stat-text">Denied Register Users</p>
                  
              </div>
             
            </div>
          </div>
        </div>
        <div class="col-xl-6 pl-xl-2">
          <div class="row">
              <div class="col-sm-6 pr-sm-2 statistics-grid">
                   <!--Pending Users-->
                  <div class="card card_border border-primary-top p-4">
                      <a href="BarangayResidentPendingRegister.aspx"><i class="lnr lnr-users"></i></a>
                      <h3 class="text-secondary number">
                          <asp:Label ID="lblpendingregister" runat="server" Text="Label"></asp:Label></h3>
                      <p class="stat-text">Pending Register Users</p>

                  </div>

              </div>
           
          </div>
        </div>
          

      </div>
    </div>
    <!-- //statistics data -->
      <br />
      <br />
       <!-- statistics data -->
    <div class="statistics">
        <h1>Request Documents</h1>
        <br />
      <div class="row">
       <div class="col-xl-6 pr-xl-2">
          <div class="row">
            <!--Barangay Clearance-->
            <div class="col-sm-6 pl-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                <a href="BarangayRequestDocument.aspx"><i class="lnr lnr-book"> </i></a>
                <h3 class="text-secondary number"><asp:Label ID="lblbarangayclearance" runat="server" Text="Label"></asp:Label></h3>
                <p class="stat-text">Barangay Clearance</p>
                 
              </div>
            </div>
               <!--Business Clearance-->
               <div class="col-sm-6 pr-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                <a href="barangayclearanceunregistered.aspx"><i class="lnr lnr-book"> </i></a>
                <h3 class="text-primary number"><asp:Label ID="lblbarangaybusinessclearance" runat="server" Text="Label"></asp:Label></h3>
                  <br />
                <p class="stat-text">Barangay Business Clearance</p>
                  
              </div>
            </div>
          </div>
        </div>
           <div class="col-xl-6 pr-xl-2">
          <div class="row">
            <div class="col-sm-6 pr-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                <a href="FencingPermitPending.aspx"><i class="lnr lnr-book"> </i></a>
                <h3 class="text-success number"> <asp:Label ID="lblbarangayfencingpermit" runat="server" Text="Label"></asp:Label></h3>
                  <br />
                <p class="stat-text">Barangay Fencing Permit</p>
                 
              </div>
            </div>
            <div class="col-sm-6 pl-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                  <a href="barangayindigencyPending.aspx"><i class="lnr lnr-book"> </i></a>
                  <br />
                <h3 class="text-secondary number"><asp:Label ID="lblbaranagyindigency" runat="server" Text="Label"></asp:Label></h3>
                <p class="stat-text">Barangay Indigency</p>
                 
              </div>
            </div>
          </div>
        </div>
           <div class="col-xl-6 pr-xl-2">
          <div class="row">
            <div class="col-sm-6 pr-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                <a href="excavationcuttingpermitpending.aspx"><i class="lnr lnr-book"> </i></a>
                <h3 class="text-success number"> <asp:Label ID="lblbarangayexcavationcuttingpermit" runat="server" Text="Label"></asp:Label></h3>
                  <br />
                <p class="stat-text">Barangay Excavation Cutting Permit</p>
                 
              </div>
            </div>
            <div class="col-sm-6 pl-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                  <a href="PermitoConstrucPending.aspx"><i class="lnr lnr-book"> </i></a>
                  <br />
                <h3 class="text-secondary number"><asp:Label ID="lblbarangaypermittoconstruct" runat="server" Text="Label"></asp:Label></h3>
                <p class="stat-text">Barangay Permit to Construct</p>
                 
              </div>
            </div>
          </div>
        </div>

      </div>
    </div>
    <!-- //statistics data -->
      <br />
      <br />
       <!-- statistics data -->
    <div class="statistics">
        <h1>Claimed Documents</h1>
        <br />
      <div class="row">
       <div class="col-xl-6 pr-xl-2">
          <div class="row">
           
            <div class="col-sm-6 pl-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                <a href="ClaimRequestedDocument.aspx"><i class="lnr lnr-book"> </i></a>
                <h3 class="text-secondary number"><asp:Label ID="lblclaimdocumentsbarangayclearance" runat="server" Text="Label"></asp:Label></h3>
                <p class="stat-text">Barangay Clearance</p>
                 
              </div>
            </div>
               <div class="col-sm-6 pr-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                <a href="ClaimdocumentsBusinessClearance.aspx"><i class="lnr lnr-book"> </i></a>
                <h3 class="text-primary number"><asp:Label ID="lblclaimdocumentsbarangaybusinessclearance" runat="server" Text="Label"></asp:Label></h3>
                  <br />
                <p class="stat-text">Barangay Business Clearance</p>
                  
              </div>
            </div>
          </div>
        </div>
           <div class="col-xl-6 pr-xl-2">
          <div class="row">
            <div class="col-sm-6 pr-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                <a href="FencingPermitClaimDocuments.aspx"><i class="lnr lnr-book"> </i></a>
                <h3 class="text-success number"> <asp:Label ID="lblclaimdocumentsbarangayfencingpermit" runat="server" Text="Label"></asp:Label></h3>
                  <br />
                <p class="stat-text">Barangay Fencing Permit</p>
                 
              </div>
            </div>
            <div class="col-sm-6 pl-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                  <a href="barangayindigencyClaim.aspx"><i class="lnr lnr-book"> </i></a>
                  <br />
                <h3 class="text-secondary number"><asp:Label ID="lblclaimdocumentsbarangayindigency" runat="server" Text="Label"></asp:Label></h3>
                <p class="stat-text">Barangay Indigency</p>
                 
              </div>
            </div>
          </div>
        </div>
           <div class="col-xl-6 pr-xl-2">
          <div class="row">
            <div class="col-sm-6 pr-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                <a href="excavationcuttingpermitclaim.aspx"><i class="lnr lnr-book"> </i></a>
                <h3 class="text-success number"> <asp:Label ID="lblclaimdocumentsbarangayexcavationcuttingpermit" runat="server" Text="Label"></asp:Label></h3>
                  <br />
                <p class="stat-text">Barangay Excavation Cutting Permit</p>
                 
              </div>
            </div>
            <div class="col-sm-6 pl-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                  <a href="PermittoconstrucClaim.aspx"><i class="lnr lnr-book"> </i></a>
                  <br />
                <h3 class="text-secondary number"><asp:Label ID="lblclaimdocumentsbarangaypermittoconstruct" runat="server" Text="Label"></asp:Label></h3>
                <p class="stat-text">Barangay Permit to Construct</p>
                 
              </div>
            </div>
          </div>
        </div>

      </div>
    </div>
    <!-- //statistics data -->

    <!-- accordions -->
    <div class="accordions">
      <div class="row">
        <!-- accordion style 1 -->
        <div class="col-lg-12 mb-4">
          <div class="card card_border">
            <div class="card-header chart-grid__header">
              notifications
            </div>
            <div class="card-body">
              <div class="accordion" id="accordionExample">
                <div class="card">
                  <div class="card-header bg-white p-0" id="headingOne">
                    <a href="#" class="card__title p-3" data-toggle="collapse" data-target="#collapseOne"
                      aria-expanded="true" aria-controls="collapseOne">New List Notification</a>
                  </div>

                  <div id="collapseOne" class="collapse show" aria-labelledby="headingOne"
                    data-parent="#accordionExample">
                    <div class="card-body para__style">
                      
                      
                    </div>
                  </div>
                </div>
               
              </div>
            </div>
          </div>
        </div>
        <!-- //accordion style 1 -->
      </div>
    </div>
    <!-- //accordions -->

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


<script src="assets/js/jquery-3.3.1.min.js"></script>
<script src="assets/js/jquery-1.10.2.min.js"></script>

<!-- chart js -->
<script src="assets/js/Chart.min.js"></script>
<script src="assets/js/utils.js"></script>
<!-- //chart js -->

<!-- Different scripts of charts.  Ex.Barchart, Linechart -->
<script src="assets/js/bar.js"></script>
<script src="assets/js/linechart.js"></script>
<!-- //Different scripts of charts.  Ex.Barchart, Linechart -->


<script src="assets/js/jquery.nicescroll.js"></script>
<script src="assets/js/scripts.js"></script>

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
 <script src="assets/js/modernizr.js"></script>
 <script>
     $(window).load(function () {
         // Animate loader off screen
         $(".se-pre-con").fadeOut("slow");;
     });
 </script>
 <!--// loading-gif Js -->

<!-- Bootstrap Core JavaScript -->
<script src="assets/js/bootstrap.min.js"></script>

</body>

  
</asp:Content>
