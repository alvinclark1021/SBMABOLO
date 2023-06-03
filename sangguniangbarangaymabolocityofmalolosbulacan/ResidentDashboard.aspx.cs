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

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class ResidentDashboard1 : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;

        string cs = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string connectionString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
       
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GetTransactionHistory();
            if (Session["user"] != null)
            {
                lblsessionlogin.Text = Session["user"].ToString();

            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (this.Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }

            try
            {
                SqlConnection con = new SqlConnection(strConnString);
                con.Open();
                str = "select * from tbl_createaccount where tbl_username='" + Session["user"] + "'";
                com = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                lblfullname.Text = ds.Tables[0].Rows[0]["tbl_name"].ToString();
                lblsessionlogin.Text = ds.Tables[0].Rows[0]["tbl_username"].ToString();
                lblname.Text = ds.Tables[0].Rows[0]["tbl_name"].ToString();
                
            }
            catch {
                Session.RemoveAll();
                Session.Abandon();

                Response.Redirect("Login.aspx", false);
            }

            
        }

        private void GetTransactionHistory()
        {
            
        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResidentChangePassword.aspx", false);
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileSettingsResident.aspx", false);
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();

            Response.Redirect("Login.aspx", false);
        }

        protected void linkdeactivateaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmpassworddeactivateaccount.aspx", false);
        }
    }
}