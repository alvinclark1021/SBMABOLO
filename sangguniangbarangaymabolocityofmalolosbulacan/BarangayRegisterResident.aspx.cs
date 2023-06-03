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
using CdnJs.Core;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class BarangayRegisterResident : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProducts();
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

        private void LoadProducts()
        {
            SqlConnection consssss = new SqlConnection(cs);
            string query = "select * from tbl_createaccount WHERE Status = 'Approved' ORDER BY date ASC";
            SqlCommand cms = new SqlCommand(query, consssss);
            consssss.Open();
            rptregisterdusers.DataSource = cms.ExecuteReader();
            rptregisterdusers.DataBind();
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
            SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
            SqlCommand cmdss;
            cmdss = new SqlCommand(@"Insert Into Activity (Username,Activity,Date) Values (@Username,@Activity,@Date)");

            cmdss.Parameters.AddWithValue("@Username", lblsessionlogin.Text);
            cmdss.Parameters.AddWithValue("@Activity", lblactivity.Text);
            cmdss.Parameters.AddWithValue("@Date", lbldate.Text);

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
            string querys = "SELECT * FROM tbl_createaccount WHERE (Status='Approved' OR tbl_name LIKE '%" + txtSearch.Text + "%' OR date LIKE '%" + txtSearch.Text + "%' OR residentcontrolnumber LIKE '%" + txtSearch.Text + "%') AND Status != 'Disapproved' AND Status != 'Pending'";

            connection.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptregisterdusers.DataSource = ds;
            rptregisterdusers.DataBind();
            connection.Close();
        }

        protected void linkprofile_Click1(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            string querys = "SELECT * FROM tbl_createaccount WHERE (Status='Approved' OR tbl_name LIKE '%" + txtSearch.Text + "%' OR date LIKE '%" + txtSearch.Text + "%' OR residentcontrolnumber LIKE '%" + txtSearch.Text + "%') AND Status != 'Disapproved' AND Status != 'Pending'";

            connection.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptregisterdusers.DataSource = ds;
            rptregisterdusers.DataBind();
            connection.Close();
        }

        protected void review_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblid") as Label).Text;
            Response.Redirect("SBMResidentInformation.aspx");
        }
    }
}