<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertProductType.aspx.cs" Inherits="TokoBeDia.View.VProductType.InsertProductType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insert New Product Type</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" ID="userWarnLbl"></asp:Label>
            <asp:Button runat="server" ID="homeBtn" Text="Home" OnClick="homeBtn_Click" />
            <asp:Button runat="server" ID="logoutBtn" Text="Log Out" OnClick="logoutBtn_Click" />
        </div>
        <div>
            <asp:Label runat="server" Text="Insert New Product Type"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label runat="server" Text="Product Type Name: "></asp:Label>
            <asp:TextBox runat="server" ID="typeNameBox"></asp:TextBox>
            <asp:Label runat="server" ID="nameValidate"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" Text="Product Type Description: "></asp:Label>
            <asp:TextBox runat="server" ID="descBox"></asp:TextBox>
            <asp:Label runat="server" ID="descValidate"></asp:Label>
        </div>
        <div>
            <asp:Button runat="server" ID="submitBtn" Text="Submit" OnClick="submitBtn_Click" ValidationGroup="insertType" />
            <asp:Label runat="server" ID="warningLbl"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
