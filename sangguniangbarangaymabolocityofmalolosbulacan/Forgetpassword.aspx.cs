using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using System.Net;
using DocumentFormat.OpenXml.Wordprocessing;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class Forgetpassword : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        DataTable dt = new DataTable();

        string token = Guid.NewGuid().ToString();


        protected void Page_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
        }



        private void SendEmail(string name, string email, string resetLink)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<p style='font-size:19px;'>Hi " + name + ",<br/>");
                sb.Append("We're sending you this email because you requested a password reset. ");
                sb.Append("Click the link below to create a new password. <a href='" + resetLink + "'>Click Here</a>. ");
                sb.Append("Your new password must:<br/></p>");
                sb.Append("<p style='font-size:19px;'>* Contain 6 characters </p>");
                sb.Append("<p style='font-size:19px;'>* Contain at least one mixed-case letter  </p>");
                sb.Append("<p style='font-size:19px;'>* Contain at least one number </p>");
                sb.Append("<p style='font-size:19px;'>* Not be the same as your previous password </p>");
                sb.Append("<p style='font-size:19px;'>This link will expire in 1 hour. After that, you'll need to submit a new request to reset your password. ");
                sb.Append("If you didn't request a password reset, you can ignore this email. Thank You.</p>");
                sb.Append("<p style='font-size:19px;'><b>From: Sangguniang Barangay,</b><br/>");
               

                MailMessage message = new System.Net.Mail.MailMessage("sangguniangbarangaymabolo@gmail.com", email.Trim(), "Reset Your Password", sb.ToString());

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");
                smtp.EnableSsl = true;

                message.IsBodyHtml = true;

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                // handle exception here
            }
        }


        protected void btnsendemail_Click(object sender, EventArgs e)
        {

            // ...

            Session["email"] = txtrecoveryemail.Text;
            Session["token"] = DateTime.Now;

            string name = string.Empty;

            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM tbl_createaccount WHERE tbl_email=@tbl_email AND Status='Approved'", con);
            con.Open();

            adp.SelectCommand.Parameters.AddWithValue("@tbl_email", txtrecoveryemail.Text);
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                name = dt.Rows[0]["tbl_name"].ToString();

                // Generate a unique token
                string resetToken = Guid.NewGuid().ToString();

                // Set reset token and expiration time
                DateTime expirationTime = DateTime.Now.AddHours(1);

                // Update the tbl_createaccount table
                SqlCommand cmd = new SqlCommand("UPDATE tbl_createaccount SET reset_token=@reset_token, reset_token_expiration=@reset_token_expiration WHERE tbl_email=@tbl_email", con);
                cmd.Parameters.AddWithValue("@reset_token", resetToken);
                cmd.Parameters.AddWithValue("@reset_token_expiration", expirationTime);
                cmd.Parameters.AddWithValue("@tbl_email", txtrecoveryemail.Text);
                cmd.ExecuteNonQuery();

                // Construct the reset link with the unique token
                string resetLink = "http://sbmabolo-001-site1.itempurl.com/ResetPassword.aspx?token=" + resetToken;
                //string resetLink = "https://localhost:44304/ResetPassword.aspx?token=" + resetToken;

                // Send the reset link in an email
                SendEmail(name, txtrecoveryemail.Text, resetLink);

                // ...

                string emailAddress = Session["email"].ToString();
                string redirectScript = $"swal('Email has been sent to {emailAddress} with a reset link. Please check your inbox and/or spam folder.', '', 'success').then(function() {{ window.location = 'Login.aspx'; }});";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

                // ...

                con.Close();

                txtrecoveryemail.Text = "";
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your email has not been found or has not yet been approved.', '', 'error')", true);
                txtrecoveryemail.Text = "";
            }


        }

    }
}