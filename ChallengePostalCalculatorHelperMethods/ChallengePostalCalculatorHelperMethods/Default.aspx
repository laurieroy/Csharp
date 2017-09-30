<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengePostalCalculatorHelperMethods.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="shipping">
    
        Postal Calculator<br />
        <p>
        Width:&nbsp;&nbsp;
        <asp:TextBox ID="widthTextBox" runat="server" OnTextChanged="handleChange" AutoPostBack="True"></asp:TextBox>
        </p>
        Length:
        <asp:TextBox ID="lengthTextBox" runat="server" OnTextChanged="handleChange" AutoPostBack="True"></asp:TextBox>
        <p>
        Height:&nbsp;&nbsp;
        <asp:TextBox ID="heightTextBox" runat="server" OnTextChanged="handleChange" AutoPostBack="True"></asp:TextBox>
        </p>
        <asp:RadioButton ID="groundRadioButton" runat="server" AutoPostBack="True" OnCheckedChanged="handleChange" GroupName="shippingType" Text="Ground" />
        <br />
        <asp:RadioButton ID="airRadioButton" runat="server" AutoPostBack="True" OnCheckedChanged="handleChange" GroupName="shippingType" Text="Air" />
        <br />
        <asp:RadioButton ID="nextRadioButton" runat="server" AutoPostBack="True" OnCheckedChanged="handleChange" GroupName="shippingType" Text="Next Day" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
