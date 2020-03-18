<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectBranch.aspx.cs" Inherits="PharmacyWebApplication.SelectBranch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label id ="BranchLabel" runat="server" Text=" Select A Branch " ></asp:Label>
            
            <asp:DropDownList id="DropDownListBranches" runat="server" DataTextField = "Location" DataValueField = "ID"  OnSelectedIndexChanged="Selection_Change"  AutoPostBack="true">
                
            </asp:DropDownList>
        
            </br>
            <asp:Button ID="AddNewItemInStock" runat="server" Text="Add New Item In Stock" OnClick="AddNewItemInStockClick"/> 
            </br>
            <asp:Button ID="UpdateQuantity" runat="server" Text="Update Item Quantity" OnClick="UpdateQuantityClick"/> 
            </br>
            <asp:Button ID="ViewItems" runat="server" Text="View Available Items" OnClick="ViewItemsClick"/> 
            </br>
            <asp:Button ID="ViewActions" runat="server" Text="View Previous Actions" OnClick="ViewActionsClick"/> 
            </br>
            <asp:Button ID="ViewSales" runat="server" Text="View Sales" OnClick="ViewSalesClick"/> 
            </br>
            <asp:Button ID="back" runat="server" Text="Back" OnClick="BackClick"/>
           </br>
            
        </div>
    </form>
</body>
</html>
