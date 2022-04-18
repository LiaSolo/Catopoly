using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class SpecialCells : Cells //можно ли просто оставить в селл?
    {
        public SpecialCells(string name) : base(name)
        {
            Name = name;
        }
    }
}
