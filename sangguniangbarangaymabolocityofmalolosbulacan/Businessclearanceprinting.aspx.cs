using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using System.Net;
using Org.BouncyCastle.Asn1.Cmp;
using System.Drawing;


namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class Businessclearanceprinting : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        protected void Page_Load(object sender, EventArgs e)
        {           
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldatesssss.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (Session["admin"] != null)
            {
                lblfullname.Text = Session["admin"].ToString();

            }
            else
            {
                cmdss = new SqlCommand(@"Insert Into Activity (Username,Date,Activity) Values (@Username,@Date,@Activity)", conss);
                cmdss.Parameters.AddWithValue("@Username", lblfullname.Text);
                cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
                cmdss.Parameters.AddWithValue("@Activity", lblensission.Text);
                conss.Open();
                cmdss.Connection = conss;
                cmdss.ExecuteNonQuery();
                conss.Close();
                Response.Redirect("BarangayOfficalLogin.aspx");
            }

            if (this.Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
            LoadDataclearance();
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "select * from BarangayOfficalInformation where tbl_Email='" + Session["admin"] + "'";
            com = new SqlCommand(str, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lblnameofoffical.Text = ds.Tables[0].Rows[0]["tbl_Fullname"].ToString();
            lblfullname.Text = ds.Tables[0].Rows[0]["tbl_Fullname"].ToString();
            lblsessionlogin.Text = ds.Tables[0].Rows[0]["tbl_Email"].ToString();
            lblbarangayofficals.Text = ds.Tables[0].Rows[0]["tbl_BarangayOfficalPosition"].ToString();
        }


        

        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmds;
        SqlDataAdapter das;
        DataTable dts;
        private void LoadDataclearance()
        {
            cons.Open();
            cmds = new SqlCommand(@"SELECT * FROM BarangayBusinessClearance WHERE ID = '" + Session["ID"].ToString() + "'", cons);
            das = new SqlDataAdapter(cmds);
            dts = new DataTable();
            das.Fill(dts);

            if (dts.Rows.Count > 0)
            {
                Session["ID"] = int.Parse(dts.Rows[0]["ID"].ToString());
                
                lblcontrolnumber.Text = dts.Rows[0]["barangaybusinesscontrolno"].ToString();
                lblfullnamesss.Text = dts.Rows[0]["operatormanager"].ToString();
                lblbusinessname.Text = dts.Rows[0]["businessname"].ToString();
                lbladdress.Text = dts.Rows[0]["businessaddress"].ToString();
                lbladdressaaa.Text = dts.Rows[0]["businessaddress"].ToString();
                lblemail.Text = dts.Rows[0]["email"].ToString();
                
            }
            cons.Close();
        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
           
            cmdss = new SqlCommand(@"Insert Into Activity (Name,Username,Date,Activity) Values (@Name,@Username,@Date,@Activity)", conss);
            cmdss.Parameters.AddWithValue("@Name", lblnameofoffical.Text);
            cmdss.Parameters.AddWithValue("@Username", lblfullname.Text);
            cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
            cmdss.Parameters.AddWithValue("@Activity", lbllogout.Text);
            conss.Open();
            cmdss.Connection = conss;
            cmdss.ExecuteNonQuery();
            conss.Close();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("BarangayOfficalLogin.aspx");
        }

        private void send()
        {
            MailMessage msg = new MailMessage();
            StringBuilder sb = new StringBuilder();
            sb.Append("Hi, " + lblfullnamesss.Text + "<br/>After reviewing your requested document, we are informing you that it is ready to pick up now.");
            sb.Append("<b>Thank you.</b> From: Sangguniang Barangay Mabolo City of Malolos Bulacan <br/>");

            MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", lblemail.Text.Trim(), "Approved Requested Document", sb.ToString());

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");
            smtp.EnableSsl = true;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }

       
      
        protected void printButton_Click(object sender, EventArgs e)
        {
            cons.Open();
            cmds = new SqlCommand(@"UPDATE BarangayBusinessClearance SET Status='Ready For Pickup', datepickup=@datepickup WHERE ID = '" + Session["ID"].ToString() + "'", cons);
            cmds.Parameters.AddWithValue("@datepickup", lbldates.Text);
            cmds.ExecuteNonQuery();
            cons.Close();
            send();


        }
    }
}