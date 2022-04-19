using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class Luxury : Decorator
    {
        public Luxury(RoomAbstract cell) : base(cell.Name + " лакшери", cell) { Level = 4; }

        public override int GetRent()
        {
            return cell.GetRent() * 2;
        }
    }
}
