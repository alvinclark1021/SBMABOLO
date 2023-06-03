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
using iTextSharp.tool.xml.css;
using System.Text;
using System.Net.Mail;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class BarangayBusinessClearanceRegistered : System.Web.UI.Page
    {

        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
       
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
            SqlConnection consssss = new SqlConnection(cs);
            string query = "select * from BarangayBusinessClearance WHERE Status='Approved/ClaimDocuments' ORDER BY datepickup ASC";
            SqlCommand cms = new SqlCommand(query, consssss);
            consssss.Open();
            BusinessClearance.DataSource = cms.ExecuteReader();
            BusinessClearance.DataBind();
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

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            
            cmdss = new SqlCommand(@"Insert Into Activity (Name,Username,Date,Activity) Values (@Name,@Username,@Date,@Activity)", conss);
            cmdss.Parameters.AddWithValue("@Name", lblsessionlogin.Text);
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

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string querys = "SELECT * FROM BarangayBusinessClearance where Status='Approved/ClaimDocuments' AND operatormanager like '%" + txtSearch.Text + "%' OR businessname like '%" + txtSearch.Text + "%' OR businessaddress like '%" + txtSearch.Text + "%' OR BarangayControlNo like '%" + txtSearch.Text + "%' OR datepickup like '" + txtSearch.Text + "' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            BusinessClearance.DataSource = ds;
            BusinessClearance.DataBind();
            con.Close();
        }
        string cs = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
       
        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            string querys = "SELECT * FROM BarangayBusinessClearance where Status='Approved/ClaimDocuments' AND operatormanager like '%" + txtSearch.Text + "%' OR businessname like '%" + txtSearch.Text + "%' OR businessaddress like '%" + txtSearch.Text + "%' OR BarangayControlNo like '%" + txtSearch.Text + "%' OR datepickup like '" + txtSearch.Text + "' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            BusinessClearance.DataSource = ds;
            BusinessClearance.DataBind();
            con.Close();
        }

        protected void lnkaprovedbusinessclearance_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblid") as Label).Text;
            Response.Redirect("ReviewBusinessClearanceApproved.aspx");
        }
    }
}
