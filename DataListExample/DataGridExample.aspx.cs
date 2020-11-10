using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DataListExample
{
    public partial class DataGridExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable table = new DataTable();
           // table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Email");
            table.Columns.Add("Contact");
            table.Rows.Add("101", "Deepak Kumar", "deepak@example.com","25412");
            table.Rows.Add("102", "John", "john@example.com","4552");
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
}