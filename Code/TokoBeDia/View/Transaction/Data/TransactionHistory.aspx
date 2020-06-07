<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="TokoBeDia.View.Transaction.Data.TransactionHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>History Transaction</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" ID="userWarnLbl"></asp:Label>
            <asp:Button runat="server" ID="homeBtn" Text="Home" OnClick="homeBtn_Click" />
            <asp:Button runat="server" ID="logoutBtn" Text="Log Out" OnClick="logoutBtn_Click" />
            <asp:Button runat="server" ID="loginBtn" Text="Login" OnClick="loginBtn_Click" Visible="false" />
        </div>
        <div>
            <br />
            <asp:Label runat="server" Text="Transaction History"></asp:Label>
            <div>
                <br />
                <asp:GridView runat="server" ID="transactionGrid">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <asp:Button runat="server" ID="transactionReportBtn" Text="Transaction Report" OnClick="transactionReportBtn_Click" Visible="false"/>
        </div>
    </div>
    </form>
</body>
</html>
