using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Dart
    {
        public int Score { get; set; }
        public bool IsDouble { get; set; }
        public bool IsTriple { get; set; }

        private Random _random;

        public Dart(Random random)
        {
            _random = random;
        }
     
        public void Throw() 
        {
            //The dart has an equal chance of scoring one through twenty, or the bullseye(0).
            Score = _random.Next(0, 21); // have to put 21 to include the 20 as is exclusive
            
            int multiplier = _random.Next(1, 101);
            if (multiplier > 95) IsTriple = true; // 5% chance
            else if (multiplier > 90) IsDouble = true;
           
        }
    }
}
