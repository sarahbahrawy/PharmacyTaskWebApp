<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBranch.aspx.cs" Inherits="PharmacyWebApplication.AddBranch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label id ="ID" runat="server" Text=" Branch ID" ></asp:Label>
            
            <asp:TextBox ID="BranchID" runat="server"></asp:TextBox>
            </br>
            <asp:Label id ="Location" runat="server" Text=" Branch Location" ></asp:Label>
            
            <asp:TextBox ID="BranchLocation" runat="server"></asp:TextBox>
            </br>
            <asp:Label id ="Label2" runat="server" Text=" Branch Address" ></asp:Label>
            
            <asp:TextBox ID="BranchAddress" runat="server"></asp:TextBox>
            </br>
            <asp:Label id ="Label3" runat="server" Text=" Branch City" ></asp:Label>
            
            <asp:TextBox ID="BranchCity" runat="server"></asp:TextBox>
            </br>
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="SubmitClick"/> 
            <asp:Button ID="back" runat="server" Text="Back" OnClick="BackClick"/>
            </br>
            <asp:Label id ="Label1" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
