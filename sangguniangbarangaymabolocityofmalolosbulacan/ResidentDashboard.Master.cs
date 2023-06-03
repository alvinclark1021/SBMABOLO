using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Data.OleDb;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;


namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class ResidentDashboard : System.Web.UI.MasterPage
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Linkbychangepassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResidentChangePassword.aspx");
        }

        protected void Linkaccountsettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileSettingsResident.aspx");
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
   
            Response.Redirect("Login.aspx");
        }

        protected void linklogoutako_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();

            Response.Redirect("Login.aspx");
        }

        protected void linkdeactivateaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmpassworddeactivateaccount.aspx");
        }
    }
}