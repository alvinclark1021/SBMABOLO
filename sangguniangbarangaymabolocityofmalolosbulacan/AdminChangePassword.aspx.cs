using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    
    public partial class AdminChangePassword : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str = null;
        SqlCommand com;
        byte up;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "select * from BarangayOfficalInformation ";
            com = new SqlCommand(str, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                if (txtcurrentpassword.Text == reader["tbl_Password"].ToString())
                {
                    up = 1;
                }
            }
            reader.Close();
            con.Close();
            if (up == 1)
            {
                con.Open();
                str = "update BarangayOfficalInformation set tbl_Password=@tbl_Password where tbl_Username='" + Session["admin"].ToString() + "'";
                com = new SqlCommand(str, con);
                com.Parameters.Add(new SqlParameter("@tbl_Password", SqlDbType.VarChar, 50));
                com.Parameters["@tbl_Password"].Value = txtnewpassword.Text;
                com.ExecuteNonQuery();
                con.Close();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                       "swal('Password changed Successfully','','success')", true);

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                       "swal('Password not match','','warning')", true);
            }
        }
    }
}