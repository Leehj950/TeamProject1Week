using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.EnemyInfo;
using TeamSpartaDungeonGame.Interface;
using TeamSpartaDungeonGame.PlayerInfo;
using TeamSpartaDungeonGame.Utility;

namespace TeamSpartaDungeonGame.Content
{
    public enum Difficulty
    {
        EASY = 1,
        MEDIUM,
        HARD,
        BOSS,
        EXIT
    }

    public enum BattleList
    {
        ATTACK = 1,
        SKIPTURN,
        EXIT
    }

    public enum ActionList
    {
        BATTLESTRAT = 1,
        RUN
    }

    internal class Dungeon : IFramework
    {
        /// <summary>
        /// 변수
        /// </summary>
        private bool isExit = false;
        private bool isDungeonExit = false;
        private Player player;
        private bool isEasy;
        private bool isMedium;
        private bool isHard;
        private bool isBattle = false;
        private bool isTarget = false;
        private int enemyCount;
        private int indunHp; // 입장한 후 체력
        /// <summary>
        /// 생성자
        /// </summary>
        public Dungeon(Player player)
        {
            this.player = player;
        }

        List<Enemy> enemies = new List<Enemy>();

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
                case Difficulty.EASY:
                    InDungeonLoop(Difficulty.EASY);
                    break;
                case Difficulty.MEDIUM:
                    InDungeonLoop(Difficulty.MEDIUM);
                    break;
                case Difficulty.HARD:
                    InDungeonLoop(Difficulty.HARD);
                    break;
                case Difficulty.BOSS:
                    InDungeonLoop(Difficulty.BOSS);
                    break;
                case Difficulty.EXIT:
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
            Reset();
        }

        void InDungeonInitalize(Difficulty difficulty)
        {

            if (difficulty == Difficulty.EASY)
            {
                enemies.Add(new Enemy("미니언", 2, 15, 5, 100, 10));
                enemies.Add(new Enemy("공허충", 3, 10, 9, 300, 20));
                enemies.Add(new Enemy("대포미니언", 5, 25, 8, 500, 30));
                enemyCount = enemies.Count;
            }
            else if (difficulty == Difficulty.MEDIUM)
            {

            }
            else if (difficulty == Difficulty.HARD)
            {

            }
            else if (difficulty == Difficulty.BOSS)
            {

            }
        }

        public void InDungeonLoop(Difficulty value)
        {
            Difficulty select = value;
            InDungeonInitalize(select);
            while (!isDungeonExit)
            {
                InDungeonRender();
                InDungeonUpdate();
            }
        }

        public void InDungeonRender()
        {
            Console.Clear();
            Console.WriteLine("배틀");
            Console.WriteLine("");
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].PrintStat(isBattle, i);
            }
            if (isBattle == false)
            {
                Console.WriteLine("1.전투를 시작하겠습니까?");
                Console.WriteLine("2.도망치겠습니까?");
            }
            else
            {
                Console.WriteLine("1.공격");
                Console.WriteLine("2.턴넘기기");
                Console.WriteLine("3.도망치기");
            }
        }

        public void InDungeonUpdate()
        {
            if (!isBattle)
            {
                switch ((ActionList)ConsoleUtility.PromptMenuChoice(1, 2))
                {
                    case ActionList.BATTLESTRAT:
                        isBattle = true;
                        break;
                    case ActionList.RUN:
                        isDungeonExit = true;
                        isExit = true;
                        break;
                }
            }
            else
            {
                switch ((BattleList)ConsoleUtility.PromptMenuChoice(1, 3))
                {
                    case BattleList.ATTACK:
                        PlayerTurn();
                        break;
                    case BattleList.SKIPTURN:
                        EnemeyTurn();
                        break;
                    case BattleList.EXIT:
                        isDungeonExit = true;
                        break;
                }
            }
        }
        void Reset()
        {
            enemies.Clear();
            isBattle = false;
            isDungeonExit= false;
            isExit = false;
        }
        void EnemeyTurn()
        {
            int number;
            while (true)
            {
                Random random = new Random();
                number = random.Next(1, enemies.Count);

                if (enemies[number-1].Stats.Hp <= 0)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            int curHp = player.Stat.Hp;

            enemies[number].Attack(player);

            int selet = ConsoleUtility.PromptMenuChoice(0, 0);

            if (selet == 0 && player.Stat.Hp > 0)
            {
                return;
            }
            else if (selet == 0 && player.Stat.Hp <= 0)
            {
                bool islive = player.Death(curHp);
                isDungeonExit = islive;
                isExit = islive;
            }
        }

        void PlayerTurn()
        {
            while (!isTarget)
            {
                Console.Clear();
                Console.WriteLine("배틀");
                Console.WriteLine("");
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].PrintStat(isBattle, i );
                }

                Console.WriteLine();
                Console.WriteLine("공격할 대상을 선택하세요.");

                int selet = ConsoleUtility.PromptMenuChoice(1, enemies.Count);

                if (enemies[selet-1].Stats.Hp <= 0)
                {
                    continue;
                }

                PlayerResult(enemies[selet-1]);
            }

        }
        void PlayerResult(Enemy number)
        {
            Console.Clear();
            // 전투
            player.Attack(number);
            // 전투후

            Console.WriteLine("0. 다음");

            int selet = ConsoleUtility.PromptMenuChoice(0, 0);

            if (selet == 0 && enemyCount != 0)
            {
                EnemeyTurn();
            }
            else if (selet == 0 && enemyCount == 0)
            {
                DungeonClear();
            }
        }

        void DungeonClear()
        {
            Console.Clear();
            Console.WriteLine("Battle!! - Result");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Victory");
            Console.WriteLine();
            Console.WriteLine($"던전에서 몬스터 {enemies.Count}마리를 잡았습니다.");

            Console.WriteLine($"Lv.{player.Stat.Lv} {player.Stat.Name}");

            Console.WriteLine("0. 다음");

            int selet = ConsoleUtility.PromptMenuChoice(0, 0);

            if (selet == 0)
            {
                isDungeonExit = true;
                isExit = true;
            }
        }

    }



}
