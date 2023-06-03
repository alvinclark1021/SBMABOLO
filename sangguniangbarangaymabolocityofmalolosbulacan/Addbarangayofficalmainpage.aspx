<%@ Page Title="" Language="C#" MasterPageFile="~/BarangayAdminDashboard.Master" AutoEventWireup="true" CodeBehind="Addbarangayofficalmainpage.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.Addbarangayofficalmainpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

  <title></title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
  <!-- Template CSS -->
  <link rel="stylesheet" href="assets/css/style-starter.css">

  <!-- google fonts -->
  <link href="//fonts.googleapis.com/css?family=Nunito:300,400,600,700,800,900&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
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
        <asp:Label ID="lblchangepassword" runat="server" Text="Chnage Profile information" Visible="false" ForeColor="#033C73"></asp:Label>
                
       <!-- sidebar nav start -->
      <ul class="nav nav-pills nav-stacked custom-nav">
        <li class="active"><a href="BarangayAdminDashboard.aspx"><i class="fa fa-tachometer"></i><span> Dashboard</span></a>
        </li>
        <li class="menu-list">
          <a href="#"><i class="lnr lnr-file-add"></i>
            <span>Request Documents<i class="lnr lnr-chevron-right"></i></span></a>
          <ul class="sub-menu-list">
            <li><a href="BarangayRequestDocument.aspx">Pending Request Documents</a> </li>
            <li><a href="barangayclearanceunregistered.aspx">Pending Business Clearance Documents</a> </li>
              <li><a href="BarangayRequestDocument.aspx">Claim Request Documents</a> </li>
            <li><a href="barangayclearanceunregistered.aspx">Claim Request Business Clearance Document</a> </li>
              <li><a href="BarangayBusinessClearanceRegistered.aspx">Business Clearance Registered</a> </li>
            <li><a href="BarangayBusinessClearanceDisapproved.aspx">Business Clearance Disapproved</a> </li>
          </ul>
        </li>
           <li class="menu-list">
          <a href="#"><i class="lnr lnr-users"></i>
            <span>Users<i class="lnr lnr-chevron-right"></i></span></a>
          <ul class="sub-menu-list">
            <li><a href="BarangayResidentPendingRegister.aspx">Pending registered users</a> </li>
              <li><a href="DisApprovedApplicationRegisterResident.aspx">Denied Register Users</a> </li>
            <li><a href="BarangayRegisterResident.aspx">Registered Users</a> </li>
          </ul>
        </li>
          <li><a href="BarangayAdminRegister.aspx"><i class="lnr lnr-users"></i> <span>Add account barangay mabolo officals</span></a></li>
           <li><a href="Addbarangayofficalmainpage.aspx"><i class="lnr lnr-page-break"></i> <span>Barangay Officals Display Main Page</span></a></li>
           <li><a href="Addpurposes.aspx"><i class="lnr lnr-menu-circle"></i> <span>Add Purposes for requested documents</span></a></li>
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
                    <h5 class="user-name"><asp:Label ID="lblfullnames" runat="server" Text=" fullname"></asp:Label></h5>
                    <span class="status ml-2"><asp:Label ID="lblbarangayofficals" runat="server" Text="Barangay Position"></asp:Label></span>
                  </li>
                  <li><asp:LinkButton ID="linkprofile" OnClick="linkprofile_Click" class="fa fa-user" runat="server"> My Profile</asp:LinkButton> </li>
                  <li> <asp:LinkButton ID="Linkchangepasswprd" OnClick="Linkchangepasswprd_Click" class="fa fa-lock" runat="server"> Change Password</asp:LinkButton> </li>
                  <li class="logout"><asp:LinkButton ID="Linklogout" OnClick="Linklogout_Click" class="fa fa-power-off"  runat="server"> Logout</asp:LinkButton></li>
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
        <li class="breadcrumb-item active" aria-current="page">Add Offical Display Main Page</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4">
        
      <h1>Hi <span class="text-primary"><asp:Label ID="lblfullname" runat="server" Text=" fullname"></asp:Label></span>, Welcome back</h1>
      <h1><asp:Label ID="lbldates" runat="server" Text="Label"></asp:Label></h1>
      <p>Very detailed & featured admin.</p>
    </div>
        <!-- forms -->
        <section class="forms">
            <!-- forms 1 -->
            <div class="card card_border py-2 mb-4">
                <div class="cards__heading">
                    <h3>Add Offical Display for main page<span></span></h3>
                </div>

                  <div class="card-body">
                    <div class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Barangay Officals</label>
                        <div class="input-group">
                            <asp:textbox ID="txtSearch" runat="server" placeholder="Barangay Officals" class="form-control input-style" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"  />                        
                            </div>
                        </div>
                      <asp:Button ID="Btnserachbar" class="btn btn-primary btn-style mt-4" OnClick="Btnserachbar_Click" runat="server" Text="Search" />
                 
                       <br />
                    <br />
                      
                    </div>
                    
                  <asp:Repeater ID="rptProducts" runat="server">
                            <HeaderTemplate>
                                 <table class="table table-sm table-hover">
                                    <thead class="text-primary">
                                        <tr>
                                            <th style="border: 1px solid black">Name</th>
                                            <th style="border: 1px solid black">Postion</th>
                                            <th style="border: 1px solid black">Profile Image</th>
                                            <th style="border: 1px solid black">Action</th>
                                       
                                        </tr>
                                    </thead>        
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td style="width: 24%">
                                                <asp:Label ID="lblid" Text='<%#Eval("ID") %>' runat="server" Visible="false" />
                                                <asp:Label ID="lblname" Text='<%#Eval("BarangayOfficalName") %>' runat="server" />
                                            </td>
                                            <td style="width: 20%">
                                              <asp:Label ID="lblpostion" Text='<%#Eval("BarangayOfficalPosition") %>' runat="server" /> 
                                            </td>
                                           
                                             <td style="width: 11%">
                                                <img src='BarangayOfficalsImage/<%#Eval("BarangayOfficalImage") %>' width="140" />
                                            </td>
                                            <td style="width: 13%">
                                                <asp:linkbutton text="Edit" ID="lnkeditofficals" runat="server" class="btn btn-outline-secondary" CssClass="btn-success" OnClick="lnkeditofficals_Click"  />
                                                 <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" class="btn btn-outline-secondary" CssClass="btn-success" Text="Delete" runat="server" />
                                            </td>
                                           
                                        </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
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
