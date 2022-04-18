﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class Board //перекинуть в програм, фокусы с наследуемыми типами
    {
        public Cells[] array = new Cells[18];
        public Board() 
        {
            array[0] = new SpecialCells("СТАРТ");

            //покупки в коридоре
            array[1] = new Rooms(1000, "Шкаф", "Коридор");
            array[2] = new Rooms(500, "Пуфик", "Коридор");
            array[3] = new Rooms(1500, "Лестница на второй этаж", "Коридор");

            array[4] = new SpecialCells("ШАНС");
            array[5] = new SpecialCells("Тыгыдыкает в 3 часа ночи");

            //покупки в гостиной
            array[6] = new Rooms(1500, "Телевизор", "Гостиная");
            array[7] = new Rooms(1000, "Диван", "Гостиная");
            array[8] = new Rooms(500, "Подоконник", "Гостиная");

            array[9] = new SpecialCells("Обнимашки");

            //покупки на кухне
            array[10] = new Rooms(800, "Обеденный стол", "Кухня");
            array[11] = new Rooms(1000, "Холодильник", "Кухня");
            array[12] = new Rooms(500, "Подоконник", "Кухня");

            array[13] = new SpecialCells("ШАНС");
            array[14] = new SpecialCells("Рвёт штору");

            //покупки в спальне
            array[15] = new Rooms(1000, "Кровать", "Спальня");
            array[16] = new Rooms(800, "Трюмо", "Спальня");
            array[17] = new Rooms(500, "Подоконник", "Спальня");
        }

       
        

        

    }
}
