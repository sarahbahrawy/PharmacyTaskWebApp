﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace PharmacyWebApplication
{
    public partial class ViewActions : System.Web.UI.Page
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
            String sqlStatement = @"select B.location'Branch Location' , C.Name 'Category Name',I.Name 
                            'Item Name', A.PreviousQuantity 'Previous Quantity' , 
                            A.CurrentQuantity 'Current Quantity',E.name 'Employee Name',
                            AT.Name 'Action Type', A.Day ,A.Time
                            from Actions A , Branch B , Category C , ActionTypes AT , Items I , Employees E
                    where A.BranchID = B.ID and A.CategoryID = C.ID and A.ItemID=I.ID and A.EmployeeID=E.ID and A.BranchID=@Bid
                        and A.ActionTypeID=AT.ID 
                        order by A.Time";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sqlStatement, Conn.ConnectionString);
            da.SelectCommand.Parameters.Add("Bid", BranchID);
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

        }
    }
}