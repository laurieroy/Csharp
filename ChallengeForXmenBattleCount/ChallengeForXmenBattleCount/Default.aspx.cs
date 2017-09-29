using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeForXmenBattleCount
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Wolverine fewest battles
            // Pheonix most battles

            string[] names = new string[] { "Professor X", "Iceman", "Angel", "Beast", "Pheonix", "Cyclops", "Wolverine", "Nightcrawler", "Storm", "Colossus" };
            int[] numbers = new int[] { 7, 9, 12, 15, 17, 13, 2, 6, 8, 13 };
            // thier soln smallestNumberIndex ="";
            //     largestNumberIndex ="";
            string result = "";

            for (int i = 0; i < names.Length; i++)
            {
                if (numbers[i] == numbers.Max())
                {

                    result = String.Format("Most Battles belongs to : {0} (value: {1})<br />", names[i], numbers[i].ToString());
                }
                if (numbers[i] == numbers.Min())
                {
                    result += String.Format("Least Battles belongs to : {0} (value: {1})", names[i], numbers[i].ToString());
                    break;
                }
                /* Their solution wrote it out which is probably what happens behind the scense with max and min
                 if (numbers[i] > number[largestNumberIndex])
                 {
                    largestNumberIndex = i;
                 }             
                 if (numbers[i] < number[smallestNumberIndex])
                 {
                    smallestNumberIndex = i;
                 }
                 
                
                 
            }
            result = String.Format("Most Battles belongs to : {0} (value: {1})<br />", names[largestNumberIndex], numbers[largestNumberIndex]);
            result += String.Format("<br />Least Battles belongs to : {0} (value: {1})", names[smallestNumberIndex], numbers[smallestNumberIndex]);
            */
            }
            resultLabel.Text = result; 
        }
    }
}