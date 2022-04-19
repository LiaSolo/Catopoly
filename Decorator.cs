using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    abstract class Decorator : RoomAbstract
    {
        protected RoomAbstract cell;
        public Decorator(string betterment, RoomAbstract cell) : base(cell.Cost, betterment, cell.Room)
        {
            Owner = cell.Owner;
            this.cell = cell;
        }
    }
}
