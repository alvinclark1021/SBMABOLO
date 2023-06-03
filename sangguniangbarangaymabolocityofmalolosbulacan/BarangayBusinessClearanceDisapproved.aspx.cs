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
using System.Text;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class BarangayBusinessClearanceDisapproved : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (!Page.IsPostBack)
            {
                loaddatabase();
            }
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
                cmdss.Parameters.AddWithValue("@Activity", lblsessionlogin.Text);
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

        public void loaddatabase()
        {
            cons.Open();
            cmd = new SqlCommand(@"SELECT * FROM BarangayBusinessClearance WHERE Status='Disapproved'ORDER BY operatormanager ASC", cons);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            rptProducts.DataSource = dt;
            rptProducts.DataBind();
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Hi," + lblsessionlogin.Text + "<br/> Your account has be Logout with date and time: " + lbldate.Text);

                sb.Append("<b>Thanks</b>,<br> Sangguniang Barangay Mabolo City of Malolos Bulacan <br/>");

                MailMessage message = new System.Net.Mail.MailMessage("sangguniangbarangaymabolo@gmail.com", lblsessionlogin.Text.Trim(), "To Login Account Administrator", sb.ToString());

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;

                smtp.Credentials = new System.Net.NetworkCredential("sangguniangbarangaymabolo@gmail.com", "donqtviszauaucyd");

                smtp.EnableSsl = true;
                message.IsBodyHtml = true;
                smtp.Send(message);
            }
            catch
            {
                Response.Redirect("BarangayAdminDashboard.aspx");
            }
            cmdss = new SqlCommand(@"Insert Into Activity (Name,Username,Date,Activity) Values (@Name,@Username,@Date,@Activity)", conss);
            cmdss.Parameters.AddWithValue("@Name", lblfullnames.Text);
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

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM DisapprovedBusinessclearance where BusinessOnwername like '%" + txtSearch.Text + "%' OR BusinessName like '%" + txtSearch.Text + "%' OR BusinessControlNumber like '%" + txtSearch.Text + "%' OR datedisapproved like '%" + txtSearch.Text + "%'";
            cons.Open();
            SqlDataAdapter ad = new SqlDataAdapter(qry, cons);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptProducts.DataSource = ds;
            rptProducts.DataBind();
            cons.Close();
        }

        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM DisapprovedBusinessclearance where BusinessOnwername like '%" + txtSearch.Text + "%' OR BusinessName like '%" + txtSearch.Text + "%' OR BusinessControlNumber like '%" + txtSearch.Text + "%' OR datedisapproved like '%" + txtSearch.Text + "%'";
            cons.Open();
            SqlDataAdapter ad = new SqlDataAdapter(qry, cons);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptProducts.DataSource = ds;
            rptProducts.DataBind();
            cons.Close();
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }
    }
}