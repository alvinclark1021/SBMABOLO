using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class Addpurposes : System.Web.UI.Page
    {
        SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdss;
        string strConnString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string str;
        SqlCommand com;
        SqlCommand cmd;
        string strcon = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        
        byte up;
        SqlConnection conssx = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdssx;
       
        SqlDataAdapter da;
        SqlCommand alvin;
        SqlDataAdapter alvins;
        DataTable dt;
        DataTable gta;
        string connectionString = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        string con = ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString;
        SqlConnection consa = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdsa;
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmds;
        protected void Page_Load(object sender, EventArgs e)
        {
            Loadgoodmornal();
            LoadBarangayBusiness();
            Loadexcavation();
            LoadOP();
            LoadBI();
            Loadfencing();
            LoadBarangayClearance();
            if (Session["admin"] != null)
            {
                lblfullname.Text = Session["admin"].ToString();

            }
            else
            {
                SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
                SqlCommand cmdss;
                cmdss = new SqlCommand(@"Insert Into Activity (Username,Activity,Date) Values (@Username,@Activity,@Date)");

                cmdss.Parameters.AddWithValue("@Username", lblsessionlogin.Text);
                cmdss.Parameters.AddWithValue("@Activity", lblactivity.Text);
                cmdss.Parameters.AddWithValue("@Date", lbldate.Text);

                conss.Open();
                cmdss.Connection = conss;
                cmdss.ExecuteNonQuery();
                conss.Close();
                Response.Redirect("BarangayOfficalLogin.aspx");
            }
            lbldate.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            lbldates.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
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
            lblfullnames.Text = ds.Tables[0].Rows[0]["tbl_Fullname"].ToString();
            lblfullname.Text = ds.Tables[0].Rows[0]["tbl_Fullname"].ToString();
            lblsessionlogin.Text = ds.Tables[0].Rows[0]["tbl_Email"].ToString();
            lblbarangayofficals.Text = ds.Tables[0].Rows[0]["tbl_BarangayOfficalPosition"].ToString();
        }

        private void LoadBarangayClearance()
        {
            cons.Open();
            alvin = new SqlCommand(@"SELECT * FROM BarangayClearancess WHERE Status ='Pending' ORDER BY BarangaySelected ASC", cons);
            alvins = new SqlDataAdapter(alvin);
            gta = new DataTable();
            alvins.Fill(gta);

            rptProducts.DataSource = gta;
            rptProducts.DataBind();
            cons.Close();
        }

        private void Loadexcavation()
        {
            conssxs.Open();
            cmdssxs = new SqlCommand(@"SELECT * FROM ExcavationPermit WHERE Status ='Pending' ORDER BY BarangayAddPurpose ASC", conssxs);
            nba = new SqlDataAdapter(cmdssxs);
            gtas = new DataTable();
            nba.Fill(gtas);

            Repeater4.DataSource = gtas;
            Repeater4.DataBind();
            conssxs.Close();
        }


       


        SqlConnection sd = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand si;
        DataTable das1;
        SqlDataAdapter pbs;
        private void LoadBI()
        {
            sd.Open();
            si = new SqlCommand(@"SELECT * FROM BarangayIndegency WHERE Status ='Pending' ORDER BY date ASC", sd);
            pbs = new SqlDataAdapter(si);
            das1 = new DataTable();
            pbs.Fill(das1);

            Repeater2.DataSource = das1;
            Repeater2.DataBind();
            sd.Close();
        }
        //001
        protected void Btnserachbar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
 
            string querys = "SELECT * FROM BarangayClearancess where BarangaySelected like '%" + txtSearch.Text + "%' OR date like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptProducts.DataSource = ds;
            rptProducts.DataBind();
            con.Close();
        }
        //000
        protected void Linklogout_Click(object sender, EventArgs e)
        {
            SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
            SqlCommand cmdss;
            cmdss = new SqlCommand(@"Insert Into Activity (Username,Activity,Date) Values (@Username,@Activity,@Date)");

            cmdss.Parameters.AddWithValue("@Username", lblsessionlogin.Text);
            cmdss.Parameters.AddWithValue("@Activity", lblactivity.Text);
            cmdss.Parameters.AddWithValue("@Date", lbldate.Text);

            conss.Open();
            cmdss.Connection = conss;
            cmdss.ExecuteNonQuery();
            conss.Close();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("BarangayOfficalLogin.aspx");
        }


        private void LoadOP()
        {
            conssxs.Open();
            cmdssxs = new SqlCommand(@"SELECT * FROM BarangayOccupanypermit WHERE Status ='Pending' ORDER BY date ASC", conssxs);
            nba = new SqlDataAdapter(cmdssxs);
            gtas = new DataTable();
            nba.Fill(gtas);

            Repeater3.DataSource = gtas;
            Repeater3.DataBind();
            conssxs.Close();
        }

        protected void Linkchangepasswprd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminChangepassword.aspx");
        }

        SqlConnection conssss = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdssss;
        //001
        protected void lnkapproved_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblid") as Label).Text;

            conssss.Open();
            cmdssss = new SqlCommand(@"UPDATE BarangayClearancess SET Status='Approved' WHERE ID = '" + Session["ID"].ToString() + "'", conssss);
            cmdssss.ExecuteNonQuery();
            conssss.Close();
            LoadBarangayClearance();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Your Add Purposes Success.','','success')", true);
            LoadBarangayClearance();
        }
       
        //001
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
            
            string querys = "SELECT * FROM BarangayClearancess where BarangaySelected like '%" + txtSearch.Text + "%' OR date like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            rptProducts.DataSource = ds;
            rptProducts.DataBind();
            con.Close();
        }

        //002
        SqlConnection conssxs = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmdssxs;
        DataTable gtas;
        SqlDataAdapter nba;
        
       
        //001
        SqlConnection d = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand es;
        protected void Lnkdeletepurpose_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblid") as Label).Text;

            d.Open();
            es = new SqlCommand(@"Delete BarangayClearancess WHERE ID = '" + Session["ID"].ToString() + "'", d);
            es.ExecuteNonQuery();
            d.Close();
            LoadBarangayClearance();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your purpose are deleted.','','error')", true);
        }

        

        protected void lnkapproved2_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblidsa") as Label).Text;

            conssss.Open();
            cmdssss = new SqlCommand(@"UPDATE BarangayIndegency SET Status='Approved' WHERE ID = '" + Session["ID"].ToString() + "'", conssss);
            cmdssss.ExecuteNonQuery();
            conssss.Close();
            LoadBI();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your Add Purposes Success.','','success')", true);
        }

        protected void lnkdisapproved2_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblidsa") as Label).Text;

            conssss.Open();
            cmdssss = new SqlCommand(@"UPDATE BarangayIndegency SET Status='Disapproved' WHERE ID = '" + Session["ID"].ToString() + "'", conssss);
            cmdssss.ExecuteNonQuery();
            conssss.Close();
            LoadBI();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your purposes are disapprove list.','','warning')", true);
        }

        protected void Lnkdeletepurpose2_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblidsa") as Label).Text;
            d.Open();
            es = new SqlCommand(@"Delete BarangayIndegency WHERE ID = '" + Session["ID"].ToString() + "'", d);
            es.ExecuteNonQuery();
            d.Close();
            LoadBI();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your purpose are deleted.','','error')", true);
        }

        protected void btnbarangayindency_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM BarangayIndegency where Purposenamebarangayind like '%" + txtSearch.Text + "%' OR date like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            Repeater2.DataSource = ds;
            Repeater2.DataBind();
            con.Close();
        }

        protected void txtbarangayindency_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM BarangayIndegency where Purposenamebarangayind like '%" + txtSearch.Text + "%' OR date like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            Repeater2.DataSource = ds;
            Repeater2.DataBind();
            con.Close();
        }


        //occunapany
        protected void BntBarangayOccupanyPermit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM BarangayOccupanypermit where BarangayOccupanyPermits like '%" + txtSearch.Text + "%' OR date like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            Repeater3.DataSource = ds;
            Repeater3.DataBind();
            con.Close();
        }
        
        protected void txtBarangayOccupanyPermit_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM BarangayOccupanypermit where BarangayOccupanyPermits like '%" + txtSearch.Text + "%' OR date like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            Repeater3.DataSource = ds;
            Repeater3.DataBind();
            con.Close();
        }
        SqlConnection wq = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand qw;
        protected void lnkapproved3_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblidfer") as Label).Text;

            wq.Open();
            qw = new SqlCommand(@"UPDATE BarangayOccupanypermit SET Status='Approved' WHERE ID = '" + Session["ID"].ToString() + "'", wq);
            qw.ExecuteNonQuery();
            wq.Close();
            LoadOP();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your Add Purposes Success.','','success')", true);
        }

        SqlConnection ki = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand li;
        protected void lnkdisapproved3_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblidfer") as Label).Text;

            ki.Open();
            li = new SqlCommand(@"UPDATE BarangayOccupanypermit SET Status='Disapproved' WHERE ID = '" + Session["ID"].ToString() + "'", ki);
            li.ExecuteNonQuery();
            ki.Close();
            LoadOP();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your purposes are disapprove list.','','warning')", true);
        }

        SqlConnection ta = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand hi;
        protected void Lnkdeletepurpose3_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblidfer") as Label).Text;
            ta.Open();
            hi = new SqlCommand(@"Delete BarangayOccupanypermit WHERE ID = '" + Session["ID"].ToString() + "'", ta);
            hi.ExecuteNonQuery();
            ta.Close();
            LoadOP();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your purpose are deleted.','','error')", true);
        }

        //exa
        protected void txtexcavation_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM ExcavationPermit where BarangayAddPurpose like '%" + txtSearch.Text + "%' OR Date like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            Repeater4.DataSource = ds;
            Repeater4.DataBind();
            con.Close();
        }

        protected void Bntexcavation_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM ExcavationPermit where BarangayAddPurpose like '%" + txtSearch.Text + "%' OR Date like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            Repeater4.DataSource = ds;
            Repeater4.DataBind();
            con.Close();
        }

        protected void lnkapproved4_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblexcavationpermit") as Label).Text;

            wq.Open();
            qw = new SqlCommand(@"UPDATE ExcavationPermit SET Status='Approved' WHERE ID = '" + Session["ID"].ToString() + "'", wq);
            qw.ExecuteNonQuery();
            wq.Close();
            Loadexcavation();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your Add Purposes Success.','','success')", true);
        }

        

        protected void Lnkdeletepurpose4_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblexcavationpermit") as Label).Text;
            ta.Open();
            hi = new SqlCommand(@"Delete ExcavationPermit WHERE ID = '" + Session["ID"].ToString() + "'", ta);
            hi.ExecuteNonQuery();
            ta.Close();
            Loadexcavation();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your purpose are deleted.','','error')", true);
        }

        
        //business Clearance
        private void LoadBarangayBusiness()
        {
            conssxs.Open();
            cmdssxs = new SqlCommand(@"SELECT * FROM BarangayBusinessClerance WHERE Status ='Pending' ORDER BY Date ASC", conssxs);
            nba = new SqlDataAdapter(cmdssxs);
            gtas = new DataTable();
            nba.Fill(gtas);

            businessclearance.DataSource = gtas;
            businessclearance.DataBind();
            conssxs.Close();
        }

        protected void lnkapproved5_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblid") as Label).Text;

            conssss.Open();
            cmdssss = new SqlCommand(@"UPDATE BarangayClearancess SET Status='Approved' WHERE ID = '" + Session["ID"].ToString() + "'", conssss);
            cmdssss.ExecuteNonQuery();
            conssss.Close();
            LoadBarangayClearance();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your Add Purposes Success.','','success')", true);
        }

        protected void Lnkdeletepurpose5_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblid") as Label).Text;
            d.Open();
            es = new SqlCommand(@"Delete BarangayClearancess WHERE ID = '" + Session["ID"].ToString() + "'", d);
            es.ExecuteNonQuery();
            d.Close();
            LoadBarangayClearance();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your purpose are deleted.','','error')", true);
        }

        protected void txtserachbusiness_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM BarangayBusinessClerance where BarangayBuisnessname like '%" + txtSearch.Text + "%' OR Date like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            businessclearance.DataSource = ds;
            businessclearance.DataBind();
            con.Close();
        }

        protected void Btnbusiness_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM BarangayBusinessClerance where BarangayBuisnessname like '%" + txtSearch.Text + "%' OR Date like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            businessclearance.DataSource = ds;
            businessclearance.DataBind();
            con.Close();
        }

        protected void lnkapproved12_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("rptProducts") as Label).Text;

            conssss.Open();
            cmdssss = new SqlCommand(@"UPDATE BarangayClearancess SET Status='Approved' WHERE ID = '" + Session["ID"].ToString() + "'", conssss);
            cmdssss.ExecuteNonQuery();
            conssss.Close();
            LoadBarangayClearance();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your Add Purposes Success.','','success')", true);
        }

        protected void Lnkdeletepurpose12_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("rptProducts") as Label).Text;
            d.Open();
            es = new SqlCommand(@"Delete BarangayClearancess WHERE ID = '" + Session["ID"].ToString() + "'", d);
            es.ExecuteNonQuery();
            d.Close();
            LoadBarangayClearance();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your purpose are deleted.','','error')", true);
        }

        private void Loadfencing()
        {
            conssxs.Open();
            cmdssxs = new SqlCommand(@"SELECT * FROM FencingPermit WHERE Status ='Pending' ORDER BY Namess ASC", conssxs);
            nba = new SqlDataAdapter(cmdssxs);
            gtas = new DataTable();
            nba.Fill(gtas);

            Repeater1.DataSource = gtas;
            Repeater1.DataBind();
            conssxs.Close();
        }

        protected void lnkapproved41_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblfecing") as Label).Text;

            conssss.Open();
            cmdssss = new SqlCommand(@"UPDATE FencingPermit SET Status='Approved' WHERE ID = '" + Session["ID"].ToString() + "'", conssss);
            cmdssss.ExecuteNonQuery();
            conssss.Close();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your Add Purposes Success.','','success')", true);
            Loadfencing();
        }

        protected void Lnkdeletepurpose41_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblfecing") as Label).Text;
            d.Open();
            es = new SqlCommand(@"Delete FencingPermit WHERE ID = '" + Session["ID"].ToString() + "'", d);
            es.ExecuteNonQuery();
            d.Close();
            Loadfencing();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your purpose are deleted.','','error')", true);
        }


        private void Loadgoodmornal()
        {
            conssxs.Open();
            cmdssxs = new SqlCommand(@"SELECT * FROM GoodMornal WHERE Status ='Pending' ORDER BY Name ASC", conssxs);
            nba = new SqlDataAdapter(cmdssxs);
            gtas = new DataTable();
            nba.Fill(gtas);

            Repeater6.DataSource = gtas;
            Repeater6.DataBind();
            conssxs.Close();
        }


        protected void txtgoodmornal_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM GoodMornal where Name like '%" + txtSearch.Text + "%' OR Date like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            Repeater6.DataSource = ds;
            Repeater6.DataBind();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);

            string querys = "SELECT * FROM GoodMornal where Name like '%" + txtSearch.Text + "%' OR Date like '%" + txtSearch.Text + "%' ";
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(querys, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            Repeater6.DataSource = ds;
            Repeater6.DataBind();
            con.Close();
        }

        protected void lnkapproved411_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblgoodmornal") as Label).Text;

            conssss.Open();
            cmdssss = new SqlCommand(@"UPDATE GoodMornal SET Status='Approved' WHERE ID = '" + Session["ID"].ToString() + "'", conssss);
            cmdssss.ExecuteNonQuery();
            conssss.Close();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your Add Purposes Success.','','success')", true);
            Loadgoodmornal();
        }

        protected void Lnkdeletepurpose411_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Session["ID"] = (item.FindControl("lblgoodmornal") as Label).Text;
            d.Open();
            es = new SqlCommand(@"Delete GoodMornal WHERE ID = '" + Session["ID"].ToString() + "'", d);
            es.ExecuteNonQuery();
            d.Close();
            Loadgoodmornal();
            Session["ID"] = null;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Your purpose are deleted.','','error')", true);
        }

        protected void linkprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("BarangayAdminProfilesettings.aspx");
        }
    }
}