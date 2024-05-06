using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamSpartaDungeonGame.Interface;
using TeamSpartaDungeonGame.PlayerInfo;

namespace TeamSpartaDungeonGame.EnemyInfo
{
    internal class Enemy : IAction
    {
        EnemyStats stats;
        public EnemyStats Stats { get { return stats; } }

        bool isDead;

        public Enemy(string name, int level, int hp, int atk, int gold, int exp)
        {
            stats = new EnemyStats(name, level, hp, atk, gold, exp);
        }
        public void Attack()
        {

        }

        public void Attack(Player player)
        {
            Console.Clear();
            Console.WriteLine($" Lv. {stats.Level} {stats.Name}의 공격");
            Console.WriteLine($" {player.Stat.Name}를 맞췄습니다. [{ stats.Atk}] ");


            Console.Write($"Hp : {player.Stat.Hp} ->");

            player.Stat.Hp -= stats.Atk;

            Console.WriteLine($"{player.Stat.Hp}");
        }

        public void Death()
        {
            Console.WriteLine($" Lv. {stats.Level} {stats.Name}");
            Console.WriteLine($"Hp: {stats.Hp} => Dead");
        }

        public float Critical()
        {
            return 0.0f;
        }

        public void Dodge()
        {

        }

        public void PrintStat(bool value, int number)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (stats.Hp <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Lv. {stats.Level} {stats.Name} Dead");
                Console.WriteLine();
                Console.ResetColor();
                return;
            }
            if (value == false)
            {
                Console.Write($"Lv. {stats.Level} {stats.Name} Hp: {stats.Hp}");
            }
            else { value = true; }
            {
                Console.Write($"{number +1}. Lv. {stats.Level} {stats.Name} Hp: {stats.Hp}");
            }
            Console.WriteLine();
            Console.ResetColor();

        }

        public void PrintBattle(int damage)
        {
            Console.WriteLine($" Lv. {stats.Level} {stats.Name} [데미지 : {damage}] ");
            
            if(stats.Hp <= 0)
            {
                Death();
            }
            else if(stats.Hp > 0) 
            {
                Console.WriteLine();
                Console.WriteLine($"Lv. {stats.Level} {stats.Name} ");
                Console.WriteLine($"Hp: {stats.Hp}");
            }
        }
    }
}
