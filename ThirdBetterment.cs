using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class ThirdBetterment : Decorator
    {
        public ThirdBetterment(RoomAbstract cell) : base(cell.Name + " пупер", cell) { Level = 3; }

        public override int GetRent()
        {
            return cell.GetRent() * 2;
        }
    }
}
