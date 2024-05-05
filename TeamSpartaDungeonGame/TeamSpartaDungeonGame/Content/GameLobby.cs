using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Interface;
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
        SAVE,
        TITLE,
        EXIT

    }


    internal class GameLobby : IFramework
    {

        private bool IsExit;
        public GameLobby()
        {

        }
        // 렌더러는 거기서 그림을 출력하는 함수.
        public void Render()
        {

        }
        //업데이트는 입력및 계산을 주로 업데이트에서 하고
        // 입력을 받는 것을 주로 합니다.
        public void Update()
        {
            int number = ConsoleUtility.PromptMenuChoice(1, 6);

            switch ((LobbyList)number)
            {
                case LobbyList.PLAYSTATS:
                    break;
                case LobbyList.INVERTER:
                    break;
                case LobbyList.SHOP:
                    break;
                case LobbyList.RESTAREA:
                    break;
                case LobbyList.DUNGEON:
                    break;
                case LobbyList.SAVE:
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
            while (IsExit)
            {
                Render();
                Update();
            }
        }
    }
}
