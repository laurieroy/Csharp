<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeDaysBetweenDates.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dayspan Calendar Dates</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>How many days have elapsed?</h1>
        <br />
        <br />
        <strong>Choose first date:</strong><asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <br />
        <br />
        <br />
        <br />
        <strong>Choose a second date:</strong>
        <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
        <br />
        <asp:Button ID="okButton" runat="server" OnClick="okButton_Click" Text="See Days" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
