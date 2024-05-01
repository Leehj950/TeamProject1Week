using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.ItemInfo;

namespace TeamSpartaDungeonGame.PlayerInfo
{
    internal class Player
    {
        private List<Item> inventory;
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }

        public float Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }

        public Player( string name, string job, int level, float atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
}
