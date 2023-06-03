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
    public partial class InactiveResident : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        string cs = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
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
            if (!Page.IsPostBack)
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
        }

        private void LoadProducts()
        {
           
            SqlConnection consssss = new SqlConnection(cs);
            string query = "select * from InactiveBarangayResident";
            SqlCommand cms = new SqlCommand(query, consssss);
            consssss.Open();
            ID.DataSource = cms.ExecuteReader();
            ID.DataBind();
            consssss.Close();
        }

        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            string querys = "SELECT * FROM InactiveBarangayResident where name like '%" + txtSearch.Text + "%' OR email like '%" + txtSearch.Text + "%' OR address like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            ID.DataSource = ds;
            ID.DataBind();
            con.Close();
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
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string querys = "SELECT * FROM InactiveBarangayResident where name like '%" + txtSearch.Text + "%' OR email like '%" + txtSearch.Text + "%' OR address like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            ID.DataSource = ds;
            ID.DataBind();
            con.Close();
        }
    }
}