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
using System.Reflection.Emit;
using static System.Net.WebRequestMethods;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class BarangayClearance : System.Web.UI.Page
    {
        SqlConnection cona = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmda;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        string str;
        SqlCommand com;
        SqlConnection conssaa = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand daj;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldatemenow.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (!Page.IsPostBack)
            {
                getUserPersonalDetails();
               
            }

            if (!IsPostBack)
            {
                LoadDropdownDataBarangayClearance();
            }

            LOADBarangayResidentInformation();
            
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


        private void LoadDropdownDataBarangayClearance()
        {
            
            using (SqlConnection connection = new SqlConnection(strConnString))
            {
                using (SqlCommand command = new SqlCommand("SELECT BarangaySelected FROM BarangayClearancess WHERE Status='Approved' ORDER BY BarangaySelected ASC", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        Droppupose.DataSource = dataSet.Tables[0];
                        Droppupose.DataTextField = "BarangaySelected";
                        Droppupose.DataBind();

                        Droppupose.Items.Insert(0, new ListItem("Select", "1"));
                        Droppupose.Items.Insert(Droppupose.Items.Count, new ListItem("Others", "0")); // Set the value of "Others" to 0 for now

                        Droppupose.SelectedIndex = 0;
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
                txtmobilenumber.Text = dt.Rows[0]["tbl_mobilenumber"].ToString();
                txtemail.Text = dt.Rows[0]["tbl_email"].ToString();
                txtaddress.Text = dt.Rows[0]["tbl_address"].ToString() + " " + dt.Rows[0]["defaultaddress"].ToString();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        private void LOADBarangayResidentInformation()
        {
            conss.Open();
            SqlCommand cmdss = conss.CreateCommand();
            cmdss.CommandType = CommandType.Text;
            cmdss.CommandText = "SELECT COUNT(*) FROM BarangayClearanceInfomation";
            int count = (int)cmdss.ExecuteScalar();
            conss.Close();

            string datePart = DateTime.Today.ToString("MMddyyyy");
            string sequenceNumber = (count + 1).ToString("D1");

            txtcontrolnumber.Text = "Clearanceno" + datePart + "-" + sequenceNumber;

        }

        protected void Bntcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResidentDashboard.aspx", false);
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx", false);
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileSettingsResident.aspx", false);
        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResidentChangePassword.aspx", false);
        }

        SqlConnection respones = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand nes;
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string fileName = FileUpload1.FileName;
            string fileExtension = Path.GetExtension(fileName);

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
            {
                FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "BarangayCeficationInformatio/" + FileUpload1.FileName);
                FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "ResidentImageprofile/" + FileUpload1.FileName);

                respones.Open();
                nes = new SqlCommand(@"UPDATE tbl_createaccount SET @tbl_residentimage=@tbl_residentimage WHERE tbl_username = '" + Session["user"].ToString() + "' ", respones);
                nes.Parameters.AddWithValue("@tbl_residentimage", fileName);
                nes.Connection = respones;
                nes.ExecuteNonQuery();
                respones.Close();

                if (btnAddPurpose.Text == "View options")
                {
                    Droppupose.SelectedValue = "12";
                }

                cmd = new SqlCommand(@"Insert Into BarangayClearanceInfomation (fullname,email,mobilenumber,address,purpose,barangaycefication,barangayControlnumber,datepickup,ResidentImage,Addotherpurposes) Values (@fullname,@email,@mobilenumber,@address,@purpose,@barangaycefication,@barangayControlnumber,@datepickup,@ResidentImage,@Addotherpurposes)");
                cmd.Parameters.AddWithValue("@fullname", txtfullname.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@mobilenumber", txtmobilenumber.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@purpose", Droppupose.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@datepickup", lbldatemenow.Text);
                cmd.Parameters.AddWithValue("@barangaycefication", lblBarangayClearance.Text);
                cmd.Parameters.AddWithValue("@barangayControlnumber", txtcontrolnumber.Text);
                cmd.Parameters.AddWithValue("@ResidentImage", fileName);
                cmd.Parameters.AddWithValue("@Addotherpurposes", txtOtherOption.Text);
              
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();

                // email send after to request documnets 
                StringBuilder sb = new StringBuilder();
                sb.Append("<div style='font-size: 18px;'>");
                sb.Append("Hi, " + txtfullname.Text + "<br/>");
                sb.Append("Within 24 to 48 hours, your barangay clearance document is being processed in order to examine your request. <br/>");
                sb.Append("Details about the document you requested are provided. <br/>");
                sb.Append("Control no: " + txtcontrolnumber.Text + "<br/>");
                sb.Append("Name: " + txtfullname.Text + "<br/>");
                sb.Append("Address: " + txtaddress.Text + "<br/>");
                sb.Append("Email: " + txtemail.Text + "<br/>");
                sb.Append("Date Request Document: " + lbldate.Text + "<br/>");
                sb.Append("</div>");


                MailMessage message = new System.Net.Mail.MailMessage("sbmabolo522@gmail.com", txtemail.Text.Trim(), "Barangay Clearance Document Process", sb.ToString());

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;

                smtp.Credentials = new System.Net.NetworkCredential("sbmabolo522@gmail.com", "uivsblcztjuwxtlx");

                smtp.EnableSsl = true;
                message.IsBodyHtml = true;
                smtp.Send(message);

               
                Session["BarangayClearance"] = txtfullname.Text;
                //To success to nofications
                string redirectScript = $"swal('Hi {txtfullname.Text}, your request is currently being processed. Please wait for an email message.', '', 'success').then(function() {{ window.location = 'opticalreceipt.aspx'; }});";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);
              
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                               "swal('Jpeg or Png be allowed.','','error')", true);
            }


        }

        protected void linkdeactivateaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmpassworddeactivateaccount.aspx");
        }

        protected void btnAddPurpose_Click(object sender, EventArgs e)
        {
            if(btnAddPurpose.Text == "Add other purposes")
            {
                Droppupose.SelectedItem.Value = "12";
                Session["testsssssa"] = "12";
                divpurpose.Visible = false;
                divaddpurpose.Visible = true;
                btnAddPurpose.Text = "View options";
            }
            else
            {
                Session["testsssssa"] = Droppupose.SelectedItem.Value;
                divpurpose.Visible = true;
                divaddpurpose.Visible = false;
                btnAddPurpose.Text = "other";
            }
            
        }

        protected void Droppupose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Droppupose.SelectedValue == "1") // Assuming "0" is the value for "Others" option
            {
                divbuttonvissible.Visible = true; // Show the button
            }
            else
            {
                divbuttonvissible.Visible = false; // Hide the button
            }
        }
    }
}