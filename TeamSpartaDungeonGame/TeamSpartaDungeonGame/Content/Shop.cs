using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Interface;
using TeamSpartaDungeonGame.ItemInfo;
using TeamSpartaDungeonGame.PlayerInfo;
using TeamSpartaDungeonGame.Utility;

namespace TeamSpartaDungeonGame.Content
{
    internal class Shop : IFramework
    {


        private bool isExit = false;
        private bool isExitPurch = false;
        private bool isExitSell = false;
        private Player player;
        private List<Item> storeInventory;
        //private List<Item> inventory;
        private Inventory inventory;
        private int max = Pagecount;
        private int min = 0;
        const int Pagecount = 9;


        public Shop(Player player)
        {
            this.player = player;
            inventory = player.Invern;
        }
        public void InitalizeShop()
        {
            storeInventory = new List<Item>();
            storeInventory.Add(new Item("낡은 헤드셋", "한쪽만 들리는 헤드셋", ItemType.ARMOR, 0, 15, 30, 0, 1000, 0, 0));
            storeInventory.Add(new Item("부숴진 키보드", "샷건을 많이 친 키보드", ItemType.WEAPON, 20, 0, 0, 45, 1200, 0, 0));
            storeInventory.Add(new Item("낡은 마우스", "한쪽만 눌리는 마우스", ItemType.ACCESSORY, 0, 0, 0, 0, 1000, 4, 4));
            storeInventory.Add(new Item("타구봉", "거지들의 애용 무기", ItemType.WEAPON, 10, 0, 0, 20, 700, 0, 0));
            storeInventory.Add(new Item("낡은 옷", "구멍이 많이 난 옷", ItemType.ARMOR, 0, 10, 25, 0, 600, 0, 0));
            storeInventory.Add(new Item("쪽박", "거지들의 애용 밥그릇", ItemType.ACCESSORY, 0, 0, 0, 0, 800, 3, 3));
            storeInventory.Add(new Item("마이크", "노래방 낡은 마이크", ItemType.WEAPON, 15, 0, 0, 30, 1000, 0, 0));
            storeInventory.Add(new Item("무대 의상", "반짝이는 옷", ItemType.ARMOR, 0, 18, 60, 0, 1500, 0, 0));
            storeInventory.Add(new Item("스피커", "소리를 증폭시켜주는 장치", ItemType.ACCESSORY, 0, 0, 0, 0, 2000, 7, 7));
            storeInventory.Add(new Item("샤넬 백", "명품 가방", ItemType.WEAPON, 40, 0, 0, 80, 6000, 0, 0));
            storeInventory.Add(new Item("샤넬 코트", "명품 옷", ItemType.ARMOR, 0, 35, 99, 0, 4000, 0, 0));
            storeInventory.Add(new Item("샤넬 No.5", "명품 향수", ItemType.ACCESSORY, 0, 0, 0, 0, 3000, 9, 9));
        }

        public void Update()
        {
            switch (ConsoleUtility.PromptMenuChoice(0, 4))
            {
                case 0:
                    isExit = true;
                    break;
                case 1:
                    PurchaseMenuLoop();
                    break;
                case 2:
                    NextPage();
                    break;
                case 3:
                    PreviousPage();
                    break;
                case 4:
                    SellMenuLoop();
                    break;
            }
        }

        public void Render()
        {
            Console.Clear();

            ConsoleUtility.ShowTitle("■ 상점 ■");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            ConsoleUtility.PrintTextHighlights("", player.Stat.Gold.ToString(), "G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            for (int i = min; i < max; i++)
            {
                storeInventory[i].PrintStoreItemStatDesciption();
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 다음 페이지");
            Console.WriteLine("3. 이전 페이지");
            Console.WriteLine("4. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.ResetColor();
        }

        public void Loop()
        {
            while (!isExit)
            {
                Render();
                Update();
            }
            Reset();
        }

        void Reset()
        {
            isExit = false;
            isExitPurch = false;
            isExitSell = false;
        }

        public void PurchaseMenuUpdate()
        {
            int keyInput = ConsoleUtility.PromptMenuChoice(0, storeInventory.Count);

            switch (keyInput)
            {
                case 0:
                    isExitPurch = true; 
                    break;
                default:
                    //1 : 이미 구매한 경우
                    if (storeInventory[keyInput - 1].IsPurchased)
                    {
                        PurchaseMenuRender("이미 구매한 아이템입니다.");
                    }
                    //2 : 돈이 충분해서 살 수 있는 경우
                    else if (player.Stat.Gold >= storeInventory[keyInput - 1].Price)
                    {
                        player.Stat.Gold -= storeInventory[keyInput - 1].Price;
                        storeInventory[keyInput - 1].Purchased();
                        inventory.Invent.Add(storeInventory[keyInput - 1]);
                    }
                    //3 : 돈이 모자라는 경우
                    else
                    {
                        PurchaseMenuRender("Gold가 부족합니다.");
                    }
                    break;

            }
        }

        public void PurchaseMenuRender(string? prompt = null)
        {
            if (prompt != null)
            {
                //1초간 메시지를 띄운 다음에 다시 진행
                Console.Clear();
                ConsoleUtility.ShowTitle(prompt);
                Thread.Sleep(1000);//몇 밀리초동안 멈출것인가?
            }

            Console.Clear();

            ConsoleUtility.ShowTitle("■ 상점 - 구매하기■");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            ConsoleUtility.PrintTextHighlights("", player.Stat.Gold.ToString(), "G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < storeInventory.Count; i++)
            {
                storeInventory[i].PrintStoreItemStatDesciption(true, i + 1);
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("0. 나가기");
            Console.ResetColor();
            Console.WriteLine("");
        }

        public void PurchaseMenuLoop()
        {
            while (!isExitPurch)
            {
                PurchaseMenuRender();
                PurchaseMenuUpdate();
            }
            isExitPurch = false;
        }

        public void SellMenuUpdate()
        {
            int keyInput = ConsoleUtility.PromptMenuChoice(0, inventory.Invent.Count);

            switch (keyInput)
            {
                case 0:
                    isExitSell = true;
                    break;
                default:
                    // : 판매할 수 있는 경우
                    player.Stat.Gold += inventory.Invent[keyInput - 1].Price;
                    inventory.Invent[keyInput - 1].Selled();
                    inventory.Invent.Remove(inventory.Invent[keyInput - 1]);
                    break;
            }
        }

        public void SellMenuRender()
        {
            Console.Clear();

            ConsoleUtility.ShowTitle("■ 상점 - 판매하기■");
            Console.WriteLine("불필요한 아이템을 팔 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            ConsoleUtility.PrintTextHighlights("", player.Stat.Gold.ToString(), "G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            if (inventory.Invent.Count != 0)
            {
                for (int i = 0; i < inventory.Invent.Count; i++)
                {
                    inventory.Invent[i].PrintStoreSellItemStatDesciption(true, i + 1);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("0. 나가기");
            Console.ResetColor();
        }

        public void SellMenuLoop()
        {
            while (!isExitSell)
            {
                SellMenuRender();
                SellMenuUpdate();
            }
            isExitSell = false;
        }

        public void NextPage()
        {
            if (max == storeInventory.Count)
            {
                return;
            }//void 에서 return은 메서드 탈출을 의미한다.

            min = max;
            max += Pagecount;

            if (max > storeInventory.Count)
            {
                max = storeInventory.Count;
            }
        }

        public void PreviousPage()
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

