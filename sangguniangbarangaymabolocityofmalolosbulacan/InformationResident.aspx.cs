using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class InformationResident : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        DataTable dt ;
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            getUserPersonalDetails();
            //To Disable the Future Dates in CalendarExtender control
            CalendarExtender1.EndDate = DateTime.Now;
            txtmobileno.Attributes.Add("maxlength", "11");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd HH:mm ");
            try
            {
                string email = Session["email"].ToString();
            }

            catch
            {
                Response.Redirect("index.aspx");
            }
        }
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlDataAdapter das;
        DataTable dts;
        SqlCommand cmds;
        void getUserPersonalDetails()
        {
            cons.Open();
            cmds = new SqlCommand(@"SELECT * FROM tbl_createaccount WHERE tbl_email=@tbl_email", cons);
            cmds.Parameters.AddWithValue("@tbl_email", Session["email"].ToString());
            das = new SqlDataAdapter(cmds);
            dts = new DataTable();
            das.Fill(dts);

            if (dts.Rows.Count > 0)
            {
                Session["email"] = dts.Rows[0]["tbl_email"].ToString();
                txtregistationno.Text = dts.Rows[0]["residentcontrolnumber"].ToString();
                txtfullname.Text = dts.Rows[0]["tbl_name"].ToString();
                txtemail.Text = dts.Rows[0]["tbl_email"].ToString();
                txtmobileno.Text = dts.Rows[0]["tbl_mobilenumber"].ToString();
                txtaddress.Text = dts.Rows[0]["tbl_address"].ToString();
                txtbirthday.Text = dts.Rows[0]["tbl_birthday"].ToString();
                Selectedmaleorfemale.SelectedValue = dts.Rows[0]["tbl_Gender"].ToString();
                Dropselectede.SelectedValue = dts.Rows[0]["VotersRegistered"].ToString();
                lblimages.Text = dts.Rows[0]["tbl_validid"].ToString();
            }

            cons.Close();


        }

        protected void Bntsubmitinformation_Click(object sender, EventArgs e)
        {
            string fileName = FileUpload1.FileName;
            if (fileName != "")
            {
                lblimages.Text = fileName;
                string fileExtwnsion = Path.GetExtension(lblimages.Text);

                if (fileExtwnsion.ToLower() != ".jpg" && fileExtwnsion.ToLower() != ".png")
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                              "swal('Only jpg and png file allowed.','','error')", true);
                }
                else
                {
                    FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "Pendingregistationresident/" + lblimages.Text);
                    try
                    {
                        SqlConnection con = new SqlConnection(strcon);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlCommand cmd = new SqlCommand("update tbl_createaccount set tbl_name=@tbl_name, tbl_address=@tbl_address, tbl_birthday=@tbl_birthday, tbl_mobilenumber=@tbl_mobilenumber,tbl_address=@tbl_address, VotersRegistered=@VotersRegistered, tbl_validid=@tbl_validid WHERE tbl_email='" + Session["email"].ToString().Trim() + "'", con);

                        cmd.Parameters.AddWithValue("@tbl_name", txtfullname.Text);
                        cmd.Parameters.AddWithValue("@tbl_mobilenumber", txtmobileno.Text);
                        cmd.Parameters.AddWithValue("@tbl_birthday", txtbirthday.Text);
                        cmd.Parameters.AddWithValue("@tbl_Gender", Selectedmaleorfemale.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@tbl_address", txtaddress.Text);
                        cmd.Parameters.AddWithValue("@VotersRegistered", Dropselectede.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@tbl_validid", lblimages.Text);
                        int result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result > 0)
                        {
                            Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                            getUserPersonalDetails();
                        }
                        else
                        {
                            Response.Write("<script>alert('Invaid entry');</script>");
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                    //cmd = new SqlCommand(@"UPDATE tbl_createaccount SET tbl_name=@tbl_name, tbl_mobilenumber=@tbl_mobilenumber, tbl_birthday=@tbl_birthday, tbl_Gender=@tbl_Gender, tbl_address=@tbl_address, VotersRegistered=@VotersRegistered, tbl_validid=@tbl_validid WHERE tbl_email=@tbl_email", con);
                    //cmd.Parameters.AddWithValue("@tbl_name", txtfullname.Text);
                    //cmd.Parameters.AddWithValue("@tbl_mobilenumber", txtmobileno.Text);
                    //cmd.Parameters.AddWithValue("@tbl_birthday", txtbirthday.Text);
                    //cmd.Parameters.AddWithValue("@tbl_Gender", Selectedmaleorfemale.SelectedItem.Value);
                    //cmd.Parameters.AddWithValue("@tbl_address", txtaddress.Text);
                    //cmd.Parameters.AddWithValue("@VotersRegistered", Dropselectede.SelectedItem.Value);
                    //cmd.Parameters.AddWithValue("@tbl_validid", lblimages.Text);
                    //cmd.Parameters.AddWithValue("@tbl_email", email);
                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Hi," + txtfullname.Text + "<br/> thank you for revise information review and validate your information to be review with 24 hours be activated please wait for approval <br/>");
                    sb.Append("Your information details <br/>");
                    sb.Append("Name :" + txtfullname.Text + "<br/>");
                    sb.Append("Address: " + txtaddress.Text + "<br/>");
                    sb.Append("Email : " + txtemail.Text + "<br/>");
                    sb.Append("Registration no: " + txtregistationno.Text + "<br/>");
                    sb.Append("Date Registration: " + lbldate.Text + "<br/>");
                    sb.Append("<b>Thanks</b>,<br> Sangguniang Barangay Mabolo City of Malolos Bulacan <br/>");

                    MailMessage message = new System.Net.Mail.MailMessage("sangguniangbarangaymabolo@gmail.com", txtemail.Text.Trim(), "Please Wait your account be activated with 24 hours to review ", sb.ToString());

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential("sangguniangbarangaymabolo@gmail.com", "donqtviszauaucyd");

                    smtp.EnableSsl = true;
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                               "swal('your password has been successfully updated ','','success')", true);
             
                    Response.Redirect("Login.aspx");
                }

            
            }
                   
        }
    }
}