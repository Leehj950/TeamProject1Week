using TeamSpartaDungeonGame.Interface;
using TeamSpartaDungeonGame.Utility;
using TeamSpartaDungeonGame.Manager;




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
        SceneManager sceneManager;
        Stat stat;

        public string name;
        public Stat Stat { get; }
        public Player()
        {
            stat = new Stat();
        }

        bool isExit;

        public void Attack() // 수정 많이 해야할듯?
        {
            Console.WriteLine("공격할 몬스터를 선택해주세요\n");
            Console.WriteLine("1. {0} \n 2. {1} \n 3. {2} \n", 0); // 몬스터가 구현되면 바꿀 예정
            Console.Write(" >> ");
            int playerChoice = ConsoleUtility.PromptMenuChoice(1, 3);

            switch (playerChoice)
            {

            }
        }
        public void ExpGet(int exp)
        {
            stat.Exp += exp;
        }

        public void StatLoop()
        {
            // 캐릭터 상태창
            while(isExit)
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
            stat.PlayerStatus();
        }
        public float Critical() // 크리티컬 배수 1.6을 곱해주기 위해서 float 자료형 사용
        {
            float finalDmg;    // 최종 데미지
            float criticalDmg; // 데미지 1.6배수의 값
            int critProb;
            criticalDmg = (float)(stat.Critd * 0.01);

            critProb = new Random().Next(1, 100);
            finalDmg = new Random().Next((int)(stat.Atk * 0.9), (int)(stat.Atk * 1.1));
            if (critProb <= stat.Crit)
            {
                Console.WriteLine("운좋게 치명타 발생");
                finalDmg *= criticalDmg;
            }

            return finalDmg;
        }

        public void Dodge()
        {
            int dodgeProb;
            int takeDmg; // 받는 데미지

            takeDmg = 0;// 몬스터의 데미지가 구현되면 바꿀 예정
            dodgeProb = new Random().Next(1, 100);
            if (dodgeProb <= stat.Dodge)
            {
                Console.WriteLine("어찌어찌 피했다!");
                takeDmg = 0; // 받는 데미지가 0이 된다
            }
        }

        public void CreatePlayer()
        {
            Console.WriteLine("직업선택");
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
                    stat.Atk -= 5;
                    stat.Hp -= 50;
                    stat.Mp += 100;
                    break;
                case (int)PlayerJob.POOR:
                    stat.Hp += 30;
                    stat.Def += 5;
                    stat.Dodge += 15;
                    break;
                case (int)PlayerJob.SINGER:
                    stat.Atk += 5;
                    stat.Crit += 20;
                    stat.Critd -= 10;
                    break;
                case (int)PlayerJob.RICH:
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
            
            if (stat.Hp == 0)
            {
                Console.Clear();
                Console.WriteLine("운명하셨습니다. . . \n");
                Console.Write("0. 메인메뉴로 돌아가기\n");
                int choiceNum = ConsoleUtility.PromptMenuChoice(0, 0);

                if (choiceNum == 0)
                {
                    sceneManager.SceneGameLobby();
                }
            }
        }
        
    }
}