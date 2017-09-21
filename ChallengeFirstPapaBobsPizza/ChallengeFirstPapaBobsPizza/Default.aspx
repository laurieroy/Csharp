<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeFirstPapaBobsPizza.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style2 {
            color: #FF0000;
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="logoImage" runat="server" ImageAlign="Baseline" ImageUrl="~/PapaBob.png" Width="200px" />
&nbsp;
        <h1 class="auto-style1">Papa Bob&#39;s Pizza and Software</h1>
    
    </div>
        <asp:RadioButton ID="smallRadioButton" runat="server" GroupName="sizeGroup"  Text="Baby Bob Size (10&quot;)-$10" />
        <br />
        <asp:RadioButton ID="medRadioButton" runat="server" GroupName="sizeGroup" Text="Mama Bob Size (13&quot;)-$13" />
        <br />
        <asp:RadioButton ID="lgRadioButton" runat="server" GroupName="sizeGroup" Text="Papa Bob Size (16&quot;)-$16" />
        <br />
        <br />
        <asp:RadioButton ID="thinCrustRadioButton" runat="server" GroupName="crustGroup"  Text="Thin Crust" /> 
        
        <br />
        <asp:RadioButton ID="deepCrustRadioButton" runat="server" GroupName="crustGroup" Text="Deep Dish(+$2)" />
        <br />
        <br />
        <asp:CheckBox ID="pepperoniCheckBox" runat="server" Text="Pepperoni(+$1.50)" ValidationGroup="toppingsGroup" />
        <br />
        <asp:CheckBox ID="onionsCheckBox" runat="server" Text="Onions(+$0.75)" ValidationGroup="toppingsGroup" />
        <br />
        <asp:CheckBox ID="greenPeppersCheckBox" runat="server" Text="Green Peppers (+$0.50)" ValidationGroup="toppingsGroup" />
        <br />
        <asp:CheckBox ID="redPeppersCheckBox" runat="server" Text="Red Peppers(+$0.75)" ValidationGroup="toppingsGroup" />
        <br />
        <asp:CheckBox ID="anchoviesCheckBox" runat="server" Text="Anchovies(+$2)" ValidationGroup="toppingsGroup" />
        <br />
        <br />
        <h2><span class="auto-style1"><strong>Papa Bob&#39;s </strong></span><span class="auto-style2"><strong>Special Deal</strong></span></h2>
        <br />
        Save $2 when you add Pepperoni, Green Peppers and Anchovies OR Pepperoni, Red Peppers and Onions to your pizza.<br />
        <br />
        <asp:Button ID="orderButton" runat="server" OnClick="orderButton_Click" Text="Purchase" />
        <br />
        <br />
        <asp:Label ID="orderLabel" runat="server"></asp:Label>
        <br />
        <asp:Label ID="totalLabel" runat="server"></asp:Label>
        <br />
        <br />
        Sorry, at this time you can only order one pizza online, and pick-up only... we need a better website!<br />
    </form>
</body>
</html>
