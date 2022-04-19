using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Котополия
{
    class Program //выгрузить на гит хаб
    {
        static void OutputToScreen(Cat cat1, Cat cat2)
        {
            Console.Write("имя");
            Console.SetCursorPosition(75, 0);
            Console.Write(cat1.Name);
            Console.SetCursorPosition(cat1.Name.Length + 80, 0);
            Console.WriteLine(cat2.Name);

            Console.Write("мяукоины");
            Console.SetCursorPosition(75, 1);
            Console.Write(cat1.Gold);
            Console.SetCursorPosition(cat1.Name.Length + 80, 1);
            Console.WriteLine(cat2.Gold);

            Console.Write("сбежать из тюрьмы");
            Console.SetCursorPosition(75, 2);
            Console.Write(cat1.CountBonus(0));
            Console.SetCursorPosition(cat1.Name.Length + 80, 2);
            Console.WriteLine(cat2.CountBonus(0));

            Console.Write("не заплатить сопернику за пребывание на его территории");
            Console.SetCursorPosition(75, 3);
            Console.Write(cat1.CountBonus(2));
            Console.SetCursorPosition(cat1.Name.Length + 80, 3);
            Console.WriteLine(cat2.CountBonus(2));

            Console.Write("заставить соперника заплатить двойную цену за нахождение на территории");
            Console.SetCursorPosition(75, 4);
            Console.Write(cat1.CountBonus(3));
            Console.SetCursorPosition(cat1.Name.Length + 80, 4);
            Console.WriteLine(cat2.CountBonus(3));

            Console.Write("шагов пропустить");
            Console.SetCursorPosition(75, 5);
            Console.Write(cat1.Skip);
            Console.SetCursorPosition(cat1.Name.Length + 80, 5);
            Console.WriteLine(cat2.Skip);

            Console.SetCursorPosition((cat2.Name.Length + 68) / 2, 7);
        }
            
        static void Main(string[] args)
        {
            Board board = new Board();
            Random cube = new Random();

            //появление котов
            Cat cat1 = new Cat("Барсик");           
            Cat cat2 = new Cat("Белоснежка");

            //для проверки декораторов
            //cat1.Buy((Rooms)board.array[1]);
            //cat1.Buy((Rooms)board.array[2]);
            //cat1.Buy((Rooms)board.array[3]);

            //cat1.Buy((Rooms)board.array[10]);
            //cat1.Buy((Rooms)board.array[11]);
            //cat1.Buy((Rooms)board.array[12]);

            //cat1.Buy((Rooms)board.array[6]);
            //cat1.Buy((Rooms)board.array[7]);
            //cat1.Buy((Rooms)board.array[8]);

            //cat1.Buy((Rooms)board.array[15]);
            //cat1.Buy((Rooms)board.array[16]);
            //cat1.Buy((Rooms)board.array[17]);

            //cat1.PlusGold(20000);
            //cat2.PlusGold(10000);
            

            cat1.Next = cat2;
            cat2.Next = cat1;
            Cat current = cat1;

            int index;
            while (cat1.HaveGold(0) && cat2.HaveGold(0))
            {
                OutputToScreen(cat1, cat2);
                Console.WriteLine("Ходит котик " + current.Name);

                #region движение по доске
                int move = cube.Next(1,7);
                current.MovePosition(move);

                index = current.Position;
                Cell somecell = board.array[index];

                //старт
                if (index == 0)
                {
                    Console.WriteLine($"{current.Name} попадает на {somecell.Name}");
                }
                //шанс
                else if (index == 4 || index == 13)
                {
                    Console.WriteLine($"{current.Name} получает {somecell.Name}");
                    ((Chance)somecell).OnChance(current);
                }
                //тюрьма
                else if (index == 5 || index == 14)
                {
                    Console.WriteLine($"{current.Name} косячит: {somecell.Name}");
                    ((Fault)somecell).OnPrison(current);
                }
                //обнимашки
                else if (index == 9) 
                {
                    Console.WriteLine($"{current.Name} попадает в {somecell.Name}");
                    ((Hugs)somecell).OnHugs(current);
                }
                //комнаты
                else
                {
                    Console.WriteLine($"{current.Name} попадает на {somecell.Name}");

                    if (((RoomAbstract)somecell).Owner != null && ((RoomAbstract)somecell).Owner != current)
                    {
                        Console.WriteLine(((RoomAbstract)somecell).Name + " принадлежит " + ((RoomAbstract)somecell).Owner.Name);
                        if (current.CountBonus(2) > 0)
                        {                            
                            Console.WriteLine($"Использован ШАНС: {current.Name} не платит {current.Next.Name}");
                            current.UseBonus(2);
                        }
                        else if(current.Next.CountBonus(3) > 0)
                        {
                            Console.WriteLine($"Использован ШАНС: {current.Name} платит {current.Next.Name} " +
                                $"двойную сумму {2 * ((RoomAbstract)somecell).GetRent()}");
                            current.MinusGold(2 * ((RoomAbstract)somecell).GetRent());
                            current.Next.PlusGold(2 * ((RoomAbstract)somecell).GetRent());
                            current.Next.UseBonus(3);
                        }
                        else
                        {
                            Console.WriteLine($"{current.Name} платит {current.Next.Name} {((RoomAbstract)somecell).GetRent()}");
                            current.MinusGold(((RoomAbstract)somecell).GetRent());
                            current.Next.PlusGold(((RoomAbstract)somecell).GetRent());
                        }                       
                    }
                    //покупка
                    else if (((RoomAbstract)board.array[index]).Owner == null)
                    {
                        Console.WriteLine($"{((RoomAbstract)somecell).Name} никому не принадлежит");
                        if (current.HaveGold(((RoomAbstract)somecell).Cost))
                        {
                            Console.WriteLine($"{current.Name} покупает {((RoomAbstract)somecell).Name } " +
                                $"за {((RoomAbstract)somecell).Cost} мяукоинов");
                            current.Buy((RoomAbstract)somecell);
                        }
                        else
                        {
                            Console.WriteLine($"{current.Name} имеет недостаточно средств " +
                                $"на покупку {((RoomAbstract)somecell).Name} за {((RoomAbstract)somecell).Cost} мяукоинов");
                        }                        
                    }
                    //декоратор
                    else
                    {
                        Console.WriteLine(((RoomAbstract)somecell).Name + " принадлежит " + ((RoomAbstract)somecell).Owner.Name);
                        if (current.CanDecorate(((RoomAbstract)somecell)))
                        {
                            RoomAbstract ra = new Rooms(((RoomAbstract)somecell).Cost, 
                                ((RoomAbstract)somecell).Name, ((RoomAbstract)somecell).Room); 
                            if (((RoomAbstract)somecell).Level == 0)
                            {
                                ra = new FirstBetterment(((RoomAbstract)somecell));
                            }
                            else if (((RoomAbstract)somecell).Level == 1)
                            {
                                ra = new SecondBetterment(((RoomAbstract)somecell));
                            }
                            else if (((RoomAbstract)somecell).Level == 2)
                            {
                                ra = new ThirdBetterment(((RoomAbstract)somecell));
                            }
                            else if (((RoomAbstract)somecell).Level == 3)
                            {
                                ra = new Luxury(((RoomAbstract)somecell));
                            }
                                
                            Console.WriteLine(current.Name + " взмахом волшебной палочки улучшает "
                                + ((RoomAbstract)somecell).Name + " до " + ra.Name);
                            current.Property.Remove((RoomAbstract)somecell);
                            current.Property.Add(ra);
                            board.array[index] = ra;

                        }

                    }
                }
                #endregion


                #region проверка смены ходящего

                if (current.Next.Free)
                {
                    current = current.Next;
                }

                if (!cat1.Free)
                {
                    cat1.MinusCounter();
                }
                if (!cat2.Free)
                {
                    cat2.MinusCounter();
                }
                #endregion

                Thread.Sleep(1000);
                Console.Clear();

            }

            Console.WriteLine("Игра окончена!");
            if (cat1.HaveGold(0))
            {                
                Console.WriteLine($"{cat1.Name} выигрывает!");
            }
            else
            {
                Console.WriteLine($"{cat2.Name} выигрывает!");
            }
           
            Console.ReadKey();


        }
    }
}
