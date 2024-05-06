using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Utility;

namespace TeamSpartaDungeonGame.Content
{
    public enum Difficulty
    {
        Easy = 1,
        Medium,
        Hard,
        Boss,
        Exit
    }

    internal class Dungeon
    {
        /// <summary>
        /// 변수
        /// </summary>
        private bool isExit = false;
        private bool isDungeonExit = false;
        private bool isEasy;
        private bool isMedium;
        private bool isHard;
        /// <summary>
        /// 생성자
        /// </summary>
        public Dungeon() { }

        /// <summary>
        /// 함수
        /// </summary>
        public void Update()
        {
            ///입력 받은 값
            int number = ConsoleUtility.PromptMenuChoice(1, 5);

            // 스위칭 문으로 만드는 던전문
            switch ((Difficulty)number)
            {
                case Difficulty.Easy:
                    InDungeonLoop(Difficulty.Easy);
                    break;
                case Difficulty.Medium:
                    InDungeonLoop(Difficulty.Medium);
                    break;
                case Difficulty.Hard:
                    InDungeonLoop(Difficulty.Hard);
                    break;
                case Difficulty.Boss:
                    InDungeonLoop(Difficulty.Boss);
                    break;
                case Difficulty.Exit:
                    // 이전 게임 로비로 돌아감.
                    isExit = true;
                    break;
                default:
                    break;
            }
        }

        public void Render()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("1.하급던전");
            Console.WriteLine();
            Console.Write("2.중급던전");
            Console.WriteLine();
            Console.Write("3.상급던전");
            Console.WriteLine();
            Console.Write("4.보스방");
            Console.WriteLine();
            Console.Write("5.던전이탈");
            Console.WriteLine();
        }
        public void Loop()
        {
            while (!isExit)
            {
                Render();
                Update();
            }
        }

        public void InDungeonLoop(Difficulty value)
        {
            Difficulty select = value;
            while (!isDungeonExit)
            {
                InDungeonRender(select);
                InDungeonUpdate(select);
            }
        }

        public void InDungeonRender(Difficulty value)
        {

        }

        public void InDungeonUpdate(Difficulty value)
        {

        }
    }
}
