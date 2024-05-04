using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Content;

namespace TeamSpartaDungeonGame.Manager
{
    internal class SceneManager
    {
        private static SceneManager instance;
        private GameLobby gameLobby;
        private Dungeon dungeon;
        private RestArea restArea;
        private Shop shop;

        public SceneManager()
        {
            dungeon = new Dungeon();
            restArea = new RestArea();
            shop = new Shop();
            gameLobby = new GameLobby();
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

        public void GameLobby()
        {
            gameLobby.Loop();
        }

        public void Shop()
        {
            shop.Loop();
        }

        public void Dungeon()
        {
            dungeon.Loop();
        }
    }
}
