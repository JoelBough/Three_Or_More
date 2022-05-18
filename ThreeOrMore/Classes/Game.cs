using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeOrMore.Classes
{
    internal class Game
    {

        internal void PlayerTurn(SetOfDice dice, SetOfPlayers players)
        {
            try
            {
                dice.RollAllExcept(0);
                dice.WriteDice();
                int keep = 0;
                if (dice.ThreePlusCount() > 0)
                {
                    Console.WriteLine($"you have {dice.ThreePlusCount()} {dice.ThreePlus()}'s");
                    Console.WriteLine($"No more rolls available");
                    Console.Write("Press any key to get score");
                    Console.ReadKey();
                    Console.WriteLine("");

                }
                else if (dice.Pair2() != 0)
                {
                    Console.WriteLine($"2 pairs : {dice.Pair1()} and {dice.Pair2()}");
                    keep = 0;
                    while (keep != dice.Pair1() && keep != dice.Pair2())
                    {
                        Console.Write("Enter number of pair you would like to keep: ");
                        string input = Console.ReadLine();
                        if (input.Length == 1)
                        {
                            foreach(char c in "0123456789")
                            {
                                if (input[0] == c)
                                {
                                    keep = Convert.ToInt32(input);
                                }
                            }
                            
                        }
                        
                    }
                    Console.WriteLine("Final Dice: ");
                    dice.RollAllExcept(keep);

                    //ask which pair then call roll except on that number
                    //new exception for if its roll1 or roll 2 or other
                }
                else if (dice.Pair1() != 0)
                {
                    Console.WriteLine($"1 pair: {dice.Pair1()}'s");
                    Console.Write($"Press any key to reroll the other dice");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.WriteLine("Final Dice: ");
                    dice.RollAllExcept(dice.Pair1());
                }
                else
                {
                    Console.WriteLine("All dice are different");
                    keep = 0;
                    while (keep < 1 || keep > 6)
                    {

                        Console.Write("Type a number to keep: ");
                        string input = Console.ReadLine();
                        if (input.Length == 1)
                        {
                            foreach (char c in "0123456789")
                            {
                                if (input[0] == c)
                                {
                                    keep = Convert.ToInt32(input);
                                }
                            }
                        }

                    }
                    Console.WriteLine("Final Dice: ");
                    dice.RollAllExcept(keep);
                    //choose number to reroll except
                }
                dice.WriteDice();

            }
            catch (InvalidDiceValueException e)//catch custom exception
            {
                Console.WriteLine("Wrong number dude! Wrong number!");
            }
            players.UpdateScore(dice.ThreePlusCount());
        }

        internal void PlayOneGame(SetOfDice dice, SetOfPlayers players)
        {
            while (players.HasWon() == 0)
            {
                players.PlayerTurnChange();
                PlayerTurn(dice, players);
            }
            Console.WriteLine($"Player {players.HasWon()} Wins!");
            
        }

        public void PlayGame()
        {
            bool play = true;
            while (play)
            {
                SetOfPlayers players = new SetOfPlayers();
                SetOfDice dice = new SetOfDice();
                PlayOneGame(dice, players);
                Console.Write("Play again? (Y/N): ");
                string replay = String.Empty;
                while (replay != "Y" && replay != "N")
                {
                    replay = (Console.ReadLine()).ToUpper();
                    if(replay != "Y" && replay != "N")
                    {
                        Console.WriteLine("Enter Y or N");
                    }
                }
                play = replay == "Y";
            }
            Console.WriteLine("Thanks for playing!");
        }
    }
}

