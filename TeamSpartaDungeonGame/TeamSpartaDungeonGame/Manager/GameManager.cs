using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.PlayerInfo;

namespace TeamSpartaDungeonGame.Manager
{
    public enum MenuList
    {
        GameStart = 1,
        GameLoad = 2, 
        Exit = 3
    }

    internal class GameManager
    {

        private Player player;
        private DateManager dateManager;

        public GameManager()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            dateManager = new DateManager();
            player = new Player("test", "Programmer", 1, 10, 5, 100, 15000);
        }

        public void StartGame()
        {
            Console.Clear();
            PrintGameHeader();
            MainMenu();
        }

        private void MainMenu()
        {
            Console.Clear();

            int choice = PromptMenuChoice(1, 3);

            switch ((MenuList)choice)
            {
                case MenuList.GameStart:
                    Console.WriteLine();
                    break;
                case MenuList.GameLoad:
                    Console.WriteLine();
                    break;
                case MenuList.Exit:
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }

        public void PrintGameHeader()
        {
            Console.WriteLine();
            Console.WriteLine();

        }

        public int PromptMenuChoice(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine("다시 입력해주세요.");
            }
        }
    }

}
