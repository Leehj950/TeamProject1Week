using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpartaDungeonGame.EnemyInfo
{
    internal class EnemyStats
    {
        public string Name;
        public int Level;
        public float Atk;
        public int Def;
        public int Gold;
        public int Exp;

        public EnemyStats(string name, int level, float atk, int def, int gold, int exp)
        {
            Name = name;
            Level = level;
            Atk = atk;
            Def = def;
            Gold = gold;
            Exp = exp;
        }

        public void Minion(EnemyStats stats)
        {
            Name = "미니언";
            Level = 2;
            Atk = 5;
            Def = 10;


        }
    }
}
