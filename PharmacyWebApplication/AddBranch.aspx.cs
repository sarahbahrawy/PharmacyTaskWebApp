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
    public partial class AddBranch : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection();
        List<int> BranchesIds = new List<int>();
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
            com.CommandText = "Select ID from Branch ";
            com.CommandType = CommandType.Text;
            SqlDataReader r = com.ExecuteReader();
            while (r.Read())
            {
                BranchesIds.Add(int.Parse(r[0].ToString()));

            }
        }
        protected void SubmitClick(object sender, EventArgs e)
        {
            if (BranchID.Text != "" && BranchLocation.Text != "" && BranchAddress.Text != "" && BranchCity.Text != "")
            {
                int ID = int.Parse(BranchID.Text);
                string location = BranchLocation.Text;
                string Address = BranchAddress.Text;
                string City = BranchCity.Text;

                if (BranchesIds.Contains(ID))
                {
                    Label1.Text="This ID is Already Exits";
                }
                else
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = Conn;
                    com.CommandText = "AddBranch";
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("Bid", ID);
                    com.Parameters.Add("Location", location);
                    com.Parameters.Add("Address", Address);
                    com.Parameters.Add("City", City);
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