<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="TokoBeDia.View.VProduct.UpdateProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Current Product</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" ID="userWarnLbl"></asp:Label>
            <asp:Button runat="server" ID="homeBtn" Text="Home" OnClick="homeBtn_Click" />
            <asp:Button runat="server" ID="logoutBtn" Text="Log Out" OnClick="logoutBtn_Click" />
        </div>
        <br />
        <div>
            <asp:Label runat="server" Text="Update Product"></asp:Label>
            <div>
                <div>
                <asp:Label runat="server" Text="Product Name: "></asp:Label>
                <asp:TextBox runat="server" ID="nameBox"></asp:TextBox>
                <asp:Label runat="server" ID="nameValidate"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Stock: "></asp:Label>
                <asp:TextBox runat="server" ID="stockBox"></asp:TextBox>
                <asp:Label runat="server" ID="stockValidate"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Price: "></asp:Label>
                <asp:TextBox runat="server" ID="priceBox"></asp:TextBox>
                <asp:Label runat="server" ID="priceValidate"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Product Type: "></asp:Label>
                <asp:DropDownList runat="server" ID="typeDD"></asp:DropDownList>
                <asp:Label runat="server" ID="typeValidate"></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button runat="server" ID="updateBtn" Text="Update" OnClick="updateBtn_Click" ValidationGroup="updateProduct" />
                <asp:Label runat="server" ID="warningLbl"></asp:Label>
            </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
