using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Utility;

namespace TeamSpartaDungeonGame.ItemInfo
{
    public enum ItemType//enum을 클래스 처럼 생각 클래스처럼 변수타입을 만들어서 여기서 사용
    {
        WEAPON, 
        ARMOR, 
        ACCESSORY

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

        internal void PrintItemStatDesciption(bool withNumber = false, int idx = 0)
        {
            Console.Write("- ");
            if (withNumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{idx} ");
                Console.ResetColor();
            }
            if (IsEquipped)//장착을 할 경우 E를 표현해라
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
                Console.Write(ConsoleUtility.PadRightForMixedText(Name, 9));
                //총 12칸중에서 [E]가 포함되서 9를 반환
            }
            else Console.Write(ConsoleUtility.PadRightForMixedText(Name, 12));

            Console.Write(" | ");

            if (Atk != 0) Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{Atk} ");
            if (Def != 0) Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{Def} ");
            if (Hp != 0) Console.Write($"체   력 {(Hp >= 0 ? "+" : "")}{Hp} ");

            Console.Write(" | ");

            Console.WriteLine(Desc);

        }

        internal void PrintStoreItemStatDesciption(bool withNumber = false, int idx = 0)
        {
            Console.Write("- ");
            if (withNumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{idx} ");
                Console.ResetColor();
            }
            else Console.Write(ConsoleUtility.PadRightForMixedText(Name, 15));

            Console.Write(" | ");

            if (Atk != 0) Console.Write($"공격력{(Atk >= 0 ? "+" : "")}{Atk}             ");
            if (Def != 0) Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{Def} ");
            if (Hp != 0) Console.Write($"체  력 {(Hp >= 0 ? "+" : "")}{Hp} ");
            if (Crit != 0) Console.Write($"치명타률 {(Crit >= 0 ? "+" : "")}{Crit} ");
            if (Dodge != 0) Console.Write($"회피률 {(Dodge >= 0 ? "+" : "")}{Dodge} ");
            Console.Write(" | ");

            Console.Write(ConsoleUtility.PadRightForMixedText(Desc, 25));

            Console.Write(" | ");

            if (IsPurchased)
            {
                Console.WriteLine("구매완료");
            }
            else
            {
                ConsoleUtility.PrintTextHighlights("", Price.ToString(), " G");
            }
        }

        internal void ToggleEquipStatus()
        {
            IsEquipped = !IsEquipped;
        }

        internal void Purchased()
        {
            IsPurchased = true; //아이템 팔기 구현할려면 IsPurchased를 false로  
        }

    }
}
