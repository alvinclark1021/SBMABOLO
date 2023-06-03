using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System.Net;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        DataTable dts= new DataTable();

        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmds;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

        //SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;

        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlCommand com;
        SqlDataAdapter sqlda;
        string str;
        DataTable dt;
        int RowCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd HH:mm ");
            string username = txtusername.Text;
            string password = txtpassword.Text;
            bool rememberMe = checkme.Checked;

            if (rememberMe)
            {
                HttpCookie cookie = new HttpCookie("UserCredentials");
                cookie.Values["username"] = username;
                cookie.Values["password"] = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie);
            }



            if (Session["user"] != null)
            {
                Response.Redirect("ResidentDashboard.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.Cookies["tbl_username"] != null && Request.Cookies["tbl_password"] != null)
                {
                    txtusername.Text = Request.Cookies["tbl_username"].Value;
                    txtpassword.Attributes["value"] = Request.Cookies["tbl_password"].Value;
                }
            }

            if (!IsPostBack)
            {
                // Check if the login button should be disabled
                DateTime disableTime = Convert.ToDateTime(Session["LoginDisabledUntil"] ?? DateTime.MinValue);
                if (disableTime > DateTime.Now)
                {
                    // Login button should be disabled
                    btnlogin.Enabled = false;

                    // Calculate the remaining time until the login button is re-enabled
                    TimeSpan remainingTime = disableTime - DateTime.Now;
                    int minutes = (int)remainingTime.TotalMinutes;
                    int seconds = (int)remainingTime.TotalSeconds % 60;

                    // Update the error message label with the remaining time
                    string message = $"Maximum login attempts reached. Please try again in {minutes} minutes and {seconds} seconds.";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                       $"swal('{message}', '', 'warning')", true);
                }
            }

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM tbl_createaccount WHERE (tbl_username=@tbl_username OR tbl_email=@tbl_email)", conss);
                conss.Open();

                adp.SelectCommand.Parameters.AddWithValue("@tbl_username", txtusername.Text);
                adp.SelectCommand.Parameters.AddWithValue("@tbl_email", txtusername.Text);

                DataTable dts = new DataTable();
                adp.Fill(dts);

                if (dts.Rows.Count > 0)
                {
                    string Email = dts.Rows[0]["tbl_email"].ToString().Trim();
                    string name = dts.Rows[0]["tbl_name"].ToString().Trim();
                    string userName = dts.Rows[0]["tbl_username"].ToString().Trim();
                    string password = txtpassword.Text.Trim();
                    string status = dts.Rows[0]["Status"].ToString().Trim();

                    if (Email == dts.Rows[0]["tbl_email"].ToString().Trim() && userName == dts.Rows[0]["tbl_username"].ToString().Trim() && password == dts.Rows[0]["tbl_password"].ToString().Trim() && status == "Approved")
                    {
                        // valid credentials
                        string username = userName;
                        bool rememberMe = checkme.Checked;

                        if (rememberMe)
                        {
                            Session["username"] = username;
                            Session["password"] = password;
                        }

                        Session["user"] = userName;
                        SqlCommand cmd = new SqlCommand(@"Insert Into tbl_transacationhistory (Username, Activity, Date) Values (@Username, @Activity, @Date)");

                        cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                        cmd.Parameters.AddWithValue("@Activity", lblactivity.Text);
                        cmd.Parameters.AddWithValue("@Date", lbldate.Text);

                        cons.Open();
                        cmd.Connection = cons;
                        cmd.ExecuteNonQuery();
                        cons.Close();

                        // Send login notification email
                        string recipientEmail = Email; // Email address to send the notification to
                        string recipientName = userName; // User's name
                        string subject = "Login Notification";
                        string body = $"Dear {recipientName},\n\nYou have successfully logged in to your account.\n\n{lbldate.Text}";

                        try
                        {
                            // Create a new MailMessage instance
                            MailMessage mailMessage = new MailMessage();
                            mailMessage.From = new MailAddress("sbmabolo522@gmail.com"); // Replace with your email address
                            mailMessage.To.Add(recipientEmail);
                            mailMessage.Subject = subject;
                            mailMessage.Body = body;

                            // Configure the SMTP client
                            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); // Replace with your SMTP server address
                            smtpClient.Port = 587; // Replace with the appropriate port number
                            smtpClient.UseDefaultCredentials = false;
                            smtpClient.Credentials = new NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx"); // Replace with your email credentials
                            smtpClient.EnableSsl = true;

                            // Send the email
                            smtpClient.Send(mailMessage);
                        }
                        catch (Exception ex)
                        {
                            // Handle email sending error
                            // You can display an error message or log the exception
                            Response.Redirect(ex.Message);
                        }

                        // Account creation successful
                        string redirectScript = $"setTimeout(function() {{ swal('Welcome {name} Your Account Has Been Login Successful!', '', 'success').then(function() {{ window.location = 'ResidentDashboard.aspx'; }}); }}, 1000);";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", redirectScript, true);

                    }
                    else
                    {
                        // invalid password or account status
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Invalid username/email or password.','','error')", true);
                    }
                }
                else
                {
                    // invalid username/email
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your account is currently under review and awaiting approval. Regarding your account's status, kindly wait for an email confirmation.','','info')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect(ex.Message);
            }

        }
    }
}