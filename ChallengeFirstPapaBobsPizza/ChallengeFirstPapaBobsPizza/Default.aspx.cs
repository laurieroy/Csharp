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
                order  = order + crust;
            }
            else { totalLabel.Text = "Please select a crust type."; }
            // Get toppings
            if (pepperoniCheckBox.Checked)
            {
                toppings +=  " pepperoni, ";
                total += 1.50;
                
            }
            else if (onionsCheckBox.Checked)
            {
                toppings +=  " onions, ";
                total +=  0.75;
          
            }
            else if(greenPeppersCheckBox.Checked)
            {
                toppings = toppings + " green peppers, ";
                total +=  .50;
       
            }
            else if(redPeppersCheckBox.Checked)
            {
                toppings = toppings + " red peppers, ";
                total += 0.75;
             
            }
            else if(anchoviesCheckBox.Checked)
            {
                toppings +=  " anchovies, ";
                total += 2;
             
            }
            //order = order + toppings;

            else { totalLabel.Text = "Just to confirm, you want a plain cheese pizza?"; }
            // Check if Special Deal applies:
            if ((pepperoniCheckBox.Checked && greenPeppersCheckBox.Checked && anchoviesCheckBox.Checked)
                || (pepperoniCheckBox.Checked && redPeppersCheckBox.Checked && onionsCheckBox.Checked))
            {
                total = total - 2;
            }
            totalLabel.Text = "Total: $" + total;
            orderLabel.Text = order+toppings;
        }


    }
}