using Google.Apis.Admin.Directory.directory_v1.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class suggestion : System.Web.UI.Page
    {
        SqlConnection cona = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmds;
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd HH:mm ");
            
            txtcontactnumber.Attributes.Add("maxlength", "11");

        }

       
        protected void Btnsubmitme_Click(object sender, EventArgs e)
        {

            SqlDataAdapter adp = new SqlDataAdapter("select * from tbl_createaccount where tbl_email=@tbl_email ", con);
            con.Open();

            //adp.SelectCommand.Parameters.AddWithValue("@residentcontrolnumber", txtregisterno.Text);
            adp.SelectCommand.Parameters.AddWithValue("@tbl_email", txtemail.Text);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                try
                {
                    cons.Open();
                    cmds = new SqlCommand(@"INSERT INTO Concernmessage (Email,Name,Contactnumber,Message,datetoday) 
                                VALUES (@Email,@Name,@Contactnumber,@Message,@datetoday)", cons);
                    //cmds.Parameters.AddWithValue("@RegistationNO", txtregisterno.Text);
                    cmds.Parameters.AddWithValue("@Name", txtname.Text);
                    cmds.Parameters.AddWithValue("@Contactnumber", txtcontactnumber.Text);
                    
                    cmds.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmds.Parameters.AddWithValue("@Message", txtmessagebox.Text);
                    cmds.Parameters.AddWithValue("@datetoday", lbldate.Text);
                    cmds.ExecuteNonQuery();
                    cons.Close();

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<span style=\"font-size: 19px;\">Hi, " + txtname.Text + "<br/>");
                    sb.Append("Thank you for your concern regarding your not-yet-activated account. I have checked your information, and I will advise you to wait for your account to be activated within a day. I hope you can patiently wait for the activation of your account.<br/><br/>");
                    sb.Append("Your details:<br/>");
                    sb.Append("Name: " + txtname.Text + "<br/>");
                    sb.Append("Email: " + txtemail.Text + "<br/><br/>");
                    sb.Append("<br/>Sangguniang Barangay Mabolo<br/>City of Malolos, Bulacan<br/><br/>");

                    MailMessage message = new System.Net.Mail.MailMessage("sangguniangbarangaymabolo@gmail.com", txtemail.Text.Trim(), "Please Wait your account be activated this day ", sb.ToString());

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential("sangguniangbarangaymabolo@gmail.com", "donqtviszauaucyd");

                    smtp.EnableSsl = true;

                    message.IsBodyHtml = true;

                    smtp.Send(message);

                    //txtregisterno.Text = "";
                    txtname.Text = "";
                    txtemail.Text = "";
                   
                    txtcontactnumber.Text = "";

                    // Account creation successful
                    string redirectScript = "swal('Concern message send Success!', '', 'success').then(function() { window.location = 'index.aspx'; });";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

                  

                }
                catch (Exception ex)
                {
                    // Handle exceptions that may occur during email sending or database update/insert
                    // e.g., log the error, display an error message, etc.
                    Console.WriteLine("Failed to send email or update/insert data. Error: " + ex.Message);
                }

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                     "swal('Registration No has not found or not yet create account please create account.','','error')", true);
            }

           


        }
    }
}