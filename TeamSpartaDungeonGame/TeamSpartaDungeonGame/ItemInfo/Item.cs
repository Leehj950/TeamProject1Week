using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpartaDungeonGame.ItemInfo
{
    public enum ItemType
    {
        WEAPON,
        ARMOR
    }
    internal class Item
    {
        public string Name { get;}
        public string Dese {  get;}

        private ItemType Type;
        public int Atk {  get;}
        public int Def {  get;}
        public int Price { get;}
        public bool IsEquipped { get; private set; }
        public bool IsPurchased {  get; private set; }

        public Item(string name, string dese, ItemType type, int atk, int def, int price, bool isEquipped = false, bool isPurchased = false)
        {
            Name = name;
            Dese = dese;
            Type = type;
            Atk = atk;
            Def = def;
            Price = price;
            IsEquipped = isEquipped;
            IsPurchased = isPurchased;
        }
    }
}
