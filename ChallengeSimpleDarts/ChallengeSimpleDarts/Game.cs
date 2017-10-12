using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    // Two players will take turns throwing three darts per turn.
    // Their respective scores accumulate after each turn by adding
    // the score from each dart to the Player's score. 
    // The first Player to reach 300 points wins.  

    public class Game
    {
        private Random _random;

        public Game() // constuctor
        {
            _random = new Random();
        }


        public int[] Play()
        {
            int[] round = new int[2];
            Dart newDart = new Dart(_random);
            int Score1 = 0; // score1 belongs to Player1
            int Score2 = 0; // score2 belongs to Player2

            do
            {
                // Player 1 throws first, don't have to keep track of rounds 
                Score1 += PlayerRound();
                Score2 += PlayerRound(); 
             } while (!(Score1 >= 300 || Score2 >= 300));
            round[0] = Score1;
            round[1] = Score2;
            return round;
        }

        private int PlayerRound() // remeber do only 1 thing per method
        {
            int[] turn = new int[3];
            for (int i = 0; i <= 2; i++)
            {
                Dart newDart = new Dart(_random);
                newDart.Throw();
                turn[i] = Score.DetermineScore(newDart);
             
                
                // some type of logic to add to score 1 or 2/ Score1 += //string[] PlayerRound(); put these out into a string as did in previous challenge, returns int below
            }
            return turn.Sum();
         
        }
        /*
        public string DetermineWinner(int Score1, int Score2)
        {
            string winner = "";
            winner = (Score1 > Score2) ? "Player1" : "Player2"; // for when Score1 or Score2 >= 300;
            return winner;
        }
        */
        /*
                public string DetermineWinner
            {
                get;     // totally not sure if set his correctly or better below
                private set winner = (Score1 > Score2) ? "Player1" : "Player2";
                }
        */
    }
}