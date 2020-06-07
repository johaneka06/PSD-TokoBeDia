<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TokoBeDia.View.profile.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" ID="userWarnLbl"></asp:Label>
            <asp:Button runat="server" ID="homeBtn" Text="Home" OnClick="homeBtn_Click"/>
            <asp:Button runat="server" ID="logOutBtn" Text ="Log Out" OnClick="logOutBtn_Click" />
        </div>
        <div>
            <br />
            <asp:Label runat="server" Text="Change Password"></asp:Label>
            <br />
            <div>
                <asp:Label runat="server" Text="Old Password: "></asp:Label>
                <asp:TextBox runat="server" ID="oldPswdBox" TextMode="Password"></asp:TextBox>
                <asp:Label runat="server" ID="oldPswdValidator"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="New Password: "></asp:Label>
                <asp:TextBox runat="server" ID="newPswdBox" TextMode="Password"></asp:TextBox>
                <asp:Label runat="server" ID="newPswdBoxValidator"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Confirmation Password: "></asp:Label>
                <asp:TextBox runat="server" ID="confPswdBox" TextMode="Password"></asp:TextBox>
                <asp:Label runat="server" ID="confPswdBoxValidator"></asp:Label>
            </div>
            <div>
                <br />
                <asp:Button runat="server" Text="Change Password" ID="changeBtn" OnClick="changeBtn_Click" />
                <asp:Label runat="server" ID="warningLbl"></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
