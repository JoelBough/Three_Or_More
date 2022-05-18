using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeOrMore.Classes;

namespace ThreeOrMore
{
    public class Start
    {
        static void Main()
        {
            StartGame();
        }

        static void StartGame()
        {
            Game game = new Game();
            game.PlayGame();
        }
    }
}

