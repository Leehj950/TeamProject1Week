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

        private bool IsExit;
        private Player player;
        private List<Item> Shoplist;

        public Shop(Player player) 
        {
            this.player = player;
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
    }
}
