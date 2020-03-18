using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PharmacyWebApplication
{
    public partial class ViewAvailableItems : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            int BranchID = int.Parse(Session["Branch_ID"].ToString());
            Conn.ConnectionString = @"data source=(LocalDB)\MSSQLLocalDB;
                                      attachdbfilename=C:\Users\Sara\Documents\PharmacyDB.mdf;
                                      integrated security=True;
                                      connect timeout=30;
                                      MultipleActiveResultSets=True;";

            Conn.Open();
            String sqlStatement = @"select C.Name 'Category Name', I.Name'Item Name' , S.Quantity
                        from Stock S  , Category C , Items I
                    where S.BranchID=@Bid and S.CategoryID=C.ID  and S.ItemID=I.ID ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sqlStatement, Conn.ConnectionString);
            da.SelectCommand.Parameters.Add("Bid", BranchID);
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

        }
    }
}