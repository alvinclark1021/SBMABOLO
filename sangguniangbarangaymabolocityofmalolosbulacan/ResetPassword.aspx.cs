using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Net.Mail;
using System.Net;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd HH:mm ");
            try
            {
                string email = Session["email"].ToString();
                Session["token"] = DateTime.Now;
            }

            catch
            {
                Response.Redirect("Forgetpassword.aspx");
            }
            
        }

       
        private Boolean checkemailregistedusername()
        {
            Boolean emailregistedalready = false;
            String myquery = "Select * from tbl_createaccount where tbl_password='" + txtpassword.Text + "'";
            cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            DataSet dss = new DataSet();
            ds.Fill(dss);
            if (dss.Tables[0].Rows.Count > 0)
            {
                emailregistedalready = true;
            }
            con.Close();

            return emailregistedalready;
        }


        protected void btnresetpassword_Click(object sender, EventArgs e)
        {

            string email = Session["email"].ToString();
            DateTime currentDateTime = DateTime.Now;

            // check if token is still valid
            SqlCommand cmd = new SqlCommand("SELECT tbl_name, reset_token_expiration FROM tbl_createaccount WHERE tbl_email=@tbl_email AND reset_token=@reset_token", con);
            cmd.Parameters.AddWithValue("@tbl_email", email);
            cmd.Parameters.AddWithValue("@reset_token", Request.QueryString["token"]);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string name = reader["tbl_name"].ToString();
                DateTime tokenExpiration = (DateTime)reader["reset_token_expiration"];

                // Close the existing SqlDataReader
                reader.Close();

                if (tokenExpiration < currentDateTime)
                {
                    // token is expired or invalid
                    string redirectScript = "setTimeout(function() { swal('Your reset link has expired.', '', 'error').then(function() { window.location = 'Forgetpassword.aspx'; }); }, 1000);";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);
                }
                else
                {
                    // token is still valid, update password
                    if (checkemailregistedusername())
                    {
                        if (txtpassword.Text != txtconfirmationpassword.Text)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Passwords do not match. Please try again.', '', 'warning')", true);
                            return;
                        }
                        else
                        {
                            // token is still valid, update password
                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }
                            cmd = new SqlCommand("UPDATE tbl_createaccount SET tbl_password = '" + txtpassword.Text + "' WHERE tbl_email = '" + email + "'", con);
                            cmd.ExecuteNonQuery();
                            string redirectScript = "setTimeout(function() { swal('Your password has been successfully updated.', '', 'success').then(function() { window.location = 'Login.aspx'; }); }, 1000);";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);
                            // Send the reset link in an email
                            SendPasswordUpdateConfirmationEmail(email, name);
                            txtpassword.Text = "";
                            txtconfirmationpassword.Text = "";
                            cmd.Dispose();
                            con.Close();
                        }
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Passwords are the same. Please try a different password.', '', 'warning')", true);
                    }
                }
            }
            else
            {
                // Invalid token or email
                reader.Close(); // Close the SqlDataReader
                string redirectScript = "setTimeout(function() { swal('Invalid reset link.', '', 'error').then(function() { window.location = 'Forgetpassword.aspx'; }); }, 1000);";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);
            }

            con.Close();




        }


        private void SendPasswordUpdateConfirmationEmail(string email, string name)
        {
            // Prepare the email message
            MailMessage message = new MailMessage();
            message.From = new MailAddress("sbmabolo522@gmail.com"); // Replace with your email address
            message.To.Add(email);
            message.Subject = "Password Update Confirmation";


            message.Body = $"<html><body><p style='font-size: 19px;'>Dear {name},</p>";
            message.Body += $"<p style='font-size: 19px;'>Your password has been successfully updated.</p>";
            message.Body += $"<p style='font-size: 19px;'>Date to reset password: {lbldate.Text}</p></body></html>";
            message.IsBodyHtml = true; // Set the email body as HTML

            // Configure the SMTP client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx"); // Replace with your email credentials

            // Send the email
            smtpClient.Send(message);
            



        }

        protected void linklogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
    
}