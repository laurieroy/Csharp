using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Calculate cost to ship given parcel using size/volume and shipping method to give cost.
// Checks need work, but bare functionality is there.

namespace ChallengePostalCalculatorHelperMethods
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void handleChange(object sender, EventArgs e) // condensed code by putting all changes in one. woot.
        {
            calculatePostage();
        }

        private void calculatePostage()
        {
            if (!valuesExist()) return;

            double size = 0.0;
            if (!checkSize()) return;
            size = getSize();

            double rate = 0.0;
            rate = getRate();

            double postage = 0.0;
            postage = size * rate;

            resultLabel.Text = String.Format("Package size is {0}, shipping costs {1:C}.", size, postage);
            /* add in state
            widthTextBox.Text = "";
            lengthTextBox.Text = "";
            heightTextBox.Text = "";
            */
        }

        private bool valuesExist()
        {
            //  Check to be sure bare minimum filled in

            if (widthTextBox.Text.Trim().Length == 0 || lengthTextBox.Text.Trim().Length == 0)
                return false;

            if (!groundRadioButton.Checked &&
                !airRadioButton.Checked &&
                !nextRadioButton.Checked)
                return false;
            return true;

        }

        private bool checkSize()
        {
            // check that we have the right type of data, return 
            double width = 0;
            double length = 0;
            double height = 0;

            if (!double.TryParse(widthTextBox.Text, out width)) return false;
            if (!double.TryParse(lengthTextBox.Text, out length)) return false;
            // if (!double.TryParse(heightTextBox.Text, out height)) return false;

            return true;
        }
        private double getSize()
        { //get dimensions from UI, call calculateSize method, returning size

            double size = 0.0;
            double width = 0;
            double length = 0;
            double height = 0;

            width = double.Parse(widthTextBox.Text.Trim());
            length = double.Parse(lengthTextBox.Text.Trim());
            height = (heightTextBox.Text.Length > 0) ? double.Parse(heightTextBox.Text.Trim()) : 1;

            size = calculateSize(length, width, height);
            return size;
        }

        private double calculateSize(double length, double width, double height = 1)
        {   // determine size | volume of package
            double size = length * width * height;
            return size;
        }

        private double getRate()
        {   // get rate from radio buttons
            double groundRate = .15;
            double airRate = .25;
            double nextRate = .45;

            if (groundRadioButton.Checked) return groundRate;
            else if (airRadioButton.Checked) return airRate;
            else if (nextRadioButton.Checked) return nextRate;
            else resultLabel.Text = "Please select a shipping method.";
            return 0;
        }
    }
}
