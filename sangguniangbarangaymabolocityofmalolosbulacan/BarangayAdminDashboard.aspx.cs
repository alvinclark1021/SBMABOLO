using CdnJs.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class BarangayAdminDashboard1 : System.Web.UI.Page
    {

        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        SqlCommand cmd;
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            

            if (Session["admin"] != null)
            {
                lblfullname.Text = Session["admin"].ToString();

            }
            else
            {
                cmdss = new SqlCommand(@"Insert Into Activity (Username,Date,Activity) Values (@Username,@Date,@Activity)", conss);
                cmdss.Parameters.AddWithValue("@Username", lblfullname.Text);
                cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
                cmdss.Parameters.AddWithValue("@Activity", lblensission.Text);
                conss.Open();
                cmdss.Connection = conss;
                cmdss.ExecuteNonQuery();
                conss.Close();
                Response.Redirect("BarangayOfficalLogin.aspx");
            }

            if (this.Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
            
            
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "select * from BarangayOfficalInformation where tbl_Email='" + Session["admin"] + "'";
            com = new SqlCommand(str, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lblnameofoffical.Text = ds.Tables[0].Rows[0]["tbl_Fullname"].ToString();
            lblfullname.Text = ds.Tables[0].Rows[0]["tbl_Fullname"].ToString();
            lblsessionlogin.Text = ds.Tables[0].Rows[0]["tbl_Email"].ToString();
            lblbarangayofficals.Text = ds.Tables[0].Rows[0]["tbl_BarangayOfficalPosition"].ToString();


            PendingUsers();
            RegisterdUsers();
            Registerusersdenie();

            BarangayClearance();
            BarangayBusinessClearance();
            BarangayIndigency();
            BarangayFencingPermit();
            BarangayPermittocontrust();
            BarangayExcavationCutting();

            BarangayClearanceClaimDocuments();
            BarangayBusinessClearanceClaimDocuments();
            BarangayIndigencyClaimDocuments();
            BarangayFencingPermitClaimDocuments();
            BarangayPermittocontrustClaimDocuments();
            BarangayExcavationCuttingClaimDocuments();
        }
        

        public void RegisterdUsers()
        {
            string strQuery = "SELECT COUNT(*) FROM tbl_createaccount WHERE Status = 'Approved'";

            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);

            connect.Close();

            lblnewaccount.Text = dsData.Tables[0].Rows[0][0].ToString();
        }


        public void Registerusersdenie()
        {
            string strQuery = "SELECT COUNT(*) FROM tbl_createaccount WHERE Status = 'Disapproved'";

            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);

            connect.Close();

            lbldenineregisterusers.Text = dsData.Tables[0].Rows[0][0].ToString();
        }

        
        public void PendingUsers()
        {
            string strQuery = "SELECT COUNT(*) FROM tbl_createaccount WHERE Status = 'Pending'";

            connect.Open();

            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);

            connect.Close();

            lblpendingregister.Text = dsData.Tables[0].Rows[0][0].ToString();


        }


        //Barangay Pending Request Documents
        public void BarangayClearance()//BCno1
        {
            string strQuery = "SELECT COUNT(*) FROM BarangayClearanceInfomation WHERE Status = 'Pending'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);
            connect.Close();
            lblbarangayclearance.Text = dsData.Tables[0].Rows[0][0].ToString();


        }

        public void BarangayBusinessClearance()//BBCno2
        {
            string strQuery = "SELECT COUNT(*) FROM BarangayBusinessClearance WHERE Status = 'Pending'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);
            connect.Close();
            lblbarangaybusinessclearance.Text = dsData.Tables[0].Rows[0][0].ToString();


        }


        public void BarangayIndigency()//BIno3
        {
            string strQuery = "SELECT COUNT(*) FROM BarangayIndigencyInformation WHERE Status = 'Pending'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);
            connect.Close();
            lblbaranagyindigency.Text = dsData.Tables[0].Rows[0][0].ToString();


        }

        public void BarangayFencingPermit()//BFPno4
        {
            string strQuery = "SELECT COUNT(*) FROM FencingPermitInformation WHERE Status = 'Pending'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);
            connect.Close();
            lblbarangayfencingpermit.Text = dsData.Tables[0].Rows[0][0].ToString();


        }

        public void BarangayPermittocontrust()//BPCno5
        {
            string strQuery = "SELECT COUNT(*) FROM PermittocontrustInformation WHERE Status = 'Pending'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);
            connect.Close();
            lblbarangaypermittoconstruct.Text = dsData.Tables[0].Rows[0][0].ToString();


        }

        public void BarangayExcavationCutting()//BECPno6
        {
            string strQuery = "SELECT COUNT(*) FROM ExcavationCuttingInformation WHERE Status = 'Pending'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);
            connect.Close();
            lblbarangayexcavationcuttingpermit.Text = dsData.Tables[0].Rows[0][0].ToString();


        }

        // Barangay Claim Documents

        public void BarangayClearanceClaimDocuments()//BCno1
        {
            string strQuery = "SELECT COUNT(*) FROM BarangayClearanceInfomation WHERE Status = 'Claim Documents'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);
            connect.Close();
            lblclaimdocumentsbarangayclearance.Text = dsData.Tables[0].Rows[0][0].ToString();


        }

        public void BarangayBusinessClearanceClaimDocuments()//BBCno2
        {
            string strQuery = "SELECT COUNT(*) FROM BarangayBusinessClearance WHERE Status = 'Approved/ClaimDocuments'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);
            connect.Close();
            lblclaimdocumentsbarangaybusinessclearance.Text = dsData.Tables[0].Rows[0][0].ToString();


        }


        public void BarangayIndigencyClaimDocuments()//BIno3
        {
            string strQuery = "SELECT COUNT(*) FROM BarangayIndigencyInformation WHERE Status = 'ClaimDocuments'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);
            connect.Close();
            lblclaimdocumentsbarangayindigency.Text = dsData.Tables[0].Rows[0][0].ToString();


        }

        public void BarangayFencingPermitClaimDocuments()//BFPno4
        {
            string strQuery = "SELECT COUNT(*) FROM FencingPermitInformation WHERE Status = 'Claim Document'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);
            connect.Close();
            lblclaimdocumentsbarangayfencingpermit.Text = dsData.Tables[0].Rows[0][0].ToString();


        }

        public void BarangayPermittocontrustClaimDocuments()//BPCno5
        {
            string strQuery = "SELECT COUNT(*) FROM PermittocontrustInformation WHERE Status = 'Claim Document'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);
            connect.Close();
            lblclaimdocumentsbarangaypermittoconstruct.Text = dsData.Tables[0].Rows[0][0].ToString();


        }

        public void BarangayExcavationCuttingClaimDocuments()//BECPno6
        {
            string strQuery = "SELECT COUNT(*) FROM ExcavationCuttingInformation WHERE Status = 'ClaimDocuments'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            SqlDataAdapter OleDbDa = new SqlDataAdapter(cmd);
            DataSet dsData = new DataSet();
            OleDbDa.Fill(dsData);
            connect.Close();
            lblclaimdocumentsbarangayexcavationcuttingpermit.Text = dsData.Tables[0].Rows[0][0].ToString();


        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Hi," + lblsessionlogin.Text + "<br/> Your account has be Logout with date and time: " + lbldate.Text);

               
                MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", lblsessionlogin.Text.Trim(), "To Logout Account Administrator", sb.ToString());

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;

                smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");

                smtp.EnableSsl = true;
                message.IsBodyHtml = true;
                smtp.Send(message);
            }
            catch
            {
                Response.Redirect("BarangayAdminDashboard.aspx");
            }
            cmdss = new SqlCommand(@"Insert Into Activity (Name,Username,Date,Activity) Values (@Name,@Username,@Date,@Activity)", conss);
            cmdss.Parameters.AddWithValue("@Name", lblnameofoffical.Text);
            cmdss.Parameters.AddWithValue("@Username", lblfullname.Text);
            cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
            cmdss.Parameters.AddWithValue("@Activity", lbllogout.Text);
            conss.Open();
            cmdss.Connection = conss;
            cmdss.ExecuteNonQuery();
            conss.Close();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("BarangayOfficalLogin.aspx");
        }

        protected void lblmyprofilepicture_Click(object sender, EventArgs e)
        {

        }

        protected void linkprofile_Click1(object sender, EventArgs e)
        {

        }
    }
}