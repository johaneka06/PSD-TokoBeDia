<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="TokoBeDia.View.profile.ViewProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Profile</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" ID="userWarnLbl"></asp:Label>
            <asp:Button runat="server" ID="homeBtn" Text="Home" OnClick="homeBtn_Click" />
            <asp:Button runat="server" ID="logOutBtn" Text="Log Out" OnClick="logOutBtn_Click" />
        </div>
        <div>
            <br />
            <asp:Label runat="server" Text="Profile"></asp:Label>
            <br />
            <div>
                <asp:Label runat="server" Text="Name: "></asp:Label>
                <asp:Label runat="server" ID="nameLbl"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Email: "></asp:Label>
                <asp:Label runat="server" ID="emailLbl"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Gender: "></asp:Label>
                <asp:Label runat="server" ID="genderLbl"></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button runat="server" Text="Update Profile" ID="updateBtn" OnClick="updateBtn_Click"/>
                <asp:Button runat="server" Text="Change Password" ID="changePswdBtn" OnClick="changePswdBtn_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
