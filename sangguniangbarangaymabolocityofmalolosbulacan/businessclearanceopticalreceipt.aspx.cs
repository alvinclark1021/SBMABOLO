using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System.Net.Mail;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class businessclearanceopticalreceipt : System.Web.UI.Page
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
            string IpassAstringfrompage7 = Convert.ToString(Session["Businesscaterogy"]);
            string IpassAstringfrompage1 = Convert.ToString(Session["testss"]);
            string IpassAstringfrompage2 = Convert.ToString(Session["test"]);
            string IpassAstringfrompage3 = Convert.ToString(Session["testsss"]);
            string IpassAstringfrompage4 = Convert.ToString(Session["testssssss"]);
            string IpassAstringfrompage5 = Convert.ToString(Session["testsssss"]);
            string IpassAstringfrompage6 = Convert.ToString(Session["tests"]);
            string IpassAstringfrompage8 = Convert.ToString(Session["123"]);


            lblbusinessname.Text = IpassAstringfrompage6;
            lbldatemenow.Text = IpassAstringfrompage5;
            lblpurposes.Text = IpassAstringfrompage8;
            lbltxtcontrolnumber.Text = IpassAstringfrompage4;
            lblcontactnumber.Text = IpassAstringfrompage1;
            lbladdresss.Text = IpassAstringfrompage3;
            lblfullnames.Text = IpassAstringfrompage2;
            lblbusinesscategory.Text = IpassAstringfrompage7;


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

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();

            Response.Redirect("Login.aspx");
        }

        protected void btnsavepdf_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            Document document = new Document();
            MemoryStream ms = new MemoryStream();

            // Create a PDF writer to write the PDF document to a memory stream
            PdfWriter.GetInstance(document, ms);

            // Open the PDF document
            document.Open();

            // Create a table with 2 columns
            PdfPTable table = new PdfPTable(2);

            // Add content to the table
            table.AddCell("Business Clearance No:");
            table.AddCell(lbltxtcontrolnumber.Text);

            table.AddCell("Owner Name:");
            table.AddCell(lblfullnames.Text);

            table.AddCell("Mobile Number:");
            table.AddCell(lbladdresss.Text);

            table.AddCell("Purpose:");
            table.AddCell(lblpurposes.Text);

            table.AddCell("Business Category:");
            table.AddCell(lblbusinesscategory.Text);

            table.AddCell("Business Name:");
            table.AddCell(lblbusinessname.Text);

            table.AddCell("Business Address:");
            table.AddCell(lbladdresss.Text);

            table.AddCell("Date To Request Document:");
            table.AddCell(lbldatemenow.Text);

            // Add the table to the document
            document.Add(table);

            // Close the PDF document
            document.Close();

            // Send the PDF document to the user's browser for download
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=BusinessClearance.pdf");
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            // Show a message popup after saving the PDF
            string script = "alert('PDF file saved successfully!');";
            ClientScript.RegisterStartupScript(this.GetType(), "SavedPopup", script, true);
        }

        
    }
}