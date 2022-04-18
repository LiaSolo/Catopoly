using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class SecondBetterment : Decorator
    {
        int Level;
        public SecondBetterment(Rooms cell) : base(cell.Name + " значительно лучше обычного", cell) { Level = 2; }

        public override int GetRent()
        {
            return cell.GetRent() * 3;
        }
    }
}
