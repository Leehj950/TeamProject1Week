using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Interface;
using TeamSpartaDungeonGame.PlayerInfo;
using TeamSpartaDungeonGame.Utility;

namespace TeamSpartaDungeonGame.Content
{
    public enum MenuList
    {
        REST = 1,
        EXIT
    }
    internal class RestArea : IFramework
    {
        private bool isExit;
        private bool isRest;
        private bool iscalculate;
        private Stat stat;

        public RestArea(Stat value)
        {
            stat = value;
        }


        public void Initialize()
        {
            isExit = false;
            isRest = false;
        }

        public void Render()
        {
            Console.Clear();
            Console.WriteLine("휴식하기");
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : //{stat.Gold})");

            if (isRest)
            {
                if (iscalculate)
                {
                    Console.Write("휴식인 완료되었습니다.");          // 나중에 Console.SetCursorPosition 으로 바꿀 예정
                    Console.WriteLine();
                    Console.Write($"현재 체력 : {stat.Hp}");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("Gold 가 부족합니다.");
                }
            }

            Console.Write("1. 휴식하기");
            Console.Write("2. 나가기");

        }
        public void Update()
        {
            int choice = ConsoleUtility.PromptMenuChoice(1, 2);

            switch ((MenuList)choice)
            {
                case MenuList.REST:
                    isRest = true;
                    Rest();
                    break;
                case MenuList.EXIT:
                    isExit = true;
                    break;
                default:
                    break;
            }
        }

        void Rest()
        {
            if (stat.Gold > 500)
            {
                iscalculate = true;
                if (stat.Hp < 100)
                {
                    stat.Hp += 30;
                    if (stat.Hp > 100)
                    {
                        stat.Hp = 100;
                    }
                    stat.Gold -= 30;
                }
                else if (stat.Hp > 100)
                {
                    Console.Write("휴식할 필요가 없습니다.");              // 나중에 Console.SetCursorPosition 으로 바꿀 예정
                    Console.WriteLine();
                    isRest = false;
                }
            }
            else
            {
                iscalculate = false;
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
