<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="TokoBeDia.View.VProduct.ViewProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Product</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" ID="userWarningLbl"></asp:Label>
            <asp:Button runat="server" ID="homeBtn" Text="Home" OnClick="homeBtn_Click"/>
            <asp:Button runat="server" ID="loginBtn" Text="Login" OnClick="loginBtn_Click" Visible="false" />
            <asp:Button runat="server" ID="logOutBtn" Text="Log Out" OnClick="logOutBtn_Click"/>
        </div>
        <br />
        <div>
            <asp:Label runat="server" Text="View Product"></asp:Label>
            <br />
            <asp:GridView runat="server" ID="productGrid">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="selectLinkBtn" Text="Select" CommandArgument='<%#Eval("ID") %>' OnClick="selectLinkBtn_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div>
            <asp:Label runat="server" Text="Detail Selected Product: "></asp:Label>
            <div>
                <asp:Label runat="server" Text="Product ID: "></asp:Label>
                <asp:Label runat="server" ID="idLbl"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Product Name: "></asp:Label>
                <asp:Label runat="server" ID="nameLbl"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Product Price: "></asp:Label>
                <asp:Label runat="server" ID="priceLbl"></asp:Label>
            </div>
        </div>
        
        <div>
            <br />
            <asp:Button runat="server" ID="insertBtn" Text="Insert New Product" OnClick="insertBtn_Click" />
            <asp:Button runat="server" ID="updateBtn" Text="Update Current Product" OnClick="updateBtn_Click" Visible="false"/>
            <asp:Button runat="server" ID="deleteBtn" Text="Delete Current Product" OnClick="deleteBtn_Click" Visible="false"/>
            <asp:Button runat="server" ID="addToCartBtn" Text="Add To Cart" OnClick="addToCartBtn_Click" Visible="false" />
            <br />
            <asp:Label runat="server" ID="warningLbl"></asp:Label>
        </div>

    </div>
    </form>
</body>
</html>
