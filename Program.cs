using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Котополия
{
    class Program
    {
        static public void OnChance(Cat cat, string[] chance )
        {
            Random cube = new Random();
            int time = cube.Next(6);
            Console.WriteLine($"{cat.ShowName} может {chance[time]}");
            if (time == 1) //получить 600 мяукоинов
            {
                cat.PlusGold(600);
            }
            else if (time == 4) //отобрать 300 мяукоинов у соперника
            {
                cat.PlusGold(300);
                cat.ShowNext.MinusGold(300);            
            }
            else if (time == 5) //перейти на обнимашки
            {
                Hugs(cat);
            }
            else
            {
                cat.AddBonus(time);
            }
        }
        static public void Prison(Cat cat)
        {
            Random cube = new Random();
            int time1 = cube.Next(1, 7);
            int time2 = cube.Next(1, 7);
            Console.WriteLine($"{cat.ShowName} кидает 2 кубика, чтобы попытаться сбежать: {time1}, {time2}");

            if (time1 == time2)
            {
                Console.WriteLine($"{cat.ShowName} благополучно сбегает");
            }
            else if (cat.CountBonus(0) > 0)
            {
                cat.UseBonus(0);
                Console.WriteLine($"Использована карта ШАНС: {cat.ShowName} благополучно сбегает");
            }
            else if (cat.HaveGold(200))
            {
                time1 = cube.Next(2);
                if (time1 == 1)
                {
                    Console.WriteLine($"{cat.ShowName} платит 200 мяукоинов и благополучно сбегает");
                    cat.MinusGold(200);
                    
                }
                else
                {
                    Console.WriteLine($"{cat.ShowName} не может сбежать: пропускает 3 хода");
                    cat.NotFree(4);
                }
            }
            else
            {
                Console.WriteLine($"{cat.ShowName} не может сбежать: пропускает 3 хода");
                cat.NotFree(4);
            }
        }
        static public void Hugs(Cat cat)
        {
            int time;
            Random cube = new Random();
            time = cube.Next(2);
            if (time == 1)
            {
                Console.WriteLine($"{cat.ShowName} решает сбежать");
            }
            else
            {
                Console.WriteLine($"{cat.ShowName} решает остаться: пропускает 1 ход и получает 200 мяукоинов");
                cat.NotFree(2);
                cat.PlusGold(200);
            }
        }
        static void Main(string[] args)
        {
            Board board = new Board();
            Random cube = new Random();

            string[] Chance = { "сбежать из тюрьмы", 
                                "получить 600 мяукоинов", //исполняется сразу
                                "не заплатить сопернику за пребывание на его территории", 
                                "заставить соперника заплатить двойную цену за нахождение на территории", 
                                "отобрать 300 мяукоинов у соперника", //исполняется сразу
                                "перейти на обнимашки" }; //исполняется сразу

            //появление котов
            Cat cat1 = new Cat("Барсик");

            cat1.Buy((Rooms)board.array[1]);
            cat1.Buy((Rooms)board.array[2]);
            cat1.Buy((Rooms)board.array[3]);

            cat1.Buy((Rooms)board.array[10]);
            cat1.Buy((Rooms)board.array[11]);
            cat1.Buy((Rooms)board.array[12]);

            cat1.Buy((Rooms)board.array[6]);
            cat1.Buy((Rooms)board.array[7]);
            cat1.Buy((Rooms)board.array[8]);

            cat1.Buy((Rooms)board.array[15]);
            cat1.Buy((Rooms)board.array[16]);
            cat1.Buy((Rooms)board.array[17]);

            cat1.PlusGold(20000);

            Cat cat2 = new Cat("Белоснежка");

            cat2.PlusGold(10000);

            cat1.MakeNext(cat2);
            cat2.MakeNext(cat1);
            Cat current = cat1;  
            
            
            int index;
            while (cat1.HaveGold(0) && cat2.HaveGold(0))
            {
                #region красивый вывод
                Console.Write("имя");
                Console.SetCursorPosition(Chance[3].Length + 5, 0);
                Console.Write(cat1.ShowName);
                Console.SetCursorPosition(Chance[3].Length + cat1.ShowName.Length + 10, 0);
                Console.WriteLine(cat2.ShowName);

                Console.Write("мяукоины");
                Console.SetCursorPosition(Chance[3].Length + 5, 1);
                Console.Write(cat1.ShowGold);
                Console.SetCursorPosition(Chance[3].Length + cat1.ShowName.Length + 10, 1);
                Console.WriteLine(cat2.ShowGold);

                Console.Write(Chance[0]);
                Console.SetCursorPosition(Chance[3].Length + 5, 2);
                Console.Write(cat1.CountBonus(0));
                Console.SetCursorPosition(Chance[3].Length + cat1.ShowName.Length + 10, 2);
                Console.WriteLine(cat2.CountBonus(0));

                Console.Write(Chance[2]);
                Console.SetCursorPosition(Chance[3].Length + 5, 3);
                Console.Write(cat1.CountBonus(2));
                Console.SetCursorPosition(Chance[3].Length + cat1.ShowName.Length + 10, 3);
                Console.WriteLine(cat2.CountBonus(2));

                Console.Write(Chance[3]);
                Console.SetCursorPosition(Chance[3].Length + 5, 4);
                Console.Write(cat1.CountBonus(3));
                Console.SetCursorPosition(Chance[3].Length + cat1.ShowName.Length + 10, 4);
                Console.WriteLine(cat2.CountBonus(3));

                Console.Write("шагов пропустить");
                Console.SetCursorPosition(Chance[3].Length + 5, 5);
                Console.Write(cat1.HowMuchSkip);
                Console.SetCursorPosition(Chance[3].Length + cat1.ShowName.Length + 10, 5);
                Console.WriteLine(cat2.HowMuchSkip);

                Console.SetCursorPosition((Chance[3].Length + cat2.ShowName.Length - 2) /2, 7);
                Console.WriteLine("Ходит котик " + current.ShowName);

                #endregion

                #region движение по доске
                int move = cube.Next(1,7);
                current.MovePosition(move);

                index = current.ShowPosition;
                SpecialCells somespc;
                Rooms someroom;

                //старт
                if (index == 0)
                {
                    somespc = (SpecialCells)board.array[index];
                    Console.WriteLine($"{current.ShowName} попадает на {somespc.Name}");
                }
                //шанс
                else if (index == 4 || index == 13)
                {
                    somespc = (SpecialCells)board.array[index];
                    Console.WriteLine($"{current.ShowName} получает {somespc.Name}");
                    OnChance(current, Chance);
                }
                //тюрьма
                else if (index == 5 || index == 14)
                {
                    somespc = (SpecialCells)board.array[index];
                    Console.WriteLine($"{current.ShowName} косячит: {somespc.Name}");
                    Prison(current);
                }
                //обнимашки
                else if (index == 9) 
                {
                    somespc = (SpecialCells)board.array[index];
                    Console.WriteLine($"{current.ShowName} попадает в {somespc.Name}");
                    Hugs(current);
                }
                //комнаты
                else
                {
                    someroom = (Rooms)(RoomsAbstract)board.array[index];
                    Console.WriteLine($"{current.ShowName} попадает на {someroom.Name}");

                    if (someroom.Owner != null && someroom.Owner != current)
                    {
                        Console.WriteLine(someroom.Name + " принадлежит " + someroom.Owner.ShowName);
                        if (current.CountBonus(2) > 0)
                        {                            
                            Console.WriteLine($"Использован ШАНС: {current.ShowName} не платит {current.ShowNext.ShowName}");
                            current.UseBonus(2);
                        }
                        else if(current.ShowNext.CountBonus(3) > 0)
                        {
                            Console.WriteLine($"Использован ШАНС: {current.ShowName} платит {current.ShowNext.ShowName} " +
                                $"двойную сумму {2 * someroom.GetRent()}");
                            current.MinusGold(2 * someroom.GetRent());
                            current.ShowNext.PlusGold(2 * someroom.GetRent());
                            current.ShowNext.UseBonus(3);
                        }
                        else
                        {
                            Console.WriteLine($"{current.ShowName} платит {current.ShowNext.ShowName} {someroom.GetRent()}");
                            current.MinusGold(someroom.GetRent());
                            current.ShowNext.PlusGold(someroom.GetRent());
                        }                       
                    }
                    else if (someroom.Owner == null)
                    {
                        Console.WriteLine($"{someroom.Name} никому не принадлежит");
                        if (current.HaveGold(someroom.Cost))
                        {
                            Console.WriteLine($"{current.ShowName} покупает {someroom.Name } " +
                                $"за {someroom.Cost} мяукоинов");
                            current.Buy(someroom);
                        }
                        else
                        {
                            Console.WriteLine($"{current.ShowName} имеет недостаточно средств " +
                                $"на покупку {someroom.Name} за {someroom.Cost} мяукоинов");
                        }                        
                    }



                    //место для декоратора
                    //надо проверить, что можно навесить - как?
                    else
                    {
                        Console.WriteLine(someroom.Name + " принадлежит " + someroom.Owner.ShowName);
                        if (current.CanDecorate(someroom))
                        {
                            RoomsAbstract ra = new Rooms(someroom.Cost, someroom.Name, someroom.Room); 
                            if (someroom.Level == 0)
                            {
                                ra = new FirstBetterment(someroom);
                            }
                            else if (someroom.Level == 1)
                            {
                                ra = new SecondBetterment(someroom);
                            }
                            else if (someroom.Level == 2)
                            {
                                ra = new ThirdBetterment(someroom);
                            }
                            board.array[index] = ra;
                            Console.WriteLine(current.ShowName + " улучшает " + someroom.Name + " до " + ra.Name);
                        }
                    }
                }
                #endregion


                #region проверка смены ходящего

                if (current.ShowNext.IsFree)
                {
                    current = current.ShowNext;
                }

                if (!cat1.IsFree)
                {
                    cat1.MinusCounter();
                }
                if (!cat2.IsFree)
                {
                    cat2.MinusCounter();
                }
                #endregion

                Thread.Sleep(5000);
                Console.Clear();

            }

            Console.WriteLine("Игра окончена!");
            if (cat1.HaveGold(0))
            {                
                Console.WriteLine($"{cat1.ShowName} выигрывает!");
            }
            else
            {
                Console.WriteLine($"{cat2.ShowName} выигрывает!");
            }
           
            Console.ReadKey();


        }
    }
}
