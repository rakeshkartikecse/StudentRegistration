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
            try
            {
               
               
                GridView1.EditIndex = -1;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                
                gbind();
            }
            

        }

        

        

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            con.Open();
            var cmd1 = new SqlCommand("select count(*) from StudentDetails1", con);
            int i = (int)cmd1.ExecuteScalar();
            //check weather database is empty or not
            if (i > 20)
            {

                HiddenField1.Value = "Delete";
                cmd = new SqlCommand(query1, con);


                cmd.CommandType = CommandType.StoredProcedure;
                int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
                cmd.Parameters.AddWithValue("@Action", HiddenField1.Value.ToString());
                cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
                showOnSuccess.Visible = true;
                showOnSuccess.Text = "Data Deleted Successfully";
 
            }

            else
            {
                Response.Write("You Dont have sufficient Records to delete!");
            }

            con.Close();
            gbind();
            
        }

      

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            GridView1.EditIndex = -1;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            gbind();
            con.Open();
            //string query1 = "StudentRegister";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.StoredProcedure;
            HiddenField1.Visible = true;
            //if update Button is Pressed

            //check for Empty field
           if(checkEmptyField()){
               Response.Write("Please don't allow null value");
               showOnSuccess.Visible = true;
               showOnSuccess.Text = "Please don't allow null value";
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
                    showOnSuccess.Visible = true;
                    showOnSuccess.Text = "Succesfully Updated";
                  
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
                    showOnSuccess.Visible = true;
                    showOnSuccess.Text = "Username and mobile number already Exists";
                    
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    clearDataFromForm();
                   
                    con.Close();
                }
            }
           GridView1.EditIndex = -1;
           gbind();

        }

        private bool checkEmptyField()
        {
            if ((name.Text.Trim().ToString().Equals("")) || (mobile.Text.Trim().ToString().Equals("")) || (DropDownList1.SelectedValue.Trim().ToString().Equals("-----")))
            {
               
              
                return true;
            }
            return false;
        }

        private bool checkDuplicates(string p1, string p2)
        {
            //throw new NotImplementedException();
            string Name = p1;
            string Mobile = p2;
            var cmd = new SqlCommand("select count(ID) from StudentDetails1 where Name=@Name or Mobile=@Mobile", con);
            cmd.Parameters.AddWithValue("@Name", p1.ToString());
            cmd.Parameters.AddWithValue("@Mobile", p2.ToString());
           
            int i = (int)cmd.ExecuteScalar();
           
            return i > 0;
        }

        private void clearDataFromForm()
        {
            name.Text = "";
            mobile.Text = "";
            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();
            gbind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           // e.ToString();
            Response.Write(e.ToString());
            name.Text = "";
            mobile.Text = "";
            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();
            Button1.Text = "Submit".Trim();


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Edit")
            {
                Response.Write("Entered into Edit Row Command");
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
           
        }

    
    }
}