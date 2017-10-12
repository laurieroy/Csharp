using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeSimpleDarts
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Try to keep the classes as short as possible and cohesive.
        //Try to keep the methods as short as possible...no more than 6 lines of code.


        protected void okButton_Click(object sender, EventArgs e)
        {
            Game game = new ChallengeSimpleDarts.Game();
            int[] scores = new int[2];
            scores =game.Play();
            int Score1 = scores[0];
            int Score2 = scores[1]; // GetScores needs to be written under Game
            string winner = (Score1 > Score2) ? "Player1" : "Player2";
            DisplayScore(Score1, Score2, winner);

        }

 
        public void DisplayScore(int Score1, int Score2, string winner)
        {
            resultLabel.Text = String.Format("Player1: {0} <br/> Player2: {1}  <br/> Winner: {2}", Score1, Score2, winner);
        }
        
    }
}