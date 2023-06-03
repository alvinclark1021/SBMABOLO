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
    public partial class BarangayResidentPendingRegister : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        byte up;
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            Loaddatabaseregisterresident();
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

            try
            {
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

            catch
            {
                Response.Redirect("BarangayOfficalLogin.aspx");
            }
        }

        private void Loaddatabaseregisterresident()
        {
            con.Open();
            cmd = new SqlCommand(@"SELECT * FROM tbl_createaccount WHERE Status = 'Pending' ORDER BY date ASC", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            rptresidentpending.DataSource = dt;
            rptresidentpending.DataBind();
        }


        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            cmdss = new SqlCommand(@"Insert Into Activity (Username,Date,Activity) Values (@Username,@Date,@Activity)", conss);
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

        protected void lnkreviewwith24hours_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblid") as Label).Text;
            Response.Redirect("ReviewInformationResident.aspx");
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string querys = "SELECT * FROM tbl_createaccount WHERE (Status='Pending' OR tbl_name LIKE '%" + txtSearch.Text + "%' OR date LIKE '%" + txtSearch.Text + "%' OR residentcontrolnumber LIKE '%" + txtSearch.Text + "%') AND Status != 'Approved' AND Status != 'Disapproved'";

            cons.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptresidentpending.DataSource = ds;
            rptresidentpending.DataBind();
            cons.Close();
        }
        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            string querys = "SELECT * FROM tbl_createaccount WHERE (Status='Pending' OR tbl_name LIKE '%" + txtSearch.Text + "%' OR date LIKE '%" + txtSearch.Text + "%' OR residentcontrolnumber LIKE '%" + txtSearch.Text + "%') AND Status != 'Approved' AND Status != 'Disapproved'";

            cons.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptresidentpending.DataSource = ds;
            rptresidentpending.DataBind();
            cons.Close();
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }
    }
}