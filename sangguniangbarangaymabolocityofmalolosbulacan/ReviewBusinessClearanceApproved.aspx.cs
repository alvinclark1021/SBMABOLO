using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class ReviewBusinessClearanceApproved : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (!Page.IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    LoadDataclearance();
                }
                else
                {
                    Response.Redirect("barangayclearanceunregistered.aspx");
                }
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

        private void LoadDataclearance()
        {
            con.Open();
            cmd = new SqlCommand(@"SELECT * FROM BarangayBusinessClearance WHERE ID = '" + Session["ID"].ToString() + "'", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["ID"] = int.Parse(dt.Rows[0]["ID"].ToString());
                lblID.Text = dt.Rows[0]["ID"].ToString();
                lblcontrolnumber.Text = dt.Rows[0]["barangaybusinesscontrolno"].ToString();
                lblownername.Text = dt.Rows[0]["operatormanager"].ToString();
                lblbusinessname.Text = dt.Rows[0]["businessname"].ToString();
                lblbusinessaddress.Text = dt.Rows[0]["businessaddress"].ToString();
                lblmobilenumber.Text = dt.Rows[0]["phonenumber"].ToString();
                lblemail.Text = dt.Rows[0]["email"].ToString();
                lblstatus.Text = dt.Rows[0]["Status"].ToString();
            }
            con.Close();
        }

        SqlConnection conda = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlDataAdapter das;
        DataTable dts;
        SqlCommand cmdsssa;

       

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("BarangayOfficalLogin.aspx");
            cmdss = new SqlCommand(@"Insert Into Activity (Username,Date,Activity) Values (@Username,@Date,@Activity)", conss);

            cmdss.Parameters.AddWithValue("@Username", lblfullname.Text);
            cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
            cmdss.Parameters.AddWithValue("@Activity", lblactivity.Text);
            conss.Open();
            cmdss.Connection = conss;
            cmdss.ExecuteNonQuery();
            conss.Close();
        }

        


        protected void Ok_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminDashboard.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }
    }
}