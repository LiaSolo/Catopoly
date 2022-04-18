using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class FirstBetterment : Decorator
    {
        int Level;
        public FirstBetterment(Rooms cell) : base(cell.Name + " чуть лучше обычного", cell) { Level = 1; }
        
        public override int GetRent()
        {
            return cell.GetRent() * 2;
        }
    }
}
