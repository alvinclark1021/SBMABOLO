using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class BarangayResidentInformation : System.Web.UI.Page
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
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (!IsPostBack)
            {
                LoadProducts();
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
        private void LoadProducts()
        {
            con.Open();
            cmd = new SqlCommand("SELECT * FROM tbl_createaccount WHERE Status = 'Approve' ORDER BY tbl_name ASC");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            rptProducts.DataSource = dt;
            rptProducts.DataBind();
            con.Close();
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("BarangayOfficalLogin.aspx");
        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        protected void ID_DataBound(object sender, EventArgs e)
        {

        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }

        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            string qry = "SELECT Name,Address FROM tblProducts  where Name like '%" + txtSearch.Text + "%' OR Address like '%" + txtSearch.Text +"%'";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptProducts.DataSource = ds;
            rptProducts.DataBind();
            con.Close();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string qry = "SELECT Name,Address FROM tblProducts  where Name like '%" + txtSearch.Text + "%' OR Address like '%" + txtSearch.Text + "%'";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptProducts.DataSource = ds;
            rptProducts.DataBind();
            con.Close();
        }

        protected void linkprofile_Click1(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }
    }
}