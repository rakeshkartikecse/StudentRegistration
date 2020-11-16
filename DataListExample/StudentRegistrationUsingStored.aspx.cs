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
        DataTable dt;
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
            dt = new DataTable();
            dtr.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }



        //check for whether username and mobile exists already
        
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gbind();
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
           // GridView1.EditIndex = e.NewEditIndex;
            //gbind();
        }

        

        

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            con.Open();
            
            HiddenField1.Value = "Delete";
            cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.StoredProcedure;
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            cmd.Parameters.AddWithValue("@Action", HiddenField1.Value.ToString());
            cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value=id;
            cmd.ExecuteNonQuery();
            showOnSuccess.Visible = true;
            showOnSuccess.Text = "Data Deleted Successfully";

            con.Close();
            //GridView1.EditIndex = -1;

            gbind();
            
            
            
           
            


        }

      

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            GridView1.EditIndex = -1;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            //string query1 = "StudentRegister";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.StoredProcedure;
            HiddenField1.Visible = true;
            //if update Button is Pressed

            //check for Empty field
            if ((name.Text.Trim().ToString().Equals("")) && (mobile.Text.Trim().ToString().Equals("")))
            {
                Response.Write("Please don't allow null value");
            }

            else
            {
                if (Button1.Text.Trim() == "Update")
                {
                    int id2 = int.Parse((id1.Text).ToString());
                    HiddenField1.Value = "Update";
                    cmd.Parameters.AddWithValue("@Action", HiddenField1.Value.ToString());
                    cmd.Parameters.AddWithValue("@Name", name.Text.ToString());
                    cmd.Parameters.AddWithValue("@Mobile", mobile.Text.ToString());
                    cmd.Parameters.AddWithValue("@Class", DropDownList1.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Year", DropDownList2.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = id2;
                    Button1.Text = "Submit";
                    showOnSuccess.Visible = true;
                    showOnSuccess.Text = "Succesfully Updated";
                    //clearDataFromForm();

                }
                //HiddenField1.Value =;
                else
                {
                    HiddenField1.Value = "Insert";
                    cmd.Parameters.AddWithValue("@Action", HiddenField1.Value.ToString());
                    cmd.Parameters.AddWithValue("@Name", name.Text.ToString());
                    cmd.Parameters.AddWithValue("@Mobile", mobile.Text.ToString());
                    cmd.Parameters.AddWithValue("@Class", DropDownList1.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Year", DropDownList2.SelectedValue.ToString());
                    showOnSuccess.Visible = true;

                    showOnSuccess.Text = "Succesfully saved";

                }
                string p1 = name.Text.Trim().ToString();
                string p2 = mobile.Text.Trim().ToString(); ;
                //Checking for duplicates in database
                if (checkDuplicates(p1, p2))
                {
                    Response.Write("Username and mobile number already Exists");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    clearDataFromForm();
                    GridView1.EditIndex = -1;
                    gbind();
                    con.Close();
                }
            }

        }

        private bool checkDuplicates(string p1, string p2)
        {
            //throw new NotImplementedException();
            string Name = p1;
            string Mobile = p2;
            var cmd = new SqlCommand("select count(ID) from StudentDetails1 where Name=@Name or Mobile=@Mobile", con);
            cmd.Parameters.AddWithValue("@Name", p1.ToString());
            cmd.Parameters.AddWithValue("@Mobile", p2.ToString());
           // con.Open();
            int i = (int)cmd.ExecuteScalar();
            //con.Close();
            return i > 0;
        }

        private void clearDataFromForm()
        {
            name.Text = "";
            mobile.Text = "";
            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           // e.ToString();
            Response.Write(e.ToString());
            name.Text = "";
            mobile.Text = "";
            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gr = GridView1.Rows[index];
                
                string id = gr.Cells[2].Text;
                id1.Text = id;
                name.Text = gr.Cells[3].Text;
                mobile.Text = gr.Cells[4].Text;
                DropDownList1.Text = gr.Cells[5].Text;
                DropDownList2.Text = gr.Cells[6].Text;
                Button1.Text = "Update ";

               
            }
            

            gbind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                Response.Write("Can't update from here");
                gbind();

            }
            catch
            {
                Response.Write("Can't update from here");
            }
            finally
            {
                Response.Write("Can't update from here");
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gbind();
        }

        protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            GridView1.EditIndex = -1;
            gbind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }



        
       
    }
}