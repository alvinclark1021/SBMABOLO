<%@ Page Title="" Language="C#" MasterPageFile="~/ResidentDashboard.Master" AutoEventWireup="true" CodeBehind="deactivateaccount.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.deactivateaccount" %>
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
                <asp:Label ID="lbldate" runat="server" Text="Label" ForeColor="#033C73"></asp:Label>
            <asp:Label ID="lblsessionlogin" runat="server" Text="Label" ForeColor="#033C73"></asp:Label>
                <a class="navbar-brand" href="ResidentDashboard.aspx">Barangay Mabolo</a>
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
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"><asp:Label ID="lblfullname" runat="server" Text="fullname"></asp:Label></i><b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><asp:LinkButton ID="Linkchangepasswprd" OnClick="Linkchangepasswprd_Click" class="fa fa-lock" runat="server"> Change Password</asp:LinkButton></li>
                            <li><asp:LinkButton ID="linkprofile" OnClick="linkprofile_Click" class="fa fa-user" runat="server"> Profile</asp:LinkButton></li>
                            <li><asp:LinkButton ID="linkdeactivateaccount" OnClick="linkdeactivateaccount_Click" class="fa fa-power-off"  runat="server"> Deactivate account</asp:LinkButton></li>
                            <li class="divider"></li>
                             <li><asp:LinkButton ID="Linklogout" OnClick="Linklogout_Click" class="fa fa-power-off" OnClientClick="return confirm('Do you want to Logout?')"  runat="server"> Logout</asp:LinkButton></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
           <div>
        <div class="row text-center">
            <asp:Label ID="lblid" runat="server" Visible="false" Text="Label"></asp:Label>
            <asp:Label ID="lblname" runat="server" Visible="false" Text="Label"></asp:Label>
            <asp:Label ID="lbladdress" runat="server" Visible="false" Text="Label"></asp:Label>
            <asp:Label ID="lblemail" runat="server" Visible="false" Text="Label" ForeColor="White"></asp:Label>
            <asp:Label ID="lblstatus" runat="server" Visible="false" Text="Deactivate Account"></asp:Label>
            <h2>Deactivate Account</h2>
        </div>
        <div>
            <label for="firstname" class="col-md-2">
                Reason :
            </label>

            <div class="col-md-9">
                <asp:DropDownList ID="DropDownList1" Width="100%" Height="32px" runat="server">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem>Transfer into Other Barangay</asp:ListItem>
                    <asp:ListItem>Transfer into other places or citys</asp:ListItem>
                    <asp:ListItem>Transfer to others countries</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Reason" ControlToValidate="DropDownList1" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>        
        <div class="row">
            <div class="col-md-2">
            </div>
            <div class="col-md-10">
                  <asp:Button ID="btnchangepassword" class="btn btn-info" OnClick="btnchangepassword_Click" runat="server" OnClientClick="return confirm('Are you sure to Remove?')" Text="Deactivate Account" />
                <br />
                <br />
                <br />
                <button type="submit" class="btn btn-info">
                   <a href="ResidentDashboard.aspx">Cancel</a>
                </button>
            </div>
        </div>
    </div>  
    </div>
</asp:Content>
