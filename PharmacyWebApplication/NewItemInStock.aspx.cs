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
    public partial class NewItemInStock : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection();
        static int CategoryID;
        static int ItemID;
        static int EmployeeID;
        int BranchID;
        protected void Page_Load(object sender, EventArgs e)
        {
             BranchID = int.Parse(Session["Branch_ID"].ToString());
            Conn.ConnectionString = @"data source=(LocalDB)\MSSQLLocalDB;
                                      attachdbfilename=C:\Users\Sara\Documents\PharmacyDB.mdf;
                                      integrated security=True;
                                      connect timeout=30;
                                      MultipleActiveResultSets=True;";


            Conn.Open();
            if (!IsPostBack)
            {

                SqlConnection con = new SqlConnection(Conn.ConnectionString);
                string com = @"select *from Category ";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDownListCategories.DataSource = dt;
                DropDownListCategories.DataBind();
                DropDownListCategories.Items.Insert(0, "--Select--");
            }
            if (!IsPostBack)
            {

                SqlConnection con = new SqlConnection(Conn.ConnectionString);
                string com = @"select * 
                        from Employees 
                        where BranchID=@Bid ";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                adpt.SelectCommand.Parameters.Add("Bid", BranchID);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDownListEmployees.DataSource = dt;
                DropDownListEmployees.DataBind();
                DropDownListEmployees.Items.Insert(0, "--Select--");
            }
        }
        protected void Selection_ChangeCategory(Object sender, EventArgs e)
        {
            CategoryID = int.Parse(DropDownListCategories.SelectedItem.Value);
            
            
                SqlConnection con = new SqlConnection(Conn.ConnectionString);
                string com = @"select ID ,Name
                            from Items 
                            where ID NOT IN (SELECT ItemID FROM Stock where BranchID=@Bid)
                            and CategoryID=@Cid";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                adpt.SelectCommand.Parameters.Add("Bid", BranchID);
                adpt.SelectCommand.Parameters.Add("Cid", CategoryID);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDownListItems.DataSource = dt;
                DropDownListItems.DataBind();
                DropDownListItems.Items.Insert(0, "--Select--");
           
        }
        protected void Selection_ChangeItem(Object sender, EventArgs e)
        {
            ItemID = int.Parse(DropDownListItems.SelectedItem.Value);
            
        }
        protected void Selection_ChangeEmployee(Object sender, EventArgs e)
        {
            EmployeeID = int.Parse(DropDownListEmployees.SelectedItem.Value);

        }
        protected void SubmitClick(Object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string Day = now.GetDateTimeFormats('d')[0];
            string Time = now.GetDateTimeFormats('t')[0];

            if (EmployeeID!=null&& QuantityTextBox.Text != "" && BranchID !=null &&CategoryID!=null && ItemID !=null )
            {
                int q = int.Parse(QuantityTextBox.Text);


                    SqlCommand com = new SqlCommand();
                    com.Connection = Conn;
                    com.CommandText = "AddNewItemInStock";
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("Bid", BranchID);
                    com.Parameters.Add("Cid", CategoryID);
                    com.Parameters.Add("iID", ItemID);
                    com.Parameters.Add("Quantity", q);
                    com.Parameters.Add("EID", EmployeeID);
                    com.Parameters.Add("day", Day);
                    com.Parameters.Add("time", Time);

                    com.ExecuteNonQuery();
                    Label1.Text = "Added ";

                
            }
            else
            {
                Label1.Text = "Empty Data";
            }

            //Label1.Text = "BranchID= " + BranchID + " CategoryID= " + CategoryID + " ItemID= " + ItemID + " Quantity= " + QuantityTextBox.Text + " EmployeeID= "+EmployeeID+" Day= "+ Day+" Time= "+Time;
        }
        protected void BackClick(Object sender, EventArgs e)
        {
            Response.Redirect("SelectBranch.aspx");

        }
    }
}