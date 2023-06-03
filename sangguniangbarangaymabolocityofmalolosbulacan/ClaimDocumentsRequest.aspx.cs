using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using System.Web.Security;
using System.Text;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class ClaimDocumentsRequest : System.Web.UI.Page
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
                string query = "select * from BarangayClearanceInfomation Where Status='Ready To Pickup' ORDER BY datepickup DESC";
                SqlCommand cms = new SqlCommand(query, consssss);
                consssss.Open();
                rptreadyforpickup.DataSource = cms.ExecuteReader();
                rptreadyforpickup.DataBind();
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
            string searchText = txtSearch.Text;

            string query = "SELECT * FROM BarangayClearanceInfomation WHERE (Status='Ready To Pickup' OR fullname LIKE '%' + @SearchText + '%' OR datepickup LIKE '%' + @SearchText + '%') AND Status != 'Pending' AND Status != 'Claimed'";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SearchText", searchText);

                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                rptreadyforpickup.DataSource = ds;
                rptreadyforpickup.DataBind();
            }

        }
        string cs = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;

            string query = "SELECT * FROM BarangayClearanceInfomation WHERE (Status='Ready To Pickup' OR fullname LIKE '%' + @SearchText + '%' OR datepickup LIKE '%' + @SearchText + '%') AND Status != 'Pending' AND Status != 'Claimed'";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SearchText", searchText);

                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                rptreadyforpickup.DataSource = ds;
                rptreadyforpickup.DataBind();
            }



        }

        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmds;
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
                SqlCommand cmd = new SqlCommand("UPDATE BarangayClearanceInfomation SET Status = 'Claim Documents', datepickup=@datepickup WHERE ID = @ID", cons);
                cmd.Parameters.AddWithValue("@datepickup", lbldate.Text);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }

            // Rebind the repeater to reflect the updated status
            rptreadyforpickup.DataBind();

            
        }
    }
}