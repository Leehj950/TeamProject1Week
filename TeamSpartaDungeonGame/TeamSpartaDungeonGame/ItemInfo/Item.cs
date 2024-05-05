using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpartaDungeonGame.ItemInfo
{
    public enum ItemType//enum을 클래스 처럼 생각 클래스처럼 변수타입을 만들어서 여기서 사용
    {
        WEAPON, ARMOR, ACCESSORY

    }

    internal class Item
    {
        public string Name { get; }
        public string Desc { get; }
        private ItemType Type;
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Mp { get; set; }  // 마  나
        public int Price { get; }
        public float Crit { get; set; } // 크리티컬 확률
        public float Dodge { get; set; }// 회피 확률
        public bool IsEquipped { get; private set; }
        //장착유무는 이클래스에서만 정의
        public bool IsPurchased { get; private set; }
        //구매유무는 이클래에서만 정의


        public Item(string name, string desc, ItemType type, int atk, int def, int hp, int price, float crit,  float dodge, bool isEquipped = false, bool isPurchased = false)
        {
            Name = name;
            Desc = desc;
            Type = type;
            Atk = atk;
            Def = def;
            Hp = hp;
            Price = price;
            Crit = crit;
            Dodge = dodge;
            IsEquipped = isEquipped;
            IsPurchased = isPurchased;
        }
       
    }
}
