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
using DocumentFormat.OpenXml.Office.Word;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class permittoconstructcefi : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            Loadpermittocontruct();
            lbldatess.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd HH:mm ");
            if (Session["admin"] != null)
            {
                lblfullname.Text = Session["admin"].ToString();

            }
            else
            {
                SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
                SqlCommand cmdss;
                cmdss = new SqlCommand(@"Insert Into Activity (Username,Activity,Date) Values (@Username,@Activity,@Date)");

                cmdss.Parameters.AddWithValue("@Username", lblsessionlogin.Text);
                cmdss.Parameters.AddWithValue("@Activity", lblsession.Text);
                cmdss.Parameters.AddWithValue("@Date", lbldate.Text);

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
       
        SqlDataAdapter das;
        DataTable dts;
        private void Loadpermittocontruct()
        {
            con.Open();
            cmd = new SqlCommand(@"SELECT * FROM PermittocontrustInformation WHERE ID = '" + Session["ID"].ToString() + "'", con);
            das = new SqlDataAdapter(cmd);
            dts = new DataTable();
            das.Fill(dts);

            if (dts.Rows.Count > 0)
            {
                Session["ID"] = int.Parse(dts.Rows[0]["ID"].ToString());
                lblid.Text = dts.Rows[0]["ID"].ToString();
                lblemail.Text = dts.Rows[0]["email"].ToString();
                lblpurposes.Text = dts.Rows[0]["purpose"].ToString();
                lblnamess.Text = dts.Rows[0]["fullname"].ToString();
                Label1.Text = dts.Rows[0]["barangayControlnumber"].ToString();
               
            }
            con.Close();

        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }

        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("BarangayOfficalLogin.aspx");
            cmdss = new SqlCommand(@"Insert Into Activity (Username,Date,Activity) Values (@Username,@Date,@Activity)", conss);

            cmdss.Parameters.AddWithValue("@Username", lblfullname.Text);
            cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
            cmdss.Parameters.AddWithValue("@Activity", lbllogout.Text);
            conss.Open();
            cmdss.Connection = conss;
            cmdss.ExecuteNonQuery();
            conss.Close();
        }

        private void send()
        {
            MailMessage msg = new MailMessage();
            StringBuilder sb = new StringBuilder();
            sb.Append("Hi, " + lblnamess.Text + "<br/>After reviewing your requested document, we are informing you that it is ready to pick up now.");
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

        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmds;
        protected void printButton_Click(object sender, EventArgs e)
        {
            cons.Open();
            cmds = new SqlCommand(@"UPDATE PermittocontrustInformation SET Status='Ready To Pickup', datepickup=@datepickup WHERE ID = '" + Session["ID"].ToString() + "'", cons);
            cmds.Parameters.AddWithValue("@datepickup", lbldates.Text);
            cmds.ExecuteNonQuery();
            cons.Close();
            send();
        }
    }
}