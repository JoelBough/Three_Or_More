using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeOrMore.Interfaces
{
    internal interface IPlayer
    {
        public int Score { get; set; }
        public void UpdateScore(int tally);
       
    }
}
