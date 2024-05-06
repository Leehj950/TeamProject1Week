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

                    break;
                case Difficulty.Medium:
                    break;
                case Difficulty.Hard:

                    break;
                case Difficulty.Boss:
                    //if()
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
            //나중에 그리거나 글씨를 출력을 여기서모아서 출력하기.
        }
        public void Loop()
        {
            while (!isExit)
            {
                Render();
                Update();
            }
        }

        public void DungeonLoop(Difficulty value)
        {
            Difficulty select = value;
            while (!isDungeonExit)
            {
                DungeonRender(select);
                DungeonUpdate(select);
            }
        }

        public void DungeonRender(Difficulty value)
        {

        }

        public void DungeonUpdate(Difficulty value)
        {

        }
    }
}
