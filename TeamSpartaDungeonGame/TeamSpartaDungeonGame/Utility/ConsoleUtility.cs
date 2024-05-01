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
    }
}
