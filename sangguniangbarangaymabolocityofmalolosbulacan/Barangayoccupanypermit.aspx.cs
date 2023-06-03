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
using System.IO;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class Barangayoccupanypermit : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        SqlCommand cmdss;
        string str;
        SqlCommand com;
        DataTable dt;
        SqlDataAdapter da;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                // creating a new SqlConnection object and opening the connection
                using (SqlConnection connection = new SqlConnection(strConnString))
                {
                    connection.Open();

                    // creating a new SqlCommand object with the query to fetch data
                    using (SqlCommand command = new SqlCommand("SELECT BarangayOccupanyPermits FROM BarangayOccupanypermit WHERE Status='Approved' ORDER BY BarangayOccupanyPermits ASC", connection))
                    {
                        // creating a new SqlDataAdapter object with the command object
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // creating a new DataSet object to hold the data
                            DataSet dataSet = new DataSet();

                            // filling the data into the DataSet object
                            adapter.Fill(dataSet);

                            // binding the data to the dropdown list
                            DropDownList1.DataSource = dataSet.Tables[0];
                            DropDownList1.DataTextField = "BarangayOccupanyPermits";

                            DropDownList1.DataBind();

                            // inserting the default "select" item at the first index
                            DropDownList1.Items.Insert(0, new ListItem("Select barangay occupancy Permit Purposes", "0"));

                            // selecting the default "select" item
                            DropDownList1.SelectedIndex = 0;
                        }
                    }
                }
            }

            lbldatemenow.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            
            Loadname();
            LOADBarangayBusinessClearance();
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
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM BarangayCerficationinformation";
            int count = (int)cmd.ExecuteScalar();
            con.Close();

            string datePart = DateTime.Today.ToString("MMddyyyy");
            string sequenceNumber = (count + 1).ToString("D1");

            txtocccontrolnumber.Text = "occupanypermitNo" + datePart + "-" + sequenceNumber;
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
                txtaddress.Text = dt.Rows[0]["tbl_address"].ToString()  + dt.Rows[0]["defaultaddress"].ToString();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        protected void btnupdateinformation_Click(object sender, EventArgs e)
        {
            
        }

        protected void Bntcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResidentDashboard.aspx");
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

        SqlConnection conssaa = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand daj;
        private void Loadname()
        {

            //if (!IsPostBack)
            //{
            //    //using Students Database, with Windows Security as Login to SQL Server DB
            //    string connectionString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
            //    // connection string  
            //    SqlConnection con = new SqlConnection(connectionString);
            //    con.Open();

            //    SqlCommand com = new SqlCommand("select * from BarangayOccupanypermit where Status='Approved' ", con);
            //    // table name   
            //    SqlDataAdapter da = new SqlDataAdapter(com);
            //    DataSet ds = new DataSet();
            //    da.Fill(ds);  // fill dataset  
            //                  //assigning datasource to the dropdownlist           
            //    DropDownList1.DataSource = ds.Tables[0];

            //    DropDownList1.DataTextField = ds.Tables[0].Columns["BarangayOccupanyPermits"].ToString(); // text field name of table dispalyed in dropdown, "Name" column from Students table       

            //    DropDownList1.DataBind();  //binding dropdownlist  
            //}
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            string fileName = FileUpload1.FileName;
            string fileExtension = Path.GetExtension(fileName);

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
            {
                FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "BarangayCeficationInformatio/" + fileName);
                cmd = new SqlCommand(@"Insert Into BarangayCerficationinformation (fullname,email,mobilenumber,address,purpose,barangaycefication,barangayControlnumber,datepickup,ResidentImage) Values (@fullname,@email,@mobilenumber,@address,@purpose,@barangaycefication,@barangayControlnumber,@datepickup,@ResidentImage)");

                cmd.Parameters.AddWithValue("@fullname", txtfullname.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@mobilenumber", txtmobilenumber.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@purpose", DropDownList1.Text);
                cmd.Parameters.AddWithValue("@datepickup", lbldatemenow.Text);
                cmd.Parameters.AddWithValue("@barangaycefication", lblBarangayClearance.Text);
                cmd.Parameters.AddWithValue("@barangayControlnumber", txtocccontrolnumber.Text);
                cmd.Parameters.AddWithValue("@ResidentImage", fileName);
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                Session["test"] = txtfullname.Text;
                Session["tests"] = txtemail.Text;
                Session["testss"] = txtmobilenumber.Text;
                Session["testsss"] = txtaddress.Text;
                Session["testsssss"] = lbldatemenow.Text;
                Session["testssssss"] = txtocccontrolnumber.Text;
                Session["123"] = DropDownList1.Text;
                Response.Redirect("occupancypermitopticalreceipt.aspx");
                DropDownList1.Text = string.Empty;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                              "swal('Only jpg and png file allowed.','','error')", true);
            }
        }

        protected void Bntsubmitpurpose_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand(@"Insert Into BarangayOccupanypermit (BarangayOccupanyPermits,date) Values (@BarangayOccupanyPermits,@date)");
            cmd.Parameters.AddWithValue("@date", lbldatemenow.Text);
            cmd.Parameters.AddWithValue("@BarangayOccupanyPermits", txtaddpurpose.Text);
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Your Add Occupany Permit Be Sucessfully.','','successs')", true);
            txtaddpurpose.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            san.Visible = false;
            dad.Visible = true;
        }
    }
}