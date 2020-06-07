<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="TokoBeDia.View.profile.UpdateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Profile</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" ID="userWarnLbl"></asp:Label>
            <asp:Button runat="server" ID="homeBtn" Text="Home" OnClick="homeBtn_Click" />
            <asp:Button runat="server" ID="logoutBtn" Text="Log Out" OnClick="logoutBtn_Click" />
        </div>
        <div>
            <br />
            <asp:Label runat="server" Text="Update Your Profile Here"></asp:Label>
            <br />
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
                <asp:Label runat="server" Text="Gender: "></asp:Label>
                <asp:RadioButtonList runat="server" ID="genderBtn" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label runat="server" ID="genderValidator"></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button runat="server" ID="submitBtn" Text="Submit" OnClick="submitBtn_Click" />
                <asp:Label runat="server" ID="warningLbl"></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
