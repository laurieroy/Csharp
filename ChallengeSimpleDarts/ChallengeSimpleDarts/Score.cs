using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public class Score
    {

            public static int DetermineScore(Dart dart)
            {
                int value = 0;
              
                if (dart.Score > 0) // assuming dart is thrown til in bounds (and in range 0-20)
                    value = (dart.IsTriple) ? dart.Score * 3 : ((dart.IsDouble) ? dart.Score * 2 : dart.Score); // case double or triple
                else
                    value = (dart.IsTriple && dart.Score == 0) ? 50 : 25; // case bullseye (also 5% of bull, else outer) 
                // used Bob's logic here but I think in reality it should be a different 5% chunk
                return value; 
            }


    }
    
}
