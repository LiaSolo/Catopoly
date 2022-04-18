using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class Cells
    {
        public string Name { get; protected set; }
        public Cells(string name)
        {
            Name = name;
        }
    }
}
