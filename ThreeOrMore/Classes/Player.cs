using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeOrMore.Interfaces;

namespace ThreeOrMore.Classes
{
    public class Player: IPlayers
    {

        public Player()
        {
            Score = 0;
            
        }

        public int Score { get; set; }


        public void GetScore(int tally)
        {
            if (tally < 3)
            {
                Console.WriteLine($"Less than 3 of a kind: 0 points");
                Score = Score + 0;
            }
            else if (tally == 3)
            {
                Score = Score + 3;
                Console.WriteLine("3 of a kind: 3 points");
            }
            else if (tally == 4)
            {
                Score = Score + 6;
                Console.WriteLine("4 of a kind: 6 points");

            }
            else if (tally == 5)
            {
                Score = Score + 12;
                Console.WriteLine("5 of a kind: 12 points");

            }
        }
    }
}
