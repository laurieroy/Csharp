﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace challengeSimpleCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {

            double firstValue_dbl = double.Parse(firstValueTextBox.Text);
            double secondValue_dbl = double.Parse(secondValueTextBox.Text);

            double result_dbl = firstValue_dbl + secondValue_dbl;

            resultLabel.Text = result_dbl.ToString();
        }

        protected void multButton_Click(object sender, EventArgs e)
        {
            double firstValue_dbl = double.Parse(firstValueTextBox.Text);
            double secondValue_dbl = double.Parse(secondValueTextBox.Text);

            double result_dbl = firstValue_dbl * secondValue_dbl;

            resultLabel.Text = result_dbl.ToString();
        }

        protected void subtractButton_Click(object sender, EventArgs e)
        {
            double firstValue_dbl = double.Parse(firstValueTextBox.Text);
            double secondValue_dbl = double.Parse(secondValueTextBox.Text);

            double result_dbl = firstValue_dbl - secondValue_dbl;

            resultLabel.Text = result_dbl.ToString();

        }

        protected void divideButton_Click(object sender, EventArgs e)
        {
            double firstValue_dbl = double.Parse(firstValueTextBox.Text);
            double secondValue_dbl = double.Parse(secondValueTextBox.Text);

            double result_dbl = firstValue_dbl / secondValue_dbl;

            resultLabel.Text = result_dbl.ToString();
        }

        protected void firstValueTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}