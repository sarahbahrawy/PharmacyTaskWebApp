<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="PharmacyWebApplication.AddItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label id ="CategoryLabel" runat="server" Text=" Choose A Category " ></asp:Label>
            
            <asp:DropDownList id="DropDownListCategories" runat="server" DataTextField = "Name" DataValueField = "ID"  OnSelectedIndexChanged="Selection_Change"  AutoPostBack="true">
                
            </asp:DropDownList>
        
            </br>
            <asp:Label id ="ID" runat="server" Text=" Item ID " ></asp:Label>
            
            <asp:TextBox ID="ItemID" runat="server"></asp:TextBox>
            </br>
            <asp:Label id ="Name" runat="server" Text=" Item Name" ></asp:Label>
            
            <asp:TextBox ID="ItemName" runat="server"></asp:TextBox>
            </br>
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="SubmitClick"/> 
            <asp:Button ID="back" runat="server" Text="Back" OnClick="BackClick"/>
            </br>
            <asp:Label id ="Label1" runat="server"></asp:Label>
            
        </div>
    </form>
</body>
</html>
