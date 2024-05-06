﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Manager;
using TeamSpartaDungeonGame.Utility;

namespace TeamSpartaDungeonGame.PlayerInfo
{
    public class Stat
    {

        private string name;
        public string Name { get { return name; } set { name = value; } }    // 사용자 이름

        public string Job { get; set; }
        public int Lv { get; set; }  // 레  벨
        public int Atk { get; set; } // 공격력
        public int Def { get; set; } // 방어력
        public int Hp { get; set; }  // 체  력
        public int MaxHp { get; set; } // 최대 체력
        public int Mp { get; set; }  // 마  나
        public int MaxMp { get; set; } // 최대마나
        public int Gold { get; set; } // 보유 골드
        public int Crit { get; set; } // 크리티컬 확률
        public int Critd { get; set; }// 크리티컬 데미지
        public int Dodge { get; set; }// 회피 확률
        public int Exp { get; set; } // 경험치
        public Stat()
        {
            Name = " ";
            Job = "";
            Lv = 1;
            Atk = 10;
            Def = 10;
            Hp = 100;
            MaxHp = 100;
            Mp = 50;
            MaxMp = 50;
            Crit = 10;
            Critd = 160;
            Dodge = 10;
            Gold = 2000;
            Exp = 0;
        }

        public void PlayerStatus()
        {
            Console.WriteLine("     [스탯 창]     \n");
            Console.WriteLine($"이  름         : {Name}");
            Console.WriteLine($"직  업         : {Job}");
            Console.WriteLine($"LEVEL          : {Lv}");
            Console.WriteLine($"공격력         : {Atk}");
            Console.WriteLine($"방어력         : {Def}");
            Console.WriteLine($"체  력         : {Hp}");
            Console.WriteLine($"마  나         : {Mp}");
            Console.WriteLine($"크리티컬 확률   : {Crit}");
            Console.WriteLine($"크리티컬 데미지 : {Critd}");
            Console.WriteLine($"회피 확률 : {Dodge}\n");
            Console.WriteLine($"보유 골드 : {Gold}\n");
            Console.WriteLine($"현재 경험치 : {Exp}\n");
        }
    }
}







