using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;
using CdnJs.Core;
using System.IO;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class BarangayAdminRegister : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string email;
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            //To Disable the Future Dates in CalendarExtender control
            CalendarExtender1.StartDate = new DateTime(1900, 1, 1);
            //To Disable the Pass Dates in CalendarExtender control
            CalendarExtender1.EndDate = DateTime.Now;
            txtmobilenumber.Attributes.Add("maxlength", "11");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd HH:mm ");
            if (Session["admin"] != null)
            {
                lblfullname.Text = Session["admin"].ToString();

            }
            else
            {
                Response.Redirect("BarangayOfficalLogin.aspx");
            }

            if (this.Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
           
            LOADBarangayResidentInformation();

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
        private Boolean checkemailconfirmation()
        {
            Boolean emailregistedalready = false;
            String myquery = "Select * from BarangayOfficalInformation where tbl_Email='" + txtemail.Text + "'";
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

        private Boolean checkemailregisted()
        {
            Boolean emailregistedalready = false;
            String myquery = "Select * from BarangayOfficalInformation where tbl_BarangayOfficalPosition='" + DropDownList1.SelectedItem.Text + "'";
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

        protected void btnsubmitcreate_Click(object sender, EventArgs e)
        {

            if (checkemailregisted() == true)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                               "swal('Barangay Position has already.','','info')", true);
            }
            else
            {

                if (checkemailconfirmation() == true)
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
                            divregisteraccount.Visible = false;
                            divconfirmationcode.Visible = true;
                        }
                        catch
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                            "swal('System Under Maintenance','','Warning')", true);
                        }
                    }

                }

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
            smtp.Credentials = new System.Net.NetworkCredential("sangguniangbarangaymabolo@gmail.com", "donqtviszauaucyd");
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "Hello " + email;
            msg.Body += "Hello, " + email;
            msg.Body += " Verify your new Sangguniang Barangay Mabolo Account";
            msg.Body += "<tr>";
            msg.Body += " Welcome to Sangguniang Barangay Mabolo, Online Document Request ";
            msg.Body += "<tr>";
            msg.Body += "<td>To verify your Email Address, please use the following One Time Password (OTP) :  " + random + "</td>";
            msg.Body += "</tr>";
            msg.Body += "<td> Do not share this OTP with anyone. Sangguniang Barangay Mabolo Account takes your account security very seriously. Sangguniang Barangay Mabolo Account will never ask you to disclose or verify your Sangguniang Barangay Mabolo Account, OTP, If you receive a suspicious email with a link to update your account information, do not click on the link -- instead, report the email to sangguniangbarangaymabolo@gmail.com";
            msg.Body += "<tr>";
            msg.Body += "<td>From: Sangguniang Barangay Mabolo Team</td>";
            msg.Body += "</tr>";

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

            lblcontrolnumber.Text = "BarangayofficalNo" + datePart + "-" + sequenceNumber;
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {

            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("BarangayOfficalLogin.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string userVerificationCode = txtconfirmemail.Text;
            string sessionVerificationCode = Session["VerificationCode"] as string;
            DateTime expirationTime = (DateTime)Session["VerificationCodeExpiration"];

            if (Session["Code"].ToString() == txtconfirmemail.Text)
            {
                if (userVerificationCode == sessionVerificationCode && DateTime.Now < expirationTime)
                {
                    string fileName = FileUpload1.FileName;
                    string fileExtension = Path.GetExtension(fileName);

                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
                    {

                        FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "BarangayOfficalsImage/" + Label1.Text);
                        cmd = new SqlCommand(@"insert into BarangayOfficalInformation (tbl_Email, tbl_Fullname, tbl_BarangayOfficalPosition, tbl_Contactnumber, tbl_Password, tbl_Controlno, tbl_address, OfficalImages) values (@tbl_Email, @tbl_Fullname, @tbl_BarangayOfficalPosition, @tbl_Contactnumber, @tbl_Password, @tbl_Controlno, @tbl_address, @OfficalImages)", con);
                        cmd.Parameters.AddWithValue("@tbl_Email", txtemail.Text);
                        cmd.Parameters.AddWithValue("@tbl_Fullname", txtfullname.Text);
                        cmd.Parameters.AddWithValue("@tbl_BarangayOfficalPosition", DropDownList1.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@tbl_Contactnumber", txtmobilenumber.Text);
                        cmd.Parameters.AddWithValue("@tbl_Password", txtpassword.Text);
                        cmd.Parameters.AddWithValue("@tbl_Controlno", lblcontrolnumber.Text);
                        cmd.Parameters.AddWithValue("@tbl_address", txtaddress.Text);
                        cmd.Parameters.AddWithValue("@OfficalImages", Label1.Text);
                        con.Open();
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        
                        cmdss = new SqlCommand(@"Insert Into Activity (Name,Username,Activity,Date,BarangayControlNo) Values (@Name,@Username,@Activity,@Date,@BarangayControlNo)");
                        cmdss.Parameters.AddWithValue("@Name", txtfullname.Text);
                        cmdss.Parameters.AddWithValue("@Username", txtemail.Text);
                        cmdss.Parameters.AddWithValue("@Activity", lblactivity.Text);
                        cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
                        cmdss.Parameters.AddWithValue("@BarangayControlNo", lblcontrolnumber.Text);

                        conss.Open();
                        cmdss.Connection = conss;
                        cmdss.ExecuteNonQuery();
                        conss.Close();
                        Response.Redirect("BarangayAdminDashboard.aspx");


                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                    "swal('Only Images.','','error')", true);
                    }

                   

                }
                else
                {
                    // Verification failed or expired
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Verification code is Expired ','','error')", true);
                    txtconfirmemail.Text = string.Empty;
                }

               
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Verification code is invalid','','info')", true);
            }
        }

        protected void btnresendemail_Click(object sender, EventArgs e)
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
                    divconfirmationcode.Visible = true;
                }
                catch
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                    "swal('System Under Maintenance','','Warning')", true);
                }
            }
        }
    }
}