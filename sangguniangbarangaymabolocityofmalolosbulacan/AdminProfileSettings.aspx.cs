using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;
using System.Data;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class AdminProfileSettings : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getUserPersonalDetails();
            }
        }

        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from BarangayOfficalInformation where tbl_Username='" + Session["admin"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                txtfullname.Text = dt.Rows[0]["tbl_Fullname"].ToString();
                txtmobilenumber.Text = dt.Rows[0]["tbl_Contactnumber"].ToString();
                txtemail.Text = dt.Rows[0]["tbl_Email"].ToString();
                txtaddress.Text = dt.Rows[0]["tbl_address"].ToString();
                txtbirthday.Text = dt.Rows[0]["tbl_birthday"].ToString();
                DropDownList1.Text = dt.Rows[0]["tbl_Gender"].ToString();
                txtposition.Text = dt.Rows[0]["tbl_BarangayOfficalPosition"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        protected void Bntcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admindashboard.aspx");
        }

        protected void btnupdateinformation_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update BarangayOfficalInformation set tbl_Fullname=@tbl_Fullname, tbl_address=@tbl_address, tbl_birthday=@tbl_birthday, tbl_Gender=@tbl_Gender WHERE tbl_Username='" + Session["admin"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@tbl_Fullname", txtfullname.Text.Trim());
                cmd.Parameters.AddWithValue("@tbl_address", txtaddress.Text.Trim());
                cmd.Parameters.AddWithValue("@tbl_birthday", txtbirthday.Text.Trim());
                cmd.Parameters.AddWithValue("@tbl_Gender", DropDownList1.SelectedItem.Value);


                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getUserPersonalDetails();
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}