<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewItemInStock.aspx.cs" Inherits="PharmacyWebApplication.NewItemInStock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label id ="Lab" runat="server" Text="Add In Your Branch New Item Was Not Avaiable"  ></asp:Label>
            </br>
            <asp:Label id ="CategoryLabel" runat="server" Text=" Select A Category " ></asp:Label>
            
            <asp:DropDownList id="DropDownListCategories" runat="server" DataTextField = "name" DataValueField = "ID"  OnSelectedIndexChanged="Selection_ChangeCategory"  AutoPostBack="true">
                
            </asp:DropDownList>
        
            </br>
            <asp:Label id ="ItemLabel" runat="server" Text=" Select An Item " ></asp:Label>
            
            <asp:DropDownList id="DropDownListItems" runat="server" DataTextField = "name" DataValueField = "ID"  OnSelectedIndexChanged="Selection_ChangeItem"  AutoPostBack="true">
                
            </asp:DropDownList>
        
            </br>
            <asp:Label id ="emp" runat="server" Text=" Employee " ></asp:Label>
            
            <asp:DropDownList id="DropDownListEmployees" runat="server" DataTextField = "name" DataValueField = "ID"  OnSelectedIndexChanged="Selection_ChangeEmployee"  AutoPostBack="true">
                
            </asp:DropDownList>
        
            </br>
            <asp:Label id ="Quantity" runat="server" Text=" How Many Quantity" ></asp:Label>
            
            <asp:TextBox ID="QuantityTextBox" runat="server"></asp:TextBox>
            </br>
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="SubmitClick"/> 
            <asp:Button ID="back" runat="server" Text="Back" OnClick="BackClick"/>
            </br>
            <asp:Label id ="Label1" runat="server"  ></asp:Label>
            
        </div>
    </form>
</body>
</html>
