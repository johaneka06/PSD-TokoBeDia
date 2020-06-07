<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TokoBeDia.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" Text="Email: "></asp:Label>
            <asp:TextBox runat="server" ID="emailBox"></asp:TextBox> <%--kalau pakai boostrap bisa dikasih placeholder (text yg transparan)--%>
            <asp:Label runat="server" ID="emailValidator"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" Text="Password: "></asp:Label> 
            <asp:TextBox runat="server" ID="passwordBox" TextMode="Password"></asp:TextBox> <%--kalau pakai boostrap bisa dikasih placeholder (text yg transparan)--%>
            <asp:Label runat="server" ID="passwordValidator"></asp:Label>
        </div>
        <div>
            <asp:Button runat="server" ID="loginBtn" Text="Login" OnClick="loginBtn_Click" />
            <asp:CheckBox runat="server" ID="rememberMeChk" Text="Remeber Me" />
            <asp:Label runat="server" ID="warningLbl"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" Text="Doesn't have account?"></asp:Label>
            <asp:LinkButton runat="server" ID="registerBtn" Text="Register Here" OnClick="registerBtn_Click"></asp:LinkButton>
        </div>
    </div>
    </form>
</body>
</html>
