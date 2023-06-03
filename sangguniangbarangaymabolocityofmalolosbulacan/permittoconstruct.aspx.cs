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
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Net;


namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class permittoconstruct : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Creating a new SqlConnection object and opening the connection
                using (SqlConnection connection = new SqlConnection(strConnString))
                {
                    connection.Open();

                    // Creating a new SqlCommand object with the query to fetch data
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Permittoconstruct WHERE Status='Approved' ORDER BY Name ASC", connection))
                    {
                        // Creating a new SqlDataAdapter object with the command object
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Creating a new DataSet object to hold the data
                            DataSet dataSet = new DataSet();

                            // Filling the data into the DataSet object
                            adapter.Fill(dataSet);

                            // Binding the data to the dropdown list
                            DropDownList1.DataSource = dataSet.Tables[0];
                            DropDownList1.DataTextField = "Name";

                            DropDownList1.DataBind();

                            // Inserting the default "select" item at the first index
                            DropDownList1.Items.Insert(0, new ListItem("Select barangay Permit to construct Purposes", "0"));

                            // Selecting the default "select" item
                            DropDownList1.SelectedIndex = 0;
                        }
                    }
                }
            }

            lbldatemenow.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            Loadname();
            if (!Page.IsPostBack)
            {
                getUserPersonalDetails();
            }

            LOADBarangayClearance();
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
                txtaddress.Text = dt.Rows[0]["tbl_address"].ToString() + " " + dt.Rows[0]["defaultaddress"].ToString();
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

        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        private void LOADBarangayClearance()
        {
           
            conss.Open();
            SqlCommand cmdss = conss.CreateCommand();
            cmdss.CommandType = CommandType.Text;
            cmdss.CommandText = "SELECT COUNT(*) FROM PermittocontrustInformation";
            int count = (int)cmdss.ExecuteScalar();
            conss.Close();

            string datePart = DateTime.Today.ToString("MMddyyyy");
            string sequenceNumber = (count + 1).ToString("D1");

            txtpermittoconstruct.Text = "Permittoconstruct#" + datePart + "-" + sequenceNumber;
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            string fileName = FileUpload1.FileName;
            string fileExtension = Path.GetExtension(fileName);

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
            {
                FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "ResidentImageprofile/" + FileUpload1.FileName);
                cmd = new SqlCommand(@"Insert Into PermittocontrustInformation (fullname,email,mobilenumber,address,purpose,barangaycefication,barangayControlnumber,datepickup,ResidentImage) Values (@fullname,@email,@mobilenumber,@address,@purpose,@barangaycefication,@barangayControlnumber,@datepickup,@ResidentImage)");

                cmd.Parameters.AddWithValue("@fullname", txtfullname.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@mobilenumber", txtmobilenumber.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@purpose", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@datepickup", lbldatemenow.Text);
                cmd.Parameters.AddWithValue("@barangaycefication", lblBarangayClearance.Text);
                cmd.Parameters.AddWithValue("@barangayControlnumber", txtpermittoconstruct.Text);
                cmd.Parameters.AddWithValue("ResidentImage", fileName);
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();

                // email send after to request documnets 
                StringBuilder sb = new StringBuilder();
                sb.Append("<p style='font-size:17px;'>Hi, " + txtfullname.Text + "<br/>Within 24 to 48 hours, your barangay permit to contruct document is in processed in order to examine your request. <br/></p>");
                sb.Append("<p style='font-size:17px;'>Details about the document you requested are provided. <br/></p>");
                sb.Append("<p style='font-size:17px;'>Control no           : " + txtpermittoconstruct.Text + "<br/></p>");
                sb.Append("<p style='font-size:17px;'>Name                 : " + txtfullname.Text + "<br/></p>");
                sb.Append("<p style='font-size:17px;'>Address              : " + txtaddress.Text + "<br/></p>");
                sb.Append("<p style='font-size:17px;'>Email                : " + txtemail.Text + "<br/></p>");
                sb.Append("<p style='font-size:17px;'>Date Request Document    : " + lbldate.Text + "<br/></p>");



                MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", txtemail.Text.Trim(), "Barangay Permit to Construct Document Process ", sb.ToString());

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;

                smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");

                smtp.EnableSsl = true;
                message.IsBodyHtml = true;
                smtp.Send(message);


                Session["test"] = txtfullname.Text;
                Session["tests"] = txtemail.Text;
                Session["testss"] = txtaddress.Text;
                Session["testsss"] = txtmobilenumber.Text;
                Session["testsssss"] = lbldatemenow.Text;
                Session["testssssss"] = txtpermittoconstruct.Text;

                //To success to nofications
                string redirectScript = $"swal('Hi {txtfullname.Text}, your request is currently being processed. Please wait for an email message.', '', 'success').then(function() {{ window.location = 'PermitToConstructRecipient.aspx'; }});";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);
                
             
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                              "swal('Only jpg and png file allowed.','','error')", true);
            }

        }

        SqlConnection conssaa = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand daj;
        private void Loadname()
        {
            if (!IsPostBack)
            {
                //using Students Database, with Windows Security as Login to SQL Server DB
                string connectionString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
                // connection string  
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand com = new SqlCommand("select * from Permittoconstruct where Status='Approved' ", con);
                // table name   
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset  
                              //assigning datasource to the dropdownlist           
                DropDownList1.DataSource = ds.Tables[0];

                DropDownList1.DataTextField = ds.Tables[0].Columns["Name"].ToString(); // text field name of table dispalyed in dropdown, "Name" column from Students table       

                DropDownList1.DataBind();  //binding dropdownlist  
            }
        }

        protected void Linklogout_Click1(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void linkdeactivateaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmpassworddeactivateaccount.aspx");
        }

        protected void btnaddpurpose_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand(@"Insert Into Permittoconstruct (Name,date) Values (@Name,@date)");
            cmd.Parameters.AddWithValue("@date", lbldatemenow.Text);
            cmd.Parameters.AddWithValue("@Name", txtaddpurposeme.Text);
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Your Add Business Category Be Sucessfully.','','successs')", true);
            txtaddpurposeme.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            good.Visible = false;
            sadme.Visible = true;
        }
    }
}