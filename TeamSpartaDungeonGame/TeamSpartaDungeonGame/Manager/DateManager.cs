using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Content;
using TeamSpartaDungeonGame.ItemInfo;
using TeamSpartaDungeonGame.PlayerInfo;

namespace TeamSpartaDungeonGame.Manager
{
    [Serializable]
    internal class DateManager
    {

        // 플레이어 정보값
        private static DateManager instance;  //DateManager 싱글톤


        public static DateManager Instance() //객채를 생성하기위한 싱글톤 함수
        {
            if (instance == null)
            {
                instance = new DateManager();
                return instance;
            }
            return instance;
        }

        public void LoadDate()
        {

        }

        public void SaveDate()
        {

        }
    }
}
