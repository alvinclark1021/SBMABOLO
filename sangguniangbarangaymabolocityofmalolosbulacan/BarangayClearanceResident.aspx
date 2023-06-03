<%@ Page Title="" Language="C#" MasterPageFile="~/BarangayAdminDashboard.Master" AutoEventWireup="true" CodeBehind="BarangayClearanceResident.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.BarangayClearanceResident" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>

        div {
            padding-bottom:20px;
        }

    </style>
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
                    <li><a href="Adminbarangaybusinessclearance.aspx"><i class="fas fa-file-alt"></i> Barangay Business Clearance Registered</a></li>
                     <li><a href="History.aspx"><i class="fas fa-user-slash"></i>History</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right navbar-user">
                    
                     <li class="dropdown user-dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"><asp:Label ID="lblfullname" runat="server" Text=" fullname"></asp:Label></i><b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><asp:LinkButton ID="Linkchangepasswprd" OnClick="Linkchangepasswprd_Click" class="fa fa-lock" runat="server"> Change Password</asp:LinkButton></li>
                            <li><asp:LinkButton ID="linkprofile" OnClick="linkprofile_Click" class="fa fa-user" runat="server"> Profile</asp:LinkButton></li>
                            <li class="divider"></li>
                             <li><asp:LinkButton ID="Linklogout" OnClick="Linklogout_Click" class="fa fa-power-off"  runat="server"> Logout</asp:LinkButton></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
         <br />
        <h1> Request Documents</h1>
        <br />
         <!-- MAIN CONTENT -->
        <div class="row ">
            <div class="col-lg-12 col-md-12">
                <div class="card" style="min-height: 485px">
                    <div class="card-header card-header-text">
                        <h5>Barangay Resident</h5>
                          <asp:textbox ID="txtSearch" runat="server" placeholder="Search Control No" class="form-control w-50" AutoPostBack="True" />
                        <br />
                        <br />
                    </div>
                    <asp:GridView ID="ID" AutoGenerateColumns="false" CssClass="table" runat="server">
                        <Columns>
                            <asp:BoundField HeaderText="Control Number" DataField="barangayControlnumber" />
                            <asp:BoundField HeaderText="Fullname" DataField="fullname" />
                             <asp:BoundField HeaderText="Email" DataField="email" />
                             <asp:BoundField HeaderText="Contact No" DataField="mobilenumber" />
                             <asp:BoundField HeaderText="Address" DataField="address" />
                             <asp:BoundField HeaderText="Purpose" DataField="purpose" />
                             <asp:BoundField HeaderText="Barangay Cetification" DataField="barangaycefication" />
                             <asp:BoundField HeaderText="Date" DataField="datepickup" />


                        </Columns>
                    </asp:GridView>
                </div>
           </div>
        </div>
              </div>
</asp:Content>
