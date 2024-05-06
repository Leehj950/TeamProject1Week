using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Interface;
using TeamSpartaDungeonGame.PlayerInfo;

using TeamSpartaDungeonGame.Utility;


namespace TeamSpartaDungeonGame.Manager
{
    public enum MenuList
    {
        GAMESTART = 1,
        GAMELOAD = 2,
        EXIT = 3
    }

    internal class GameManager : IFramework
    {

        private Player player;
        private static GameManager instance = null;
        private DateManager dateManager;
        private SceneManager sceneManager;

        public GameManager()
        {
            player = new Player();
            dateManager = DateManager.Instance();
            sceneManager = SceneManager.Instance();
            sceneManager.initalize(player);
            Console.Title = "TeamSpartDungenGame";
            Console.SetWindowSize(122, 52);
        }

        public static GameManager Instance()
        {
            if (instance == null)
            {
                return instance = new GameManager();
            }
            return instance;
        }

        public void StartGame()
        {
            this.Loop();
        }


        public void Render()
        {
            Console.Clear();
            ConsoleUtility.PrintOutline();
            ConsoleUtility.PrintGameTitle();
            ConsoleUtility.PrintGameHeader();
        }

        public void Update()
        {
            //int choice = PromptMenuChoice(1, 3);
            int choice = ConsoleUtility.PromptMenuChoice(1, 3, 48, 40);

            switch ((MenuList)choice)
            {
                case MenuList.GAMESTART:
                    Console.WriteLine();
                    //if (Name == "")
                    //{
                    //    // 캐릭터 만드는 함수 
                    //    //player가 만들어지면 만드는 함수
                    //}
                    // 그후 로비로 가는 것 의미한다.
                    sceneManager.SceneGameLobby();
                    break;
                case MenuList.GAMELOAD:
                    Console.WriteLine();
                    // 세이브 데이터 불러오기
                    dateManager.LoadDate();
                    break;
                case MenuList.EXIT:
                    Console.WriteLine();
                    // 게임 종료
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        
        public void Loop()
        {
            while(true)
            {
                Render();
                Update();
            }
        }
    }
}