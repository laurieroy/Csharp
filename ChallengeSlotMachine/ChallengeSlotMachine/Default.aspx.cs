using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeSlotMachine
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string imageFirst = getImages();    // probably don't need all of this, but check
                image1.ImageUrl = "/Images/" + imageFirst + ".png";
                //ViewState.Add("FirstReel", imageFirst);
                string imageSecond = getImages();
                image2.ImageUrl = "/Images/" + imageSecond + ".png";
                //ViewState.Add("SecondReel", imageSecond);
                string imageThird = getImages();
                image3.ImageUrl = "/Images/" + imageThird + ".png";
                //ViewState.Add("ThirdReel", imageThird);

                betTextBox.Text = "";
                resultLabel.Text = "Please enter a bet.";
                int pot = 100;
                displayPot(pot);
                ViewState.Add("Pot", pot);
            }
        }
        
        protected void spinButton_Click(object sender, EventArgs e)
        {
            // Get 3 random images           // do while money > 0 (Can determine min bet if you want) 
            resultLabel.Text = "in button";   // DELETE
            int pot = getPot();
            int bet = getBet();
            bet = checkBet(bet, pot); 
            spinReel(bet, pot);      //   runImages() // gets new random images. 
            //    runs them through the logic of what wins / losses are. displays result
            //adjustPot(winnings, pot); // adds winnings or subtracts bet

        }

        /*  */
        private int getPot()
        {
            int pot = (int)ViewState["Pot"];       
            ViewState["Pot"] = pot;
            moneyLabel.Text = String.Format("Current pot: {0:C}.", pot);
            //if want to blank out winning box while play slots
            // moneyLabel.Text = "";
            return pot;
        }
      
        private int getBet() // read bet text. if blank, ask for value.  if bad chars, get new. else parse.
        {
            // get bet for this round
            int bet = 0;
            string sbet = betTest(betTextBox.Text);
            verifyBet(sbet);
            
            return bet;
        }
        
        private string betTest(string s) // Do you recommend a better way to check this?
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                resultLabel.Text = "Please enter a new bet.";
                return s;
            }      
            else
                return s;
        }
        private void verifyBet(string sbet)
        {
            int bet = 0;
            if (Int32.TryParse(betTextBox.Text, out bet));
            else resultLabel.Text = String.Format("Please enter a number less than your pot.");
            return;
        }
        private int checkBet(int bet, int pot) // check if pot covers bet. if yes, 
        { 
            // checking to be sure pot covers bet
            while (bet > pot) {
                resultLabel.Text = String.Format("Please enter a new bet. The pot is only {0:C}.", pot);
                getBet();
            }
            return bet;
        }

        private void spinReel(int bet, int pot)                              // work on this * **********************
        {
            string[] imageResults = displayImages();
            //string[] imageResults = new string[] { "imageFirst", "imageSecond", "imageThird" };
            //runImages(); if gets too long, break into method
            resultLabel.Text = "";
            int result = didWinLose(bet, pot, imageResults); // loser = -1 if lost, 0 if not. sevens = 0 if not 100, cherries = 0,2,3,4
            /*
            // declare any vars                                            
            do
            {
                /* from web
                for (i as Integer = 1 to 3)
                    Dim img As Image = CType(Form.FindControl("image" & i.ToString()), Image)
                    img.ImageUrl = getImageUrlForI(i)
                Next
                */
            /*

            // fuck. deleted out the while bit

            */

        }

        private string[] displayImages()
        {
            string imageFirst = getImages();
            image1.ImageUrl = "/Images/" + imageFirst + ".png";
            string imageSecond = getImages();
            image2.ImageUrl = "/Images/" + imageSecond + ".png";
            string imageThird = getImages();
            image3.ImageUrl = "/Images/" + imageThird + ".png";
            string[] imageResults = new string[] { "imageFirst", "imageSecond", "imageThird" };
            return imageResults;
        }

        private string getImages() //grab one of 12 images in random order. 
        {
            string[] images = new string[] {
                "Bar", "Lemon", "Strawberry", "HorseShoe", "Watermelon", "Diamond",
                "Bell", "Orange", "Plum", "Clover", "Cherry", "Seven" };
            return images[random.Next(11)];
        }
        /*
        runImages()
        {
            // clear result label
            resultLabel.Text = "";
            didWinLose(bet);
            // didWin logic. i feel like this should be a switch table, whatever it is we have in c#
            // did Win calls adjust Pot and updates  moneyLabel. Bet remains.
           
        }
        */
        /*
        private string retrieveImages(string imageResults) // i guess i hsould put in mem and not viewstate TODO ************************
        {
            string imageFirst = ViewState["FirstImage"].ToString();
            string imageFirst = 
            string imageSecond = ViewState["SecondImage"].ToString();
            return imageFirst;
            string imageThird = ViewState["ThirdImage"].ToString();
            return imageFirst;
        }
        */
        private int didWinLose(int bet, int pot, string[] imageResults) // still need to add in bit subracting out each round. rewrite winnings in memory
        {
            int sevens = 0; // think about this logic for a bit.
            int cherries = 0;
            int loser = 0;

            loser = didLose(bet, imageResults);
            int result = loser; 
            while (loser != -1)
            {
                sevens = didWin7(imageResults);
                if (sevens > result) result = sevens;
                int winnings = (sevens != 0) ? determineWinnings(bet, sevens) : 0;  //displayWin(bet, winnings) : ;
                       
                cherries = didWinCherries(imageResults); // returns 0-4 if won cherries. 
                if (cherries > result) result = cherries;
                int roundWinnings = (cherries != 0) ? determineWinnings(bet, cherries) : 0;   //displayWin(bet, cherries);
            } 
            return result;
        }

        private int didLose(int bet, string[] imageResults) // need to think this logic A BI. loss = true? or number? boolean is 0 or 1
        {
            string imageFirst = imageResults[0];//ViewState["FirstImage"].ToString();
            string imageSecond = imageResults[1]; //ViewState["SecondImage"].ToString();// MAYBE CHANGE THIS UP *************************************
            string imageThird = imageResults[2];//ViewState["ThirdImage"].ToString();

            if (imageFirst == "Bar" || imageSecond == "Bar" || imageThird == "Bar")
            {
                // 1 bar loses
                int factor = -1;
                int pot = determineWinnings(bet, factor);
                displayLose(bet);
                return factor;
            }
            else return 0;
        }

        private int didWin7(string[] imageResults)
        {
            int factor = 0;
            string imageFirst = imageResults[0];//ViewState["FirstImage"].ToString();
            string imageSecond = imageResults[1]; //ViewState["SecondImage"].ToString();// MAYBE CHANGE THIS UP *************************************
            string imageThird = imageResults[2];//ViewState["ThirdImage"].ToString();

            if (imageFirst == "Seven" && imageSecond == "Seven" && imageThird == "Seven")
            {
                return factor = 100;
            }
            else return factor;
        }
        private int didWinCherries(string[] imageResults)
        {
            int factor = 0;
            string imageFirst = imageResults[0];//ViewState["FirstImage"].ToString();
            string imageSecond = imageResults[1]; //ViewState["SecondImage"].ToString();// MAYBE CHANGE THIS UP *************************************
            string imageThird = imageResults[2];//ViewState["ThirdImage"].ToString();

            if (imageFirst == "Cherry" || imageSecond == "Cherry" || imageThird == "Cherry") 
            {
                return factor = 2;
                if (imageFirst == "Cherry" && imageSecond == "Cherry"
                    || imageSecond == "Cherry" && imageThird == "Cherry"
                    || imageFirst == "Cherry" && imageThird == "Cherry")
                {
                    return factor = 3;
                    if (imageFirst == "Cherry" && imageSecond == "Cherry" && imageThird == "Cherry") return factor = 4;
                }
            }
            return factor; // might need else here
        }


        private int determineWinnings(int bet, int factor)
        { 
            int winnings = bet * factor;
            
            return winnings;
        }

        private int adjustPot(int winnings, int pot)
        {
            pot = pot + winnings;
            return pot;
        }

        private void displayPot(int pot)
        {
            moneyLabel.Text = String.Format("Current pot: {0:C}", pot);
        }
        
        private void displayWin(int bet, int winnings) // grab winnnings from viewstate //! doh. need anotehr step, determine winnings
        {
            resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", bet, winnings);
        }
        
        private void displayLose(int bet)
        {
            resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.", bet);
        }

 

    }
}