using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class index : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadBarangayofficals();
        }

        private void LoadBarangayofficals()
        {
            con.Open();
            cmd = new SqlCommand("SELECT * FROM BarangayOfficalInformation WHERE Status='Approved' ORDER BY tbl_address ASC");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            rptbarangayofficals.DataSource = dt;
            rptbarangayofficals.DataBind();
            con.Close();
        }
    }
}