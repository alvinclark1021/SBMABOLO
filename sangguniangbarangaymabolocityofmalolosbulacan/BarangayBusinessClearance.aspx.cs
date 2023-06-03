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
using System.Xml.Linq;
using System.Net.Mail;
using System.Text;


namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class BarangayBusinessClearance : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
       
        SqlCommand cmd;
        string str;
        SqlCommand com;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldatemenow.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (!Page.IsPostBack)
            {
                getUserPersonalDetails();
                Loadname();
                RenewalBusiness();

            }
            lbldate.Text = DateTime.Now.ToString("D");
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
            cmdss.CommandText = "SELECT COUNT(*) FROM BarangayBusinessClearance";
            int count = (int)cmdss.ExecuteScalar();
            conss.Close();

            string datePart = DateTime.Today.ToString("MMddyyyy");
            string sequenceNumber = (count + 1).ToString("D1");

            txtcontrolnumber.Text = "BCNo" + datePart + "-" + sequenceNumber;
        }

        private void RenewalBusiness()
        {
            // using the connection string from web.config file
            string connectionString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;

            // creating a new SqlConnection object and opening the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // creating a new SqlCommand object with the query to fetch data
                using (SqlCommand command = new SqlCommand("SELECT BarangayBuisnessname FROM BarangayBusinessClerance WHERE Status='New' ORDER BY BarangayBuisnessname ASC", connection))
                {
                    // creating a new SqlDataAdapter object with the command object
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // creating a new DataSet object to hold the data
                        DataSet dataSet = new DataSet();

                        // filling the data into the DataSet object
                        adapter.Fill(dataSet);

                        // binding the data to the dropdown list
                        Dropselection.DataSource = dataSet.Tables[0];
                        Dropselection.DataTextField = "BarangayBuisnessname";
                        
                        Dropselection.DataBind();

                        // inserting the default "select" item at the first index
                        Dropselection.Items.Insert(0, new ListItem("Select", "-1"));

                        // selecting the default "select" item
                        Dropselection.SelectedIndex = 0;
                    }
                }
            }
        }

        private void Loadname()
        {
            // using the connection string from web.config file
            string connectionString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;

            // creating a new SqlConnection object and opening the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // creating a new SqlCommand object with the query to fetch data
                using (SqlCommand command = new SqlCommand("SELECT BarangayBuisnessname FROM BarangayBusinessClerance WHERE Status='Approved' ORDER BY BarangayBuisnessname ASC", connection))
                {
                    // creating a new SqlDataAdapter object with the command object
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // creating a new DataSet object to hold the data
                        DataSet dataSet = new DataSet();

                        // filling the data into the DataSet object
                        adapter.Fill(dataSet);

                        // binding the data to the dropdown list
                        Dropselectbusinessclearance.DataSource = dataSet.Tables[0];
                        Dropselectbusinessclearance.DataTextField = "BarangayBuisnessname";
                        //Dropselectbusinessclearance.DataValueField = "ID";
                        Dropselectbusinessclearance.DataBind();

                        // inserting the default "select" item at the first index
                        Dropselectbusinessclearance.Items.Insert(0, new ListItem("Select Business Category", "-1"));

                        // selecting the default "select" item
                        Dropselectbusinessclearance.SelectedIndex = 0;
                    }
                }
            }
            

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
                txtbusinessownername.Text = dt.Rows[0]["tbl_name"].ToString();
                txtcontactnumber.Text = dt.Rows[0]["tbl_mobilenumber"].ToString();
                txtemail.Text = dt.Rows[0]["tbl_email"].ToString();
                txtbusinessaddress.Text = dt.Rows[0]["tbl_address"].ToString() + " " + dt.Rows[0]["defaultaddress"].ToString();
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
       
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (Dropselectbusinessclearance.SelectedIndex == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                         "swal('Please choose your business category.','','info')", true);
            }
            else
            {

                if (Dropselection.SelectedIndex == 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                             "swal('Please choose your business application .','','info')", true);
                }
                else
                {
                    string fileName = FileUpload2.FileName;
                    string fileExtension = Path.GetExtension(fileName);

                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
                    {

                        FileUpload2.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "BusinessClearanceHouseorcommincalbuliding/" + fileName);

                        cmd = new SqlCommand(@"Insert Into BarangayBusinessClearance (fullname,email,phonenumber,address,purpose,operatormanager,businessname,businessaddress,businesscategory,datepickup,barangaycef,barangaybusinesscontrolno,validhouesorcommenecialbulding) Values (@fullname,@email,@phonenumber,@address,@purpose,@operatormanager,@businessname,@businessaddress,@businesscategory,@datepickup,@barangaycef,@barangaybusinesscontrolno,@validhouesorcommenecialbulding)");
                        cmd.Parameters.AddWithValue("@fullname", txtfullname.Text);
                        cmd.Parameters.AddWithValue("@email", txtemail.Text);
                        cmd.Parameters.AddWithValue("@phonenumber", txtcontactnumber.Text);
                        cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                        cmd.Parameters.AddWithValue("@purpose", Dropselection.Text);
                        cmd.Parameters.AddWithValue("@operatormanager", txtbusinessownername.Text);
                        cmd.Parameters.AddWithValue("@businessname", txtbusinessname.Text);
                        cmd.Parameters.AddWithValue("@businessaddress", txtbusinessaddress.Text);
                        cmd.Parameters.AddWithValue("@businesscategory", Dropselectbusinessclearance.Text);
                        cmd.Parameters.AddWithValue("@datepickup", lbldate.Text);
                        cmd.Parameters.AddWithValue("@barangaycef", lblbarangaycef.Text);
                        cmd.Parameters.AddWithValue("@barangaybusinesscontrolno", txtcontrolnumber.Text);
                        cmd.Parameters.AddWithValue("@validhouesorcommenecialbulding", fileName);
                        con.Open();
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<div style='font-size: 19px;'>");
                        sb.Append("Hi, " + txtfullname.Text + "<br/>");
                        sb.Append("Within 24 to 72 hours, your barangay business clearance document is being processed in order to examine your request. <br/>");
                        sb.Append("<br/>Your Business Clearance Details <br/>");
                        sb.Append("Registration no: " + txtcontrolnumber.Text + "<br/>");
                        sb.Append("Date Registration: " + lbldate.Text + "<br/>");
                        sb.Append("Name: " + txtbusinessname.Text + "<br/>");
                        sb.Append("Email: " + txtbusinessaddress.Text + "<br/>");
                        sb.Append("<br/><b>Thanks for your understanding and request for the document</b>,<br/> Sangguniang Barangay Mabolo City of Malolos Bulacan <br/>");
                        sb.Append("</div>");


                        MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", txtemail.Text.Trim(), "Thanks Barangay business clearance", sb.ToString());

                        SmtpClient smtp = new SmtpClient();

                        smtp.Host = "smtp.gmail.com";

                        smtp.Port = 587;

                        smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");

                        smtp.EnableSsl = true;

                        message.IsBodyHtml = true;

                        smtp.Send(message);

                       
                        Session["Businesscaterogy"] = Dropselectbusinessclearance.Text;
                        Session["test"] = txtbusinessownername.Text;
                        Session["tests"] = txtbusinessname.Text;
                        Session["testss"] = txtbusinessaddress.Text;
                        Session["testsss"] = txtcontactnumber.Text;
                        Session["testsssss"] = lbldate.Text;
                        Session["testssssss"] = txtcontrolnumber.Text;
                        Session["123"] = Dropselection.Text;

                        //To success to nofications
                        string redirectScript = $"swal('Hi {txtfullname.Text}, your request is currently being processed. Please wait for an email message.', '', 'success').then(function() {{ window.location = 'businessclearanceopticalreceipt.aspx'; }});";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                 "swal('Only jpg and png file allowed.','','error')", true);
                    }
                }
                
            }
            
        }

        protected void linkdeactivateaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmpassworddeactivateaccount.aspx");
        }

       
    }
}