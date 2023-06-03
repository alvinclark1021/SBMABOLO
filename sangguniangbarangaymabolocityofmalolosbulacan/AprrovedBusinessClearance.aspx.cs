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
using System.EnterpriseServices;
using System.Net.Mail;
using System.Text;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class AprrovedBusinessClearance : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (!Page.IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    LoadDataclearance();
                }
                else
                {
                    Response.Redirect("barangayclearanceunregistered.aspx");
                }
            }
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

        private void LoadDataclearance()
        {
            con.Open();
            cmd = new SqlCommand(@"SELECT * FROM BarangayBusinessClearance WHERE ID = '" + Session["ID"].ToString() + "'", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["ID"] = int.Parse(dt.Rows[0]["ID"].ToString());
                lblID.Text = dt.Rows[0]["ID"].ToString();
                lblcontrolnumber.Text = dt.Rows[0]["barangaybusinesscontrolno"].ToString();
                lblownername.Text = dt.Rows[0]["operatormanager"].ToString();
                lblbusinessname.Text = dt.Rows[0]["businessname"].ToString();
                lblbusinessaddress.Text = dt.Rows[0]["businessaddress"].ToString();
                lblmobilenumber.Text = dt.Rows[0]["phonenumber"].ToString();
                lblemail.Text = dt.Rows[0]["email"].ToString();
                lblstatus.Text = dt.Rows[0]["Status"].ToString();
            }
            con.Close();
        }

        SqlConnection conda = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlDataAdapter das;
        DataTable dts;
        SqlCommand cmdsssa;

        protected void btnapprovedt_Click(object sender, EventArgs e)
        {
            



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
            cmdss.Parameters.AddWithValue("@Activity", lblactivity.Text);
            conss.Open();
            cmdss.Connection = conss;
            cmdss.ExecuteNonQuery();
            conss.Close();
        }

        protected void Disapproved_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "CompleteRequirements")
            {
                conda.Open();
                cmdsssa = new SqlCommand(@"UPDATE BarangayBusinessClearance SET Status='Ready For Pickup' WHERE ID = '" + Session["ID"].ToString() + "'", conda);
                cmdsssa.ExecuteNonQuery();
                conda.Close();
                StringBuilder sbs = new StringBuilder();
                sbs.Append("Hi," + lblfullname.Text + "<br/> After Review new application or renew application are be approved please wait for schedule claim documents <br/>");
                sbs.Append("Your Reason is :" + DropDownList1.SelectedItem.Value + "<br/>");
                sbs.Append("Your details here <br/>");
                sbs.Append("Name :" + lblfullname.Text + "<br/>");
                sbs.Append("Name :" + lblbusinessname.Text + "<br/>");
                sbs.Append("Name :" + lblbusinessaddress.Text + "<br/>");
                sbs.Append("Email : " + lblemail.Text + "<br/>");
                sbs.Append("Registration no: " + lblcontrolnumber.Text + "<br/>");
                sbs.Append("Date Approved: " + lbldate.Text + "<br/>");
                sbs.Append("<br/><b>Thanks</b>,<br> Sangguniang Barangay Mabolo City of Malolos Bulacan <br/>");


                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Timeout = 5000; // Set timeout value in milliseconds


                MailMessage messages = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", lblemail.Text.Trim(), "Thank you your business clearance", sbs.ToString());

                SmtpClient smtps = new SmtpClient();

                smtps.Host = "smtp.gmail.com";

                smtps.Port = 587;

                smtps.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");

                smtps.EnableSsl = true;

                messages.IsBodyHtml = true;

                smtps.Send(messages);

                Session["ID"] = lblID.Text;
                //Account to Sucess to create
                string redirectScript = "swal('Business Clearance has been Approved Successfully!', '', 'success').then(function() { window.location = 'Businessclearanceprinting.aspx'; });";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

                Disapproved.Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "validations")
            {
                conda.Open();
                cmdsssa = new SqlCommand(@"UPDATE BarangayBusinessClearance SET Status='Disapproved' WHERE ID = '" + Session["ID"].ToString() + "'", conda);
                cmdsssa.ExecuteNonQuery();
                conda.Close();
                StringBuilder sb = new StringBuilder();
                sb.Append("Hi," + lblfullname.Text + "<br/> After Review 48 hours new application or renew application be are Disapproved Reason is " + DropDownList1.SelectedItem.Value + "<br/>");
                sb.Append("Your details here <br/>");
                sb.Append("Name :" + lblfullname.Text + "<br/>");
                sb.Append("Name :" + lblbusinessname.Text + "<br/>");
                sb.Append("Name :" + lblbusinessaddress.Text + "<br/>");
                sb.Append("Email : " + lblemail.Text + "<br/>");
                sb.Append("Registration no: " + lblcontrolnumber.Text + "<br/>");
                sb.Append("Date Approved: " + lbldate.Text + "<br/>");
                sb.Append("<br/><b>Thanks</b>,<br> Sangguniang Barangay Mabolo City of Malolos Bulacan <br/>");
                sb.Append("<br/><b> for more post new system </b> <br/>");

                sb.Append("thanks");

                MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", lblemail.Text.Trim(), "Thank you your business clearance", sb.ToString());

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;

                smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");

                smtp.EnableSsl = true;

                message.IsBodyHtml = true;

                smtp.Send(message);
                //Account to Sucess to create
                string redirectScript = "swal('Your Business Clerance are Disapproved Successfully send email!', '', 'success').then(function() { window.location = 'barangayclearanceunregistered.aspx'; });";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);
               

                Disapproved.Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "locations")
            {
                conda.Open();
                cmdsssa = new SqlCommand(@"UPDATE BarangayBusinessClearance SET Status='Disapproved' WHERE ID = '" + Session["ID"].ToString() + "'", conda);
                cmdsssa.ExecuteNonQuery();
                conda.Close();
                StringBuilder sb = new StringBuilder();
                sb.Append("Hi," + lblfullname.Text + "<br/> After Review 48 hours new application or renew application be are Disapproved Reason is " + DropDownList1.SelectedItem.Value + "<br/>");
                sb.Append("Your details here <br/>");
                sb.Append("Name :" + lblfullname.Text + "<br/>");
                sb.Append("Name :" + lblbusinessname.Text + "<br/>");
                sb.Append("Name :" + lblbusinessaddress.Text + "<br/>");
                sb.Append("Email : " + lblemail.Text + "<br/>");
                sb.Append("Registration no: " + lblcontrolnumber.Text + "<br/>");
                sb.Append("Date Approved: " + lbldate.Text + "<br/>");
                sb.Append("<br/><b>Thanks</b>,<br> Sangguniang Barangay Mabolo City of Malolos Bulacan <br/>");
                sb.Append("<br/><b> for more post new system </b> <br/>");

                sb.Append("thanks");

                MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", lblemail.Text.Trim(), "Thank you your business clearance", sb.ToString());

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;

                smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");

                smtp.EnableSsl = true;

                message.IsBodyHtml = true;

                smtp.Send(message);
                //Account to Sucess to create
                string redirectScript = "swal('Your Business Clerance are Disapproved Successfully send email!', '', 'success').then(function() { window.location = 'barangayclearanceunregistered.aspx'; });";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

                Disapproved.Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "baranagymabolo")
            {
                conda.Open();
                cmdsssa = new SqlCommand(@"UPDATE BarangayBusinessClearance SET Status='Disapproved' WHERE ID = '" + Session["ID"].ToString() + "'", conda);
                cmdsssa.ExecuteNonQuery();
                conda.Close();
                StringBuilder sb = new StringBuilder();
                sb.Append("Hi," + lblfullname.Text + "<br/> After Review 48 hours new application or renew application be are Disapproved Reason is " + DropDownList1.SelectedItem.Value + "<br/>");
                sb.Append("Your details here <br/>");
                sb.Append("Name :" + lblfullname.Text + "<br/>");
                sb.Append("Name :" + lblbusinessname.Text + "<br/>");
                sb.Append("Name :" + lblbusinessaddress.Text + "<br/>");
                sb.Append("Email : " + lblemail.Text + "<br/>");
                sb.Append("Registration no: " + lblcontrolnumber.Text + "<br/>");
                sb.Append("Date Approved: " + lbldate.Text + "<br/>");
                sb.Append("<br/><b>Thanks</b>,<br> Sangguniang Barangay Mabolo City of Malolos Bulacan <br/>");
                sb.Append("<br/><b> for more post new system </b> <br/>");

                sb.Append("thanks");

                MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", lblemail.Text.Trim(), "Thank you your business clearance", sb.ToString());

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;

                smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");

                smtp.EnableSsl = true;

                message.IsBodyHtml = true;

                smtp.Send(message);
                //Account to Sucess to create
                string redirectScript = "swal('Your Business Clerance are Disapproved Successfully send email!', '', 'success').then(function() { window.location = 'barangayclearanceunregistered.aspx'; });";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

                Disapproved.Enabled = false;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                    "swal('Please Select','','warning')", true);
            }

            
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {

        }
    }
}