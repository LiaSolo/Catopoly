using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class SecondBetterment : Decorator
    {
        public SecondBetterment(RoomAbstract cell) : base(cell.Name + " супер", cell) { Level = 2; }

        public override int GetRent()
        {
            return cell.GetRent() * 2;
        }
    }
}
