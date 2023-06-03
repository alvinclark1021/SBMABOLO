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

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class FencingPermitPending : System.Web.UI.Page
    {
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
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
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
            string cs = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
            SqlConnection consssss = new SqlConnection(cs);
            string query = "select * from FencingPermitInformation Where Status='Pending' ORDER BY datepickup DESC";
            SqlCommand cms = new SqlCommand(query, consssss);
            consssss.Open();
            rptfencingpermitpending.DataSource = cms.ExecuteReader();
            rptfencingpermitpending.DataBind();
            consssss.Close();
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
            cmdss.Parameters.AddWithValue("@Name", lblfullname.Text);
            cmdss.Parameters.AddWithValue("@Username", lblsessionlogin.Text);
            cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
            cmdss.Parameters.AddWithValue("@Activity", lblactivity.Text);
            conss.Open();
            cmdss.Connection = conss;
            cmdss.ExecuteNonQuery();
            conss.Close();
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string querys = "SELECT * FROM FencingPermitInformation WHERE (Status='Pending' OR fullname LIKE '%" + txtSearch.Text + "%' OR datepickup LIKE '%" + txtSearch.Text + "%') AND Status != 'ClaimDocuments'";

            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptfencingpermitpending.DataSource = ds;
            rptfencingpermitpending.DataBind();
            con.Close();
        }
        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            string querys = "SELECT * FROM FencingPermitInformation WHERE (Status='Pending' OR fullname LIKE '%" + txtSearch.Text + "%' OR datepickup LIKE '%" + txtSearch.Text + "%') AND Status != 'ClaimDocuments'";

            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptfencingpermitpending.DataSource = ds;
            rptfencingpermitpending.DataBind();
            con.Close();
        }

        protected void linkprofile_Click1(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }

        protected void lnkreviewwith24hours_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblid") as Label).Text;
            Response.Redirect("FencingPermitPrinting.aspx");
        }

    }
}