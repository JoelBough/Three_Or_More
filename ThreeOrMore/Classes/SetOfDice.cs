using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeOrMore.Classes
{
    internal class SetOfDice
    {
        private List<Die> _dice = new List<Die>();
        private int _pair1 = 0;
        private int _pair2 = 0;
        private int _threePlus = 0;
        private int _threePlusCount = 0;
        private int _rollCount = 0;
        // roll counter

        public SetOfDice()
        {
            for(int i = 0; i < 5; i++) 
            {
                _dice.Add(new Die());
            } 
            CalcScore();
        }

        public void WriteDice()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Die {i+1}: {_dice[i].Value}  ");
            }
            CalcScore();
        }

        private void CalcScore()
        {
            _pair1 = 0;
            _pair2 = 0;
            _threePlus = 0;
            _threePlusCount = 0;
            for(int i = 1; i < 7; i++)
            {
                int tally = _dice.Count(die => die.Value == i);
                if (tally == 2)
                {
                    if(_pair1 == 0)
                    {
                        _pair1 = i;
                    }
                    else
                    {
                        _pair2 = i;
                    }
                }
                else if(tally >= 3)
                {
                    _threePlus = i;
                    _threePlusCount = tally;
                }
            }
            _rollCount++;
        }

        public void RollAllExcept(int dieValue)
        {
            Console.WriteLine("Final Dice: ");
            foreach (Die die in _dice)
            {
                if (die.Value != dieValue)
                {
                    die.Roll();
                }
            }
            CalcScore();
        }

        public int Pair1()
        {
            return _pair1;
        }
        public int Pair2()
        {
            return _pair2;
        }
        public int ThreePlus()
        {
            return _threePlus;
        }
        public int ThreePlusCount()
        {
            return _threePlusCount;
        }
        public int RollCount()
        {
            return _rollCount;
        }
    }
}
