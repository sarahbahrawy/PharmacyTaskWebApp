using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmacyWebApplication
{
    public partial class AddCategory : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection();
        List<int> CategoriesIds = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Conn.ConnectionString = @"data source=(LocalDB)\MSSQLLocalDB;
                                      attachdbfilename=C:\Users\Sara\Documents\PharmacyDB.mdf;
                                      integrated security=True;
                                      connect timeout=30;
                                      MultipleActiveResultSets=True;";

            Conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = Conn;
            com.CommandText = "Select ID from Category ";
            com.CommandType = CommandType.Text;
            SqlDataReader r = com.ExecuteReader();
            while (r.Read())
            {
                CategoriesIds.Add(int.Parse(r[0].ToString()));

            }
        }
        protected void SubmitClick(object sender, EventArgs e)
        {
            if (CategoryID.Text != "" && CategoryName.Text != "")
            {
                int ID = int.Parse(CategoryID.Text);
                string name = CategoryName.Text;
                if (CategoriesIds.Contains(ID))
                {
                    Label1.Text = "This ID is Already Exits";
                }
                else
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = Conn;
                    com.CommandText = "AddCategory";
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("Cid", ID);
                    com.Parameters.Add("Name", name);
                    com.ExecuteNonQuery();
                    Label1.Text = "Added";
                }
            }
            else
            {
                Label1.Text = "Empty Data";
            }
        }
        protected void BackClick(object sender, EventArgs e)
        {
            Response.Redirect("FirstForm.aspx");
        }
    }
}