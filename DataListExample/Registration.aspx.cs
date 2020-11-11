using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DataListExample
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentDb"].ConnectionString);
        SqlCommand cmd;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "Register";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FName", fname.Text.ToString());
            cmd.Parameters.AddWithValue("@LName", lname.Text.ToString());
            cmd.Parameters.AddWithValue("@Mobile", mobile.Text.ToString());
            cmd.Parameters.AddWithValue("@Email", email.Text.ToString());
            cmd.Parameters.AddWithValue("@Password", password.Text.ToString());
            cmd.ExecuteNonQuery();
            Response.Write("Succesfully Registered");
            con.Close();

        }

        protected void login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            
        }
    }
}