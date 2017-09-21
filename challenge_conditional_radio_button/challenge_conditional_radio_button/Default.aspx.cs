using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace challenge_conditional_radio_button
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void okButton_Click(object sender, EventArgs e)
        {
            if (pencilRadioButton.Checked)
            {
                itemImage.ImageUrl = "pencil.png";
                //resultLabel.Text = "You selected pencil.";
            
            }
            else if (penRadioButton.Checked)
            {
                itemImage.ImageUrl = "pen.png";
                //resultLabel.Text = "You selected pen.";
            }
            else if (phoneRadioButton.Checked)
            {
                itemImage.ImageUrl = "phone.png";
                //resultLabel.Text = "You selected phone.";
            }
            else if (tabletRadioButton.Checked)
            {
                itemImage.ImageUrl = "tablet.png";
                //resultLabel.Text = "You selected tablet.";
            }
            
            else { resultLabel.Text = "Please select an option."; }
            
        }
    }
}