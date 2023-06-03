<%@ Page Title="" Language="C#" MasterPageFile="~/BarangayAdminDashboard.Master" AutoEventWireup="true" CodeBehind="Businessclearanceprinting.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.Businessclearanceprinting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Dashboard- Sangguniang Barangay Mabolo, Malolos City</title>
   <!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="Index/img/Mabolo_Logo.png" type="image/x-icon" />
    <link href="OutDocument/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
  <div class="se-pre-con"></div>
<section>
  <!-- sidebar menu start -->
  <div class="sidebar-menu sticky-sidebar-menu" id="side-bar">

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
         <asp:Label ID="lblemail" runat="server" Text="Label" Visible="false" ForeColor="#033C73"></asp:Label>
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
        <li class="breadcrumb-item active" aria-current="page">Business Clearance</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4" id="hi-administer">
        
      <h1>Hi <span class="text-primary"><asp:Label ID="lblfullname" runat="server" Text=" fullname"></asp:Label></span> Welcome back</h1>
      <h1><asp:Label ID="lbldates" runat="server" Text="Label"></asp:Label></h1>
    </div>
       <!-- forms -->
        <section class="forms">
            <!-- forms 1 -->
            <div class="card card_border py-2 mb-4">
                                   <span id="printB">
                  
                                       <asp:Button ID="printButton" Style="margin-left: -0.3%;" runat="server" OnClick="printButton_Click" Text="Print" OnClientClick="javascript:(function printFullDocument() {
    if (confirm('Are you sure you want to proceed?')) {
        const contentToPrint = document.querySelector('#content-to-print');
        const originalContent = document.querySelector('#original-content');
        contentToPrint.style.transform = 'scale(1.5)';
        document.title = 'Request Document';
        document.body.style.transform = 'scale(1.1)';
        document.querySelector('#side-bar').style.display = 'none';
        document.querySelector('#hi-administer').style.display = 'none';
        document.querySelector('#printB').style.display = 'none';
        window.print();
        document.body.innerHTML = originalContent.innerHTML;
    }
})()"
                                           Font-Bold="True" Font-Size="14pt" Width="281px" Height="40px" BackColor="#CC0000" ForeColor="White" />
                </span>

                <div class="cards__heading">
                    <section id="content-to-print">
                         <img style="position: absolute; top: 11.06in; left: 0.52in; width: 8.23in; height: 0.01in" src="vi_1.png" />
                        <img src="OutDocument/ri_1.png" style="position: absolute; top: 2.44in; left: 0in; width: 9.33in; height: 8.01in" src="ri_1.png" />

                        <div style="position: absolute; top: 0.72in; left: 3.66in; width: 2.00in; line-height: 0.25in;">
                            <div style="position: relative; left: 0.03in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">Republika</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000"> </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 0.72in; left: 3.66in; width: 2.00in; line-height: 0.25in;">
                            <div style="position: relative; left: 0.95in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">ng </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 0.72in; left: 3.66in; width: 2.00in; line-height: 0.25in;">
                            <div style="position: relative; left: 1.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">Pilipinas</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 0.94in; left: 3.66in; width: 2.00in; line-height: 0.25in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">Lalawigan</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000"> </span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 0.94in; left: 3.66in; width: 2.00in; line-height: 0.25in;">
                            <div style="position: relative; left: 0.96in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">ng </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 0.94in; left: 3.66in; width: 2.00in; line-height: 0.25in;">
                            <div style="position: relative; left: 1.25in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">Bulakan</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 1.39in; left: 3.64in; width: 2.04in; line-height: 0.25in;">
                            <div style="position: relative; left: 0.19in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">Barangay </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 1.39in; left: 3.64in; width: 2.04in; line-height: 0.25in;">
                            <div style="position: relative; left: 1.11in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">Mabolo</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 1.61in; left: 3.64in; width: 2.04in; line-height: 0.25in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">Tel. </span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 1.61in; left: 3.64in; width: 2.04in; line-height: 0.25in;">
                            <div style="position: relative; left: 0.33in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">No.. </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 1.61in; left: 3.64in; width: 2.04in; line-height: 0.25in;">
                            <div style="position: relative; left: 0.74in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">(044) </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 1.61in; left: 3.64in; width: 2.04in; line-height: 0.25in;">
                            <div style="position: relative; left: 1.22in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">760</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">-</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000">4456</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Century Gothic; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 1.94in; left: 2.56in; width: 4.21in; line-height: 0.29in;"><span style="font-style: normal; font-weight: bold; font-size: 14pt; font-family: Times New Roman; color: #000000">OFFICE </span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 1.94in; left: 2.56in; width: 4.21in; line-height: 0.29in;">
                            <div style="position: relative; left: 0.86in;"><span style="font-style: normal; font-weight: bold; font-size: 14pt; font-family: Times New Roman; color: #000000">OF </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 1.94in; left: 2.56in; width: 4.21in; line-height: 0.29in;">
                            <div style="position: relative; left: 1.19in;"><span style="font-style: normal; font-weight: bold; font-size: 14pt; font-family: Times New Roman; color: #000000">THE </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 1.94in; left: 2.56in; width: 4.21in; line-height: 0.29in;">
                            <div style="position: relative; left: 1.69in;"><span style="font-style: normal; font-weight: bold; font-size: 14pt; font-family: Times New Roman; color: #000000">BARANGAY </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 1.94in; left: 2.56in; width: 4.21in; line-height: 0.29in;">
                            <div style="position: relative; left: 2.94in;"><span style="font-style: normal; font-weight: bold; font-size: 14pt; font-family: Times New Roman; color: #000000">CHAIRMAN</span><span style="font-style: normal; font-weight: bold; font-size: 14pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 2.51in; left: 2.41in; width: 4.52in; line-height: 0.27in;"><span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Lucida Calligraphy; color: #000000">BARANGAY </span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 2.51in; left: 2.41in; width: 4.52in; line-height: 0.27in;">
                            <div style="position: relative; left: 1.60in;"><span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Lucida Calligraphy; color: #000000">BUSINESS </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 2.51in; left: 2.41in; width: 4.52in; line-height: 0.27in;">
                            <div style="position: relative; left: 2.88in;"><span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Lucida Calligraphy; color: #000000">CLEARANCE</span><span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Lucida Calligraphy; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 3.09in; left: 2.48in; width: 4.35in; line-height: 0.19in;"><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000">This </span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 3.09in; left: 2.48in; width: 4.35in; line-height: 0.19in;">
                            <div style="position: relative; left: 0.29in;"><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000">is </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.09in; left: 2.48in; width: 4.35in; line-height: 0.19in;">
                            <div style="position: relative; left: 0.42in;"><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000">to </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.09in; left: 2.48in; width: 4.35in; line-height: 0.19in;">
                            <div style="position: relative; left: 0.57in;"><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000">certify </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.09in; left: 2.48in; width: 4.35in; line-height: 0.19in;">
                            <div style="position: relative; left: 0.98in;"><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000">that </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.09in; left: 2.48in; width: 4.35in; line-height: 0.19in;">
                            <div style="position: relative; left: 1.25in;"><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000">business </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.09in; left: 2.48in; width: 4.35in; line-height: 0.19in;">
                            <div style="position: relative; left: 1.77in;"><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000">or </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.09in; left: 2.48in; width: 4.35in; line-height: 0.19in;">
                            <div style="position: relative; left: 1.93in;"><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000">trade </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.09in; left: 2.48in; width: 4.35in; line-height: 0.19in;">
                            <div style="position: relative; left: 2.27in;"><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000">activity </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.09in; left: 2.48in; width: 4.35in; line-height: 0.19in;">
                            <div style="position: relative; left: 2.74in;"><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000">described </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.09in; left: 2.48in; width: 4.35in; line-height: 0.19in;">
                            <div style="position: relative; left: 3.33in;"><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000">described </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.09in; left: 2.48in; width: 4.35in; line-height: 0.19in;">
                            <div style="position: relative; left: 3.93in;"><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000">below;</span><span style="font-style: normal; font-weight: bold; font-size: 9pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 3.61in; left: 2.00in; width: 5.32in; line-height: 0.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">
                            <asp:Label ID="lblbusinessname" align="center" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large"></asp:Label></span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                            <br />
                            </SPAN></div>
                        <div style="position: absolute; top: 3.82in; left: 2.00in; width: 5.32in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.36in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">(Business </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.82in; left: 2.00in; width: 5.32in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.11in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Name </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.82in; left: 2.00in; width: 5.32in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.59in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">or </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.82in; left: 2.00in; width: 5.32in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.79in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Trade </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 3.82in; left: 2.00in; width: 5.32in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.26in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Activity)</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 4.23in; left: 2.00in; width: 5.32in; line-height: 0.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">  <asp:Label ID="lbladdress" runat="server" Text="Label" Font-Bold="True" Font-Size="Large"></asp:Label> </span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                            <br />
                            </SPAN></div>
                        <div style="position: absolute; top: 4.44in; left: 2.00in; width: 5.32in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.25in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">(Location)</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 4.86in; left: 1.95in; width: 5.41in; line-height: 0.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">
                            <asp:Label ID="lblfullnamesss" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large"></asp:Label> </span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                            <br />
                            </SPAN></div>
                        <div style="position: absolute; top: 5.07in; left: 1.95in; width: 5.41in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.95in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">(Operator/Manager)</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 5.49in; left: 1.95in; width: 5.41in; line-height: 0.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">
                            <asp:Label ID="lbladdressaaa" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large"></asp:Label> </span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                            <br />
                            </SPAN></div>
                        <div style="position: absolute; top: 5.70in; left: 1.95in; width: 5.41in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.32in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">(Address</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">)</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Proposed </span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.72in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">to </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.91in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">be </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.13in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">established </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.98in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">in </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.17in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">this </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.48in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Barangay </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.22in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">an </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.43in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">is </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.60in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">being </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.05in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">applied </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.63in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">for </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.89in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">a </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.01in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Barangay </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.76in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Clearance </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 6.53in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">to </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 6.71in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">be </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 6.93in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">used </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 7.31in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">in </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.11in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 7.50in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">securing</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 6.32in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.17in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">corresponding </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.32in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.25in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Mayors </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.32in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.86in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Permit </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.32in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.39in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">has </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.32in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.67in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">been </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.32in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.06in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">found </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.32in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.53in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">to </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.32in; left: 0.58in; width: 8.16in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.72in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">be;</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">_____in </span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.64in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">conforming </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.53in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">with </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.89in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">the </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.15in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">provisions </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.95in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">of </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.15in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">existing </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.76in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Barangay </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.50in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Ordinances,rules </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.77in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">and </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 6.07in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">regulations </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 6.92in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">being </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 7.37in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">enforced </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.74in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 8.04in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">in</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 6.95in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.57in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">this </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 6.95in; left: 0.55in; width: 8.23in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.87in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Barangay.</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">___interposes </span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.05in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">no </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.28in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">objecti</span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.78in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">on </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.01in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">fot </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.25in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">the </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.52in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">issuance </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.18in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">of </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.38in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">the </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.65in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">corresponding </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.73in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Mayors </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.33in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Permit </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.86in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">being </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 6.31in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">applied </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.37in; left: 1.06in; width: 7.20in; line-height: 0.24in;">
                            <div style="position: relative; left: 6.89in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">for.</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 7.79in; left: 1.07in; width: 7.18in; line-height: 0.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Issued </span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 7.79in; left: 1.07in; width: 7.18in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.51in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">this  </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.79in; left: 1.07in; width: 7.18in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.72in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">of </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.79in; left: 1.07in; width: 7.18in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.91in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">
                                <asp:Label ID="lbldatesssss" runat="server" Text="Label"></asp:Label> </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.79in; left: 1.07in; width: 7.18in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.14in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">for </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.79in; left: 1.07in; width: 7.18in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.40in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">whatever </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.79in; left: 1.07in; width: 7.18in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.11in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">legal </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.79in; left: 1.07in; width: 7.18in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.51in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">purposes </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.79in; left: 1.07in; width: 7.18in; line-height: 0.24in;">
                            <div style="position: relative; left: 6.20in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">it </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.79in; left: 1.07in; width: 7.18in; line-height: 0.24in;">
                            <div style="position: relative; left: 6.35in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">may </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.79in; left: 1.07in; width: 7.18in; line-height: 0.24in;">
                            <div style="position: relative; left: 6.70in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">serve.</span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 7.79in; left: 1.07in; width: 7.18in; line-height: 0.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span>
                            <br />
                            </SPAN></div>
                        <div style="position: absolute; top: 8.21in; left: 0.55in; width: 1.98in; line-height: 0.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Control </span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 8.21in; left: 0.55in; width: 1.98in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.60in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"><asp:Label ID="lblcontrolnumber" runat="server" Text="Label" Font-Bold="True" Font-Size="Large"></asp:Label></span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">___</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 8.41in; left: 0.55in; width: 1.98in; line-height: 0.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">OR </span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 8.41in; left: 0.55in; width: 1.98in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.30in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">No;______________</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 9.76in; left: 6.66in; width: 2.11in; line-height: 0.21in;"><span style="font-style: normal; font-weight: bold; font-size: 10pt; font-family: Times New Roman; color: #000000">IGG. </span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 9.76in; left: 6.66in; width: 2.11in; line-height: 0.21in;">
                            <div style="position: relative; left: 0.37in;"><span style="font-style: normal; font-weight: bold; font-size: 10pt; font-family: Times New Roman; color: #000000">MELENCIO </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.76in; left: 6.66in; width: 2.11in; line-height: 0.21in;">
                            <div style="position: relative; left: 1.25in;"><span style="font-style: normal; font-weight: bold; font-size: 10pt; font-family: Times New Roman; color: #000000">F.TAMAYO</span><span style="font-style: normal; font-weight: bold; font-size: 10pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN><br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.07in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.15in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.22in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.29in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.36in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.44in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.51in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.58in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.65in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.73in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.80in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.87in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 0.95in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.02in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.09in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.17in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.24in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.31in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.38in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.46in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.53in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.60in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.67in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.75in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.82in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.89in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 1.97in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.04in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.11in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.19in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.26in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.33in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.40in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.48in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.55in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.62in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.69in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.77in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.84in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.91in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 2.99in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.06in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.13in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.21in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.28in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.35in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.42in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.50in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.57in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.64in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.72in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.79in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.86in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 3.93in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.01in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.08in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.15in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.23in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.30in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.37in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.44in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.52in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.59in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.66in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.73in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.81in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.88in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 4.95in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.03in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.10in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.17in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.25in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.32in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.39in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.47in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.54in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.61in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.68in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.76in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"></span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 5.83in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Punong </span></SPAN></div>
                            <br />
                        </div>
                        <div style="position: absolute; top: 9.94in; left: 1.07in; width: 7.17in; line-height: 0.24in;">
                            <div style="position: relative; left: 6.43in;"><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Barangay</span><span style="font-style: normal; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> </span>
                                <br />
                                </SPAN></div>
                        </div>
                        <img src="OutDocument/ri_2.png" style="position: absolute; top: 0.6in; left: 1.84in; width: 1.14in; height: 1.14in" src="ri_2.png" />
                        <img src="OutDocument/ri_3.png" style="position: absolute; top: 0.62in; left: 6.08in; width: 1.36in; height: 1.19in" src="ri_3.png" />

                    </section>
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
