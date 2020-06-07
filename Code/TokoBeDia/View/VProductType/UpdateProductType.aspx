<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProductType.aspx.cs" Inherits="TokoBeDia.View.VProductType.UpdateProductType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Type</title>
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
            <asp:Label runat="server" Text="Update Current Type"></asp:Label>
            <div>
                <br />
                <asp:Label runat="server" Text="Product Type ID: "></asp:Label>
                <asp:TextBox runat="server" ID="typeIdBox" Enabled="false"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" Text="Product Type Name: "></asp:Label>
                <asp:TextBox runat="server" ID="typeNameBox"></asp:TextBox>
                <asp:Label runat="server" ID="nameValidate"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Product Type Desc: "></asp:Label>
                <asp:TextBox runat="server" ID="typeDescBox"></asp:TextBox>
                <asp:Label runat="server" ID="descValidate"></asp:Label>
            </div>
        </div>
        <br />
        <div>
            <asp:Label runat="server" ID="warningLbl"></asp:Label>
            <asp:Button runat="server" ID="submitBtn" Text="Update" OnClick="submitBtn_Click" ValidationGroup="updateType" />
        </div>
    </div>
    </form>
</body>
</html>
