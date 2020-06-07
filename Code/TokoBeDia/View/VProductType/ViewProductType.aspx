<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProductType.aspx.cs" Inherits="TokoBeDia.View.VProductType.ViewProductType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Product Type</title>
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
            <asp:Label runat="server" Text="Product Type List"></asp:Label>
            <br />
            <div>
                <asp:GridView ID="ptGrid" runat="server">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="updateBtn" Text="Update" CommandArgument='<%#Eval("ProductTypeId") %>' OnClick="updateBtn_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="deleteBtn" Text="Delete" CommandArgument='<%#Eval("ProductTypeId") %>' OnClick="deleteBtn_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <asp:Label runat="server" ID="warningLbl"></asp:Label>
                <asp:Button runat="server" ID="insertBtn" Text="Insert" OnClick="insertBtn_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
