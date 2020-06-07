<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="TokoBeDia.View.profile.ManageUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View User</title>
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
            <asp:Label runat="server" Text="View User"></asp:Label>
            <br />
            <div>
                <asp:GridView runat="server" ID="userGrid">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="linkSelect" Text="Select" CommandArgument='<%#Eval("Email") %>' OnClick="linkSelect_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <br />
            <div>
                <div>
                    <asp:Label runat="server" Text="ID: "></asp:Label>
                    <asp:Label runat="server" ID="idLbl"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Text="Name: "></asp:Label>
                    <asp:Label runat="server" id="nameLbl"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Text="Email: "></asp:Label>
                    <asp:Label runat="server" ID="emailLbl"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" Text="Role: "></asp:Label>
                    <asp:RadioButtonList runat="server" ID="roleBtn" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="Administrator" Text="Administrator"></asp:ListItem>
                        <asp:ListItem Value="Member" Text="Member"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div>
                    <asp:Label runat="server" Text="Status: "></asp:Label>
                    <asp:RadioButtonList runat="server" ID="statusBtn" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="active" Text="active"></asp:ListItem>
                        <asp:ListItem Value="blocked" Text="block"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <br />
            <div>
                <asp:Button runat="server" ID="submitBtn" Text="Update User" OnClick="submitBtn_Click" />
                <asp:Label runat="server" ID="warningLbl"></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
