using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeOrMore.Classes
{
    internal class SetOfPlayers
    {
        private List<Player> _players = new List<Player>();
        public int turn = -1;

        public SetOfPlayers()
        {
            SetOfDice die = new SetOfDice();
            AddPlayers();
        }

        public void AddPlayers()
        {
            for (int i = 0; i < 2; i++)
            {
                _players.Add(new Player());
            }
        }

        public void PlayerTurnChange()
        {
            turn++;
            turn = turn % 2;
            Console.WriteLine($"Player {turn +1}'s turn");
            Console.WriteLine("Press any key to roll");
            Console.ReadKey();

        }

        public void UpdateScore(int ThreePlusCount)
        {
            _players[turn].GetScore(ThreePlusCount);
            Console.WriteLine($"Player 1 Score: {_players[0].Score}");
            Console.WriteLine($"Player 2 Score: {_players[1].Score}");
        }

        public int HasWon()
        {
            if(_players[0].Score > 2)
            {
                return 1;
            }
            else if(_players[1].Score > 2)
            {
                return 2;
            }
            return 0;
        }
        


    }
}
