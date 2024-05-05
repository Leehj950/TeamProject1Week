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
        GameStart = 1,
        GameLoad = 2,
        Exit = 3
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

        public void Initialize()
        {
            player = new Player("test", "Programmer", 1, 10, 5, 100, 15000);
            Console.SetWindowSize(122, 52);
            Console.Title = "TeamSpartDungenGame";
            //
            player = new Player();
            // 데이터 매니저를 싱글톤으로 생성함.
            dateManager = DateManager.Instance();
            sceneManager = SceneManager.Instance();
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
            Console.Clear();

            //int choice = PromptMenuChoice(1, 3);
            int choice = ConsoleUtility.PromptMenuChoice(1, 3, 48, 40);

            switch ((MenuList)choice)
            {
                case MenuList.GameStart:
                    Console.WriteLine();
                    if (player.Name == "")
                    {
                        // 캐릭터 만드는 함수 
                        //player가 만들어지면 만드는 함수
                    }
                    // 그후 로비로 가는 것 의미한다.
                    sceneManager.SceneGameLobby();
                    break;
                case MenuList.GameLoad:
                    Console.WriteLine();
                    // 세이브 데이터 불러오기
                    dateManager.LoadDate();
                    break;
                case MenuList.Exit:
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