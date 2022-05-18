using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeOrMore.Classes
{
    internal class Game
    {

        internal void RunGame(SetOfDice dice, SetOfPlayers players)
        {
            players.PlayerTurnChange();
            for (int rolling = 1; rolling < 2; rolling++)
            {
                try
                {
                    players.AddPlayers();
                    dice.WriteDice();
                    int keep = 0;
                    if (dice.ThreePlusCount() > 0)
                    {
                        Console.WriteLine($"you have {dice.ThreePlusCount()} {dice.ThreePlus()}'s");
                        Console.WriteLine($"No more rolls available");
                        rolling++;
                        Console.WriteLine("Press any key to get score");
                        Console.ReadKey();
                    }
                    else if (dice.Pair2() != 0)
                    {
                        Console.WriteLine($"2 pairs : {dice.Pair1()} and {dice.Pair2()}");
                        keep = 0;
                        while (keep != dice.Pair1() && keep != dice.Pair2())
                        {
                            Console.Write("Enter number of pair you would like to keep: ");
                            keep = Convert.ToInt32(Console.ReadLine());
                        }
                        dice.RollAllExcept(keep);

                        //ask which pair then call roll except on that number
                        //new exception for if its roll1 or roll 2 or other
                    }
                    else if (dice.Pair1() != 0)
                    {
                        Console.WriteLine($"1 pair: {dice.Pair1()}'s");
                        Console.WriteLine($"Press any key to reroll the other dice");
                        Console.ReadKey();
                        dice.RollAllExcept(dice.Pair1());
                    }
                    else
                    {
                        Console.WriteLine("All dice are different");
                        keep = 0;
                        while (keep < 1 || keep > 6)
                        {
                            Console.Write("Type a number to keep: ");
                            keep = Convert.ToInt32(Console.ReadLine());

                        }
                        dice.RollAllExcept(keep);
                        //choose number to reroll except
                    }
                    dice.WriteDice();
                    rolling++;

                }
                catch (InvalidDiceValueException e)//catch custom exception
                {
                    Console.WriteLine("Wrong number dude! Wrong number!");
                }
            }
            players.UpdateScore(dice.ThreePlusCount());
        }

        internal void WinGame(SetOfDice dice, SetOfPlayers players)
        {
            while (players.HasWon() == 0)
            {
                RunGame(dice, players);
            }
            Console.WriteLine($"Player {players.HasWon()} Wins!");
            
        }

        public void PlayGame()
        {
            SetOfPlayers players = new SetOfPlayers();
            SetOfDice dice = new SetOfDice();
            WinGame(dice, players);
            bool play = true;
            while (play)
            {
                Console.Write("Play again? (Y/N): ");
                string replay = (Console.ReadLine()).ToUpper();
                if (replay == "Y")
                {
                    PlayGame();
                }
                else if(replay == "N")
                {
                    play = false;
                }
                else if(replay != "Y" && replay != "N")
                {
                    Console.WriteLine("Enter Y or N");
                }
            }
            Console.WriteLine("Thanks for playing!");

        }
    }
}

