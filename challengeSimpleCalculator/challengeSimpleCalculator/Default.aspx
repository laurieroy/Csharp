<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="challengeSimpleCalculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-weight: 700; font-size: large">
    
        <h1>Simple Calculator</h1>
        <p class="auto-style2">
            First Value:&nbsp;
            <asp:TextBox ID="firstValueTextBox" runat="server" OnTextChanged="firstValueTextBox_TextChanged"></asp:TextBox>
        </p>
        <p class="auto-style2">
            Second Value:&nbsp;
            <asp:TextBox ID="secondValueTextBox" runat="server"></asp:TextBox>
        </p>
        <p class="auto-style2">
            <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="+" Width="36px" />
&nbsp;<asp:Button ID="subtractButton" runat="server" OnClick="subtractButton_Click" Text="-" Width="36px" />
&nbsp;<asp:Button ID="multButton" runat="server" OnClick="multButton_Click" Text="*" Width="36px" />
&nbsp;<asp:Button ID="divideButton" runat="server" OnClick="divideButton_Click" Text="/" Width="36px" />
        </p>
        <p class="auto-style2">
            &nbsp;</p>
        <p class="auto-style2">
            <asp:Label ID="resultLabel" runat="server" BackColor="#0099FF" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </p>
    
    </div>
    </form>
</body>
</html>
