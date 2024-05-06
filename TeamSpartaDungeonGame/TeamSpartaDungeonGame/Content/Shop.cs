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
        private bool IsExit;
        private Player player;
        private List<Item> storeInventory;
        private List<Item> inventory;

        

        public Shop(Player player) 
        {
            this.player = player;
        }
        public void InitalizeShop()
        {
            storeInventory = new List<Item>();
            storeInventory.Add(new Item("낡은 헤드셋", "한쪽만 들리는 헤드셋", ItemType.ARMOR, 0, 15, 30, 1000, 0, 0));
            storeInventory.Add(new Item("부숴진 키보드", "샷건을 많이 친 키보드", ItemType.WEAPON, 20, 0, 0, 1200, 0, 0));
            storeInventory.Add(new Item("낡은 마우스", "한쪽만 눌리는 마우스", ItemType.ACCESSORY, 0, 0, 0, 1000, 4, 4));
            storeInventory.Add(new Item("타구봉", "거지들의 애용 무기", ItemType.WEAPON, 10, 0, 0, 700, 0, 0));
            storeInventory.Add(new Item("낡은 옷", "구멍이 많이 난 옷", ItemType.ARMOR, 0, 10, 25, 600, 0, 0));
            storeInventory.Add(new Item("쪽박", "거지들의 애용 밥그릇", ItemType.ACCESSORY, 0, 0, 0, 800, 3, 3));
            storeInventory.Add(new Item("마이크", "노래방 낡은 마이크", ItemType.WEAPON, 15, 0, 0, 1000, 0, 0));
            storeInventory.Add(new Item("무대 의상", "반짝이는 옷", ItemType.ARMOR, 0, 18, 60, 1500, 0, 0));
            storeInventory.Add(new Item("스피커", "소리를 증폭시켜주는 장치", ItemType.ACCESSORY, 0, 0, 0, 2000, 7, 7));
            storeInventory.Add(new Item("샤넬 백", "명품 가방", ItemType.WEAPON, 40, 0, 0, 6000, 0, 0));
            storeInventory.Add(new Item("샤넬 코트", "명품 옷", ItemType.ARMOR, 0, 35, 99, 4000, 0, 0));
            storeInventory.Add(new Item("샤넬 No.5", "명품 향수", ItemType.ACCESSORY, 0, 0, 0, 3000, 9, 9));
        }
        public void Initalize(Player value) 
        {

        }

        public void Update()
        {

        }
        
        public void Render()
        {

        }

        public void Loop()
        {
            while(!IsExit)
            {
                Render();
                Update();
            }

        }

        private int max = Pagecount;
        private int min = 0;
        const int Pagecount = 9;
        private void StoreMenu()
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
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 다음 페이지");
            Console.WriteLine("3. 이전 페이지");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            switch (ConsoleUtility.PromptMenuChoice(0, 3))
            {
                case 0:
                    
                    break;
                case 1:
                    PurchaseMenu();
                    break;
                case 2:
                    NextPage();
                    StoreMenu();
                    break;
                case 3:
                    PreviousPage();
                    StoreMenu();
                    break;
            }

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
        private void PurchaseMenu(string? prompt = null)
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
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");

            int keyInput = ConsoleUtility.PromptMenuChoice(0, storeInventory.Count);

            switch (keyInput)
            {
                case 0:
                    StoreMenu();
                    break;
                default:
                    //1 : 이미 구매한 경우
                    if (storeInventory[keyInput - 1].IsPurchased)
                    {
                        PurchaseMenu("이미 구매한 아이템입니다.");
                    }
                    //2 : 돈이 충분해서 살 수 있는 경우
                    else if (player.Stat.Gold >= storeInventory[keyInput - 1].Price)
                    {
                        player.Stat.Gold -= storeInventory[keyInput - 1].Price;
                        storeInventory[keyInput - 1].Purchased();
                        inventory.Add(storeInventory[keyInput - 1]);
                        PurchaseMenu();
                    }
                    //3 : 돈이 모자라는 경우
                    else
                    {
                        PurchaseMenu("Gold가 부족합니다.");
                    }
                    break;

            }
        }

    }
}
