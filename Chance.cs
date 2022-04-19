using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class Chance : Cell
    {
        private string[] chances = { "сбежать из тюрьмы",
                                "получить 600 мяукоинов", //исполняется сразу
                                "не заплатить сопернику за пребывание на его территории",
                                "заставить соперника заплатить двойную цену за нахождение на территории",
                                "отобрать 300 мяукоинов у соперника", //исполняется сразу
                                "перейти на обнимашки" }; //исполняется сразу
        public Chance(string bonus) : base(bonus) { }
        
        public void OnChance(Cat cat)
        {
            Random cube = new Random();
            int time = cube.Next(6);
            Console.WriteLine($"{cat.Name} может {chances[time]}");
            if (time == 1) //получить 600 мяукоинов
            {
                cat.PlusGold(600);
            }
            else if (time == 4) //отобрать 300 мяукоинов у соперника
            {
                cat.PlusGold(300);
                cat.Next.MinusGold(300);
            }
            else if (time == 5) //перейти на обнимашки
            {
                Hugs temp = new Hugs(" ");
                temp.OnHugs(cat);
            }
            else
            {
                cat.AddBonus(time);
            }
        }
    }
}
