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
        EXIT = 2
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("스파르타");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" 던전에 오신 여러분 환영합니다.");
            Console.ResetColor();
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. 게임시작");
            Console.WriteLine("2. 게임종료");
            Console.ResetColor();
//             ConsoleUtility.PrintOutline();
//             ConsoleUtility.PrintGameTitle();
//             ConsoleUtility.PrintGameHeader();

        }

        public void Update()
        {
            switch ((MenuList)ConsoleUtility.PromptMenuChoice(1, 2))
            {
                case MenuList.GAMESTART:
                    Console.WriteLine();
                    if(player.Stat.Name == " ")
                    {
                        player.CreatePlayer();
                    }
                    // 그후 로비로 가는 것 의미한다.
                    sceneManager.SceneGameLobby();
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