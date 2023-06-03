<%@ Page Title="" Language="C#" MasterPageFile="~/BarangayAdminDashboard.Master" AutoEventWireup="true" CodeBehind="BarangayAdminRegistered.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.BarangayAdminRegistered" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        div {
            padding-bottom:20px;
        }

    </style>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="wrapper">
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            <div class="navbar-header">
            <asp:Label ID="lblsessionlogin" runat="server" Text="Label" ForeColor="#033C73"></asp:Label>
                <a class="navbar-brand" href="index.html">Barangay Mabolo</a>
            </div>
            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav side-nav">
                   <li class="active"><a href="BarangayAdminDashboard.aspx"><i class="fa fa-bullseye"></i> Dashboard</a></li>
                    <li><a href="BarangayRequestDocument.aspx"><i class="far fa-file-alt"></i> Request Documents</a></li>
                    <li><a href="BarangayRegisterResident.aspx"><i class="fas fa-user-alt"></i> Register Users</a></li>
                    <li><a href="BarangayInactiveaccountresident.aspx"><i class="fas fa-user-slash"></i> Inactive Users</a></li>
                    <li><a href="BarangayResidentInformation.aspx"><i class="fas fa-file-alt"></i>Barangay Clearance</a></li>
                     <li><a href="History.aspx"><i class="fas fa-user-slash"></i>History</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right navbar-user">
                    
                     <li class="dropdown user-dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"><asp:Label ID="lblfullname" runat="server" Text=" fullname"></asp:Label></i><b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><asp:LinkButton ID="Linkchangepasswprd" OnClick="Linkchangepasswprd_Click" class="fa fa-lock" runat="server"> Change Password</asp:LinkButton></li>
                            <li><asp:LinkButton ID="linkprofile" OnClick="linkprofile_Click" class="fa fa-user" runat="server"> Profile</asp:LinkButton></li>
                            <li class="divider"></li>
                             <li><asp:LinkButton ID="Linklogout" OnClick="Linklogout_Click" class="fa fa-power-off" OnClientClick="return confirm('Are you sure you want to log out?')"  runat="server"> Logout</asp:LinkButton></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
         <br />
        <h1> Registered Barangay Officals</h1>
        <br />
         <!-- MAIN CONTENT -->
        <div class="row ">
            <div class="col-lg-12 col-md-12">
                <div class="card" style="min-height: 485px">
                    <div class="card-header card-header-text">
                          <asp:textbox ID="txtSearch" runat="server" placeholder="Search Barangay Resident" class="form-control w-50" AutoPostBack="True" />
                        <br />
                        <br />
                    </div>
                    <div class="card-content table-responsive">
                        <asp:Repeater ID="rptProducts" runat="server">
                            <HeaderTemplate>
                                 <table class="table table-sm table-hover">
                                    <thead class="text-primary">
                                        <tr>
                                            <th style="border: 1px solid black">Name</th>
                                            <th style="border: 1px solid black">Email</th>
                                            <th style="border: 1px solid black">Mobile Number</th>
                                            <th style="border: 1px solid black">Address</th>
                                            <th style="border: 1px solid black">Action</th>
                                        </tr>
                                    </thead>        
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td style="width: 55%">
                                                <asp:Label ID="lblID" Text='<%#Eval("ID") %>' runat="server" Visible="false" />
                                                <asp:Label ID="lblname" Text='<%#Eval("tbl_Fullname") %>' runat="server" />
                                            </td>
                                            <td style="width: 15%">
                                                <asp:Label ID="lblemail" Text='<%#Eval("tbl_Email") %>' runat="server" />
                                            </td>
                                            <td style="width: 15%">
                                                <asp:Label ID="lblcontactnumber" Text='<%#Eval("tbl_Contactnumber") %>' runat="server" />
                                            </td>
                                            <td style="width: 15%">
                                                <asp:Label ID="lbladdress" Text='<%#Eval("tbl_address") %>' runat="server" />
                                            </td>
                                            <td style="width: 15%">
                         
                                                <asp:linkbutton text="Deactivae Account" ID="DeActivateAccount" runat="server" class="btn btn-outline-danger" OnClick="DeActivateAccount_Click" />
                                            </td>
                                        </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
           </div>
        </div>
              </div>


     
</asp:Content>
