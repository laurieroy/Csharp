<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeSlotMachine.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laurie's Slot machine game</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="image1" runat="server" Height="96px" Width="80px" />
        <asp:Image ID="image2" runat="server" Height="96px" Width="80px" />
        <asp:Image ID="image3" runat="server" Height="96px" Width="80px" />
    
    </div>
        <p>
            Your Bet: $<asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="spinButton" runat="server" OnClick="spinButton_Click" Text="Pull the Lever!" />
        </p>
        <p>
            <asp:Label ID="resultLabel" runat="server" style="font-weight: 700"></asp:Label>
        </p>
        <p>
            <asp:Label ID="moneyLabel" runat="server" style="font-weight: 700"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            1 Cherry - x2&nbsp; Your Bet</p>
        <p>
            2 Cherries - x3 Your Bet</p>
        <p>
            3 Cherries - x4 Your Bet</p>
        <p>
            3 7&#39;s - Jackpot! - x100 Your Bet</p>
        <p>
            HOWEVER... If there is even one bar, you win nothing.</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
