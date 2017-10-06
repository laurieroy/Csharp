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
                string[] imageResults = new string[] { getImages(), getImages(), getImages() };
                displayImages(imageResults);
                int pot = 100;
                resultLabel.Text = "Please enter a bet.";
                displayPot(pot);
                ViewState.Add("Pot", 100);
            }
        }

        protected void spinButton_Click(object sender, EventArgs e) // bob's pullButton
        {
          
            int pot = getPot();
            int bet = getBet(); // bet is 0 or an int ******************************************
            bet = checkBet(bet, pot); // his code lets you bet -# to earn money

            string[] imageResults = pullLever(bet, pot); // his winnings, confirm it matchs yours *********
            int winnings = nameMethod(bet, pot, imageResults); //#103 *************somewhere here it dies. either this or didWin
            int result = didWinLose(bet, pot, imageResults); //***********************************
            displayResult(bet, winnings);
        }

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
            int bet = 0;
            betTest(betTextBox.Text);
            //if (!int.TryParse(betTextBox.Text, out bet)) return bet;
            //else return bet;
            bet = verifyBet(betTextBox.Text);
            return bet;
        }
        // Bob's code just has the one line above, opposite logic
        private void betTest(string s) // Do you recommend a better way to check this?
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                resultLabel.Text = "<p style =\"color:#ee3b32;\" > Please enter a new bet.</p>";
                return; //returns blank to not break code
            }      
            else return;
        }

        private int verifyBet(string sbet) //, out int bet
        {
            int bet = 0;
            if (Int32.TryParse(betTextBox.Text, out bet)) ; // just added return. 
    
            else
                resultLabel.Text = String.Format("Please enter a number less than your pot.");
            return bet;
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
        /*
        private void spinReel(int bet, int pot, )    //, string[] images     //bob's code spin reel is getImages , this is his pullLever  // work on this * **********************
        {
            resultLabel.Text = "";
  
            int winnings = pullLever(bet, pot); //string[] imageResults = removed string [] from return***********************
            int result = didWinLose(bet, pot, imageResults); // loser = -1 if lost, 0 if not. sevens = 0 if not 100, cherries = 0,2,3,4
                    
        }
        */

        private  string[] pullLever(int bet, int pot) //string[] // he has pullLever managing most stuff. // lookup what static is
        {
            string[] imageResults = new string[] { getImages(), getImages(), getImages() };
            displayImages(imageResults);
            return imageResults;
        }

        private int nameMethod(int bet, int pot,  string[] imageResults)
        {
        int factor = didWinLose(bet, pot, imageResults); // factor - 0:loss, 100:jackpot 2,3,4 :cherries
        return bet* factor; // his code has it here. 
        }

        private void displayImages(string[] images) 
        {
            image1.ImageUrl = "/Images/" + images[0] + ".png";
            image2.ImageUrl = "/Images/" + images[1] + ".png";
            image3.ImageUrl = "/Images/" + images[2] + ".png";
        }

        private string getImages() //grab one of 12 images in random order. 
        {
            string[] images = new string[] {
                "Bar", "Lemon", "Strawberry", "HorseShoe", "Watermelon", "Diamond",
                "Bell", "Orange", "Plum", "Clover", "Cherry", "Seven" };
            return images[random.Next(11)];
        }

        private int didWinLose(int bet, int pot, string[] imageResults) // still need to add in bit subracting out each round. rewrite winnings in memory
        {
            int cherries = 0;

            if (didLose(bet, imageResults)) return -1; // allows factor * bet to subtract
            if (didWin7(imageResults)) return 100;
            if (didWinCherries(imageResults, out cherries)) return cherries;
            return 0;
        }

        private bool didLose(int bet, string[] imageResults) 
        {
            if (imageResults[0] == "Bar" || imageResults[1] == "Bar" || imageResults[2] == "Bar")
                return true;
            else return false;
        }

        private bool didWin7(string[] imageResults)
        {
            if (imageResults[0] == "Seven" && imageResults[1] == "Seven" && imageResults[2] == "Seven")
                return  true;
            else return false;
        }

        private bool didWinCherries(string[] imageResults, out int factor)
        {
            factor = determineFactor(imageResults);
            if (factor > 0) return true;
            return false;
        }

        private int determineFactor(string[] imageResults )
        {
            int cherryCount = determineCherryCount(imageResults);
            if (cherryCount == 1) return 2;
            if (cherryCount == 2) return 3;
            if (cherryCount == 3) return 4;
            return 0;
        }

        private int determineCherryCount(string[] imageResults) // broke method into 2
        {
            int cherryCount = 0;
            if (imageResults[0] == "Cherry") cherryCount++;
            if (imageResults[1] == "Cherry") cherryCount++;
            if (imageResults[2] == "Cherry") cherryCount++;
            return cherryCount;
        }
        private int determineWinnings(int bet, int factor)
        { 
            int winnings = bet * factor; // took out the cases where factor = -1 or 1 so now broken
            return winnings;
        }

        private int adjustPot(int winnings, int pot)
        {
            pot += winnings;
            return pot;
        }
        // Question to instructor, what is advantage of using viewstate for pot instead of var
        private void displayPot(int pot)
        {
            moneyLabel.Text = String.Format("Current pot: {0:C}", pot);
        }
        /*
        private void displayWin(int bet, int winnings) // grab winnnings from viewstate //! doh. need anotehr step, determine winnings
        {
            resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", bet, winnings);
        }
        
        private void displayLose(int bet)
        {
            resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.", bet);
        }
        */

        private void displayResult(int bet, int winnings)
        {
            if (winnings > 0)
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", bet, winnings);
            else
                resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.", bet);
        }

    }
}