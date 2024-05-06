using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpartaDungeonGame.EnemyInfo
{
    internal class EnemyStats
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Gold { get; set; }
        public int Exp { get; set; }

        public bool Islive {  get; set; }

        public EnemyStats(string name, int level, int  atk, int def, int gold, int exp)
        {
            Name = name;
            Level = level;
            Atk = atk;
            Def = def;
            Gold = gold;
            Exp = exp;
        }
    }
}
