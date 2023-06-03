using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class FencingPermit : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        string str;
        SqlCommand com;
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                // creating a new SqlConnection object and opening the connection
                using (SqlConnection connection = new SqlConnection(strConnString))
                {
                    connection.Open();

                    // creating a new SqlCommand object with the query to fetch data
                    using (SqlCommand command = new SqlCommand("SELECT Namess FROM FencingPermit WHERE Status='Approved' ORDER BY Namess ASC", connection))
                    {
                        // creating a new SqlDataAdapter object with the command object
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // creating a new DataSet object to hold the data
                            DataSet dataSet = new DataSet();

                            // filling the data into the DataSet object
                            adapter.Fill(dataSet);

                            // binding the data to the dropdown list
                            Droppupose.DataSource = dataSet.Tables[0];
                            Droppupose.DataTextField = "Namess";

                            Droppupose.DataBind();

                            // inserting the default "select" item at the first index
                            Droppupose.Items.Insert(0, new ListItem("Select Fencing Permit Purposes", "0"));

                            // selecting the default "select" item
                            Droppupose.SelectedIndex = 0;
                        }
                    }
                }
            }

            lbldatemenow.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            //Loadname();
            if (!Page.IsPostBack)
            {
                getUserPersonalDetails();
                
            }
            lbldatemenow.Text = DateTime.Now.ToString("D");
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
        private void LOADBarangayBusinessClearance()
        {
            conss.Open();
            SqlCommand cmdss = conss.CreateCommand();
            cmdss.CommandType = CommandType.Text;
            cmdss.CommandText = "SELECT COUNT(*) FROM FencingPermitInformation";
            int count = (int)cmdss.ExecuteScalar();
            conss.Close();

            string datePart = DateTime.Today.ToString("MMddyyyy");
            string sequenceNumber = (count + 1).ToString("D1");

            txtocccontrolnumber.Text = "FencingPermit#" + datePart + "-" + sequenceNumber;
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
            if (Droppupose.SelectedIndex == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                         "swal('Please choose your barangay fencing permit purposes.','','info')", true);
            }
            else
            {
                string fileName = FileUpload1.FileName;
                string fileExtension = Path.GetExtension(fileName);

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
                {
                    FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "ResidentImageprofile/" + FileUpload1.FileName);
                    cmd = new SqlCommand(@"Insert Into FencingPermitInformation (fullname,email,mobilenumber,address,purpose,barangaycefication,barangayControlnumbers,datepickup,ResidentImage,Addotherpurposes) Values (@fullname,@email,@mobilenumber,@address,@purpose,@barangaycefication,@barangayControlnumbers,@datepickup,@ResidentImage,@Addotherpurposes)");

                    cmd.Parameters.AddWithValue("@fullname", txtfullname.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@mobilenumber", txtmobilenumber.Text);
                    cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@purpose", Droppupose.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@datepickup", lbldatemenow.Text);
                    cmd.Parameters.AddWithValue("@barangaycefication", lblBarangayClearance.Text);
                    cmd.Parameters.AddWithValue("@barangayControlnumbers", txtocccontrolnumber.Text);
                    cmd.Parameters.AddWithValue("@ResidentImage", fileName);
                    cmd.Parameters.AddWithValue("@Addotherpurposes", txtaddotherpurpose.Text);
                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    // email send after to request documnets 
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<div style='font-size: 18px;'>");
                    sb.Append("Hi, " + txtfullname.Text + "<br/>");
                    sb.Append("Within 24 to 48 hours, your barangay Fencing Permit document is being processed in order to examine your request. <br/>");
                    sb.Append("Details about the document you requested are provided. <br/>");
                    sb.Append("Control no: " + txtocccontrolnumber.Text + "<br/>");
                    sb.Append("Name: " + txtfullname.Text + "<br/>");
                    sb.Append("Address: " + txtaddress.Text + "<br/>");
                    sb.Append("Email: " + txtemail.Text + "<br/>");
                    sb.Append("Date Request Document: " + lbldate.Text + "<br/>");
                    sb.Append("</div>");


                    MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", txtemail.Text.Trim(), "Barangay Fencing Permit Document Process ", sb.ToString());

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
                    Session["testssssss"] = txtocccontrolnumber.Text;
                    Session["123"] = Droppupose.Text;

                    //To success to nofications
                    string redirectScript = $"swal('Hi {txtfullname.Text}, your request is currently being processed. Please wait for an email message.', '', 'success').then(function() {{ window.location = 'FencingPermitrecipient.aspx'; }});";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);
                    

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                  "swal('Only jpg and png file allowed.','','error')", true);
                }
            }

            



        }

        protected void linkdeactivateaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmpassworddeactivateaccount.aspx");
        }

        protected void btnaddpurposess_Click(object sender, EventArgs e)
        {
            divepurposess.Visible = true;
            divaddpurposess.Visible = false;
        }
    }
}