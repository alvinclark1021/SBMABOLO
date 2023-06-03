using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.tool.xml;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class opticalreceipt : System.Web.UI.Page
    {
        SqlConnection cona = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmda;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        string str;
        SqlCommand com;
        protected void Page_Load(object sender, EventArgs e)
        {

            barangayclearancedatabase();
            

            lbldatemenow.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
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

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResidentChangePassword.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileSettingsResident.aspx");
        }


        void barangayclearancedatabase()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from BarangayClearanceInfomation where fullname='" + Session["BarangayClearance"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                lblemail.Text = dt.Rows[0]["email"].ToString();
                lbldatemenow.Text = dt.Rows[0]["datepickup"].ToString();
                lblpurposes.Text = dt.Rows[0]["purpose"].ToString();
                lbltxtcontrolnumber.Text = dt.Rows[0]["barangayControlnumber"].ToString();
                lblfullnames.Text = dt.Rows[0]["fullname"].ToString();
                lblcontactnumber.Text = dt.Rows[0]["mobilenumber"].ToString();
                lbladdresss.Text = dt.Rows[0]["address"].ToString() ;

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

       

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            Document document = new Document();
            MemoryStream ms = new MemoryStream();

            // Create a PDF writer to write the PDF document to a memory stream
            PdfWriter.GetInstance(document, ms);

            // Open the PDF document
            document.Open();
            
            // Create a table with 2 columns
            PdfPTable table = new PdfPTable(2);

            // Add content to the table
            table.AddCell("ClearanceNo:");
            table.AddCell(lbltxtcontrolnumber.Text);

            table.AddCell("Name:");
            table.AddCell(lblfullnames.Text);

            table.AddCell("Email:");
            table.AddCell(lblemail.Text);

            table.AddCell("Address:");
            table.AddCell(lbladdresss.Text);

            table.AddCell("Purposes:");
            table.AddCell(lblpurposes.Text);

            table.AddCell("Date To Request Document:");
            table.AddCell(lbldatemenow.Text);

            // Add the table to the document
            document.Add(table);

            // Close the PDF document
            document.Close();

            // Send the PDF document to the user's browser for download
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=BarangayClearance.pdf");
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            // Redirect to another page
            string redirectUrl = "ResidentDashboard.aspx";
            string redirectScript = $"swal('Your Claim Stub has been successfully saved!', '', 'success').then(function() {{ window.location = '{redirectUrl}'; }});";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", redirectScript, true);

        }


    }
}