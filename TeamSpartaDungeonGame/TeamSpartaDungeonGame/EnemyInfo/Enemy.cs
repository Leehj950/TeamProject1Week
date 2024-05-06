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
        Player player;

        public Enemy(string name, int level, int atk, int def, int gold, int exp, Player player)
        {
            this.player = player;
            stats = new EnemyStats(name, level, atk, def, gold, exp);
        }

        public void Attack()
        {
            Random rendobj = new Random();
            int rendomValue = rendobj.Next(1, 100);
            float atkPrents = rendomValue / 100;
            float dodge = (rendomValue - 100) / 100;

            if (Dodge1(dodge))
            {

                player.Stat.Hp -= (int)(stats.Atk * Critical(atkPrents));
            }
            else
            {
                Console.WriteLine("Player가 회피하였습니다.");
            }
        }

        public void Death()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }



        public void UsingItem()
        {

        }

        public float Critical()
        {
            return 0.0f;
        }

        public float Critical(float num)
        {
            if (num == 0.1f)
            {
                return 1.6f;
            }

            return 1.0f;
        }

        public void Dodge()
        {

        }
        public void Dodge(float num)
        {

        }

        public bool Dodge1(float num)
        {
            return false;
        }
    }
}
