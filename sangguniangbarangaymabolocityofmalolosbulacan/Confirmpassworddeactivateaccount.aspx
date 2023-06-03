<%@ Page Title="" Language="C#" MasterPageFile="~/ResidentDashboard.Master" AutoEventWireup="true" CodeBehind="Confirmpassworddeactivateaccount.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.Confirmpassworddeactivateaccount" %>
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
                <a class="navbar-brand" href="ResidentDashboard.aspx">Barangay Mabolo</a>
            </div>
            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav side-nav">
                   <li class="active"><a href="ResidentDashboard.aspx"><i class="fa fa-tachometer"></i> Dashboard</a></li>
                  
                    <li><a href="BarangayClearance.aspx"><i class="fa fa-file-text-o"></i> Certification Clearance</a></li>
                    <li><a href="BarangayBusinessClearance.aspx"><i class="fa fa-file-text-o"></i> Certification Business Clearance</a></li>
                    <li><a href="Barangayoccupanypermit.aspx"><i class="fa fa-file-text-o"></i> Certification Occupancy Permit</a></li>
                    <li><a href="BarangayRequestDocuments.aspx"><i class="fa fa-file-text-o"></i>Certification Good Moral</a></li>
                    <li><a href="Cerficationofresidency.aspx"><i class="fa fa-file-text-o"></i> Certification Residency</a></li>
                    <li><a href="Certificationofindigency.aspx"><i class="fa fa-file-text-o"></i> Certification Indigency</a></li>
                    <li><a href="ExcavationCuttingPermit.aspx"><i class="fa fa-file-text-o"></i> Certification Excavation Permit</a></li>
                    <li><a href="permittoconstruct.aspx"><i class="fa fa-file-text-o"></i> Certification Permit to Construct</a></li>
                    <li><a href="FencingPermit.aspx"><i class="fa fa-file-text-o"></i> Certification Fencing Permit</a></li>
                      <li><a href="transactionhistory.aspx"><i class="fa fa-history"></i> History</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right navbar-user">
                    
                     <li class="dropdown user-dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"><asp:Label ID="lblfullname" runat="server" Text="fullname"></asp:Label></i><b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><asp:LinkButton ID="Linkchangepasswprd" OnClick="Linkchangepasswprd_Click" class="fa fa-lock" runat="server"> Change Password</asp:LinkButton></li>
                            <li><asp:LinkButton ID="linkprofile" OnClick="linkprofile_Click" class="fa fa-user" runat="server"> Profile</asp:LinkButton></li>
                             <li><asp:LinkButton ID="linkdeactivateaccount" OnClick="linkdeactivateaccount_Click" class="fa fa-power-off"  runat="server"> Deactivate account</asp:LinkButton></li>
                            <li class="divider"></li>
                             <li><asp:LinkButton ID="Linklogout" OnClick="Linklogout_Click" class="fa fa-power-off"  runat="server"> Logout</asp:LinkButton></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
           <div>
        <div class="row text-center">
            <h2>Confirmation Password</h2>
        </div>
        <div>
            <label for="firstname" class="col-md-2">
                Enter Password :
            </label>

            <div class="col-md-9">
             <asp:TextBox ID="txtcurrentpassword" class="form-control" placeholder="Current Password" TextMode="Password" Width="100%" Height="32px" required="" runat="server"></asp:TextBox>
            </div>
        </div>        
        <div class="row">
            <div class="col-md-2">
            </div>
            <div class="col-md-10">
                  <asp:Button ID="btnconfirmatinpassword" class="btn btn-info" OnClick="btnconfirmatinpassword_Click" runat="server" Text="Confirm Password" />
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
