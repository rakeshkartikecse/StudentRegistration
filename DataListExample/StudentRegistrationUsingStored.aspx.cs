using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataListExample
{
    public partial class StudentRegistrationUsingStored : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentDb"].ConnectionString);
        SqlDataAdapter dtr;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        string query1 = "StudentRegister";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gbind();
            }
        }

        private void gbind()
        {
            string query="select * from StudentDetails1";
            dtr = new SqlDataAdapter(query, con);
            dtr.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
                
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gbind();
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gbind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gbind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            con.Open();
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            HiddenField1.Value = "Delete";
            cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Action", HiddenField1.Value.ToString());
            cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
            showOnSuccess.Visible = true;
            showOnSuccess.Text = "Data Deleted Successfully";
            con.Close();
            gbind();
            


        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id=int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            HiddenField1.Value = "Update";
            con.Open();
            cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", HiddenField1.Value.ToString());
            /*cmd.Parameters.AddWithValue("@Name", ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString());
            cmd.Parameters.AddWithValue("Mobile", ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString());
            cmd.Parameters.AddWithValue("Class", ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString());
            cmd.Parameters.AddWithValue("Year", ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString());*/
            cmd.Parameters.AddWithValue("ID", SqlDbType.Int).Value = id;
            name.Text = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString();
            mobile.Text = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString();
            DropDownList1.Text = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString();
            DropDownList2.Text = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString();
            cmd.Parameters.AddWithValue("@Name", name.Text);
            cmd.Parameters.AddWithValue("@Mobile", mobile.Text);
            cmd.Parameters.AddWithValue("@Class", DropDownList1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@Year", DropDownList2.SelectedValue.ToString());

            cmd.ExecuteNonQuery();
            con.Close();
            showOnSuccess.Visible = true;
            showOnSuccess.Text = "Sucessfully updatedd!";
            GridView1.EditIndex = -1;
            gbind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            //string query1 = "StudentRegister";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.StoredProcedure;
            HiddenField1.Visible = true;
            HiddenField1.Value = "Insert";
            //HiddenField1.Value =;
            cmd.Parameters.AddWithValue("@Action", HiddenField1.Value.ToString());
            cmd.Parameters.AddWithValue("@Name", name.Text.ToString());
            cmd.Parameters.AddWithValue("@Mobile", mobile.Text.ToString());
            cmd.Parameters.AddWithValue("@Class", DropDownList1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@Year", DropDownList2.SelectedValue.ToString());
            cmd.ExecuteNonQuery();
            showOnSuccess.Visible = true;
            showOnSuccess.Text = "Succesfully saved";
            gbind();
            con.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            name.Text = "";
            mobile.Text = "";
            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();

        }

        
       
    }
}