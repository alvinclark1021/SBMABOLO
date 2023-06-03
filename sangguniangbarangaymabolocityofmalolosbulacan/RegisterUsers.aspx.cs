using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace sangguniangbarangaymabolocityofmalolosbulacan
{
    public partial class RegisterUsers : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Databaseko"].ConnectionString);
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtndel = sender as LinkButton;
            GridViewRow gdrow = lnkbtndel.NamingContainer as GridViewRow;
            int fileid = Convert.ToInt32(gvdetails.DataKeys[gdrow.RowIndex].Value.ToString());

            
                using (SqlCommand cmd = new SqlCommand("", con))
                {
                    cmd.CommandText = "delete  from tbl_createaccount where ID=@ID";
                    cmd.Parameters.AddWithValue("@ID", fileid);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dr);
                    gvdetails.DataSource = dataTable;
                    gvdetails.DataBind();
                    Response.Write("<script>alert('Record successfully delete')</script>");
                    BindUserDetails();
                }
        }

        protected void BindUserDetails()
        {
            SqlCommand cmd = new SqlCommand(("select * from tbl_createaccount"), con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = ds;
                gvdetails.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gvdetails.DataSource = ds;
                gvdetails.DataBind();
                int columncount = gvdetails.Rows[0].Cells.Count;
                gvdetails.Rows[0].Cells.Clear();
                gvdetails.Rows[0].Cells.Add(new TableCell());
                gvdetails.Rows[0].Cells[0].ColumnSpan = columncount;
                gvdetails.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
    }
}
