using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class Rooms : RoomsAbstract
    {
        //private string Name, Room; //room на будущее
        //private int Cost, Rent; //cost - покупка, rent - рента
        //private Cat Owner;
        private int Rent;
        public int Level;
        public string Room;

        public Rooms(int cost, string name, string room) : base(cost, name, room) { Cost = cost; Rent = cost / 10; Owner = null; Name = name; Room = room; Level = 0; }

        public override int GetRent()
        {
            return Rent;
        }


        
    }
}
