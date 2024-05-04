using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Interface;

namespace TeamSpartaDungeonGame.Content
{
    internal class GameLobby : IFramework
    {
        Dungeon dungeon;
        RestArea restArea;
        Shop shop;

        private bool IsExit;
        public GameLobby()
        {

        }
        // 렌더러는 거기서 그림을 출력하는 함수.
        public void Render()
        {

        }
        //업데이트는 입력및 계산을 주로 업데이트에서 하고
        // 입력을 받는 것을 주로 합니다.
        public void Update()
        {

        }
        public void Loop()
        {
            Render();
            Update();
        }
    }
}
