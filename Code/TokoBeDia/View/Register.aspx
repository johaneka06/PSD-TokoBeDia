<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TokoBeDia.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" ID="userWarnLbl"></asp:Label>
            <asp:Label runat="server" Text="Register Yourself Here"></asp:Label>
        </div>
        <br />
        <div>
            <div>
                <asp:Label runat="server" Text="Name: "></asp:Label>
                <asp:TextBox runat="server" ID="nameBox"></asp:TextBox>
                <asp:Label runat="server" ID="nameValidator"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Email: "></asp:Label>
                <asp:TextBox runat="server" ID="emailBox"></asp:TextBox>
                <asp:Label runat="server" ID="emailValidator"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Password: "></asp:Label>
                <asp:TextBox runat="server" ID="passwdBox" TextMode="Password"></asp:TextBox>
                <asp:Label runat="server" ID="passwordValidator"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Confirm Password: "></asp:Label>
                <asp:TextBox runat="server" ID="confPasswdBox" TextMode="Password"></asp:TextBox>
                <asp:Label runat="server" ID="confPasswordValidator"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Gender: " ></asp:Label>
                <asp:RadioButtonList runat="server" ID="genderSelector" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label runat="server" ID="genderValidator"></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button runat="server" Text="Register" ID="registerBtn" OnClick="registerBtn_Click" />
                <asp:Label runat="server" ID="warningLbl"></asp:Label>
            </div>
        </div>
        
    </div>
    </form>
</body>
</html>
