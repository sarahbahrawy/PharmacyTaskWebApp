<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="PharmacyWebApplication.AddCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label id ="ID" runat="server" Text=" Category ID" ></asp:Label>
            
            <asp:TextBox ID="CategoryID" runat="server"></asp:TextBox>
            </br>
            <asp:Label id ="Name" runat="server" Text=" Category Name" ></asp:Label>
            
            <asp:TextBox ID="CategoryName" runat="server"></asp:TextBox>
            </br>
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="SubmitClick"/> 
            <asp:Button ID="back" runat="server" Text="Back" OnClick="BackClick"/>
            </br>
            <asp:Label id ="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
