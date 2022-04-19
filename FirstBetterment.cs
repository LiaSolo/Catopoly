using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class FirstBetterment : Decorator
    {
        //int Level;
        public FirstBetterment(RoomAbstract cell) : base(cell.Name + " класс", cell) {Level = 1; }
        
        public override int GetRent()
        {
            return cell.GetRent() * 2;
        }
    }
}
