using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.ItemInfo;
using TeamSpartaDungeonGame.Manager;
using TeamSpartaDungeonGame.Utility;

namespace TeamSpartaDungeonGame.PlayerInfo
{
    internal class Inventory
    {
        private int max = Pagecount;
        private int min = 0;
        const int Pagecount = 9;
        private bool IsExit = false;

        private List<Item> inventory;

<<<<<<< Updated upstream
=======
        public int bonusAtk = 0;
        public int bonusDef =0;
        public int bonusHp = 0;
        public int bonusMp = 0;
        public int bonusCrit = 0;
        public float bonusDodge = 0;

        public List<Item> Invent { get { return inventory; } }

        public Inventory()
        {
            inventory = new List<Item>();
        }

        public void testin()
        {
            if (inventory.Count != 0)
            {
                bonusAtk = inventory.Select(item => item.IsEquipped ? item.Atk : 0).Sum();
                bonusDef = inventory.Select(item => item.IsEquipped ? item.Def : 0).Sum();
                bonusHp = inventory.Select(item => item.IsEquipped ? item.Hp : 0).Sum();
                bonusMp = inventory.Select(item => item.IsEquipped ? item.Mp : 0).Sum();
                bonusCrit = inventory.Select(item => item.IsEquipped ? item.Crit : 0).Sum();
                bonusDodge = inventory.Select(item => item.IsEquipped ? item.Dodge : 0).Sum();
            }

        }

>>>>>>> Stashed changes
        public void Update()
        {
            switch (ConsoleUtility.PromptMenuChoice(0, 3))
            {
                case 0:
                    //MainMenu();
                    break;
                case 1:
                    EquipMenuLoop();
                    break;
                case 2:
                    InvenNextPage();
                    Loop();
                    break;
                case 3:
                    InvenPreviousPage();
                    Loop();
                    break;
            }
        }

public void Render()
{
    Console.Clear();

    ConsoleUtility.ShowTitle("■ 인벤토리 ■");
    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
    Console.WriteLine("");
    Console.WriteLine("[아이템 목록]");

    for (int i = min; i < max; i++)
    {
        inventory[i].PrintItemStatDesciption();
    }

    Console.WriteLine("");
    Console.WriteLine("1. 장착관리");
    Console.WriteLine("2. 다음 페이지");
    Console.WriteLine("3. 이전 페이지");
    Console.WriteLine("0. 나가기");
    Console.WriteLine("");
}

        public void Loop()
        {
            while (!IsExit)
            {
                Render();
                Update();
            }
        }

        public void EquipMenuUpdate()
        {
            int KeyInput = ConsoleUtility.PromptMenuChoice(0, inventory.Count);

            switch (KeyInput)
            {
                case 0:
                    Loop();
                    break;
                default:
                    inventory[KeyInput - 1].ToggleEquipStatus();
                    EquipMenuLoop();
                    break;
            }
        }
        
        public void EquipMenuRender()
        {
            Console.Clear();

            ConsoleUtility.ShowTitle("■ 인벤토리 - 장착 관리 ■");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < inventory.Count; i++)
            {
                inventory[i].PrintItemStatDesciption(true, i + 1);
            }//나가기 0번고정, 나머지가 1번부터 배정
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
        }
        public void EquipMenuLoop()
        {
            while (!IsExit)
            {
                EquipMenuRender();
                EquipMenuUpdate();
            }
        }

        public void InvenNextPage()
        {
            if (max == inventory.Count)
            {
                return;
            }//void 에서 return은 메서드 탈출을 의미한다.

            min = max;
            max += Pagecount;

            if (max > inventory.Count)
            {
                max = inventory.Count;
            }
        }

        public void InvenPreviousPage()
        {
            if (min == 0)
            {
                return;
            }

            max = min;
            min -= Pagecount;

            if (min < 0)
            {
                min = 0;
            }
        }
    }
}

