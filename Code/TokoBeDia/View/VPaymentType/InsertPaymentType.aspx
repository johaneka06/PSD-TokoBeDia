﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertPaymentType.aspx.cs" Inherits="TokoBeDia.View.VPaymentType.InsertPaymentType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insert New Payment type</title>
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
            <asp:Label runat="server" Text="Insert New Paymet Type"></asp:Label>
            <br />
            <div>
                <asp:Label runat="server" Text="Payment Type Name: "></asp:Label>
                <asp:TextBox runat="server" ID="nameBox"></asp:TextBox>
                <asp:Label runat="server" ID="nameValidate"></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button runat="server" ID="insertBtn" Text="Submit" OnClick="insertBtn_Click" ValidationGroup="payment"/>
                <asp:Label runat="server" ID="warningLbl"></asp:Label> 
            </div>
        </div>
    </div>
    </form>
</body>
</html>
