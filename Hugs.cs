using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class Hugs : Cell
    {
        public Hugs(string hugs) : base(hugs) { }

        public void OnHugs(Cat cat)
        {
            int time;
            Random cube = new Random();
            time = cube.Next(2);
            if (time == 1)
            {
                Console.WriteLine($"{cat.Name} решает сбежать");
            }
            else
            {
                Console.WriteLine($"{cat.Name} решает остаться: пропускает 1 ход и получает 200 мяукоинов");
                cat.NotFree(2);
                cat.PlusGold(200);
            }
        }
    }
}
