using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Interface;
using TeamSpartaDungeonGame.ItemInfo;
using TeamSpartaDungeonGame.PlayerInfo;

namespace TeamSpartaDungeonGame.Content
{
    internal class Shop : IFramework
    {

<<<<<<< Updated upstream
        private bool IsExit;
        private Player player;
        private List<Item> storeInventory;

        

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
=======
>>>>>>> Stashed changes
    }
}
