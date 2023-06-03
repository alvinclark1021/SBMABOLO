<%@ Page Title="" Language="C#" MasterPageFile="~/BarangayAdminDashboard.Master" AutoEventWireup="true" CodeBehind="DisapprovedBusinessClearance.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.DisapprovedBusinessClearance" %>
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
                <a class="navbar-brand" href="BarangayAdminDashboard.aspx">Barangay Mabolo</a>
            </div>
            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav side-nav">
                    <li><a href="BarangayAdminDashboard.aspx"><i class="fa fa-tachometer"></i> Dashboard</a></li>
                    <li><a href="BarangayRequestDocument.aspx"><i class="far fa-file-alt"></i> Request Documents</a></li>
                    <li><a href="BarangayRegisterResident.aspx"><i class="fas fa-user-alt"></i> Register Users</a></li>
                    <li><a href="ConcernsMessageUser.aspx"><i class="fas fa-user-slash"></i>Concern Message</a></li>
                    <li><a href="BarangayResidentPendingRegister.aspx"><i class="fas fa-user-slash"></i>Pending Register Users</a></li>
                    <li><a href="DisApprovedApplicationRegisterResident.aspx"><i class="fas fa-user-slash"></i>Disapproved Register Users</a></li>
                    <li><a href="BarangayResidentInformation.aspx"><i class="fas fa-file-alt"></i>Barangay Clearance</a></li>
                     <li><a href="barangayclearanceunregistered.aspx"><i class="fas fa-file-alt"></i>Business Clearance Unregistered</a></li>
                     <li><a href="BarangayBusinessClearanceRegistered.aspx"><i class="fas fa-file-alt"></i>Business Clearance Registered</a></li>
                     <li><a href="BarangayBusinessClearanceDisapproved.aspx"><i class="fas fa-file-alt"></i>Business Clearance Disapproved</a></li>
                    <li><a href="Addbarangayofficalmainpage.aspx"><i class="fas fa-file-alt"></i>Add Offical Display Main Page</a></li>
                    <li><a href="BarangayAdminRegister.aspx"><i class="fas fa-file-alt"></i>Add Account Barangay Officals</a></li>
                     <li><a href="Addpurposes.aspx"><i class="fas fa-user-slash"></i>Add Purpose</a></li>
                       <li><a href="History.aspx"><i class="fas fa-user-slash"></i>History</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right navbar-user">
                    
                     <li class="dropdown user-dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"><asp:Label ID="lblfullname" runat="server" Text=" fullname"></asp:Label></i><b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><asp:LinkButton ID="Linkchangepasswprd" OnClick="Linkchangepasswprd_Click" class="fa fa-lock" runat="server"> Change Password</asp:LinkButton></li>
                            <li class="divider"></li>
                             <li><asp:LinkButton ID="Linklogout" OnClick="Linklogout_Click" class="fa fa-power-off"  runat="server"> Logout</asp:LinkButton></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
                <div>
        <div class="row text-center">
            <asp:Label ID="lblID" Visible="false" runat="server" ForeColor="White" Text="Label"></asp:Label>
            <asp:Label ID="lbldate" Visible="false" runat="server" ForeColor="White" Text="Label"></asp:Label>
             <asp:Label ID="lblactivity" Visible="false" runat="server" Text="Logout" ForeColor="White"></asp:Label>
            <asp:Label ID="lbldisapprove" Visible="false" runat="server" Text="Disapproved" ForeColor="White"></asp:Label>
            <h1>Barangay Business Clearance Denied</h1>
        </div>
          <div>
            <label for="firstname" class="col-md-2">
                <br />
                BusinessClearanceNo:
            </label>
            <div class="col-md-9">
                <br />
                <asp:Label ID="lblcontrolnumber" runat="server" Font-Bold="True" Font-Size="Large" Text="Label"></asp:Label>
            </div>
        </div>       
            <div>
            <label for="firstname" class="col-md-2">
                <br />
                Onwer name:
            </label>
            <div class="col-md-9">
                <br />
                <asp:Label ID="lblownername" runat="server" Font-Bold="True" Font-Size="Large" Text="Label"></asp:Label>
            </div>
           
        </div>        
        <div>
            <label for="lastname" class="col-md-2">
                <br />
                Email:
            </label>
            <div class="col-md-9">
                <br />
                <asp:Label ID="lblemail" runat="server" Font-Bold="True" Font-Size="Large" Text="Label"></asp:Label>
            </div>
        </div>
        <div>
            <label for="emailaddress" class="col-md-2">
                <br />
                Contact Number:
            </label>
            <div class="col-md-9">
                <br />
                <asp:Label ID="lblmobilenumber" runat="server" Font-Bold="True" Font-Size="Large" Text="Label"></asp:Label>
            </div>
        </div>
        <div>
            <label for="password" class="col-md-2">
                <br />
                Business Name:
            </label>
            <div class="col-md-9">
                <br />
                <asp:Label ID="lblbusinessname" runat="server" Font-Bold="True" Font-Size="Large" Text="Label"></asp:Label>
            </div>
        </div>
            <div>
            <label for="password" class="col-md-2">
                <br />
                Business Address:
            </label>
            <div class="col-md-9">
                <br />
                 <asp:Label ID="lblbusinessaddress" runat="server" Font-Bold="True" Font-Size="Large" Text="Label"></asp:Label>
                <br />
            </div>
             
        </div>
            <div>
            <label for="password" class="col-md-2">
                <br />
              Status:
            </label>
            <div class="col-md-9">
                <br />
              <asp:Label ID="lblstatus" runat="server" Text="Label" Font-Bold="True" Font-Size="Large"></asp:Label>
            </div>
             
        </div>
            <div class="row">
                 <div class="col-md-2">
            </div>
            <div class="col-md-10">
              <asp:Button ID="btndisapprovedt" OnClick="btndisapprovedt_Click" class="btn btn-info" runat="server" Text="Disapproved" />
                <br />
                <br />
                <button type="submit" class="btn btn-info">
                    <a href="barangayclearanceunregistered.aspx">Back</a></button>
                <br />
                <br />
            </div>
        </div>

        </div>  
              </div>

</asp:Content>
