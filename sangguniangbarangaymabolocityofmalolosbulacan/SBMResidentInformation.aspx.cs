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
    public partial class SBMResidentInformation : System.Web.UI.Page
    {
        SqlConnection conssa = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdssa;
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
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (!Page.IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    getUserPersonalDetails();
                }
                else
                {
                    Response.Redirect("BarangayResidentPendingRegister.aspx", false);
                }
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
        }


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlDataAdapter da;
        DataTable dt;
        void getUserPersonalDetails()
        {
            con.Open();
            cmd = new SqlCommand(@"SELECT * FROM tbl_createaccount WHERE ID = '" + Session["ID"].ToString() + "'", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["ID"] = int.Parse(dt.Rows[0]["ID"].ToString());
                lblresidentno.Text = dt.Rows[0]["residentcontrolnumber"].ToString();
                lblfullnamess.Text = dt.Rows[0]["tbl_name"].ToString();
                lblemail.Text = dt.Rows[0]["tbl_email"].ToString();
                lblcontano.Text = dt.Rows[0]["tbl_mobilenumber"].ToString();
                lbladdress.Text = dt.Rows[0]["tbl_address"].ToString() +" " + dt.Rows[0]["defaultaddress"].ToString();
                lblbirthday.Text = dt.Rows[0]["tbl_birthday"].ToString();
                lblgender.Text = dt.Rows[0]["tbl_Gender"].ToString();
                lblvoterregister.Text = dt.Rows[0]["VotersRegistered"].ToString();
                Image1.ImageUrl = dt.Rows[0]["tbl_validid"].ToString();

            }
            con.Close();
        }

        



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
            cmdss.Parameters.AddWithValue("@Activity", lbllogout.Text);
            conss.Open();
            cmdss.Connection = conss;
            cmdss.ExecuteNonQuery();
            conss.Close();
        }

        protected void Btnreviewvalidid_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewValidid.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayRegisterResident.aspx");
        }
    }
}