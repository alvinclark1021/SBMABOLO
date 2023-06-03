<%@ Page Title="" Language="C#" MasterPageFile="~/BarangayAdminDashboard.Master" AutoEventWireup="true" CodeBehind="PrintingClearance.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.PrintingClearance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <title>Print Clearance</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <!-- Template CSS -->
    <link rel="stylesheet" href="assets/css/style-starter.css">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <!-- google fonts -->
    <link href="//fonts.googleapis.com/css?family=Nunito:300,400,600,700,800,900&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Label ID="lblemail" Visible="true" runat="server" Text=""></asp:Label>

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
                    <a href="BarangayAdminDashboard.aspx" title="logo">
                        <img src="assets/images/logo.png" alt="logo-icon">
                    </a>
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

                            <div class="profile_details" id="setHide">
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
                                                <h5 class="user-name">
                                                    <asp:Label ID="lblfullnames" runat="server" Text=" fullname"></asp:Label></h5>
                                                <span class="status ml-2">
                                                    <asp:Label ID="lblbarangayofficals" runat="server" Text="Barangay Position"></asp:Label></span>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="linkprofile" OnClick="linkprofile_Click" class="fa fa-user" runat="server"> My Profile</asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="Linkchangepasswprd" OnClick="Linkchangepasswprd_Click" class="fa fa-lock" runat="server"> Change Password</asp:LinkButton>
                                            </li>
                                            <li class="logout">
                                                <asp:LinkButton ID="Linklogout" OnClick="Linklogout_Click" OnClientClick="return confirm('Are you sure you want to log out?')" class="fa fa-power-off" runat="server"> Logout</asp:LinkButton></li>
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
                <asp:Label ID="lbldate" runat="server" ForeColor="White" Visible="false" Text="Label"></asp:Label>
                <asp:Label ID="lblactivity" runat="server" ForeColor="White" Visible="false" Text="Logout"></asp:Label>
                <asp:Label ID="lblsession" runat="server" ForeColor="White" Visible="false" Text="End Session"></asp:Label>
                 <asp:Label ID="lblstatus" runat="server" ForeColor="White" Visible="false" Text="Label"></asp:Label>
                 <asp:Label ID="lblids" runat="server" ForeColor="White" Visible="false" Text="Label"></asp:Label>
                <!-- content -->
                <div class="container-fluid content-top-gap">

                    <%--<nav aria-label="breadcrumb">
                        <ol class="breadcrumb my-breadcrumb">
                            <li class="breadcrumb-item"><a href="BarangayAdminDashboard.aspx">Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Barangay Clearance Priting</li>
                        </ol>
                    </nav>--%>
                    <div class="welcome-msg pt-3 pb-4" id="hi-administer">

                        <h1>Hi <span class="text-primary"  >
                            <asp:Label ID="lblfullname" runat="server" Text=" fullname"></asp:Label></span>, Welcome back</h1>
                        <h1>
                            <asp:Label ID="lbldates" runat="server" Text="Label"></asp:Label></h1>
                    </div>
                    <!-- forms -->
                    <div class="forms">
                        <!-- forms 1 -->
                        <div class="card card_border py-2 mb-4">
                            <span id="printB">
                  
                                <asp:Button ID="printButton" Style="margin-left: -0.3%;" OnClick="printButton_Click" runat="server" Text="Print" OnClientClick="javascript:(function printFullDocument() {
    if (confirm('Are you sure you want to proceed?')) {
        const contentToPrint = document.querySelector('#content-to-print');
        const originalContent = document.querySelector('#original-content');
        contentToPrint.style.transform = 'scale(1.5)';
        document.title = 'Request Document';
        document.body.style.transform = 'scale(1.1)';
        document.querySelector('#side-bar').style.display = 'none';
        document.querySelector('#hi-administer').style.display = 'none';
        document.querySelector('#printB').style.display = 'none';
        document.querySelector('#setHide').style.display = 'none';
        window.print();
        document.body.innerHTML = originalContent.innerHTML;
    }
})()"
                                           Font-Bold="True" Font-Size="14pt" Width="281px" Height="40px" BackColor="#CC0000" ForeColor="White" />

                </span>
                               <div class="card-body">
                                <section id="content-to-print" class="center">
                                    <img style="position: absolute; top: 1.62in; left: 8.87in; width: 0.22in; height: 9.03in" src="OutDocument/OutDocument/ci_1.png" />
                                    <img style="position: absolute;margin-left: -2rem; top: 1.80in; left: 0.42in; width: 0.22in; height: 9.03in" src="OutDocument/OutDocument/ci_2.png" />
                                    <img style="position: absolute;margin-left: -.7rem;top: 8.47in; width: 1.64in; height: 2.73in" src="OutDocument/OutDocument/ri_1.png" />
                                    <img style="position: absolute;margin-left: -1rem;  top: 0.76in; left: 0.16in; width: 1.64in; height: 2.73in" src="OutDocument/OutDocument/ri_2.png" />
                                    <img style="position: absolute; top: 0.77in; left: 7.32in; width: 1.78in; height: 2.75in" src="OutDocument/OutDocument/ri_3.png" />
                                    <img style="position: absolute; top: 8.47in; left: 7.47in; width: 1.64in; height: 2.73in" src="OutDocument/OutDocument/ri_4.png" />
                                    <%--here--%>
                                    <div style="position: absolute; top: 1.08in; left: 4.40in; width: 2.06in; line-height: 0.22in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000">Republic of the Philippines</span>
                                        <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <br />
                                        <div style="position: relative; left: 0.15in;">
                                            <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000">Province of Bulacan </span>
                                            <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000"></span>
                                            <br />
                                        </div>
                                    </div>
                                    <div style="position: absolute; top: 1.32in; left: 4.4in; width: 2.06in; line-height: 0.22in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <br />
                                        <div style="position: relative; left: 0.29in;">
                                            <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000">City of Malolos
                                            </span><span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000"></span>
                                            <br />
                                        </div>
                                    </div>
                                    <div style="position: absolute; top: 1.79in; left: 4.40in; width: 0.77in; line-height: 0.20in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000">Barangay</span>
                                        <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 1.79in; left: 5.20in; width: 0.86in; line-height: 0.20in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000">MABOLO</span>
                                        <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 2.03in; left: 4.80in; width: 0.42in; line-height: 0.20in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000">4456</span>
                                        <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <br />
                                    </div> 
                                    <%--Here--%>
                                    <div style="position: absolute; top: 2.80in; left: 3.61in; width: 4.24in; line-height: 0.23in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 16pt; font-family: Monotype Corsiva; color: #000000">OFFICE OF THE BARANGAY CHAIRMAN</span>
                                        <span style="font-style: italic; font-weight: normal; font-size: 16pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 16pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 3.31in; left: 4.91in; width: 1.67in; line-height: 0.20in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000">PAGPAPATUNAY  </span>
                                        <span style="font-style: italic; font-weight: normal; font-size: 14pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 4.04in; left: 4.12in; width: 5.99in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">Ito ay nagpapatunay na si 
                                        <asp:Label ID="lblfullnameq" runat="server" Text="Label "></asp:Label>
                                            &nbsp;<label>ay naninirahan sa</label>

                                        </span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 4.08in; left: 5.64in; width: 5.99in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">_______________</span><br />
                                    </div>
                                    <div style="position: absolute; top: 4.04in; width: 0.87in; line-height: 0.17in; right: 330px;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span>

                                    </div>
                                    <div style="position: absolute; top: 4.04in; left: 8.64in; width: 0.17in; line-height: 0.17in; height: 48px;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 4.24in; left: 2.72in; width: 4.4in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">
                                            <asp:Label ID="lbladdress" runat="server" Text="Label"></asp:Label>
                                        </span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 4.28in; left: 2.72in; width: 5.99in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">___________________________________________</span><br />
                                    </div>
                                    <div style="position: absolute; top: 4.56in; left: 2.68in; width: 6.02in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">ay isang taong nagtataglay ng mabuting kalooban at may magandang katangian sa</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 4.56in; left: 7.64in; width: 0.70in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">Barangay.</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 4.88in; left: 2.72in; width: 6in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000">Pinatutunayan pa rin na siya ay walang kasong anuman maging criminal o</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Times New Roman; color: #000000"> sibil na napailalim sa tanggapang ito batay sa aming talaan.</span><br />
                                    </div>
                                    <div style="position: absolute; top: 5.4in; left: 2.68in; width: 6.04in; line-height: 0.19in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">Ang pagpapatunay  na ito ay ipinagkakaloob bilang pagkilala o pagpapatotoo lamang sa</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">mga legal na layunin o maging sa trabaho o gawain</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 6.93in; left: 2.78in; width: 1.71in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">. Ipinagkaloob ngyong ika</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 6.93in; left: 4.45in; width: 0.09in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">-</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 6.93in; left: 4.50in; width: 2.19in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">
                                            <asp:Label ID="lbldatess" runat="server" Text="Label"></asp:Label>
                                        </span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 6.96in; left: 4.52in; width: 5.99in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">_____________________</span><br />
                                    </div>

                                    <div style="position: absolute; top: 7.37in; left: 3.04in; width: 4.74in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">Pangalan  at Lagda ng Kumuha</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">
                                            <asp:Label ID="lblnamess" runat="server" Text="Label"></asp:Label>
                                        </span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 7.4in; left: 5in; width: 5.99in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">_____________________</span><br />
                                    </div>

                                    <div style="position: absolute; top: 7.56in; left: 2.68in; width: 2.52in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">Control No
                                        <asp:Label ID="lblcontrolnumber" runat="server" Text="Label"></asp:Label></span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 7.6in; left: 3.4in; width: 5.99in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">_____________________</span><br />
                                    </div>

                                    <div style="position: absolute; top: 7.78in; left: 2.69in; width: 2.52in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">Sedula Bilang_____________</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>

                                    <div style="position: absolute; top: 8.01in; left: 2.69in; width: 2.55in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">Kinuha sa _______________</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 8.27in; left: 2.69in; width: 2.52in; line-height: 0.14in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 9pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">Noong ika_______________</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 8.85in; left: 5.96in; width: 2.25in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">IGG. MELENCIO F.  TAMAYO</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 9.05in; left: 6.55in; width: 1.20in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">Punong Barangay</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute; top: 9.46in; left: 3.23in; width: 0.08in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000">.</span><span style="font-style: italic; font-weight: normal; font-size: 12pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <img style="position: absolute; top: 1.18in; left: 15rem; width: 0.92in; height: 0.91in" src="OutDocument/OutDocument/ri_5.png" />

                                    <img style="position: absolute; top: 1.16in; left: 40rem; width: 1.25in; height: 1.00in" src="OutDocument/OutDocument/ri_6.png" />
                                    <div style="position: absolute;margin-left: 1rem;  top: 1.49in; left: 0.48in; width: 1.66in; line-height: 0.16in;margin-top: 2.5rem;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"></span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">IGG. Melencio F. Tamayo</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 2.02in; left: 0.48in; width: 1.26in; line-height: 0.16in; margin-top: 1rem;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Barangay Kagawad:</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 2.45in; left: 0.48in; width: 1.32in; line-height: 0.16in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Igg. Danilo E. Calara</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 2.65in; left: 0.48in; width: 1.43in; line-height: 0.16in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(Committee on Finance)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 3.01in; left: 0.48in; width: 1.49in; line-height: 0.16in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Igg. Avelino B. Bautista</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 3.21in; left: 0.48in; width: 1.82in; line-height: 0.16in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(Committee on Peace &amp; Order)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 3.57in; left: 0.48in; width: 1.55in; line-height: 0.16in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Igg. Dedan A. Paguiligan</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 3.78in; left: 0.48in; width: 1.75in; line-height: 0.16in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(Committee on Public Works)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 4.13in; left: 0.48in; width: 1.51in; line-height: 0.16in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Igg. Gloria  G. Dimagiba</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 4.34in; left: 0.48in; width: 1.36in; line-height: 0.16in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(Committee on Health)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 4.69in; left: 0.48in; width: 1.34in; line-height: 0.16in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Igg. Lalaine S. Santos</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                        >
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 4.90in; left: 0.48in; width: 1.62in; line-height: 0.16in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(Committee on Agriculture)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 5.25in; left: 0.48in; width: 1.96in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Igg. Mark Anthony H. Dumalag</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Committee on Livelihood)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 5.81in; left: 0.48in; width: 1.58in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Igg.Rowena E. Dela Cruz</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Committee on Education)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 6.37in; left: 0.48in; width: 1.24in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Igg.Carlo S. Estrella</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">SK Chairperson)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 6.93in; left: 0.48in; width: 1.33in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Gng. Riza DC. Dimla</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(Ingat-Yaman)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 7.50in; left: 0.48in; width: 1.13in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Gng. Isabel R. Par</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(Kalihim)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 8.06in; left: 0.48in; width: 1.96in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Gng. Mary  Ann C. San Antonio</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(Clerk)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 8.62in; left: 0.48in; width: 1.22in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">Gng. Liza A. Simon</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(BWDO)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 9.18in; left: 0.48in; width: 1.11in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">G. Rafael Q.Paras</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(Hepe)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <div style="position: absolute;margin-left: 1rem; top: 9.74in; left: 0.48in; width: 1.50in; line-height: 0.17in;">
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">G. Benigno B. Omilan jr.</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                        <span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000">(Deputy)</span><span style="font-style: italic; font-weight: normal; font-size: 11pt; font-family: Monotype Corsiva; color: #000000"> </span>
                                        <br />
                                    </div>
                                    <img style="position: absolute;margin-right: -2rem; top: 0.79in; left: 2.53in; width: 0.05in; height: 10.35in" src="vi_1.png" />

                                </section>
                            </div>
                           
                           


                        </div>
                        <br />
                        <br />
                </div>
            </div>

        </section>
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
