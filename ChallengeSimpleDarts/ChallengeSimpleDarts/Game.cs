using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
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
                // Player 1 throws first, add keep track of rounds, display round scores.
                Score1 += PlayerRound();
                Score2 += PlayerRound(); 
             } while (!(Score1 >= 300 || Score2 >= 300));
            round[0] = Score1;
            round[1] = Score2;
            return round;
        }

        private int PlayerRound() 
        {
            int[] turn = new int[3];
            for (int i = 0; i <= 2; i++)
            {
                Dart newDart = new Dart(_random);
                newDart.Throw();
                turn[i] = Score.DetermineScore(newDart);
            }
            return turn.Sum();
         
        }
    }
}