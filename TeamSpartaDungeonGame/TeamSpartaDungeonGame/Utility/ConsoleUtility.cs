using System;
using System.Collections.Generic;
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
        public static int PromptMenuChoice(int min, int max)
        {
            while(true) 
            {
                Console.WriteLine("원하시는 번호를 입력해주세요.");
                if(int.TryParse(Console.ReadLine(), out int choice) && choice >=min && choice <= max) 
                {
                    return choice; 
                }
            }
        }

<<<<<<< Updated upstream
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

=======
>>>>>>> Stashed changes
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
    }
}
