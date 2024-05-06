using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Interface;
using TeamSpartaDungeonGame.Manager;
using TeamSpartaDungeonGame.PlayerInfo;
using TeamSpartaDungeonGame.Utility;

namespace TeamSpartaDungeonGame.Content
{
    public enum LobbyList
    {
        PLAYSTATS = 1,
        INVERTER,
        SHOP,
        RESTAREA,
        DUNGEON,
        EXIT

        //TITLE,
    }


    internal class GameLobby : IFramework
    {

        private Player player;
        private bool isExit;
        public GameLobby(Player player)
        {
            this.player = player;
        }
        // 렌더러는 거기서 그림을 출력하는 함수.
        public void Render()
        {
            Console.Clear();
            ConsoleUtility.ShowTitle("■ 게임로비 ■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write("1.플레이어 스탯창");
            Console.WriteLine();
            Console.Write("2.인벤토리");
            Console.WriteLine();
            Console.Write("3.상점");
            Console.WriteLine();
            Console.Write("4. 휴식처");
            Console.WriteLine();
            Console.Write("5. 던전");
            Console.WriteLine();
            Console.Write("6. 게임종료");
            Console.WriteLine();
            Console.ResetColor();
        }
        //업데이트는 입력및 계산을 주로 업데이트에서 하고
        // 입력을 받는 것을 주로 합니다.
        public void Update()
        {
            int number = ConsoleUtility.PromptMenuChoice(1, 6);

            switch ((LobbyList)number)
            {
                case LobbyList.PLAYSTATS:
                    SceneManager.Instance().ScenePlayerStats();
                    break;
                case LobbyList.INVERTER:
                    SceneManager.Instance().SceneInventory();
                    break;
                case LobbyList.SHOP:
                    SceneManager.Instance().SceneShop();
                    break;
                case LobbyList.RESTAREA:
                    SceneManager.Instance().SceneRsetArea();
                    break;
                case LobbyList.DUNGEON:
                    SceneManager.Instance().SceneDungeon();
                    break;
                case LobbyList.EXIT:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        public void Loop()
        {
            while (!isExit)
            {
                Render();
                Update();
            }
        }
    }
}
