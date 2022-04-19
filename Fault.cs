using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class Fault : Cell
    {
        public Fault(string fault) : base(fault) { }
        
        public void OnPrison(Cat cat)
        {
            Random cube = new Random();
            int time1 = cube.Next(1, 7);
            int time2 = cube.Next(1, 7);
            Console.WriteLine($"{cat.Name} кидает 2 кубика, чтобы попытаться сбежать: {time1}, {time2}");

            if (time1 == time2)
            {
                Console.WriteLine($"{cat.Name} благополучно сбегает");
            }
            else if (cat.CountBonus(0) > 0)
            {
                cat.UseBonus(0);
                Console.WriteLine($"Использована карта ШАНС: {cat.Name} благополучно сбегает");
            }
            else if (cat.HaveGold(200))
            {
                time1 = cube.Next(2);
                if (time1 == 1)
                {
                    Console.WriteLine($"{cat.Name} платит 200 мяукоинов и благополучно сбегает");
                    cat.MinusGold(200);

                }
                else
                {
                    Console.WriteLine($"{cat.Name} не может сбежать: пропускает 3 хода");
                    cat.NotFree(4);
                }
            }
            else
            {
                Console.WriteLine($"{cat.Name} не может сбежать: пропускает 3 хода");
                cat.NotFree(4);
            }
        }
    }
}
