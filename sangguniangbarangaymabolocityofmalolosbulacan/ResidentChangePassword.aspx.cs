using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class ResidentChangePassword : System.Web.UI.Page
    {
        SqlConnection cona = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmda;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str = null;
        SqlCommand com;
        byte up;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
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
            com = new SqlCommand(str, cons);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lblfullname.Text = ds.Tables[0].Rows[0]["tbl_name"].ToString();
            lblsessionlogin.Text = ds.Tables[0].Rows[0]["tbl_username"].ToString();
            lblname.Text = ds.Tables[0].Rows[0]["tbl_name"].ToString();
        }

        

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        private Boolean checkemailregistedusername()
        {
            Boolean emailregistedalready = false;
            String myquery = "Select tbl_email from tbl_createaccount where tbl_password='" + txtnewpassword.Text + "'";
            cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            DataSet dss = new DataSet();
            ds.Fill(dss);
            if (dss.Tables[0].Rows.Count > 0)
            {
                emailregistedalready = true;
            }
            con.Close();

            return emailregistedalready;
        }


        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            if (checkemailregistedusername() == true)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Password are same.','','warning')", true);
            }
            else
            {
                SqlConnection con = new SqlConnection(strConnString);
                con.Open();
                str = "select tbl_password from tbl_createaccount ";
                com = new SqlCommand(str, con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (txtcurrentpassword.Text == reader["tbl_password"].ToString())
                    {
                        up = 1;
                    }
                }
                reader.Close();
                con.Close();
                if (up == 1)
                {
                    con.Open();
                    str = "update tbl_createaccount set tbl_password=@tbl_password where tbl_username='" + Session["user"].ToString() + "'";
                    com = new SqlCommand(str, con);
                    com.Parameters.Add(new SqlParameter("@tbl_password", SqlDbType.VarChar, 50));
                    com.Parameters["@tbl_password"].Value = txtnewpassword.Text;
                    com.ExecuteNonQuery();
                    con.Close();
                    //To success to nofications
                    string redirectScript = $"swal('Hi {lblfullname.Text}, Congratulations Password changed Successfully!', '', 'success').then(function() {{ window.location = 'ResidentDashboard.aspx'; }});";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

                    

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                           "swal('Try Again-that's not your current password','','warning')", true);
                }
            }

           
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileSettingsResident.aspx");
        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResidentChangePassword.aspx");
        }

        protected void linkdeactivateaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmpassworddeactivateaccount.aspx");
        }
    }
}
