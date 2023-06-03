using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using CdnJs.Core;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class BarangayAdminProfilesettings : System.Web.UI.Page
    {
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        SqlCommand cmd;
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (!Page.IsPostBack)
            {
                getUserPersonalDetails();
            }

            if (Session["admin"] != null)
            {
                lblfullname.Text = Session["admin"].ToString();

            }
            else
            {
                cmdss = new SqlCommand(@"Insert Into Activity (Username,Date,Activity) Values (@Username,@Date,@Activity)", conss);
                cmdss.Parameters.AddWithValue("@Username", lblfullname.Text);
                cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
                cmdss.Parameters.AddWithValue("@Activity", lblensission.Text);
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

        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd = new SqlCommand("SELECT * from BarangayOfficalInformation where tbl_Email='" + Session["admin"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                txtfullname.Text = dt.Rows[0]["tbl_Fullname"].ToString();
                txtemail.Text = dt.Rows[0]["tbl_Email"].ToString();
                txtmobilenumber.Text = dt.Rows[0]["tbl_mobilenumber"].ToString();
                Txtbirthday.Text = dt.Rows[0]["tbl_BarangayOfficalPosition"].ToString();
      
                txtaddress.Text = dt.Rows[0]["tbl_address"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        protected void btnchangeprofile_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update BarangayOfficalInformation set tbl_Fullname=@tbl_Fullname, tbl_address=@tbl_address WHERE tbl_email='" + Session["admin"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@tbl_Fullname", txtfullname.Text.Trim());
                cmd.Parameters.AddWithValue("@tbl_address", txtaddress.Text.Trim());

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    // Account creation successful
                    string redirectScript = "swal('Profile has been update Successfully', '', 'success').then(function() { window.location = 'BarangayAdminDashboard.aspx'; });";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);
                    cmdss = new SqlCommand(@"Insert Into Activity (Username,Date,Activity) Values (@Username,@Date,@Activity)", conss);
                    cmdss.Parameters.AddWithValue("@Username", lblfullname.Text);
                    cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
                    cmdss.Parameters.AddWithValue("@Activity", lblchangepassword.Text);
                    conss.Open();
                    cmdss.Connection = conss;
                    cmdss.ExecuteNonQuery();
                    conss.Close();
                    getUserPersonalDetails();
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
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

        
    }
}