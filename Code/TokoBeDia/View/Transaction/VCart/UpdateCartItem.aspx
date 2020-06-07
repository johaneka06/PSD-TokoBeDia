<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCartItem.aspx.cs" Inherits="TokoBeDia.View.Transaction.VCart.UpdateCartItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Cart Item</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" ID="userWarnLbl"></asp:Label>
            <asp:Button runat="server" Text="Home" ID="homeBtn" OnClick="homeBtn_Click" />
        </div>
        <div>
            <br />
            <asp:Label runat="server" Text="Updae Existing Cart Item"></asp:Label>
            <div>
                <br />
                <div>
                    <asp:Label runat="server" Text="Item Name: "></asp:Label>
                    <asp:TextBox runat="server" ID="nameBox" Enabled="false"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" Text="Item Price: "></asp:Label>
                    <asp:TextBox runat="server" ID="priceBox" Enabled="false"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" Text="Item Qty: "></asp:Label>
                    <asp:TextBox runat="server" ID="qtyBox"></asp:TextBox>
                    <asp:Label runat="server" Text="* 0 will remove this item"></asp:Label>
                </div>
            </div>
            <div>
                <br />
                <asp:Button runat="server" ID="submitBtn" Text="Update" OnClick="submitBtn_Click" />
                <asp:Label runat="server" ID="warningLbl"></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
