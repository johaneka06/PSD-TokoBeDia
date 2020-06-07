<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPaymentType.aspx.cs" Inherits="TokoBeDia.View.VPaymentType.ViewPaymentType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Type List</title>
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
            <asp:Label runat="server" Text="View Payment Type"></asp:Label>
            <br />
            <div>
                <asp:Label runat="server" ID="paymentWarning"></asp:Label>
                <asp:GridView runat="server" ID="paymentGrid">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="updateBtn" Text="Update" CommandArgument='<%#Eval("PaymentTypeId") %>' OnClick="updateBtn_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="deleteBtn" Text="Delete" CommandArgument='<%#Eval("PaymentTypeId") %>' OnClick="deleteBtn_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div>
                <asp:Button runat="server" ID="insertBtn" Text="Insert New Payment Type" OnClick="insertBtn_Click" />
                <asp:Label runat="server" ID="warningLbl"></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
