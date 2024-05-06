using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpartaDungeonGame.Utility
{
    internal class ConsoleUtility
    {
        //콘솔에 관한 기능이 있을때. 그리고
        //사용이 계속 반복적으로 쓸때 여기서 함수를
        //만들어서 쓴다.

        public static int PromptMenuChoice(int min, int max, int x, int y)
        {

            while (true)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("원하시는 번호를 입력해주세요.");
                Console.SetCursorPosition(x, y+1);    
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                else
                {
                    Console.SetCursorPosition(x, y-1);
                    Console.WriteLine("잘못입력한 값입니다.");
                }
            }
        }

        public static int PromptMenuChoice(int min, int max)
        {
            while(true) 
            {
                Console.WriteLine("원하시는 번호를 입력해주세요.");
                if(int.TryParse(Console.ReadLine(), out int choice) && choice >=min && choice <= max) 
                {
                    return choice; 
                }
                else
                {
                    Console.WriteLine("잘못입력한 값입니다.");
                }
            }
        }

        internal static void ShowTitle(string title) //이렇게 하면 매개변수로 들어온 ■ 상태보기 ■ 가 마제타 색깔이 된다.
        {
            Console.ForegroundColor = ConsoleColor.Magenta;// 색깔 마제타로 입히기
            Console.WriteLine(title);
            Console.ResetColor();// 색깔 초기화 초기화 안하면 다음 출력될 텍스트의 색깔도 마제타색깔로 변경된다.
        }

        public static void PrintTextHighlights(string s1, string s2, string s3 = "")
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
            //이렇게 하면 s1그냥 텍스트 s2 노란색텍스트 색깔 초기화 후 s3 그냥 텍스트 이러면 s2를 강조해줄수 있다.

        }

        public static int GetPrintableLength(string str)
        {
            int length = 0;
            foreach (char c in str)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2;
                }
                else
                {
                    length += 1;
                }

            }

            return length;
        }

        public static string PadRightForMixedText(string str, int totalLength)
        {
            int currentLength = GetPrintableLength(str);
            int padding = totalLength - currentLength;
            return str.PadRight(str.Length + padding);
        }

        public static void PrintOutline()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 60; i++)
            {
                //상하
                Console.SetCursorPosition(i * 2, 0);
                Console.Write('■');
                Console.SetCursorPosition(i * 2, 50);
                Console.Write('■');
            }

            for (int i = 0; i <= 50; i++)
            {
                //좌우
                Console.SetCursorPosition(0, i);
                Console.Write('■');
                Console.SetCursorPosition(120, i);
                Console.Write('■');
            }
        }

        public static void PrintGameHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 60; i++)
            {
                Console.SetCursorPosition(i * 2, 30);
                Console.Write('■');
                Console.SetCursorPosition(i * 2, 50);
                Console.Write('■');
            }

            for (int i = 0; i <= 16; i++)
            {
                Console.SetCursorPosition(0, i * 2);
                Console.Write('■');
                Console.SetCursorPosition(120, i * 2);
                Console.Write('■');
            }
            Console.ResetColor();

        }

        public static void PrintGameTitle()
        {

            Console.SetCursorPosition(20, 3);
            Console.Write("TTTTTTTTTTTTTTTTTTTTTTT SSSSSSSSSSSSSSS   DDDDDDDDDDDDD             GGGGGGGGGGGGG");
            Console.SetCursorPosition(20, 4);
            Console.Write("T:::::::::::::::::::::T SS:::::::::::::::SD::::::::::::DDD          GGG::::::::::::G");
            Console.SetCursorPosition(20, 5);
            Console.Write("T:::::::::::::::::::::T SS:::::::::::::::SD::::::::::::DDD       GGG::::::::::::G");
            Console.SetCursorPosition(20, 6);
            Console.Write("T:::::::::::::::::::::TS:::::SSSSSS::::::SD:::::::::::::::DD GG:::::::::::::::G");
            Console.SetCursorPosition(20, 7);
            Console.Write("T:::::::::::::::::::::TS:::::SSSSSS::::::SD:::::::::::::::DD GG:::::::::::::::G");
            Console.SetCursorPosition(20, 8);
            Console.Write("T:::::::::::::::::::::TS:::::SSSSSS::::::SD:::::::::::::::DD GG:::::::::::::::G");
            Console.SetCursorPosition(20, 9);
            Console.Write("T:::::TT:::::::TT:::::TS:::::S SSSSSSSDDD:::::DDDDD:::::D G:::::GGGGGGGG::::G");
            Console.SetCursorPosition(20, 10);
            Console.Write("T:::::::::::::::::::::TS:::::SSSSSS::::::SD:::::::::::::::DD GG:::::::::::::::G");
            Console.SetCursorPosition(20, 11);
            Console.Write("T:::::::::::::::::::::TS:::::SSSSSS::::::SD:::::::::::::::DD GG:::::::::::::::G");
            Console.SetCursorPosition(20, 12);
            Console.Write("T:::::::::::::::::::::TS:::::SSSSSS::::::SD:::::::::::::::DD GG:::::::::::::::G");
            Console.SetCursorPosition(20, 13);

            //T:::::::::::::::::::::TS:::::SSSSSS::::::SD:::::::::::::::DD GG:::::::::::::::G
            //T:::::TT:::::::TT:::::TS:::::S SSSSSSSDDD:::::DDDDD:::::D G:::::GGGGGGGG::::G
            //TTTTTT T:::::T TTTTTTS:::::S D:::::D D:::::D G:::::G GGGGGG
            //        T:::::T S:::::S D:::::D D:::::DG:::::G
            //        T:::::T S::::SSSS           D:::::D D:::::DG:::::G
            //        T:::::T SS::::::SSSSS      D:::::D D:::::DG:::::G GGGGGGGGGG
            //        T:::::T SSS::::::::SS    D:::::D D:::::DG:::::G G::::::::G
            //        T:::::T SSSSSS::::S   D:::::D D:::::DG:::::G GGGGG::::G
            //        T:::::T S:::::S D:::::D D:::::DG:::::G G::::G
            //        T:::::T S:::::S D:::::D D:::::D G:::::G G::::G
            //      TT:::::::TT SSSSSSS     S:::::SDDD:::::DDDDD:::::D G:::::GGGGGGGG::::G
            //      T:::::::::T S::::::SSSSSS:::::SD:::::::::::::::DD GG:::::::::::::::G
            //      T:::::::::T S:::::::::::::::SS D::::::::::::DDD          GGG::::::GGG:::G
            //      TTTTTTTTTTT       SSSSSSSSSSSSSSS DDDDDDDDDDDDD                GGGGGG GGGG








        }
    }
}
