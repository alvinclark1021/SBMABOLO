using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class Messagetoreviewinformationresident : System.Web.UI.Page
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
            lblsessionlogin.Text = ds.Tables[0].Rows[0]["tbl_Email"].ToString();
            lblbarangayofficals.Text = ds.Tables[0].Rows[0]["tbl_BarangayOfficalPosition"].ToString();
            lblnameofoffical.Text = ds.Tables[0].Rows[0]["tbl_Fullname"].ToString();

            getUserPersonalDetails();
        }

        void getUserPersonalDetails()
        {
            con.Open();
            cmd = new SqlCommand(@"SELECT * FROM Concernmessage WHERE ID = '" + Session["ID"].ToString() + "'", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["ID"] = int.Parse(dt.Rows[0]["ID"].ToString());
                lblfullnamess.Text = dt.Rows[0]["Name"].ToString();
                lblemail.Text = dt.Rows[0]["Email"].ToString();
                lblcontano.Text = dt.Rows[0]["Contactnumber"].ToString();
                lbladdress.Text = dt.Rows[0]["datetoday"].ToString();
                txtconcernsmessage.Text = dt.Rows[0]["Message"].ToString();
                

            }
            con.Close();
        }


        protected void Linklogout_Click(object sender, EventArgs e)
        {
            SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
            SqlCommand cmdss;
            cmdss = new SqlCommand(@"Insert Into Activity (Username,Activity,Date) Values (@Username,@Activity,@Date)");

            cmdss.Parameters.AddWithValue("@Username", lblsessionlogin.Text);
            cmdss.Parameters.AddWithValue("@Activity", lblactivity.Text);
            cmdss.Parameters.AddWithValue("@Date", lbldate.Text);

            conss.Open();
            cmdss.Connection = conss;
            cmdss.ExecuteNonQuery();
            conss.Close();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("BarangayOfficalLogin.aspx");
        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }


        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }
        //002
        SqlConnection conssss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdssss;
        DataTable gtas;
        SqlDataAdapter nba;
        protected void btnok_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("rptProducts") as Label).Text;

            conssss.Open();
            cmdssss = new SqlCommand(@"UPDATE BarangayClearancess SET Status='Send Email' WHERE ID = '" + Session["ID"].ToString() + "'", conssss);
            cmdssss.ExecuteNonQuery();
            conssss.Close();
           
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                      "swal('Your Concerns are send success .','','success')", true);
        }
    }
}