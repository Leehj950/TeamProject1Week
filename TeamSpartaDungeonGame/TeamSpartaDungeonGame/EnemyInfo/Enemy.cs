using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamSpartaDungeonGame.Interface;

namespace TeamSpartaDungeonGame.EnemyInfo
{
    internal class Enemy : IAction
    {
        EnemyStats stats;
        bool isDead;

        public Enemy(string name, int level, float atk, int def, int gold, int exp)
        {
            stats = new EnemyStats(name, level, atk, def, gold, exp);
        }

        public void Attack()
        {

        }
        
        public void Death()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
        
        public void UsingItem()
        {

        }

        public float Critical()
        {
            return 0.0f;
        }
        
        public void Dodge()
        {

        }
    }
}
