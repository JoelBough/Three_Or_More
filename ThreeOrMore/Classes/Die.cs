using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeOrMore.Interfaces;

namespace ThreeOrMore.Classes
{
    public class Die: IDie // using interface
    {
        private Random _random = new Random();
        public Die() //constructor
        {
            Roll();
        }
        public Die(int starting_value) //Polymorphism/ constructor overload
        {
            Value = starting_value;
            if(Value < 1 || Value > 6)
            {
                throw new InvalidDiceValueException();//Custom exception
            }
        }
        public int Value { get; set; } // creates property
        public void Roll()// roll dice
        {
            int number = _random.Next(1, 7);
            Value = number;
        }
        
    }
}
