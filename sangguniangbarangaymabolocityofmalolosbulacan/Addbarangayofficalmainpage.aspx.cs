using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class Addbarangayofficalmainpage : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
      
        string str;
        SqlCommand com;
        byte up;
        SqlConnection conssx = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdssx;
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conssaa = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand daj;
        SqlCommand cmdss;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlCommand alvin;
        SqlDataAdapter alvins;
        DataTable dt;
        DataTable gta;
        string connectionString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string con = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlConnection consa = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdsa;
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmds;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd HH:mm ");
            //LoadOfficalname();
            //Loadofficalposition();
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

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        

        
        private void LoadBarangayofficals()
        {
            cons.Open();
            alvin = new SqlCommand(@"SELECT * FROM BarangayOfficalDisplay ORDER BY BarangayOfficalName ASC", cons);
            alvins = new SqlDataAdapter(alvin);
            gta = new DataTable();
            alvins.Fill(gta);

            rptProducts.DataSource = gta;
            rptProducts.DataBind();
            cons.Close();
        }

        protected void lnkeditofficals_Click(object sender, EventArgs e)
        {

        }

        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM BarangayOfficalDisplay where BarangayOfficalName like '%" + txtSearch.Text + "%' OR BarangayOfficalPosition like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptProducts.DataSource = ds;
            rptProducts.DataBind();
            con.Close();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM BarangayOfficalDisplay where BarangayOfficalName like '%" + txtSearch.Text + "%' OR BarangayOfficalPosition like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptProducts.DataSource = ds;
            rptProducts.DataBind();
            con.Close();
        }


        SqlConnection conssss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdssss;
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblid") as Label).Text;

            conssss.Open();
            cmdssss = new SqlCommand(@"Delete BarangayOfficalDisplay WHERE ID = '" + Session["ID"].ToString() + "'", conssss);
            cmdssss.ExecuteNonQuery();
            conssss.Close();
            LoadBarangayofficals();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                               "swal('Your Offical are remove.','','error')", true);
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }
    }
}