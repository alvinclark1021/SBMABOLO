<%@ Page Title="" Language="C#" MasterPageFile="~/BarangayAdminDashboard.Master" AutoEventWireup="true" CodeBehind="InactiveResident.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.InactiveResident" %>
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
            <asp:Label ID="lbldate" runat="server" ForeColor="White" Visible="false"  Text="Label"></asp:Label>
                        <asp:Label ID="lblactivity" runat="server" ForeColor="White" Visible="false"  Text="Logout"></asp:Label>
            <div class="navbar-header">
            <asp:Label ID="lblsessionlogin" runat="server" Text="Label" ForeColor="#033C73"></asp:Label>
                <a class="navbar-brand" href="BarangayAdminDashboard.aspx">Barangay Mabolo</a>
            </div>
            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav side-nav">
                     <li class="active"><a href="BarangayAdminDashboard.aspx"><i class="fa fa-tachometer"></i> Dashboard</a></li>
                    <li><a href="BarangayRequestDocument.aspx"><i class="far fa-file-alt"></i> Request Documents</a></li>
                    <li><a href="BarangayRegisterResident.aspx"><i class="fas fa-user-alt"></i> Register Users</a></li>
                    <li><a href="InactiveResident.aspx"><i class="fas fa-user-slash"></i> Inactive Users</a></li>
                    <li><a href="BarangayResidentInformation.aspx"><i class="fas fa-file-alt"></i>Barangay Clearance</a></li>
                    <li><a href="barangayclearanceunregistered.aspx"><i class="fas fa-file-alt"></i>Business Clearance Unregistered</a></li>
                    <li><a href="BarangayBusinessClearanceRegistered.aspx"><i class="fas fa-file-alt"></i>Business Clearance Registered</a></li>
                    <li><a href="BarangayBusinessClearanceDisapproved.aspx"><i class="fas fa-file-alt"></i>Business Clearance Disapproved</a></li>
                    <li><a href="BarangayAdminRegister.aspx"><i class="fas fa-file-alt"></i>Add Account Barangay Officals</a></li>
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
        <h1> Inactive Barangay Resident</h1>
        <br />
         <!-- MAIN CONTENT -->
        <div class="row ">
            <div class="col-lg-12 col-md-12">
                <div class="card" style="min-height: 485px">
                    <div class="card-header card-header-text">
                        <h5>Search Inactive Resident</h5>
                          <asp:textbox ID="txtSearch" runat="server" placeholder="Search Barangay Resident" class="form-control w-50" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged" />
                        <br />
                        <br />
                         <asp:Button ID="Btnserachbar" class="btn btn-info" OnClick="Btnserachbar_Click" runat="server" Text="Search" />

                    </div>
                <asp:GridView ID="ID" AutoGenerateColumns="false" CssClass="table" runat="server">
                        <Columns>
                            <asp:BoundField HeaderText="Resident Name" DataField="name" />
                            <asp:BoundField HeaderText="Email" DataField="email" />
                             <asp:BoundField HeaderText="Address" DataField="address" />
                             <asp:BoundField HeaderText="Date" DataField="date" />
                             <asp:BoundField HeaderText="Status" DataField="Status" />
                        </Columns>
                    </asp:GridView>
                </div>
           </div>
        </div>
              </div>
</asp:Content>
