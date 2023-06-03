using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;
using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using System.Web.Security;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class Cerficationofresidency : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        string str;
        SqlCommand com;
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        DataTable dt;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getUserPersonalDetails();
            }

            LOADBarangayBusinessClearance();
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

        private void LOADBarangayBusinessClearance()
        {
            conss.Open();
            SqlCommand cmdss = conss.CreateCommand();
            cmdss.CommandType = CommandType.Text;
            cmdss.CommandText = "SELECT COUNT(*) FROM BarangayCerficationinformation";
            int count = (int)cmdss.ExecuteScalar();
            conss.Close();

            string datePart = DateTime.Today.ToString("MMddyyyy");
            string sequenceNumber = (count + 1).ToString("D1");

            txtresidency.Text = "ResidencyNo" + datePart + "-" + sequenceNumber;
        }

        void getUserPersonalDetails()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from tbl_createaccount where tbl_username='" + Session["user"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                txtfullname.Text = dt.Rows[0]["tbl_name"].ToString();
                txtmobilenumber.Text = dt.Rows[0]["tbl_mobilenumber"].ToString();
                txtemail.Text = dt.Rows[0]["tbl_email"].ToString();
                txtaddress.Text = dt.Rows[0]["tbl_address"].ToString();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

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

        protected void Linkchangepasswprd_Click1(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            SqlConnection cona = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
            SqlCommand cmda;
            cmda = new SqlCommand(@"Insert Into BarangayCerficationinformation (fullname,email,mobilenumber,address,purpose,barangaycefication,barangayControlnumber,datepickup) Values (@fullname,@email,@mobilenumber,@address,@purpose,@barangaycefication,@barangayControlnumber,@datepickup)");

            cmda.Parameters.AddWithValue("@fullname", txtfullname.Text);
            cmda.Parameters.AddWithValue("@email", txtemail.Text);
            cmda.Parameters.AddWithValue("@mobilenumber", txtmobilenumber.Text);
            cmda.Parameters.AddWithValue("@address", txtaddress.Text);
            cmda.Parameters.AddWithValue("@purpose", DropDownList1.SelectedItem.Value);
            cmda.Parameters.AddWithValue("@datepickup", lbldatemenow.Text);
            cmda.Parameters.AddWithValue("@barangaycefication", lblBarangayClearance.Text);
            cmda.Parameters.AddWithValue("@barangayControlnumber", txtresidency.Text);

            cona.Open();
            cmda.Connection = cona;
            cmda.ExecuteNonQuery();
            cona.Close();
            Session["test"] = txtfullname.Text;
            Session["tests"] = txtemail.Text;
            Session["testss"] = txtmobilenumber.Text;
            Session["testsss"] = txtaddress.Text;

            Session["testsssss"] = lbldatemenow.Text;
            Session["testssssss"] = txtmobilenumber.Text;
            Response.Redirect("ResidencyRecipient.aspx");

        }

        protected void linkdeactivateaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmpassworddeactivateaccount.aspx");
        }

        protected void btnsubmitpurpose_Click(object sender, EventArgs e)
        {

        }
    }
}