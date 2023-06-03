<%@ Page Title="" Language="C#" MasterPageFile="~/BarangayAdminDashboard.Master" AutoEventWireup="true" CodeBehind="Addpurposes.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.Addpurposes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!--This Icon is for the icon in Title Bar-->
    <link rel="icon" href="Index/img/Mabolo_Logo.png" type="image/x-icon" />
  <title>Add Purpose</title>
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
      <!-- sidebar nav start -->
      <ul class="nav nav-pills nav-stacked custom-nav">
        <li class="active"><a href="BarangayAdminDashboard.aspx"><i class="fa fa-tachometer"></i><span> Dashboard</span></a>
        </li>
        <li class="menu-list">
          <a href="#"><i class="fa fa-file-text"></i>
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
            <li><a href="BarangayResidentPendingRegister.aspx">Pending Registered Users</a> </li>
              <li><a href="DisApprovedApplicationRegisterResident.aspx">Disapproved Registered Users</a> </li>
            <li><a href="BarangayRegisterResident.aspx">Registered Users</a> </li>
          </ul>
        </li>
          <li><a href="BarangayAdminRegister.aspx"><i class="lnr lnr-users"></i> <span>Add Account Barangay Officals</span></a></li>
           <li><a href="Addbarangayofficalmainpage.aspx"><i class="lnr lnr-page-break"></i> <span>Add Account Barangay for main page</span></a></li>
        <li><a href="BarangayResidentInformation.aspx"><i class="lnr lnr-users"></i> <span>Resident Profile</span></a></li>
           <li><a href="Addpurposes.aspx"><i class="lnr lnr-book"></i> <span>Add Purposes</span></a></li>
        <li><a href="ConcernsMessageUser.aspx"><i class="lnr lnr-bookmark"></i> <span>Concern Message</span></a></li>
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
                    <h5 class="user-name"><asp:Label ID="lblfullname" runat="server" Text="fullname"></asp:Label></h5>
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
        <li class="breadcrumb-item active" aria-current="page">Add Purposes</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4">
        
      <h1>Hi <span class="text-primary"><asp:Label ID="lblfullnames" runat="server" Text="fullname"></asp:Label></span>, Welcome back</h1>
      <h1><asp:Label ID="lbldates" runat="server" Text="Label"></asp:Label></h1>
      <p>Very detailed & featured admin.</p>
    </div>
        <!-- forms -->
        <section class="forms">
            <!-- forms 1 -->
            <div class="card card_border py-2 mb-4">
                <div class="cards__heading">
                    <h3>Add Purposes<span></span></h3>
                </div>
               
                       <div class="card-body">
                    <div class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Barangay Clearance Purposes</label>
                        <div class="input-group">
                               <asp:textbox ID="txtSearch" runat="server" placeholder="Barangay Clearance" aria-describedby="emailHelp" class="form-control input-style" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"  />                        
                            </div>
                        </div>
                           <asp:Button ID="Btnserachbar" class="btn btn-primary btn-style mt-4" OnClick="Btnserachbar_Click" runat="server" Text="Search" />
                       <br />
                    <br />
                     <asp:Repeater ID="rptProducts" runat="server">
                            <HeaderTemplate>
                                 <table class="table table-sm table-hover">
                                    <thead class="text-primary">
                                        <tr>
                                            <th style="border: 1px solid black">Purpose</th>
                                            <th style="border: 1px solid black">Date</th>
                                            <th style="border: 1px solid black">Status</th>
                                            <th style="border: 1px solid black">Action</th>
                                        </tr>
                                    </thead>        
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td style="width: 30%">
                                                <asp:Label ID="lblid" Text='<%#Eval("ID") %>' runat="server" Visible="false" />
                                                <asp:Label ID="lblname" Text='<%#Eval("BarangaySelected") %>' runat="server" />
                                            </td>
                                            <td style="width: 11%">
                                              <asp:Label ID="lblpostion" Text='<%#Eval("date") %>' runat="server" /> 
                                            </td>
                                           
                                             <td style="width: 11%">
                                                 <asp:Label ID="lblstatus" Text='<%#Eval("Status") %>' runat="server" /> 
                                            </td>
                                            <td style="width: 12%">
                                                <asp:linkbutton text="Approved" ID="lnkapproved5" runat="server" class="btn btn-outline-secondary" CssClass="btn-success" OnClientClick="return confirm('Do you want to Add Purpose?')" OnClick="lnkapproved5_Click"  />
                                                <asp:linkbutton text="Disapproved" ID="Lnkdeletepurpose5" runat="server" class="btn btn-outline-secondary" CssClass="btn-danger" OnClientClick="return confirm('Do you want to Delete Purpose?')" OnClick="Lnkdeletepurpose5_Click"  />
                                            </td>
                                        </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                       
               <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />

                <!--2-->
                 <div class="card-body">
                    <div class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Barangay Business Clearance Purposes</label>
                        <div class="input-group">
                             <asp:textbox ID="txtserachbusiness" runat="server" placeholder="Business Clearance" aria-describedby="emailHelp" class="form-control input-style" AutoPostBack="True" OnTextChanged="txtserachbusiness_TextChanged"  />                           

                        </div>
                        </div>
                     <asp:Button ID="Btnbusiness" class="btn btn-primary btn-style mt-4" Width="122px" Height="46px" OnClick="Btnbusiness_Click" runat="server" Text="Search" />
                       <br />
                    <br />
                 <asp:Repeater ID="businessclearance" runat="server">
                            <HeaderTemplate>
                                 <table class="table table-sm table-hover">
                                    <thead class="text-primary">
                                        <tr>
                                            <th style="border: 1px solid black">Purpose</th>
                                            <th style="border: 1px solid black">Date</th>
                                            <th style="border: 1px solid black">Status</th>
                                            <th style="border: 1px solid black">Action</th>
                                        </tr>
                                    </thead>        
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td style="width: 30%">
                                                <asp:Label ID="lblsw" Text='<%#Eval("ID") %>' runat="server" Visible="false" />
                                                <asp:Label ID="lblnamesa" Text='<%#Eval("BarangayBuisnessname")%>' runat="server" />
                                            </td>
                                            <td style="width: 11%">
                                              <asp:Label ID="lblpostionsa" Text='<%#Eval("date") %>' runat="server" /> 
                                            </td>
                                           
                                             <td style="width: 11%">
                                                 <asp:Label ID="lblstatussa" Text='<%#Eval("Status") %>' runat="server" /> 
                                            </td>
                                            <td style="width: 12%">
                                                <asp:linkbutton text="Approved" ID="lnkapproved12" runat="server" class="btn btn-outline-secondary" CssClass="btn-success" OnClientClick="return confirm('Do you want to add purpose?')" OnClick="lnkapproved12_Click"  />
                                                 <asp:linkbutton text="Disapproved" ID="Lnkdeletepurpose12" runat="server" class="btn btn-outline-secondary" CssClass="btn-danger" OnClientClick="return confirm('Do you want to delete purpose?')" OnClick="Lnkdeletepurpose12_Click"  />
                                            </td>
                                        </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                     </div>
                    
                    
                        <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />

                <!--3-->
                <div class="card-body">
                    <div class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Barangay Indegency Purposes</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtbarangayindency" runat="server" placeholder="Indegency" aria-describedby="emailHelp" class="form-control input-style" AutoPostBack="True" OnTextChanged="txtbarangayindency_TextChanged" />
                        </div>
                    </div>
                     <asp:Button ID="btnbarangayindency" class="btn btn-primary btn-style mt-4" OnClick="btnbarangayindency_Click" runat="server" Text="Search" />
                       <br />
                    <br />
                             <asp:Repeater ID="Repeater2" runat="server">
                            <HeaderTemplate>
                                 <table class="table table-sm table-hover">
                                    <thead class="text-primary">
                                        <tr>
                                            <th style="border: 1px solid black">Purpose</th>
                                            <th style="border: 1px solid black">Date</th>
                                            <th style="border: 1px solid black">Status</th>
                                            <th style="border: 1px solid black">Action</th>
                                        </tr>
                                    </thead>        
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td style="width: 30%">
                                                <asp:Label ID="lblidsa" Text='<%#Eval("ID") %>' runat="server" Visible="false" />
                                                <asp:Label ID="lblnamesa" Text='<%#Eval("Purposenamebarangayind") %>' runat="server" />
                                            </td>
                                            <td style="width: 11%">
                                              <asp:Label ID="lblpostionsa" Text='<%#Eval("date") %>' runat="server" /> 
                                            </td>
                                           
                                             <td style="width: 11%">
                                                 <asp:Label ID="lblstatussa" Text='<%#Eval("Status") %>' runat="server" /> 
                                            </td>
                                            <td style="width: 12%">
                                                <asp:linkbutton text="Approved" ID="lnkapproved2" runat="server" class="btn btn-outline-secondary" CssClass="btn-success" OnClientClick="return confirm('Do you want to Add purpose?')" OnClick="lnkapproved2_Click"  />
                                                 <asp:linkbutton text="Disapproved" ID="Lnkdeletepurpose2" runat="server" class="btn btn-outline-secondary" CssClass="btn-danger" OnClientClick="return confirm('Do you want to Delete Purpose?')" OnClick="Lnkdeletepurpose2_Click"  />
                                            </td>
                                        </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                </div>
                      
                 <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                             <!--4-->
                             <div class="card-body">
                    <div class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Barangay Occupany Permit Purposes</label>
                        <div class="input-group">
                           <asp:textbox ID="txtBarangayOccupanyPermit" runat="server" placeholder="Occupany Permit" aria-describedby="emailHelp" class="form-control input-style" AutoPostBack="True" OnTextChanged="txtBarangayOccupanyPermit_TextChanged"  />                      

                        </div>
                    </div> 
                         <asp:Button ID="BntBarangayOccupanyPermit" class="btn btn-primary btn-style mt-4" OnClick="BntBarangayOccupanyPermit_Click" runat="server" Text="Search" />
                       <br />
                    <br />
                   <asp:Repeater ID="Repeater3" runat="server">
                            <HeaderTemplate>
                                 <table class="table table-sm table-hover">
                                    <thead class="text-primary">
                                        <tr>
                                            <th style="border: 1px solid black">Purpose</th>
                                            <th style="border: 1px solid black">Date</th>
                                            <th style="border: 1px solid black">Status</th>
                                            <th style="border: 1px solid black">Action</th>
                                        </tr>
                                    </thead>        
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td style="width: 30%">
                                                <asp:Label ID="lblidfer" Text='<%#Eval("ID") %>' runat="server" Visible="false" />
                                                <asp:Label ID="lblpermitoccupany" Text='<%#Eval("BarangayOccupanyPermits") %>' runat="server" />
                                            </td>
                                            <td style="width: 11%">
                                              <asp:Label ID="lblpostionsa" Text='<%#Eval("date") %>' runat="server" /> 
                                            </td>
                                           
                                             <td style="width: 11%">
                                                 <asp:Label ID="lblstatussa" Text='<%#Eval("Status") %>' runat="server" /> 
                                            </td>
                                            <td style="width: 12%">
                                                <asp:linkbutton text="Approved" ID="lnkapproved3" runat="server" class="btn btn-outline-secondary" CssClass="btn-success" OnClientClick="return confirm('Do you want to add purpose?')" OnClick="lnkapproved3_Click"  />
                                                 <asp:linkbutton text="Disapproved" ID="Lnkdeletepurpose3" runat="server" class="btn btn-outline-secondary" CssClass="btn-danger" OnClientClick="return confirm('Do you want to delete purpose?')" OnClick="Lnkdeletepurpose3_Click"  />
                                            </td>
                                        </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>

                       </div>
                        <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                           <!--5--> 
                             <div class="card-body">
                    <div class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Barangay Excavation Permit Purposes</label>
                        <div class="input-group">
                            <asp:textbox ID="txtexcavation" runat="server" placeholder="Excavation Permit" class="form-control w-50" AutoPostBack="True" OnTextChanged="txtexcavation_TextChanged"  />
                    </div> 
                        </div>
                                  <asp:Button ID="Bntexcavation" class="btn btn-primary btn-style mt-4" OnClick="Bntexcavation_Click" runat="server" Text="Search" />
                       <br />
                    <br />
                        <asp:Repeater ID="Repeater4" runat="server">
                            <HeaderTemplate>
                                 <table class="table table-sm table-hover">
                                    <thead class="text-primary">
                                        <tr>
                                            <th style="border: 1px solid black">Purpose</th>
                                            <th style="border: 1px solid black">Date</th>
                                            <th style="border: 1px solid black">Status</th>
                                            <th style="border: 1px solid black">Action</th>
                                        </tr>
                                    </thead>        
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td style="width: 30%">
                                                <asp:Label ID="lblexcavationpermit" Text='<%#Eval("ID") %>' runat="server" Visible="false" />
                                                <asp:Label ID="lblpermitoccupany" Text='<%#Eval("BarangayAddPurpose") %>' runat="server" />
                                            </td>
                                            <td style="width: 11%">
                                              <asp:Label ID="lblpostionsa" Text='<%#Eval("Date") %>' runat="server" /> 
                                            </td>
                                           
                                             <td style="width: 11%">
                                                 <asp:Label ID="lblstatussa" Text='<%#Eval("Status") %>' runat="server" /> 
                                            </td>
                                            <td style="width: 12%">
                                                <asp:linkbutton text="Approved" ID="lnkapproved4" runat="server" class="btn btn-outline-secondary" CssClass="btn-success" OnClientClick="return confirm('Do you want to add purpose?')" OnClick="lnkapproved4_Click"  />
                                                 <asp:linkbutton text="Disapproved" ID="Lnkdeletepurpose4" runat="server" class="btn btn-outline-secondary" CssClass="btn-danger" OnClientClick="return confirm('Do you want to delete purpose?')" OnClick="Lnkdeletepurpose4_Click"  />
                                            </td>
                                        </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                                 </div>
                
                       <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                        <!--6-->
                        <div class="card-body">
                    <div class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Barangay Fencing Permit</label>
                        <div class="input-group">
                            <asp:textbox ID="txtfencing" runat="server" placeholder="Fencing Permit" aria-describedby="emailHelp" class="form-control input-style" AutoPostBack="True" OnTextChanged="txtexcavation_TextChanged"  />
                    </div> 
                        </div>
                            <asp:Button ID="btnfecing" class="btn btn-primary btn-style mt-4" OnClick="Bntexcavation_Click" runat="server" Text="Search" />
                       <br />
                    <br />
                         <asp:Repeater ID="Repeater1" runat="server">
                            <HeaderTemplate>
                                 <table class="table table-sm table-hover">
                                    <thead class="text-primary">
                                        <tr>
                                            <th style="border: 1px solid black">Purpose</th>
                                            <th style="border: 1px solid black">Date</th>
                                            <th style="border: 1px solid black">Status</th>
                                            <th style="border: 1px solid black">Action</th>
                                        </tr>
                                    </thead>        
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td style="width: 30%">
                                                <asp:Label ID="lblfecing" Text='<%#Eval("ID") %>' runat="server" Visible="false" />
                                                <asp:Label ID="lblpermitoccupany" Text='<%#Eval("BarangayAddPurpose") %>' runat="server" />
                                            </td>
                                            <td style="width: 11%">
                                              <asp:Label ID="lblpostionsa" Text='<%#Eval("Date") %>' runat="server" /> 
                                            </td>
                                           
                                             <td style="width: 11%">
                                                 <asp:Label ID="lblstatussa" Text='<%#Eval("Status") %>' runat="server" /> 
                                            </td>
                                            <td style="width: 12%">
                                                <asp:linkbutton text="Approved" ID="lnkapproved41" runat="server" class="btn btn-outline-secondary" CssClass="btn-success" OnClientClick="return confirm('Do you want to add purpose?')" OnClick="lnkapproved41_Click"  />
                                                 <asp:linkbutton text="Disapproved" ID="Lnkdeletepurpose41" runat="server" class="btn btn-outline-secondary" CssClass="btn-danger" OnClientClick="return confirm('Do you want to delete purpose?')" OnClick="Lnkdeletepurpose41_Click"  />
                                            </td>
                                        </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                            </div>
                       
                        <!--7-->
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                        <div class="card-body">
                    <div class="form-group">
                        <label for="exampleInputPassword1" class="input__label">Barangay Good Mornal Purposes</label>
                        <div class="input-group">
                            <asp:textbox ID="txtgoodmornal" runat="server" placeholder="Good Mornal" aria-describedby="emailHelp" class="form-control input-style" AutoPostBack="True" OnTextChanged="txtgoodmornal_TextChanged"  />
                    </div> 
                        </div>
                             <asp:Button ID="Button1" class="btn btn-primary btn-style mt-4" OnClick="Button1_Click" runat="server" Text="Search" />
                       <br />
                    <br />
                        <asp:Repeater ID="Repeater6" runat="server">
                            <HeaderTemplate>
                                 <table class="table table-sm table-hover">
                                    <thead class="text-primary">
                                        <tr>
                                            <th style="border: 1px solid black">Purpose</th>
                                            <th style="border: 1px solid black">Date</th>
                                            <th style="border: 1px solid black">Status</th>
                                            <th style="border: 1px solid black">Action</th>
                                        </tr>
                                    </thead>        
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td style="width: 30%">
                                                <asp:Label ID="lblgoodmornal" Text='<%#Eval("ID") %>' runat="server" Visible="false" />
                                                <asp:Label ID="lblpermitoccupany" Text='<%#Eval("Name") %>' runat="server" />
                                            </td>
                                            <td style="width: 11%">
                                              <asp:Label ID="lblpostionsa" Text='<%#Eval("Date") %>' runat="server" /> 
                                            </td>
                                           
                                             <td style="width: 11%">
                                                 <asp:Label ID="lblstatussa" Text='<%#Eval("Status") %>' runat="server" /> 
                                            </td>
                                            <td style="width: 12%">
                                                <asp:linkbutton text="Approved" ID="lnkapproved411" runat="server" class="btn btn-outline-secondary" CssClass="btn-success" OnClientClick="return confirm('Do you want to add purpose?')" OnClick="lnkapproved411_Click"  />
                                                 <asp:linkbutton text="Disapproved" ID="Lnkdeletepurpose411" runat="server" class="btn btn-outline-secondary" CssClass="btn-danger" OnClientClick="return confirm('Do you want to delete purpose?')" OnClick="Lnkdeletepurpose411_Click"  />
                                            </td>
                                        </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                            </div>
                      
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
