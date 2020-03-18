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
    public partial class SelectBranch : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection();
        static int BranchID;
        protected void Page_Load(object sender, EventArgs e)
        {
            Conn.ConnectionString = @"data source=(LocalDB)\MSSQLLocalDB;
                                      attachdbfilename=C:\Users\Sara\Documents\PharmacyDB.mdf;
                                      integrated security=True;
                                      connect timeout=30;
                                      MultipleActiveResultSets=True;";


            Conn.Open();
            if (!IsPostBack)
            {

                SqlConnection con = new SqlConnection(Conn.ConnectionString);
                string com = "Select ID , Location from Branch";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDownListBranches.DataSource = dt;
                DropDownListBranches.DataBind();
                DropDownListBranches.Items.Insert(0, "--Select--");


            }

        }
        protected void Selection_Change(Object sender, EventArgs e)
        {
            BranchID = int.Parse(DropDownListBranches.SelectedItem.Value);
            Session["Branch_ID"] = BranchID;

        }
        protected void AddNewItemInStockClick(object sender, EventArgs e)
        {
            Response.Redirect("NewItemInStock.aspx");
        }
        protected void UpdateQuantityClick(object sender, EventArgs e)
        {
            Response.Redirect("UpdateQuantity.aspx");
        }
        protected void ViewActionsClick(object sender, EventArgs e)
        {
            Response.Redirect("ViewActions.aspx");
        }
        protected void ViewSalesClick(object sender, EventArgs e)
        {
            Response.Redirect("ViewSales.aspx");
            
        }
        protected void ViewItemsClick(object sender, EventArgs e)
        {
            Response.Redirect("ViewAvailableItems.aspx");
            
        }
        protected void BackClick(object sender, EventArgs e)
        {
            Response.Redirect("FirstForm.aspx");
        }
    }
}