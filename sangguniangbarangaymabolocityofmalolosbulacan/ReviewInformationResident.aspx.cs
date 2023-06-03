using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;
using System.IO;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;


namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class ReviewInformationResident : System.Web.UI.Page
    {
        SqlConnection conssa = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdssa;
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
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (!Page.IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    ResidentViewInformation();
                }
                else
                {
                    Response.Redirect("BarangayResidentPendingRegister.aspx",false);
                }


            }

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
            lblfullname.Text = ds.Tables[0].Rows[0]["tbl_Fullname"].ToString();
            lblsessionlogin.Text = ds.Tables[0].Rows[0]["tbl_Email"].ToString();
            lblbarangayofficals.Text = ds.Tables[0].Rows[0]["tbl_BarangayOfficalPosition"].ToString();
            lblfullnames.Text = ds.Tables[0].Rows[0]["tbl_Fullname"].ToString();
        }


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlDataAdapter da;
        DataTable dt;
        void ResidentViewInformation()
        {
            con.Open();
            cmd = new SqlCommand(@"SELECT * FROM tbl_createaccount WHERE ID = '" + Session["ID"].ToString() + "'", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["ID"] = int.Parse(dt.Rows[0]["ID"].ToString());
                lblresidentno.Text = dt.Rows[0]["residentcontrolnumber"].ToString();
                lblfullnamess.Text = dt.Rows[0]["tbl_name"].ToString();
                lblemail.Text = dt.Rows[0]["tbl_email"].ToString();
                lblcontano.Text = dt.Rows[0]["tbl_mobilenumber"].ToString();
                lbladdress.Text = dt.Rows[0]["tbl_address"].ToString() + " " + dt.Rows[0]["defaultaddress"].ToString();
                lblbirthday.Text = dt.Rows[0]["tbl_birthday"].ToString();
                lblgender.Text = dt.Rows[0]["tbl_Gender"].ToString();

                
            }

            con.Close();
        }






        private void send()
        {
            MailMessage msg = new MailMessage();
            StringBuilder sb = new StringBuilder();
            sb.Append("<span style=\"font-size: 19px;\">Thanks, " + lblfullnamess.Text + " for registering! <br/>Your account has been activated. Today, " + lbldate.Text + "<br/></span>");
            sb.Append("<span style=\"font-size: 19px;\">Click the link below to login to your account. <br><a href=\"http://sbmabolo-001-site1.itempurl.com/Login.aspx\">Click Here </a><br/></span>");
            //sb.Append("Please click the link below to login on your account. <br> <a href=\"http://www.sangguniangbarangaymabolomaloloscitybulacan.com/Login.aspx\">Click Here To Login</a><br/>");
            MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", lblemail.Text.Trim(), "Congratulations! Your account has been approved.", sb.ToString());
            message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");
            smtp.EnableSsl = true;

            smtp.Send(message);

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");
            smtp.EnableSsl = true;
            message.IsBodyHtml = true;

            // Set the font size to 19px for the email body
            string bodyWithFontSize = "<span style=\"font-size: 19px;\">" + message.Body + "</span>";
            message.Body = bodyWithFontSize;

            smtp.Send(message);

        }


        private void deniedaccount()
        {
            string username = GetUserEmail(lblemail.Text); // Retrieve username using GetUserEmail method

            MailMessage msg = new MailMessage();
            StringBuilder sb = new StringBuilder();
            sb.Append("<span style=\"font-size: 19px;\">Hi, " + lblfullnamess.Text + "<br/>We would like to inform you that your account has been denied.<br/>" +
                "After reviewing your account information on " + lbldate.Text + "<br/></span>");
            sb.Append("<span style=\"font-size: 19px;\">The reason is: " + Dropmepuposes.SelectedItem.Value.Trim() + "<br/></span>");
            sb.Append("<span style=\"font-size: 19px;\"><a href='http://sbmabolo-001-site1.itempurl.com/contact?email=" + lblemail.Text + "'>Your Account has been permanently deleted. Please contact Sangguniang Barangay Mabolo for assistance</a><br/></span>"); // Include the link for contacting the Sangguniang Barangay Mabolo
            sb.Append("<span style=\"font-size: 19px;\">Thank you for your understanding.</span>");

            MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", lblemail.Text.Trim(), "Your Account has been Denied", sb.ToString());

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");
            smtp.EnableSsl = true;
            message.IsBodyHtml = true;

            smtp.Send(message);

        }

        private void sendemailme()
        {
            string username = GetUserEmail(lblemail.Text); // Retrieve username using GetUserEmail method

            MailMessage msg = new MailMessage();
            StringBuilder sb = new StringBuilder();
            sb.Append("<span style=\"font-size: 19px;\">Hi, " + lblfullnamess.Text + "<br/>We would like to inform you that your account has been denied.<br/>" +
                "After reviewing your account information on " + lbldate.Text + "<br/></span>");
            sb.Append("<span style=\"font-size: 19px;\">The reason is: " + Dropmepuposes.SelectedItem.Value.Trim() + "<br/></span>");
            //sb.Append("<a href='http://www.sangguniangbarangaymabolomaloloscitybulacan.com/InformationResident.aspx?username=" + username);
            sb.Append("<span style=\"font-size: 19px;\"><a href='http://sbmabolo-001-site1.itempurl.com/InformationResident.aspx?username=" + username);
            sb.Append("&email=" + lblemail.Text + "'>Click here to edit your information</a><br/></span>"); // Include the link for editing user information
            sb.Append("<b>Thanks you for your understanding.</b>");

            MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", lblemail.Text.Trim(), "Your Account has been Denied", sb.ToString());

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");
            smtp.EnableSsl = true;
            message.IsBodyHtml = true;

            smtp.Send(message);

        }


        SqlConnection conda = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlDataAdapter das;
        DataTable dts;
        SqlCommand cmdsssa;

        protected void btndisapproved_Click(object sender, EventArgs e)
        {
            
        }

        SqlCommand dsaa;

        private string GetUserEmail(string email)
        {
            string username = string.Empty;

            using (SqlConnection conda = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString))
            {
                using (SqlCommand dsaa = new SqlCommand("SELECT tbl_username FROM tbl_createaccount WHERE tbl_email=@tbl_email", conda))
                {
                    dsaa.Parameters.AddWithValue("@tbl_email", email);
                    conda.Open();
                    object result = dsaa.ExecuteScalar();
                    if (result != null)
                    {
                        username = result.ToString();
                    }
                    conda.Close();
                }
            }

            return username;
        }

       

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("BarangayOfficalLogin.aspx");
            cmdss = new SqlCommand(@"Insert Into Activity (Username,Date,Activity) Values (@Username,@Date,@Activity)", conss);

            cmdss.Parameters.AddWithValue("@Username", lblfullname.Text);
            cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
            cmdss.Parameters.AddWithValue("@Activity", lbllogout.Text);
            conss.Open();
            cmdss.Connection = conss;
            cmdss.ExecuteNonQuery();
            conss.Close();
        }

        protected void Btnreviewvalidid_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewValidid.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }


       
        protected void Btnapprovedordenied_Click(object sender, EventArgs e)
        {
            if (Dropmepuposes.SelectedValue == "Validateme")
            {
                conssa.Open();
                cmdssa = new SqlCommand(@"UPDATE tbl_createaccount SET Status='Approved', Purposeandreason=@Purposeandreason WHERE ID = '" + Session["ID"].ToString() + "'", conssa);
                cmdssa.Parameters.AddWithValue("@Purposeandreason", Dropmepuposes.SelectedItem.Value);
                cmdssa.ExecuteNonQuery();
                conssa.Close();
                send();
                // Account has been denied 
                string redirectScript = "swal('Approved', '', 'success').then(function() { window.location = 'BarangayResidentPendingRegister.aspx'; });";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);


            }
            else if (Dropmepuposes.SelectedValue == "RepalceID")
            {
                Session["email"] = lblemail.Text;
                conda.Open();
                cmdsssa = new SqlCommand(@"UPDATE tbl_createaccount SET Status='Disapproved', Purposeandreason=@Purposeandreason WHERE ID = '" + Session["ID"].ToString() + "'", conda);
                cmdsssa.Parameters.AddWithValue("@Purposeandreason", Dropmepuposes.SelectedItem.Value);
                cmdsssa.ExecuteNonQuery();
                conda.Close();

                // Account has been denied 
                string redirectScript = "swal('Denied', '', 'warning').then(function() { window.location = 'BarangayResidentPendingRegister.aspx'; });";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

                sendemailme();
                
            }
            else if (Dropmepuposes.SelectedValue == "NotResident")
            {
                Session["email"] = lblemail.Text;
                conda.Open();
                cmdsssa = new SqlCommand(@"UPDATE tbl_createaccount SET Status='Disapproved',Purposeandreason=@Purposeandreason WHERE ID = '" + Session["ID"].ToString() + "'", conda);
                cmdsssa.Parameters.AddWithValue("@Purposeandreason", Dropmepuposes.SelectedItem.Value);
                cmdsssa.ExecuteNonQuery();
                conda.Close();
                deniedaccount();
                // Account has been denied 
                string redirectScript = "swal('Denied', '', 'warning').then(function() { window.location = 'BarangayResidentPendingRegister.aspx'; });";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

                sendemailme();
               
            }
            else if (Dropmepuposes.SelectedValue == "Requirements")
            {
                Session["email"] = lblemail.Text;
                conda.Open();
                cmdsssa = new SqlCommand(@"UPDATE tbl_createaccount SET Status='Disapproved',Purposeandreason=@Purposeandreason WHERE ID = '" + Session["ID"].ToString() + "'", conda);
                cmdsssa.Parameters.AddWithValue("@Purposeandreason", Dropmepuposes.SelectedItem.Value);
                cmdsssa.ExecuteNonQuery();
                conda.Close();

                // Account has been denied 
                string redirectScript = "swal('Denied', '', 'warning').then(function() { window.location = 'BarangayResidentPendingRegister.aspx'; });";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);
                sendemailme();
                
            }

            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                    "swal('Please Select Purposes','','error')", true);
                return;
            }
        }
    }
}