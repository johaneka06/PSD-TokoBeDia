<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="TokoBeDia.View.Transaction.VCart.AddToCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add To Cart</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" ID="userWarnLbl"></asp:Label>
            <asp:Button runat="server" ID="homeBtn" Text="Home" OnClick="homeBtn_Click"/>
        </div>
        <br />
        <div>
            <asp:Label runat="server" Text="Add Your Current Product To Cart"></asp:Label>
            <div>
                <br />
                <div>
                    <asp:Label runat="server" Text="Product Name: "></asp:Label>
                    <asp:Label runat="server" ID="productNameLbl"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Text="Product Price: "></asp:Label>
                    <asp:Label runat="server" ID="productPriceLbl"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Text="Product Stock: "></asp:Label>
                    <asp:Label runat="server" ID="productStockLbl"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Text="Product Type: "></asp:Label>
                    <asp:Label runat="server" ID="productTypeLbl"></asp:Label>
                </div>
            </div>
            <br />
            <div>
                <asp:Label runat="server" Text="Input Qty: "></asp:Label>
                <asp:TextBox runat="server" ID="qtyBox"></asp:TextBox>
            </div>
            <div>
                <br />
                <asp:Button runat="server" Text="Add to Cart" ID="addBtn" OnClick="addBtn_Click"/>
                <asp:Label runat="server" ID="warningLbl"></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
