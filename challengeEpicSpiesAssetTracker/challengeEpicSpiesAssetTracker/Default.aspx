<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="challengeEpicSpiesAssetTracker.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 242px;
            height: 300px;
        }
        .auto-style2 {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="epic spies logo" class="auto-style1" height="150" src="epic-spies-logo.jpg" /><br />
        <h1 class="auto-style2">Asset Performance Tracker</h1>
        <br />
        Asset Name:
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Elections Rigged:
        <asp:TextBox ID="riggedTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Acts of Subterfuge Performed:
        <asp:TextBox ID="actsTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Add Asset" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
