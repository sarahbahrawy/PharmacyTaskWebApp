using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmacyWebApplication
{
    public partial class FirstForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddNewBranchClick(object sender, EventArgs e)
        {
            Response.Redirect("AddBranch.aspx");
        }
        protected void AddNewCategoryClick(object sender, EventArgs e)
        {
            Response.Redirect("AddCategory.aspx");
        }
        protected void AddNewItemClick(object sender, EventArgs e)
        {
            Response.Redirect("AddItem.aspx");
        }
        protected void SelectBranchClick(object sender, EventArgs e)
        {
            Response.Redirect("SelectBranch.aspx");
        }
        protected void BranchesActionsClick(object sender, EventArgs e)
        {
            Response.Redirect("AllBranchesActions.aspx");
        }
        protected void BrancheSalesClick(object sender, EventArgs e)
        {
            Response.Redirect("AllBranchesSales.aspx");
        }
    }
}