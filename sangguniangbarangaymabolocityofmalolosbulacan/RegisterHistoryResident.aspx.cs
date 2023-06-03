using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class RegisterHistoryResident : System.Web.UI.Page
    {
        string connectionString = "@Data Source=CLARKSON\\PROGRAMMER;Initial Catalog=SangguniangBarangayMaboloOnlineRequestDocuments;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * From tbl_createaccount",sqlCon);
                DataTable dttbl = new DataTable();
                sqlDa.Fill(dttbl);
                databaserecords.DataSource= dttbl;
                databaserecords.DataBind();

            }
        }

        protected void datagrid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}