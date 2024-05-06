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
        public int Hp {  get; set; }
        public int Atk { get; set; }
        
        public int Gold { get; set; }
        public int Exp { get; set; }

        public bool Islive {  get; set; }

        public EnemyStats(string name, int level,int hp, int  atk, int gold, int exp)
        {
            Name = name;
            Level = level;
            Hp = hp;
            Atk = atk;
            Gold = gold;
            Exp = exp;
            
        }

        public void Minion(EnemyStats stats)
        {
            Name = "미니언";
            Level = 2;
            Hp = 15;
            Atk = 5;
            Gold = 100;
            Exp = 10;
           
        }

        public void VoidBug(EnemyStats stats)
        {
            Name = "공허충";
            Level = 3;
            Hp = 10;
            Atk = 9;
            
            Gold = 300;
            Exp = 20;
        }

        public void CanonMinion(EnemyStats stats)
        {
            Name = "대포미니언";
            Level = 5;
            Hp = 25;
            Atk = 8;
            Gold = 500;
            Exp = 30;
        }
    }
}

            
