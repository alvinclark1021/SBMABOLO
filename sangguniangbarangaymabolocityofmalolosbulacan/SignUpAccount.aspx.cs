using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.IO;
using System.Threading;
using System.Web.Security;
using static System.Net.WebRequestMethods;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.Reflection.Emit;
using Google.Apis.Admin.Directory.directory_v1.Data;
using System.Web.UI.HtmlControls;
using static Google.Apis.Admin.Directory.directory_v1.DirectoryService;
using System.Xml.Linq;
using System.Globalization;
using System.Windows;
using DocumentFormat.OpenXml.Wordprocessing;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class SignUpAccount : System.Web.UI.Page
    {
        public static readonly DateTime Mindate;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            //To Disable the Future Dates in CalendarExtender control
            CalendarExtender1.StartDate = new  DateTime(1900,1,1);
            //To Disable the Pass Dates in CalendarExtender control
            CalendarExtender1.EndDate = DateTime.Now;
            txtmobilenumber.Attributes.Add("maxlength", "11");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd HH:mm ");
            LOADBarangayResidentInformation();

            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            

        }

        private void LOADBarangayResidentInformation()
        {
          
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM tbl_createaccount";
            int count = (int)cmd.ExecuteScalar();
            con.Close();

            string datePart = DateTime.Today.ToString("MMddyyyy");
            string sequenceNumber = (count + 1).ToString("D1");

            lblregistationno.Text ="Mabolo" + datePart + "-" + sequenceNumber;

        }

        private Boolean checkemailregistedusername()
        {
            

            bool userExists = false;
            string myQuery = "SELECT COUNT(*) FROM tbl_createaccount WHERE tbl_username = @username AND tbl_password = @password";
            SqlCommand cmd = new SqlCommand(myQuery, con);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
            {
                userExists = true;
            }
            con.Close();
            return userExists;
        }

        private Boolean checkemailregisted()
        {
            Boolean emailregistedalready = false;
            String myquery = "Select tbl_email from tbl_createaccount where tbl_email='" + txtemail.Text + "'";
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

        protected void btnemail_Click(object sender, EventArgs e)
        {
                try
                {
                    if (checkemailregisted() == true)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Email is already registered.','','info')", true);
                    }
                    else
                    {
                    if (Page.IsValid)
                    {
                        try
                        {
                            string random = gencode();
                            email = txtemail.Text;
                            sendMsg(email, random);

                            Session["Code"] = random;
                            Session["VerificationCode"] = random;
                            Session["VerificationCodeExpiration"] = DateTime.Now.AddMinutes(15); // 15 minutes expiration
                            lblresendemail.Text = txtemail.Text;
                            divemailalreadyexistingornot.Visible = false;
                            divconfirmcodesemail.Visible = true;
                        }
                        catch
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                            "swal('System Under Maintenance','','Warning')", true);
                        }
                    }

                }
                }

                catch
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('please wait loading page','','Warning')", true);
                    return;
                }    
        }

        public String gencode()
        {
            var chars = "0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new string(stringChars);
            return finalString;
        }

        public static void sendMsg(string email, string random)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");
            //smtp.Credentials = new System.Net.NetworkCredential("1021@sangguniangbarangaymabolomaloloscitybulacan.com", "1021Alvin!");
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "Hello " + email;
            msg.Body += "<span style=\"font-size:18px;\">Hello, " + email + "</span>";
            msg.Body += "<br>";
            msg.Body += "<span style=\"font-size:18px;\">Verify your new Sangguniang Barangay Mabolo Account for online document request.</span>";
            msg.Body += "<br>";
            msg.Body += "<br>";
            msg.Body += "<table>";
            msg.Body += "<tr>";
            msg.Body += "<td><span style=\"font-size:18px;\">To verify your Email Address, please use the following One Time Password (OTP):</span></td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td><span style=\"font-size:65px;\">" + random + "</span></td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td><span style=\"font-size:18px;\">Your OTP is valid for 15 minutes.</span></td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td><span style=\"font-size:18px;\">Do not share this OTP with anyone. Sangguniang Barangay Mabolo Account takes your account security very seriously.</span></td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td><span style=\"font-size:18px;\">If you receive a suspicious email with a link to update your account information, do not click on the link -- instead, report the email to sangguniangbarangaymabolo@gmail.com</span></td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td><span style=\"font-size:18px;\">From: Sangguniang Barangay Mabolo Team</span></td>";
            msg.Body += "</tr>";
            msg.Body += "</table>";


            string toAddress = email;
            msg.To.Add(toAddress);

            string fromAddress = "\"Sangguniang Barangay Mabolo\" <sangguniangbarangaymabolo@gmail.com>";
            msg.From = new MailAddress(fromAddress);
            msg.IsBodyHtml = true;

            try
            {
                smtp.Send(msg);
            }
            catch
            {
                //throw;
            }
        }

        protected void btnconfirmationcodeemail_Click(object sender, EventArgs e)
        {
            string userVerificationCode = txtactivationcode.Text;
            string sessionVerificationCode = Session["VerificationCode"] as string;
            DateTime expirationTime = (DateTime)Session["VerificationCodeExpiration"];

            if (Session["Code"].ToString() == txtactivationcode.Text)
            {
                if (userVerificationCode == sessionVerificationCode && DateTime.Now < expirationTime)
                {
                    divconfirmcodesemail.Visible = false;
                    divregisterusers.Visible = true;

                }
                else
                {
                    // Verification failed or expired
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Verification code is Expired ','','error')", true);
                    txtactivationcode.Text = string.Empty;
                }

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Verification code is invalid','','info')", true);
                txtactivationcode.Text = string.Empty;

            }
        }

        protected void bntback_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void linklogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        

        protected void linkmeback_Click(object sender, EventArgs e)
        {
            divemailalreadyexistingornot.Visible = true;
            divconfirmcodesemail.Visible = false;
        }

        protected void Btnresendemail_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string random = gencode();
                    email = lblresendemail.Text;
                    sendMsg(email, random);

                    Session["VerificationCode"] = random;
                    Session["VerificationCodeExpiration"] = DateTime.Now.AddMinutes(15); // 5 minutes expiration
                    Session["Code"] = random;
                    lblresendemail.Text = lblresendemail.Text;
                    divemailalreadyexistingornot.Visible = false;
                    divconfirmcodesemail.Visible = true;

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                    "swal('Email has resend please check your email','','success')", true);
                }
                catch
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                    "swal('System has not function','','Warning')", true);
                }
            }
        }

        SqlConnection conqw = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdqwq;


        



        protected void btnsignup_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("SELECT COUNT(*) FROM tbl_createaccount WHERE tbl_name LIKE @tbl_name AND tbl_mobilenumber LIKE @tbl_mobilenumber AND tbl_birthday LIKE @tbl_birthday AND tbl_address LIKE @tbl_address", con);
            cmd.Parameters.AddWithValue("@tbl_name", txtfullname.Text);
            cmd.Parameters.AddWithValue("@tbl_mobilenumber", txtmobilenumber.Text);
            cmd.Parameters.AddWithValue("@tbl_address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@tbl_birthday", txtbirthday.Text);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            if (count > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "swal('Your account is already registered.', '', 'warning')", true);
                return;
            }
            else
            {
                // Save the data to the database
                // Rest of your code...
                string fileName = FileUpload1.FileName;
                string fileExtension = Path.GetExtension(fileName);

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
                {

                    if (checkemailregistedusername() == true)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                           "swal('Username or password already exists.','','error')", true);
                        
                    }
                    else
                    {
                        // Save the data
                        try
                        {
                            FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "Pendingregistationresident/" + fileName);
                            con.Open();
                            cmd = new SqlCommand("INSERT INTO tbl_createaccount (tbl_name, tbl_email, tbl_username, tbl_password, tbl_mobilenumber , tbl_Gender, tbl_address , tbl_birthday, tbl_validid ,residentcontrolnumber,date,defaultaddress,TypeID,Idnumber) VALUES (@tbl_name, @tbl_email, @tbl_username, @tbl_password, @tbl_mobilenumber , @tbl_Gender, @tbl_address, @tbl_birthday, @tbl_validid ,@residentcontrolnumber, @date, @defaultaddress,@TypeID,@Idnumber)", con);
                            cmd.Parameters.AddWithValue("@tbl_name", txtfullname.Text);
                            cmd.Parameters.AddWithValue("@tbl_email", txtemail.Text);
                            cmd.Parameters.AddWithValue("@tbl_username", txtusername.Text);
                            cmd.Parameters.AddWithValue("@tbl_password", txtpassword.Text);
                            cmd.Parameters.AddWithValue("@tbl_mobilenumber", txtmobilenumber.Text);
                            cmd.Parameters.AddWithValue("@tbl_Gender", Selectedmaleorfemale.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@tbl_address", txtaddress.Text);
                            cmd.Parameters.AddWithValue("@tbl_birthday", txtbirthday.Text);

                            cmd.Parameters.AddWithValue("@tbl_validid", fileName);
                            cmd.Parameters.AddWithValue("@residentcontrolnumber", lblregistationno.Text);
                            cmd.Parameters.AddWithValue("@date", lbldate.Text);
                            cmd.Parameters.AddWithValue("@defaultaddress", txtdefaultaddress.Text);
                            cmd.Parameters.AddWithValue("@TypeID", DropDownList1.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@Idnumber", txtidnumber.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            conqw.Open();
                            cmdqwq = new SqlCommand("INSERT INTO tbl_transacationhistory (Name, Activity, Controlno, Username, Date ) VALUES (@Name, @Activity, @Controlno, @Username, @Date )", conqw);
                            cmdqwq.Parameters.AddWithValue("@Name", txtfullname.Text);
                            cmdqwq.Parameters.AddWithValue("@Activity", lblactivitys.Text);
                            cmdqwq.Parameters.AddWithValue("@Username", txtusername.Text);
                            cmdqwq.Parameters.AddWithValue("@Controlno", lblregistationno.Text);
                            cmdqwq.Parameters.AddWithValue("@Date", lbldate.Text);
                            cmdqwq.ExecuteNonQuery();
                            conqw.Close();

                            // email send after to registation your account
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<span style=\"font-size:19px;\">Hello, " + txtfullname.Text + "</span><br/>");
                            sb.Append("<span style=\"font-size:19px;\">Your account has been created but needs to be approved by the administrator before you can login.</span><br/>");
                            sb.Append("<span style=\"font-size:19px;\">An email will be sent to the email address you used when you registered this account once it has been approved.</span><br/>");
                            sb.Append("<span style=\"font-size:19px;\">Thank you for your patience.</span>");
                            sb.Append("<br/><br/><span style=\"font-size:19px;\">Your information details:</span> <br/>");
                            sb.Append("<span style=\"font-size:17px;\">Registration no         : " + lblregistationno.Text + "</span><br/>");
                            sb.Append("<span style=\"font-size:17px;\">Date of Registration    : " + lbldate.Text + "</span><br/>");
                            sb.Append("<span style=\"font-size:17px;\">Name                    : " + txtfullname.Text + "</span><br/>");
                            sb.Append("<span style=\"font-size:17px;\">Address                 : " + txtaddress.Text + " " + txtdefaultaddress.Text + "</span><br/>");
                            sb.Append("<span style=\"font-size:17px;\">Email                   : " + txtemail.Text + "</span><br/>");



                            MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", txtemail.Text.Trim(), "Account Awaiting Approval ", sb.ToString());

                            SmtpClient smtp = new SmtpClient();

                            smtp.Host = "smtp.gmail.com";

                            smtp.Port = 587;

                            smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");

                            smtp.EnableSsl = true;
                            message.IsBodyHtml = true;
                            smtp.Send(message);
                            SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
                            SqlCommand cmdss;
                            cmdss = new SqlCommand(@"Insert Into Activity (Name,Username,Activity,Date,BarangayControlNo) Values (@Name,@Username,@Activity,@Date,@BarangayControlNo)");
                            cmdss.Parameters.AddWithValue("@Name", txtfullname.Text);
                            cmdss.Parameters.AddWithValue("@Username", txtusername.Text);
                            cmdss.Parameters.AddWithValue("@Activity", lblactivity.Text);
                            cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
                            cmdss.Parameters.AddWithValue("@BarangayControlNo", lblregistationno.Text);
                            conss.Open();
                            cmdss.Connection = conss;

                            cmdss.ExecuteNonQuery();
                            conss.Close();
                            // Account creation successful
                            string redirectScript = $"setTimeout(function() {{ swal('Hi {txtfullname.Text}, your account was successfully created! Please wait for an email message.', '', 'success').then(function() {{ window.location = 'Login.aspx'; }}); }}, 1000);";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", redirectScript, true);

                            DropDownList1.Text = string.Empty;
                            txtidnumber.Text = string.Empty;
                        }
                        catch (Exception ex)
                        {
                            // Handle any errors
                            // You can display an error message or log the exception
                        }

                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                   "swal('Only image (.jpg, .png) can be upload. ! ','','warning')", true);

                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "NationalId")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "DriverLicense")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "Passport")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "TINID")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "PAG-IBIGID")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "POSTALID")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "UMID")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "PRCID")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "SeniorCitizenID")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "SSSID")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "GSISID")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "OWWAID")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "PWDIS")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "Voter'sID")
            {
                FileUpload1.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "IntegratedBar")
            {
                FileUpload1.Visible = true;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                    "swal('Please Select Valid ID','','error')", true);
                return;
            }

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 2097152) //2MB = 2097152 bytes
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}