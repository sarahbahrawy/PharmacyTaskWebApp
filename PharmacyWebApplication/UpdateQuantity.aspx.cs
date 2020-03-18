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
    public partial class IncreaseQuantity : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection();
        static int CategoryID;
        static int ItemID;
        static int EmployeeID;
        static int ActionTypeID;
        int BranchID;
        string Day;
        string Time;
        int previousQ;
        static List<string> PreviousQuantity = new List<string>();
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
                string com = @"select distinct  C.Name , C.ID
                            from Stock S , Category C
                            where S.CategoryID=C.ID and S.BranchID=@Bid ";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                adpt.SelectCommand.Parameters.Add("Bid", BranchID);
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

            if (!IsPostBack)
            {

                SqlConnection con = new SqlConnection(Conn.ConnectionString);
                string com = @"select * 
                        from ActionTypes where ID <>1 ";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDownListActionTypes.DataSource = dt;
                DropDownListActionTypes.DataBind();
                DropDownListActionTypes.Items.Insert(0, "--Select--");
            }


        }
        protected void Selection_ChangeCategory(Object sender, EventArgs e)
        {
            
            CategoryID = int.Parse(DropDownListCategories.SelectedItem.Value);
            SqlConnection con = new SqlConnection(Conn.ConnectionString);
            string com = @"select I.Name,I.ID , S.Quantity 
                            from Stock S , Items I  
                        where S.ItemID=I.ID and S.BranchID=@Bid and S.CategoryID=@Cid";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            adpt.SelectCommand.Parameters.Add("Bid", BranchID);
            adpt.SelectCommand.Parameters.Add("Cid", CategoryID);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownListItems.DataSource = dt;
            DropDownListItems.DataBind();
            DropDownListItems.Items.Insert(0, "--Select--");
            PreviousQuantity =dt.AsEnumerable().Select(x => x[2].ToString()).ToList();

        }
        protected void Selection_ChangeItem(Object sender, EventArgs e)
        {
            ItemID = int.Parse(DropDownListItems.SelectedItem.Value);

        }
        protected void Selection_ChangeEmployee(Object sender, EventArgs e)
        {
            EmployeeID = int.Parse(DropDownListEmployees.SelectedItem.Value);

        }
        protected void Selection_ChangeType(Object sender, EventArgs e)
        {
            ActionTypeID = int.Parse(DropDownListActionTypes.SelectedItem.Value);
            

        }
        protected void SubmitClick(Object sender, EventArgs e)
        {
            int WantedQuantity = int.Parse(QuantityTextBox.Text);
            int index = DropDownListItems.SelectedIndex - 1;
             previousQ = int.Parse(PreviousQuantity[index]);
             
            
            DateTime now = DateTime.Now;
             Day = now.GetDateTimeFormats('d')[0];
             Time = now.GetDateTimeFormats('t')[0];
            
            if (EmployeeID != null && WantedQuantity != null && BranchID != null && CategoryID != null && ItemID != null)
            {
                if(ActionTypeID==2)
                {
                    int NewQuantity = previousQ + WantedQuantity;
                    IncreaseItemQuantity(NewQuantity);
                }
                else
                {
                    if (WantedQuantity<= previousQ)
                    {
                        // Label1.Text = "BranchID= " + BranchID + " CategoryID= " + CategoryID + " ItemID= " + ItemID + " PreviousQuantity= " + PreviousQuantity[index] + " WantedQuantity= " + WantedQuantity +" ActionID= "+ActionTypeID+" EmployeeID= " + EmployeeID + " Day= " + Day + " Time= " + Time;
                        DecreaseItemQuantity( WantedQuantity);
                    }
                    else
                    {
                        Label1.Text = "Not Available Quantity You Have " + previousQ + " In Your Stock";
                    }

                }
                


            }
            else
            {
                Label1.Text = "Empty Data";
            }
            
            //Label1.Text = "BranchID= " + BranchID + " CategoryID= " + CategoryID + " ItemID= " + ItemID +" PreviousQuantity= "+PreviousQuantity[index]+ " Quantity= " + QuantityTextBox.Text + " NewQuantity= "+NewQuantity+" EmployeeID= "+EmployeeID+" Day= "+ Day+" Time= "+Time;
        }
        protected void BackClick(Object sender, EventArgs e)
        {
            Response.Redirect("SelectBranch.aspx");

        }
        protected void IncreaseItemQuantity(int NewQuantity)
        {
            SqlCommand com = new SqlCommand();
            com.Connection = Conn;
            com.CommandText = "IncreaseItemQuantity";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Bid", BranchID);
            com.Parameters.Add("Cid", CategoryID);
            com.Parameters.Add("iID", ItemID);
            com.Parameters.Add("PQuantity", previousQ);
            com.Parameters.Add("CQuantity", NewQuantity);
            com.Parameters.Add("EID", EmployeeID);
            com.Parameters.Add("day", Day);
            com.Parameters.Add("time", Time);

            com.ExecuteNonQuery();
            Label1.Text = "Added ";
        }
        protected void DecreaseItemQuantity(int WantedQuantity)
        {
            SqlCommand com = new SqlCommand();
            com.Connection = Conn;
            com.CommandText = "DecreaseItemQuantity";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Bid", BranchID);
            com.Parameters.Add("Cid", CategoryID);
            com.Parameters.Add("iID", ItemID);
            com.Parameters.Add("PQuantity", previousQ);
            com.Parameters.Add("WantedQuantity", WantedQuantity);
            com.Parameters.Add("ActionTID ", ActionTypeID);
            com.Parameters.Add("EID", EmployeeID);
            com.Parameters.Add("day", Day);
            com.Parameters.Add("time", Time);

            com.ExecuteNonQuery();
            Label1.Text = "Added ";
        }
    }
}