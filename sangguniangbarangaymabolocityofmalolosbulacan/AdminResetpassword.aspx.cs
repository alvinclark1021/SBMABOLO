using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class AdminForgetPassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string email = Session["adminemail"].ToString();
            }

            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                       "swal('this page has loading please wait  ','','info')", true);
            }

        }

        private Boolean passswordchanged()
        {
            Boolean emailregistedalready = false;
            String myquery = "Select * from BarangayOfficalInformation where tbl_Password='" + txtnewpassword.Text + "'";
            cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            DataSet dss = new DataSet();
            ds.Fill(dss);
            if (dss.Tables[0].Rows.Count > 0)
            {
                emailregistedalready = true;
            }
            con.Close();

            return emailregistedalready;
        }

        protected void Bbtsubitresetpassword_Click(object sender, EventArgs e)
        {

            if(passswordchanged()==true)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Password Already Changed','','info')", true);
            }
            else
            {
                string email = Session["adminemail"].ToString();
                SqlCommand cmd = new SqlCommand("Update BarangayOfficalInformation set tbl_Password = '" + txtnewpassword.Text + "'where tbl_Email= '" + email + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                           "swal('your password change successfully ','','success')", true);
                txtnewpassword.Text = "";
                txtconfirmpassword.Text = "";
                cmd.Dispose();
                Response.Redirect("BarangayOfficalLogin.aspx");
            }
            
        }
    }
}