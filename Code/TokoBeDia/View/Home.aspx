<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TokoBeDia.View.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TokoBeDia | Home</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="welcomeLbl"></asp:Label>
        <asp:Button runat="server" ID="viewProductBtn" Text="View Product" OnClick="viewProductBtn_Click"/>
        <asp:Button runat="server" ID="loginBtn" Text="Login" OnClick="loginBtn_Click"/>
        <asp:Button runat="server" ID="viewCartBtn" Text="View Cart" OnClick="viewCartBtn_Click" />
        <asp:Button runat="server" ID="viewTransactionHistBtn" Text="View Transaction History" OnClick="viewTransactionHistBtn_Click" />
        <asp:Button runat="server" ID="viewTransactionReportBtn" Text="View Transaction Report" OnClick="viewTransactionReportBtn_Click" />
        <asp:Button runat="server" ID="viewProductTypeBtn" Text="View Product Type" OnClick="viewProductTypeBtn_Click" />
        <asp:Button runat="server" ID="viewPaymentTypeBtn" Text="View Payment Type" OnClick="viewPaymentTypeBtn_Click" />
        <asp:Button runat="server" ID="viewUserBtn" Text="View User" OnClick="viewUserBtn_Click" />
        <asp:Button runat="server" ID="profileBtn" Text="View Profile" OnClick="profileBtn_Click" />
        <asp:Button runat="server" ID="logoutBtn" Text="Logout" OnClick="logoutBtn_Click" />
    </div>
    <div>
        <br />
        <asp:Label runat="server" Text="Welcome to TokoBeDia!"></asp:Label>
        <br />
        <asp:Label runat="server" ID="msg" Text="Top 5 things:"></asp:Label>
        <asp:GridView runat="server" ID="productRandomGridMember">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="selectBtn" Text="Add To Cart" CommandArgument='<%#Eval("ID") %>' OnClick="selectBtn_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:GridView runat="server" ID="productRandomGridGuest">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
