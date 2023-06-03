using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class ReadytopicupBusinessClearance : System.Web.UI.Page
    {
        SqlCommand com;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            if (!IsPostBack)
            {
                SqlConnection consssss = new SqlConnection(cs);
                string query = "select * from BarangayBusinessClearance Where Status='Ready For Pickup' ORDER BY datepickup DESC";
                SqlCommand cms = new SqlCommand(query, consssss);
                consssss.Open();
                rptreadypickup.DataSource = cms.ExecuteReader();
                rptreadypickup.DataBind();
                consssss.Close();
            }

            if (Session["admin"] != null)
            {
                lblfullname.Text = Session["admin"].ToString();

            }
            else
            {
                Response.Redirect("BarangayOfficalLogin.aspx");
            }

            if (this.Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "select * from BarangayOfficalInformation where tbl_Email='" + Session["admin"] + "'";
            com = new SqlCommand(str, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            lblfullname.Text = ds.Tables[0].Rows[0]["tbl_Fullname"].ToString();
            lblsessionlogin.Text = ds.Tables[0].Rows[0]["tbl_Email"].ToString();
            lblbarangayofficals.Text = ds.Tables[0].Rows[0]["tbl_BarangayOfficalPosition"].ToString();
            lblfullnames.Text = ds.Tables[0].Rows[0]["tbl_Fullname"].ToString();
        }




        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }

        protected void Linklogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("BarangayOfficalLogin.aspx");
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string querys = "SELECT * FROM BarangayBusinessClearance WHERE (Status='Ready For Pickup' OR operatormanager LIKE '%" + txtSearch.Text + "%' OR datepickup LIKE '%" + txtSearch.Text + "%') AND Status != 'Pending' AND Status != 'Pending'";

            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptreadypickup.DataSource = ds;
            rptreadypickup.DataBind();
            con.Close();

        }
        string cs = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            string querys = "SELECT * FROM BarangayBusinessClearance WHERE (Status='Ready For Pickup' OR operatormanager LIKE '%" + txtSearch.Text + "%' OR datepickup LIKE '%" + txtSearch.Text + "%') AND Status != 'Pending' AND Status != 'Pending'";

            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptreadypickup.DataSource = ds;
            rptreadypickup.DataBind();
            con.Close();

        }

        protected void lnkreadyforpicup_Click(object sender, EventArgs e)
        {
            LinkButton lnkreadyforpicup = (LinkButton)sender;
            RepeaterItem repeaterItem = (RepeaterItem)lnkreadyforpicup.NamingContainer;

            // Get the ID of the record from the repeater item
            Label lblid = (Label)repeaterItem.FindControl("lblid");
            int id = Convert.ToInt32(lblid.Text);

            using (SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString))
            {
                cons.Open();
                SqlCommand cmd = new SqlCommand("UPDATE BarangayBusinessClearance SET Status = 'Approved/ClaimDocuments' , datepickup=@datepickup WHERE ID = @ID", cons);
                cmd.Parameters.AddWithValue("@datepickup", lbldates.Text);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }

            // Rebind the repeater to reflect the updated status
            rptreadypickup.DataBind();

        }

    }
}