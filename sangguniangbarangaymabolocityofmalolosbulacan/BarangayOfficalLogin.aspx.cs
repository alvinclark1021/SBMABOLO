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
using System.Collections;
using System.Net;
using DocumentFormat.OpenXml.Spreadsheet;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class BarangayOfficalLogin : System.Web.UI.Page
    {
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmds;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlCommand com;
        SqlDataAdapter sqlda;
        string str;
        DataTable dt;
        int RowCount;
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                Response.Redirect("BarangayAdminDashboard.aspx");
            }
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd HH:mm ");
            if (!IsPostBack)
            {
                if (Request.Cookies["tbl_Email"] != null && Request.Cookies["tbl_Password"] != null)
                {
                    txtusername.Text = Request.Cookies["tbl_Email"].Value;
                    txtpassword.Attributes["value"] = Request.Cookies["tbl_Password"].Value;
                }
            }
        }

        protected void btnsubmitlogin_Click(object sender, EventArgs e)
        {
            string Emailaddress = txtusername.Text.Trim();
            string Password = txtpassword.Text.Trim();
            string FullName = "";
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "SELECT * FROM BarangayOfficalInformation";
            com = new SqlCommand(str);
            sqlda = new SqlDataAdapter(com.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                FullName = dt.Rows[i]["tbl_Fullname"].ToString();
                Emailaddress = dt.Rows[i]["tbl_Email"].ToString();
                Password = dt.Rows[i]["tbl_Password"].ToString();
                if (Emailaddress == txtusername.Text && Password == txtpassword.Text)
                {
                    Session["admin"] = Emailaddress;

                    cmds = new SqlCommand(@"INSERT INTO Activity (Username, Activity, Date) VALUES (@Username, @Activity, @Date)");

                    cmds.Parameters.AddWithValue("@Username", txtusername.Text);
                    cmds.Parameters.AddWithValue("@Activity", lblactivity.Text);
                    cmds.Parameters.AddWithValue("@Date", lbldate.Text);

                    cons.Open();
                    cmds.Connection = cons;
                    cmds.ExecuteNonQuery();
                    cons.Close();

                    // Send login notification email
                    string recipientEmail = Emailaddress; // Email address to send the notification to
                    string recipientName = FullName; // Add the recipient's full name
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

                   

                    string redirectScript = $"swal('Hi {FullName}, Your Account Login Has Been Successful!', '', 'success').then(function() {{ window.location = 'BarangayAdminDashboard.aspx'; }});";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Invalid Email Address or Password!', '', 'error')", true);
                }
            }



            if (Checkmetologin.Checked)
                {
                    Response.Cookies["tbl_Email"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["tbl_Password"].Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    Response.Cookies["tbl_Email"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["tbl_Password"].Expires = DateTime.Now.AddDays(-1);
                }
                Response.Cookies["tbl_Email"].Value = txtusername.Text.Trim();
                Response.Cookies["tbl_Password"].Value = txtpassword.Text.Trim();
            }

        
        }
    
}

