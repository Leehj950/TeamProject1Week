using TeamSpartaDungeonGame.Interface;
using TeamSpartaDungeonGame.Utility;
using TeamSpartaDungeonGame.Manager;
using TeamSpartaDungeonGame.EnemyInfo;




namespace TeamSpartaDungeonGame.PlayerInfo
{
    enum PlayerJob // 직업 열거형으로 명명
    {
        PROGRAMMER = 1,
        POOR = 2,
        SINGER = 3,
        RICH = 4
    }


    internal class Player : IAction
    {
        Stat stat;
        Inventory inventory;
        public Inventory Invern { get { return inventory; } }
        public Stat Stat { get { return stat; } }
        public Player()
        {
            stat = new Stat();
            inventory = new Inventory();
        }

        bool isExit;

        public void Select() // 수정 많이 해야할듯?
        {
            Console.WriteLine("공격할 몬스터를 선택해주세요\n");
            Console.WriteLine("1. {0} \n 2. {1} \n 3. {2} \n", 0); // 몬스터가 구현되면 바꿀 예정
            Console.Write(" >> ");
            int playerChoice = ConsoleUtility.PromptMenuChoice(1, 3);

            switch (playerChoice)
            {

            }
        }
        public void Attack(Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine(stat.Name + "의 공격!");
            int atk = (int)Critical();
            enemy.Stats.Hp -= atk;
            enemy.PrintBattle(atk);
        }

        public void Attack()
        {

        }
        public void ExpGet(int exp)
        {
            stat.Exp += exp;
        }

        public void StatLoop()
        {
            // 캐릭터 상태창
            while (!isExit)
            {
                Render();
                Update();
            }
        }

        void Update()
        {

            switch (ConsoleUtility.PromptMenuChoice(0, 0))
            {
                case 0:
                    isExit = true;
                    break;
                default:
                    break;
            }
        }
        void Render()
        {
            Console.Clear();
            stat.PlayerStatus();
        }
        public float Critical() // 크리티컬 배수 1.6을 곱해주기 위해서 float 자료형 사용
        {
            float finalDmg;    // 최종 데미지
            float criticalDmg; // 데미지 1.6배수의 값
            int critProb;
            criticalDmg = (float)(stat.Critd * 0.01);

            critProb = new Random().Next(1, 100);
            finalDmg = new Random().Next((int)((stat.Atk + stat.bonusAtk) * 0.9), (int)((stat.Atk + stat.bonusAtk) * 1.1));
            if (critProb <= stat.Crit + stat.bonusCrit)
            {
                Console.WriteLine("운좋게 치명타 발생 ! ! ");
                finalDmg *= criticalDmg;
            }

            // 소수점을 바꾸는 점.
            finalDmg = (float)Math.Round(finalDmg);

            return finalDmg;
        }

        public void Dodge()
        {
            int dodgeProb;
            int takeDmg; // 받는 데미지

            //takeDmg = enemyStats.Atk;// 몬스터의 데미지가 구현되면 바꿀 예정
            dodgeProb = new Random().Next(1, 100);
            if (dodgeProb <= stat.Dodge + stat.bonusDodge)
            {
                Console.WriteLine("어찌어찌 피했다!");
                takeDmg = 0; // 받는 데미지가 0이 된다
            }
        }

        public void CreatePlayer()
        {
            Console.Clear();

            Console.WriteLine("이름 작성해주세요.");
            stat.Name = Console.ReadLine();

            Console.WriteLine("직업선택");

            Console.WriteLine("프로그래머 : Atk : -5 , Hp : -50 , Mp : +100");
            Console.WriteLine("거지 : Hp : +30 , Def : +5 , Dodge : +15");
            Console.WriteLine("가수 : Atk : +5 , Crit : +20 , Critd -= 10");
            Console.WriteLine("부자 : Hp : -50 , Mp : -50, Def : -5 Atk : -5, Gold : +10000 ");
            Console.WriteLine("1. 프로그래머\n2. 거지\n3. 가수\n4. 부자\n");
            Console.Write("직업을 선택해주세요");
            Console.WriteLine(">>");
            int playerChoice = ConsoleUtility.PromptMenuChoice(1, 4);
            PlayerJobSet(playerChoice);
        }

        public void PlayerJobSet(int num1)
        {

            switch (num1) // 플레이어 직업 선택에 따른 스탯 변화
            {
                case (int)PlayerJob.PROGRAMMER:
                    stat.Job = "프로그래머";
                    stat.Atk -= 5;
                    stat.Hp -= 50;
                    stat.Mp += 100;
                    break;
                case (int)PlayerJob.POOR:
                    stat.Job = "거지";
                    stat.Hp += 30;
                    stat.Def += 5;
                    stat.Dodge += 15;
                    break;
                case (int)PlayerJob.SINGER:
                    stat.Job = "가수";
                    stat.Atk += 5;
                    stat.Crit += 20;
                    stat.Critd -= 10;
                    break;
                case (int)PlayerJob.RICH:
                    stat.Job = "부자";
                    stat.Hp -= 50;
                    stat.Mp -= 50;
                    stat.Def -= 5;
                    stat.Atk -= 5;
                    stat.Gold += 10000;
                    break;
            }
        }

        public void Death()
        {

        }

        public bool Death(int hp)
        {
            Console.Clear();

            Console.WriteLine("Battle!! - Result");
            Console.WriteLine();
            Console.WriteLine("You Lose");
            Console.WriteLine();
            Console.WriteLine($"Lv.{hp} -> 0");
            Console.WriteLine();
            Console.WriteLine("운명하셨습니다. . . \n");
            Console.Write("0. 메인메뉴로 돌아가기\n");
            int choiceNum = ConsoleUtility.PromptMenuChoice(0, 0);

            if (choiceNum == 0)
            {
                return true;
            }

            return false;
        }

    }
}