using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;

namespace DataListExample
{
    public partial class StudentReg : System.Web.UI.Page
    {
         //string cs1 = ;
          SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StudentDb"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!IsPostBack)
            {
                gvbind();
            }
        }

        public void gvbind()
        {
          

            
            SqlCommand cmd = new SqlCommand("Select * From StudentDetails1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSourceID = null;

            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
               GridView1.DataBind();
            }
            else
            {
                //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                //GridView1.DataSource = ds;
                //GridView1.DataBind();
                //int columncount = GridView1.Rows[0].Cells.Count;
                //GridView1.Rows[0].Cells.Clear();
                //GridView1.Rows[0].Cells.Add(new TableCell());
                //GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                //GridView1.Rows[0].Cells[0].Text = "No Records Found";
            }
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
          
            string query1 = "insert into StudentDetails1 (Name,Mobile,Class,Year)" + "values(@name,@mobile,@class,@year)";
             SqlCommand cmd = new SqlCommand(query1,con);
             cmd.Parameters.AddWithValue("@name", name.Text);
             cmd.Parameters.AddWithValue("@mobile", mobile.Text);
             cmd.Parameters.AddWithValue("@class", DropDownList1.Text);
             cmd.Parameters.AddWithValue("@year", DropDownList2.Text);



             con.Open();
            cmd.ExecuteNonQuery();

            con.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            name.Text = "";
            mobile.Text = "";
            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

       
    }
}