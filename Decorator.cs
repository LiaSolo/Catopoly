using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    abstract class Decorator : RoomsAbstract
    {
        protected RoomsAbstract cell;
        public Decorator(string betterment, RoomsAbstract cell) : base(betterment)
        {
            this.cell = cell;
        }
    }
}
