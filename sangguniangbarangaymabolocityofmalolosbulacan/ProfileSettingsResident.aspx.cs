using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using AjaxControlToolkit;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class ProfileSettingsResident : System.Web.UI.Page
    {
        SqlConnection cona = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmda;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlCommand cmd;
        string str;
        SqlCommand com;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (!Page.IsPostBack)
            {
                getUserPersonalDetails();
            }
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            //To Disable the Future Dates in CalendarExtender control
            CalendarExtender1.StartDate = new DateTime(1900, 1, 1);
            //To Disable the Pass Dates in CalendarExtender control
            CalendarExtender1.EndDate = DateTime.Now;
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
            try
            {
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
            catch
            {
                Response.Redirect("Login.aspx");
            }
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
                lblID.Text = dt.Rows[0]["ID"].ToString();
                lblRegistrationNo.Text = dt.Rows[0]["residentcontrolnumber"].ToString();
                txtfullname.Text = dt.Rows[0]["tbl_name"].ToString();
                txtmobilenumber.Text = dt.Rows[0]["tbl_mobilenumber"].ToString();
                txtemail.Text = dt.Rows[0]["tbl_email"].ToString();
                txtaddress.Text = dt.Rows[0]["tbl_address"].ToString();
                txtbirthday.Text = dt.Rows[0]["tbl_birthday"].ToString();
                txtdefaultaddress.Text = dt.Rows[0]["defaultaddress"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        private bool ValidatePersonalDetails()
        {
            // Perform validation here
            // You can use if-else statements to check if the input is valid
            // If the input is not valid, you can return false

            if (string.IsNullOrEmpty(txtfullname.Text.Trim()))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Please enter your full name','','Warning')", true);
                return false;
            }

            if (string.IsNullOrEmpty(txtaddress.Text.Trim()))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                               "swal('Please enter your address','','Warning')", true);
                return false;
            }

            if (string.IsNullOrEmpty(txtbirthday.Text.Trim()))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                               "swal('Please enter your birthday','','Warning')", true);
                return false;
            }

            return true;
        }




        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmds;
        protected void btnupdateinformation_Click(object sender, EventArgs e)
        {

            if (ValidatePersonalDetails())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("update tbl_createaccount set tbl_name=@tbl_name, tbl_address=@tbl_address, tbl_birthday=@tbl_birthday WHERE tbl_username='" + Session["user"].ToString().Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@tbl_name", txtfullname.Text.Trim());
                    cmd.Parameters.AddWithValue("@tbl_address", txtaddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@tbl_birthday", txtbirthday.Text.Trim());
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    getUserPersonalDetails();


                    if (result > 0)
                    {
                        cmds = new SqlCommand(@"Insert Into tbl_transacationhistory (Name,Activity,Username,Date) Values (@Name,@Activity,@Username,@Date)");
                        cmds.Parameters.AddWithValue("@Username", lblsessionlogin.Text);
                        cmds.Parameters.AddWithValue("@Activity", lbluser.Text);
                        cmds.Parameters.AddWithValue("@Date", lbldates.Text);
                        cmds.Parameters.AddWithValue("@Name", lblfullname.Text);

                        cons.Open();
                        cmds.Connection = cons;
                        cmds.ExecuteNonQuery();
                        cons.Close();
                        string redirectScript = "swal('Profile Edit has been Successfully!', '', 'success').then(function() { window.location = 'ResidentDashboard.aspx'; });";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

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

            
        }

        protected void Bntcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResidentDashboard.aspx");
        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResidentChangePassword.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileSettingsResident.aspx");
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void linkdeactivateaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmpassworddeactivateaccount.aspx");
        }
    }
}