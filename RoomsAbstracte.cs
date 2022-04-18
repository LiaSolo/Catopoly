using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    abstract class RoomsAbstract : Cells
    {
        private string Room; //на будущее
        private int Rent;

        public RoomsAbstract(int cost, string name, string room) : base(name) { Cost = cost; Rent = cost / 10; Owner = null; Name = name; Room = room; }
        public RoomsAbstract(string name) : base(name) { } // для декоратора
        public Cat Owner { get; set; }
        public int Cost { get; set; }

        public abstract int GetRent();
        public void NewOwner(Cat cat)
        {
            Owner = cat;
        }

        //public Cell(string name) { Name = name; } //служебные клетки
    }
}
