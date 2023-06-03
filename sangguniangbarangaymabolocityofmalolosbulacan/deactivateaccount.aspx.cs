using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.EnterpriseServices;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class deactivateaccount : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;

        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                lblsessionlogin.Text = Session["Username"].ToString();

            }
            else
            {
                Response.Redirect("Confirmpassworddeactivateaccount.aspx");
            }
            if (!Page.IsPostBack)
            {
                getUserPersonalDetails();
            }

            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (Session["user"] != null)
            {
                lblsessionlogin.Text = Session["user"].ToString();

            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            if (this.Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
            SqlConnection cons = new SqlConnection(strConnString);
            cons.Open();
            str = "select * from tbl_createaccount where tbl_username='" + Session["user"] + "'";
            com = new SqlCommand(str, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lblfullname.Text = ds.Tables[0].Rows[0]["tbl_name"].ToString();
            lblsessionlogin.Text = ds.Tables[0].Rows[0]["tbl_username"].ToString();
        }

        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from tbl_createaccount where tbl_username='" + Session["user"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lblid.Text = dt.Rows[0]["ID"].ToString();
                lblname.Text = dt.Rows[0]["tbl_name"].ToString();
                lbladdress.Text = dt.Rows[0]["tbl_address"].ToString();
                lblemail.Text = dt.Rows[0]["tbl_email"].ToString();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        protected void linkdeactivateaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmpassworddeactivateaccount.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileSettingsResident.aspx");
        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResidentChangePassword.aspx");
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
            SqlCommand cmdss;
            cmdss = new SqlCommand(@"Insert Into InactiveBarangayResident (name,email,address,date,Status) Values (@name,@email,@address,@date,@Status)");

            cmdss.Parameters.AddWithValue("@name", lblname.Text);
            cmdss.Parameters.AddWithValue("@email", lblemail.Text);
            cmdss.Parameters.AddWithValue("@address", lbladdress.Text);
            cmdss.Parameters.AddWithValue("@date", lbldate.Text);
            cmdss.Parameters.AddWithValue("@Status", lblstatus.Text);
            conss.Open();
            cmdss.Connection = conss;
            cmdss.ExecuteNonQuery();
            conss.Close();

            SqlConnection consss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
            SqlCommand cmdsss;
            cmdsss = new SqlCommand(@"Insert Into Activity (Name,Date,PurposeandReason,Status) Values (@Name,@Date,@PurposeandReason,@Status)");
            cmdsss.Parameters.AddWithValue("@Name", lblname.Text);
            cmdsss.Parameters.AddWithValue("@Date", lbldate.Text);
            cmdsss.Parameters.AddWithValue("@Status", lblstatus.Text);
            cmdsss.Parameters.AddWithValue("@PurposeandReason", DropDownList1.SelectedItem.Value);
            consss.Open();
            cmdsss.Connection = consss;
            cmdsss.ExecuteNonQuery();
            consss.Close();

            cmd = new SqlCommand(@"DELETE FROM tbl_createaccount WHERE ID = @ID");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ID", lblid.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}