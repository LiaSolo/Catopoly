using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class ThirdBetterment : Decorator
    {
        int Level;
        public ThirdBetterment(Rooms cell) : base(cell.Name + " super", cell) { Level = 3; }

        public override int GetRent()
        {
            return cell.GetRent() * 4;
        }
    }
}
