using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    abstract class RoomAbstract : Cell
    {
        public Cat Owner { get; set; }
        public int Cost { get; set; }
        public int Level { get; set; }
        public int Rent { get; set; }
        public string Room { get; set; }   
        
        public RoomAbstract(int cost, string name, string room) : base(name) 
        { Cost = cost; Rent = cost / 10; Owner = null; Room = room; Level = 0; }


        public abstract int GetRent();
    }
}
