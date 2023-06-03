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
using System.Web.Security;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class BarangayRequestDocuments : System.Web.UI.Page
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
            lbldatemenow.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");

            Loadname();
            if (!Page.IsPostBack)
            {
                getUserPersonalDetails();
            }

            lbldatemenow.Text = DateTime.Now.ToString("D");
            if (Session["user"] != null)
            {
                lblsessionlogin.Text = Session["user"].ToString();

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            LOADBarangayBusinessClearance();
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
            lblname.Text = ds.Tables[0].Rows[0]["tbl_name"].ToString();

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

            txtgoodmoral.Text = "GoodMoral#" + datePart + "-" + sequenceNumber;
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

        protected void Droplisttorequestdocuments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnupdateinformation_Click(object sender, EventArgs e)
        {
            
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand(@"Insert Into BarangayCerficationinformation (fullname,email,mobilenumber,address,purpose,barangaycefication,barangayControlnumber,datepickup) Values (@fullname,@email,@mobilenumber,@address,@purpose,@barangaycefication,@barangayControlnumber,@datepickup)");

            cmd.Parameters.AddWithValue("@fullname", txtfullname.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@mobilenumber", txtmobilenumber.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@purpose", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@datepickup", lbldatemenow.Text);
            cmd.Parameters.AddWithValue("@barangaycefication", lblBarangayClearance.Text);
            cmd.Parameters.AddWithValue("@barangayControlnumber", txtgoodmoral.Text);

            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();

            Session["test"] = txtfullname.Text;
            Session["tests"] = txtemail.Text;
            Session["testss"] = txtaddress.Text;
            Session["testsss"] = txtmobilenumber.Text;
            Session["testsssss"] = lbldatemenow.Text;
            Session["testssssss"] = txtgoodmoral.Text;
            Response.Redirect("goodmoralrepi.aspx");


        }

        SqlConnection conssaa = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand daj;
        private void Loadname()
        {
            conssaa.Open();
            daj = new SqlCommand("SELECT * FROM GoodMornal WHERE Status = 'Approved'");
            daj.Connection = conssaa;
            SqlDataAdapter dao = new SqlDataAdapter(daj);
            DataTable dto = new DataTable();
            dao.Fill(dto);

            DropDownList1.DataSource = dto;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select Purpose"));
            conssaa.Close();
        }

        protected void linkdeactivateaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmpassworddeactivateaccount.aspx");
        }

        
    }
}