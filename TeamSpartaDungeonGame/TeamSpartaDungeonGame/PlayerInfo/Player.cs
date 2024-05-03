using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.ItemInfo;
using TeamSpartaDungeonGame.Utility;
using TeamSpartaDungeonGame.Interface;
using System.Globalization;
using TeamSpartaDungeonGame.Utility;
using TeamSpartaDungeonGame.Interface;




namespace TeamSpartaDungeonGame.PlayerInfo
{

    internal class Player : IAction
    {

        private List<Item> inventory;
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }

        Stat stat = new Stat();
        public string Name { get; set; }




        public void Attack()
        {
            Console.WriteLine("공격할 몬스터를 선택해주세요\n");
            Console.WriteLine("1. {0} \n 2. {1} \n 3. {2} \n", Monster);
            Console.Write(" >> ");
            int playerChoice = ConsoleUtility.PromptMenuChoice(1, 3);

            switch (playerChoice)
            {

            }
        }

        public void Death()
        {
            throw new NotImplementedException();
        }

        public void StatusMenu()
        {
            // 캐릭터 상태창
            Console.Clear();

            Console.WriteLine("캐릭터 상태보기");
            Console.WriteLine();
        }



        public void UsingItem()
        {
            throw new NotImplementedException();
        }
        public int Critical()
        {
            int finalDmg;
            int critProb;
            critProb = new Random().Next(1, 100);
            finalDmg = new Random().Next((int)(stat.Atk * 0.9), (int)(stat.Atk * 1.1));
            if (critProb <= stat.Crit)
            {

                finalDmg *= stat.Critd;
            }

            return finalDmg;
        }
        public void Dodge()
        {
            int dodgeProb;

            dodgeProb = new Random().Next(1, 100);
            if (dodgeProb <= stat.Dodge)
            {

            }









        }
    }
}


       

       

        
        

       


