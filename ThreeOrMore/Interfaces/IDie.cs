using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeOrMore.Interfaces
{
    
    public interface IDie
    {
        public int Value { get; set; }
        public void Roll();
    }
}
