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
    public partial class ConcernsMessageUser : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        byte up;
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (Session["admin"] != null)
            {
                lblfullname.Text = Session["admin"].ToString();

            }
            else
            {
                cmdss = new SqlCommand(@"Insert Into Activity (Username,Date,Activity) Values (@Username,@Date,@Activity)", conss);
                cmdss.Parameters.AddWithValue("@Username", lblfullname.Text);
                cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
                cmdss.Parameters.AddWithValue("@Activity", lbllogout.Text);
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

            Loaddatabaseregisterresident();
        }

        private void Loaddatabaseregisterresident()
        {
            con.Open();
            cmd = new SqlCommand(@"SELECT * FROM Concernmessage WHERE Status = 'Pending' ORDER BY datetoday ASC", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            rptProducts.DataSource = dt;
            rptProducts.DataBind();
        }

        protected void lnkreviewwith24hours_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblid") as Label).Text;
            Response.Redirect("Messagetoreviewinformationresident.aspx");
        }

        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM Concernmessage where Name like '%" + txtSearch.Text + "%' OR Email like '%" + txtSearch.Text + "%' OR dateregisterd like '%" + txtSearch.Text + "%' OR Contactnumber like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptProducts.DataSource = ds;
            rptProducts.DataBind();
            con.Close();
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

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM Concernmessage where Name like '%" + txtSearch.Text + "%' OR Email like '%" + txtSearch.Text + "%' OR dateregisterd like '%" + txtSearch.Text + "%' OR Contactnumber like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptProducts.DataSource = ds;
            rptProducts.DataBind();
            con.Close();
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }
    }
}