using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class Confirmpassworddeactivateaccount : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlCommand com;
        SqlDataAdapter sqlda;
        string str;
        DataTable dt;
        int RowCount;

        
        byte up;
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                lblsessionlogin.Text = Session["user"].ToString();

            }
            else
            {
                Response.Redirect("Login.aspx");
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

            if (Session["Username"] != null)
            {
                lblsessionlogin.Text = Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("deactivateaccount.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.Cookies["tbl_username"] != null && Request.Cookies["tbl_password"] != null)
                {
                    lblsessionlogin.Text = Request.Cookies["tbl_username"].Value;
                    txtcurrentpassword.Attributes["value"] = Request.Cookies["tbl_password"].Value;
                }
            }
        }




        protected void btnconfirmatinpassword_Click(object sender, EventArgs e)
        {   
            string Username = lblsessionlogin.Text.Trim();
            string Password = txtcurrentpassword.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "Select * from tbl_createaccount";
            com = new SqlCommand(str);
            sqlda = new SqlDataAdapter(com.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                Username = dt.Rows[i]["tbl_username"].ToString();
                Password = dt.Rows[i]["tbl_password"].ToString();

                if (Username == lblsessionlogin.Text && Password == txtcurrentpassword.Text)
                {
                    Session["Username"] = Username;
                    Response.Redirect("deactivateaccount.aspx");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Invalid Password','','error')", true);
                }
            }

            Response.Cookies["tbl_username"].Value = lblsessionlogin.Text.Trim();
            Response.Cookies["tbl_password"].Value = txtcurrentpassword.Text.Trim();
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResidentChangePassword.aspx");
        }

        protected void linkdeactivateaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmpassworddeactivateaccount.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileSettingsResident.aspx");
        }
    }
}