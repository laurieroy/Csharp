<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Challenge_EpicSpiesAssignment.Default" MaintainScrollPositionOnPostback="true" %>

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
    
        <h2>
            <img id="logo" alt="Epic Spies Logo" class="auto-style1" height="190" src="epic-spies-logo.jpg" /></h2>
        <h2><span class="auto-style2">Spy New Assignment Form</span></h2>
        <br />
        Spy Code Name:
        <asp:TextBox ID="spyNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        New Assignment Name:
        <asp:TextBox ID="newOpNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <p>
            End Date of Previous Assignment:</p>
        <p>
            <asp:Calendar ID="lastAssCalendar" runat="server"></asp:Calendar>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Start Date of Next Assignment:</p>
        <p>
            <asp:Calendar ID="nextAssCalendar" runat="server"></asp:Calendar>
        </p>
        <p>
            Projected End Date of Next Assignment:</p>
        <p>
            <asp:Calendar ID="endAssCalendar" runat="server"></asp:Calendar>
        </p>
        <p>
            <asp:Button ID="okButton" runat="server" OnClick="okButton_Click" Text="Assign Spy" />
        </p>
        <p>
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </p>
    
    </div>
    </form>
</body>
</html>
