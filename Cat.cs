using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Котополия
{
    class Cat 
    {        
        private int[] Bonus = new int[6];
        public List<RoomAbstract> Property = new List<RoomAbstract>();
        public int Gold { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public int Skip { get; set; }
        public bool Free { get; set; }
        public Cat Next { get; set; }
        public int CountBonus(int index) => Bonus[index];

        public Cat(string name) { Name = name; Gold = 2000; Position = 0; Free = true; Skip = 0; Next = null; }
        
        public void Buy(RoomAbstract room)
        {
            Property.Add(room);
            room.Owner = this;
            MinusGold(room.Cost);
        }

        public bool CanDecorate(RoomAbstract room)
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
            Skip--;
            if (Skip == 0)
            {
                Free = true;
            }
        }

        public void NotFree(int summa) //если два котика одновременно в тюрьме, то первого надо выпустить
        {
            Skip = summa;
            Free = false;
            Next.Skip = 0;
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
