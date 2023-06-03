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
    public partial class transactionhistory : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string connectionString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
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

            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    // Retrieve the username from the "user" session variable
                    string username = Session["user"].ToString();

                    // Construct a SQL query to select the user's transaction history based on the username or email address
                    string query = "SELECT * FROM tbl_transacationhistory WHERE username = @username ORDER BY Username DESC";

                    // Open a new SqlConnection object using the connection string for your SQL Server database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Create a new SqlCommand object using the SQL query and the SqlConnection object
                        SqlCommand command = new SqlCommand(query, connection);

                        // Add SqlParameter object to replace the "@username" placeholder in the SQL query with the actual username value
                        command.Parameters.AddWithValue("@username", username);

                        // Open the SqlConnection object and execute the SqlCommand object using the SqlDataReader object to read the results
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // Check if the reader object has any rows, and if so, bind the results to the UserHistory control using the DataSource and DataBind methods
                        if (reader.HasRows)
                        {
                            UserHistory.DataSource = reader;
                            UserHistory.DataBind();
                        }

                        // Close the SqlDataReader and SqlConnection objects
                        reader.Close();
                        connection.Close();
                    }
                }
            }


            try
            {
                SqlConnection con = new SqlConnection(strConnString);
                con.Open();
                str = "select * from tbl_createaccount where tbl_username='" + Session["user"] + "'";
                com = new SqlCommand(str, con);
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

        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM tbl_transacationhistory where  Name like '%" + txtSearch.Text + "%' OR Activity like '%" + txtSearch.Text + "%' OR Controlno like '%" + txtSearch.Text + "%' OR Username like '%" + txtSearch.Text + "%' OR Date like '%" + txtSearch.Text + "%'";
            cons.Open();
            SqlDataAdapter ad = new SqlDataAdapter(qry, cons);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            UserHistory.DataSource = ds;
            UserHistory.DataBind();
            cons.Close();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM tbl_transacationhistory where Name like '%" + txtSearch.Text + "%' OR Activity like '%" + txtSearch.Text + "%' OR Controlno like '%" + txtSearch.Text + "%' OR Username like '%" + txtSearch.Text + "%' OR Date like '%" + txtSearch.Text + "%'";
            cons.Open();
            SqlDataAdapter ad = new SqlDataAdapter(qry, cons);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            UserHistory.DataSource = ds;
            UserHistory.DataBind();
            cons.Close();
        }
    }
}