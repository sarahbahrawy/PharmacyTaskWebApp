<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstForm.aspx.cs" Inherits="PharmacyWebApplication.FirstForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="AddNewBranch" runat="server" Text="Add New Branch" OnClick="AddNewBranchClick"/> 
            </br>
            <asp:Button ID="AddNewCategory" runat="server" Text="Add New Category" OnClick="AddNewCategoryClick"/> 
            </br>
            <asp:Button ID="AddNewItem" runat="server" Text="Add New Item" OnClick="AddNewItemClick"/> 
            </br>
            
            <asp:Button ID="SelectABranch" runat="server" Text="Select A Branch" OnClick="SelectBranchClick"/> 
            </br>
            <asp:Button ID="BranchesAction" runat="server" Text="View Previous Actions of All Branches" OnClick="BranchesActionsClick"/> 
            </br>
            <asp:Button ID="BranchesSales" runat="server" Text="View Sales of All Branches" OnClick="BrancheSalesClick"/> 
            </br>
        </div>
    </form>
</body>
</html>
