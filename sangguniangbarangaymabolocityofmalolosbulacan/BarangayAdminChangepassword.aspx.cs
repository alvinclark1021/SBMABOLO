using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using CdnJs.Core;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class BarangayAdminChangepassword : System.Web.UI.Page
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
            lblfullnames.Text = ds.Tables[0].Rows[0]["tbl_Fullname"].ToString();
            lblsessionlogin.Text = ds.Tables[0].Rows[0]["tbl_Email"].ToString();
            lblbarangayofficals.Text = ds.Tables[0].Rows[0]["tbl_BarangayOfficalPosition"].ToString();
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            cmdss = new SqlCommand(@"Insert Into Activity (Name,Username,Date,Activity) Values (@Name,@Username,@Date,@Activity)", conss);
            cmdss.Parameters.AddWithValue("@Name", lblfullnames.Text);
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
        SqlConnection cona = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmda;
        private Boolean checkemailregisted()
        {
            Boolean emailregistedalready = false;
            String myquery = "Select tbl_password from tbl_createaccount where tbl_password='" + txtnewpassword.Text + "'";
            cmda = new SqlCommand();
            cmda.CommandText = myquery;
            cmda.Connection = cona;
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmda;
            DataSet dss = new DataSet();
            ds.Fill(dss);
            if (dss.Tables[0].Rows.Count > 0)
            {
                emailregistedalready = true;
            }
            cona.Close();

            return emailregistedalready;
        }

        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            if(checkemailregisted()==true)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Password are same.','','warning')", true);
            }
            else
            {
                SqlConnection con = new SqlConnection(strConnString);
                con.Open();
                str = "select * from BarangayOfficalInformation ";
                com = new SqlCommand(str, con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (txtcurrentpassword.Text == reader["tbl_Password"].ToString())
                    {
                        up = 1;
                    }
                }
                reader.Close();
                con.Close();
                if (up == 1)
                {
                    con.Open();
                    str = "update BarangayOfficalInformation set tbl_Password=@tbl_Password where tbl_Email='" + Session["admin"].ToString() + "'";
                    com = new SqlCommand(str, con);
                    com.Parameters.Add(new SqlParameter("@tbl_Password", SqlDbType.VarChar, 50));
                    com.Parameters["@tbl_Password"].Value = txtnewpassword.Text;
                    com.ExecuteNonQuery();
                    con.Close();
                    cmdss = new SqlCommand(@"Insert Into Activity (Username,Date,Activity) Values (@Username,@Date,@Activity)", conss);
                    cmdss.Parameters.AddWithValue("@Username", lblfullname.Text);
                    cmdss.Parameters.AddWithValue("@Date", lbldate.Text);
                    cmdss.Parameters.AddWithValue("@Activity", lblactivity.Text);
                    conss.Open();
                    cmdss.Connection = conss;
                    cmdss.ExecuteNonQuery();
                    conss.Close();

                    //To success to nofications
                    string redirectScript = $"swal('Hi {lblfullname.Text}, Congratulations Password changed Successfully!', '', 'success').then(function() {{ window.location = 'BarangayAdminDashboard.aspx'; }});";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                           "swal('old password incorrect','','warning')", true);
                }
            }

            
        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }
    }
}