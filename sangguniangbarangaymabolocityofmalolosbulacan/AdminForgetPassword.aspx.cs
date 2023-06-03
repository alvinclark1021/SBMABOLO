using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Data;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class AdminForgetPassword1 : System.Web.UI.Page
    {
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsendemail_Click(object sender, EventArgs e)
        {
            try
            {

                Session["adminemail"] = txtrecoveryemail.Text;

                SqlDataAdapter adp = new SqlDataAdapter("select * from BarangayOfficalInformation where tbl_Email=@tbl_Email", con);
                con.Open();

                adp.SelectCommand.Parameters.AddWithValue("@tbl_Email", txtrecoveryemail.Text);

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    SqlCommand cmd = new SqlCommand("Update BarangayOfficalInformation set password_change_status=1 where tbl_Email='" + txtrecoveryemail.Text + "'", con);

                    cmd.ExecuteNonQuery();
                    SendEmail();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Email has send reset link ','','success')", true);
                    con.Close();

                    cmd.Dispose();

                    txtrecoveryemail.Text = "";

                }
                else
                {


                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Invalid Email','','error')", true);

                }

            }

            catch (Exception ex)
            {

            }

        }

        // using this method we sent the mail to reciever

        private void SendEmail()
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("Hi,<br/> Click on below given link to Reset Your Password<br/>");
                sb.Append("<a href=https://localhost:44304/AdminResetpassword.aspx?username=" + GetUserEmail(txtrecoveryemail.Text));
                //sb.Append("<a href=http://barangaymabolo-001-site1.dtempurl.com/ResetPassword.aspx?username=" + GetUserEmail(txtrecoveryemail.Text));
                sb.Append("&email=" + txtrecoveryemail.Text + ">Click here to change your password</a><br/>");
                sb.Append("<b>Thanks</b>,<br> Sangguniang Barangay Mabolo City of Malolos Bulacan <br/>");
                sb.Append("<br/><b> for more post </b> <br/>");

                sb.Append("thanks");

                MailMessage message = new System.Net.Mail.MailMessage("alvinkalasyo@gmail.com", txtrecoveryemail.Text.Trim(), "Reset Your Password", sb.ToString());

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;

                smtp.Credentials = new System.Net.NetworkCredential("alvinkalasyo@gmail.com", "xavuzphgthpouosf");

                smtp.EnableSsl = true;

                message.IsBodyHtml = true;

                smtp.Send(message);

            }

            catch (Exception ex)
            {

            }

        }

        private string GetUserEmail(string Email)
        {
            SqlCommand cmd = new SqlCommand("select tbl_Email from BarangayOfficalInformation WHERE tbl_Email=@tbl_Email", con);
            cmd.Parameters.AddWithValue("@tbl_Email", txtrecoveryemail.Text);
            string username = cmd.ExecuteScalar().ToString();
            return username;
        }
    }
}