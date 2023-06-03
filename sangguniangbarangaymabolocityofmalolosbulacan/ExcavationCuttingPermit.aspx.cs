using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Net;


namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class ExcavationCuttingPermit : System.Web.UI.Page
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

            if (!IsPostBack)
            {


                // creating a new SqlConnection object and opening the connection
                using (SqlConnection connection = new SqlConnection(strConnString))
                {
                    connection.Open();

                    // creating a new SqlCommand object with the query to fetch data
                    using (SqlCommand command = new SqlCommand("SELECT BarangayAddPurpose FROM ExcavationPermit WHERE Status='Approved' ORDER BY BarangayAddPurpose ASC", connection))
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
                            DropDownList1.DataTextField = "BarangayAddPurpose";

                            DropDownList1.DataBind();

                            // inserting the default "select" item at the first index
                            DropDownList1.Items.Insert(0, new ListItem("Select Excavation Permit Purposes", "0"));

                            // selecting the default "select" item
                            DropDownList1.SelectedIndex = 0;
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
            LOADBarangayExcavationpermit();
            if (Session["user"] != null)
            {
                lblsessionlogin.Text = Session["user"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
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

            BarangayExcavationCuttingPermitListPurposes();
        }

        private void LOADBarangayExcavationpermit()
        {
            conss.Open();
            SqlCommand cmdss = conss.CreateCommand();
            cmdss.CommandType = CommandType.Text;
            cmdss.CommandText = "SELECT COUNT(*) FROM ExcavationCuttingInformation";
            int count = (int)cmdss.ExecuteScalar();
            conss.Close();

            string datePart = DateTime.Today.ToString("MMddyyyy");
            string sequenceNumber = (count + 1).ToString("D1");

            txtpermittoconstruct.Text = "Excavation/CuttingPermitNo" + datePart + "-" + sequenceNumber;
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
       
        private void BarangayExcavationCuttingPermitListPurposes()
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedIndex == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                         "swal('Please choose your barangay excavation/cutting permit.','','info')", true);
            }
            else
            {
                string fileName = FileUpload1.FileName;
                string fileExtension = Path.GetExtension(fileName);

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
                {

                    FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "BarangayCeficationInformatio/" + fileName);
                    cmd = new SqlCommand(@"Insert Into ExcavationCuttingInformation (fullname,email,mobilenumber,addresss,purpose,barangaycefication,barangayControlnumber,datepickup,ResidentImage) Values (@fullname,@email,@mobilenumber,@addresss,@purpose,@barangaycefication,@barangayControlnumber,@datepickup,@ResidentImage)");

                    cmd.Parameters.AddWithValue("@fullname", txtfullname.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@mobilenumber", txtmobilenumber.Text);
                    cmd.Parameters.AddWithValue("@addresss", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@purpose", DropDownList1.Text);
                    cmd.Parameters.AddWithValue("@datepickup", lbldatemenow.Text);
                    cmd.Parameters.AddWithValue("@barangaycefication", lblBarangayClearance.Text);
                    cmd.Parameters.AddWithValue("@barangayControlnumber", txtpermittoconstruct.Text);
                    cmd.Parameters.AddWithValue("@ResidentImage", fileName);
                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    // email send after to request documnets 
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<div style='font-size: 18px;'>");
                    sb.Append("Hi, " + txtfullname.Text + "<br/>");
                    sb.Append("Your barangay Excavation Permit has been processed within 24 to 48 hours to review your request document. <br/>");
                    sb.Append("Details of your requested document are as follows: <br/>");
                    sb.Append("Name: " + txtfullname.Text + "<br/>");
                    sb.Append("Address: " + txtaddress.Text + "<br/>");
                    sb.Append("Email: " + txtemail.Text + "<br/>");
                    sb.Append("Control no: " + txtpermittoconstruct.Text + "<br/>");
                    sb.Append("Date Request Document: " + lbldate.Text + "<br/>");
                    sb.Append("</div>");


                    MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", txtemail.Text.Trim(), "Barangay Excavation Cutting Document Process ", sb.ToString());

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");

                    smtp.EnableSsl = true;
                    message.IsBodyHtml = true;
                    smtp.Send(message);

                    Session["test"] = txtfullname.Text;
                    Session["tests"] = txtemail.Text;
                    Session["testss"] = txtmobilenumber.Text;
                    Session["testsss"] = txtaddress.Text;
                    Session["123"] = DropDownList1.Text;
                    Session["testsssss"] = lbldatemenow.Text;
                    Session["testssssss"] = txtpermittoconstruct.Text;

                    //To success to nofications
                    string redirectScript = $"swal('Hi {txtfullname.Text}, your request is currently being processed. Please wait for an email message.', '', 'success').then(function() {{ window.location = 'ExcavationCuttingPermitRe.aspx'; }});";
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
    }
}