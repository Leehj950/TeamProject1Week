using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Content;
using TeamSpartaDungeonGame.PlayerInfo;

namespace TeamSpartaDungeonGame.Manager
{
    internal class SceneManager
    {
        private static  SceneManager instance;

        private GameLobby gameLobby;
        private Dungeon dungeon;
        private RestArea restArea;
        private Shop shop;
        private Player player;

        public void initalize(Player player)
        {
            this.player = player;
            shop = new Shop(player);
            shop.InitalizeShop();
            gameLobby = new GameLobby(player);
            restArea = new RestArea(player.Stat);
            dungeon = new Dungeon(player);
        }

        // SceneManager 싱글톤 
        public static SceneManager Instance()
        {
            if (instance == null)
            {
                instance = new SceneManager();
            }
            return instance;
        }

        public void SceneGameLobby()
        {
            gameLobby.Loop();
        }

        public void SceneShop()
        {
            shop.Loop();
        }

        public void SceneDungeon()
        {
            dungeon.Loop();
        }

        public void SceneRsetArea()
        {
            restArea.Initialize();
            restArea.Loop();
        }

        public void ScenePlayerStats( )
        {
            player.StatLoop();
        }

        public void SceneInventory()
        {
            player.Invern.Loop();
        }
    }
}
