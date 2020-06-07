<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="TokoBeDia.View.Transaction.VCart.ViewCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Cart</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" ID="userWarnLbl"></asp:Label>
            <asp:Button runat="server" ID="homeBtn" Text="Home" OnClick="homeBtn_Click" />
        </div>
        <div>
            <br />
            <asp:Label runat="server" Text="View Your Current Cart"></asp:Label>
            <div>
                <br />
                <asp:Label runat="server" ID="cartEmptyLbl"></asp:Label>
                <asp:GridView runat="server" ID="cartGrid">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="updateBtn" Text="Update" CommandArgument='<%#Eval("Product_Id") %>' OnClick="updateBtn_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="deleteBtn" Text="Delete" CommandArgument='<%#Eval("Product_Id") %>' OnClick="deleteBtn_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label runat="server" Text="Grand Total: "></asp:Label>
                <asp:Label runat="server" ID="grandTotalLbl"></asp:Label>
            </div>
        </div>
        <br />
        <div>
            <div>
                <asp:Label runat="server" Text="Payment Method: "></asp:Label>
                <asp:DropDownList runat="server" ID="paymentDD"></asp:DropDownList>
            </div>
            <br />
            <asp:Button runat="server" Text="Check Out" ID="checkOutBtn" OnClick="checkOutBtn_Click" />
            <asp:Label runat="server" ID="warningLbl"></asp:Label>
        </div>
        
    </div>
    </form>
</body>
</html>
