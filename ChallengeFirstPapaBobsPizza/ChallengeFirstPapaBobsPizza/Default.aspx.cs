using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeFirstPapaBobsPizza
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void orderButton_Click(object sender, EventArgs e)
        {
            // define vars
            double total = 0.00;
            string order = "You ordered: ";
            string crust = "";
            string toppings = "";

            // Get size
            if (smallRadioButton.Checked)
            {
                total = 10;
                order = "small pie,";
            }
            else if (medRadioButton.Checked)
            {
                total = 13;
                order = "medium pie,";
            }
            else if (lgRadioButton.Checked)
            {
                total = 16;
                order = "large pie,";
            }
            else { totalLabel.Text = "Please select a size."; }
            // Get crust type
            if (deepCrustRadioButton.Checked)
            {
                crust = " deep crust,";
                total += 2;
                order +=  crust;
            }
            else if (thinCrustRadioButton.Checked)
            {
                // no change to total
                crust = " thin curst, ";
                order += crust;
            }
            else { totalLabel.Text = "Please select a crust type."; }
            // Get toppings
            total = (pepperoniCheckBox.Checked) ? total + 1.5 : total;
            total = (onionsCheckBox.Checked) ? total + .75 : total;
            total = (greenPeppersCheckBox.Checked) ? total + 0.5 : total;
            total = (redPeppersCheckBox.Checked) ? total + .75 : total;
            total = (anchoviesCheckBox.Checked) ? total + 2 : total;

            order = (pepperoniCheckBox.Checked) ? order + " pepperoni, " : order;
            order = (onionsCheckBox.Checked) ? order + " onions, " : order;
            order = (greenPeppersCheckBox.Checked) ? order + "green peppers, " : order;
            order = (redPeppersCheckBox.Checked) ? order + " red peppers, " : order;
            order = (anchoviesCheckBox.Checked) ? order + " anchovies, " : order;

            // else { totalLabel.Text = "Just to confirm, you want a plain cheese pizza?"; }
            // Check if Special Deal applies:
            if ((pepperoniCheckBox.Checked && greenPeppersCheckBox.Checked && anchoviesCheckBox.Checked)
                || (pepperoniCheckBox.Checked && redPeppersCheckBox.Checked && onionsCheckBox.Checked))
            {
                total -= 2;
            }
            totalLabel.Text = "Total: $" + total.ToString();
            orderLabel.Text = order;
        }


    }
}