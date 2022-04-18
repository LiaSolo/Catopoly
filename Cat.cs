using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class Cat //автосвойства
    {
        private string Name;
        private int Position;
        private int Gold;
        private int Counter;
        private bool Free;
        
        private Cat Next;
        private int[] Bonus = new int[6];
        public List<Rooms> Property = new List<Rooms>();

        public int ShowGold => Gold;
        public string ShowName => Name;
        public int ShowPosition => Position;
        public int HowMuchSkip => Counter;
        public bool IsFree => Free;
        public Cat ShowNext => Next;
        public int CountBonus(int index) => Bonus[index];
        public Cat(string name) { Name = name; Gold = 2000; Position = 0; Free = true; Counter = 0; Next = null; }
        
        public void Buy(Rooms room)
        {
            Property.Add(room);
            room.Owner = this;
            MinusGold(room.Cost);
        }

        public bool CanDecorate(Rooms room)
        {

            int count = 0;
            foreach (var i in Property)
            {
                if (i.Room == room.Room)
                {
                    count++;
                    if (room.Level > i.Level)
                    {
                        return false;
                    }
                }
            }
            if (count == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HaveGold(int summa)
        {
            if (this.Gold < summa)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void PlusGold(int summa)
        {
            Gold += summa;
        }

        public void MinusGold(int summa)
        {
            Gold -= summa;
        }

        public void MinusCounter()
        {
            Counter--;
            if (Counter == 0)
            {
                Free = true;
            }
        }

        public void NotFree(int summa) //если два котика одновременно в тюрьме, то первого надо выпустить
        {
            Counter = summa;
            Free = false;
            Next.Counter = 0;
            Next.Free = true;
        }

        public void MovePosition(int move)
        {
            if (Position + move <= 17)
            { 
                Position += move;
            }
            else
            {
                Position += move - 18;
                PlusGold(400);
            }           
        }

        public void MakeNext(Cat cat) 
        {
            this.Next = cat;
        }

        public void AddBonus(int index)
        {
            Bonus[index]++;
        }

        public void UseBonus(int index)
        {
            Bonus[index]--;
        }
    }
}
