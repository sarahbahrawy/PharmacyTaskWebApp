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
    public partial class AddItem : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection();
        List<int> ItemsIds = new List<int>();
        static int CategoryID;

       

        protected void Page_Load(object sender, EventArgs e)
        {

            Conn.ConnectionString = @"data source=(LocalDB)\MSSQLLocalDB;
                                      attachdbfilename=C:\Users\Sara\Documents\PharmacyDB.mdf;
                                      integrated security=True;
                                      connect timeout=30;
                                      MultipleActiveResultSets=True;";


            Conn.Open();
            if(!IsPostBack)
            {
               
                SqlConnection con = new SqlConnection(Conn.ConnectionString);
                string com = "Select * from Category";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDownListCategories.DataSource = dt;
                DropDownListCategories.DataBind();
                DropDownListCategories.Items.Insert(0, "--Select--");


            }


            SqlCommand cm = new SqlCommand();
            cm.Connection = Conn;
            cm.CommandText = "Select ID from Items ";
            cm.CommandType = CommandType.Text;
            SqlDataReader r = cm.ExecuteReader();
            while (r.Read())
            {
                ItemsIds.Add(int.Parse(r[0].ToString()));

            }

        }
        protected void SubmitClick(object sender, EventArgs e)
        {
            if (ItemID.Text != "" && ItemName.Text != "")
            {
                int ID = int.Parse(ItemID.Text);
                string Name = ItemName.Text;

                if (ItemsIds.Contains(ID))
                {
                    Label1.Text = "This ID is Already Exits";
                }
                else
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = Conn;
                    com.CommandText = "AddItem";
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("ID", ID);
                    com.Parameters.Add("Cid", CategoryID);
                    com.Parameters.Add("name", Name);
                    
                    com.ExecuteNonQuery();
                    Label1.Text = "Added " ;

                }
            }
            else
            {
                Label1.Text = "Empty Data";
            }
        }
        protected void Selection_Change(Object sender, EventArgs e)
        {
            CategoryID =int.Parse( DropDownListCategories.SelectedItem.Value);



        }
        protected void BackClick(object sender, EventArgs e)
        {
            Response.Redirect("FirstForm.aspx");
        }
    }
}