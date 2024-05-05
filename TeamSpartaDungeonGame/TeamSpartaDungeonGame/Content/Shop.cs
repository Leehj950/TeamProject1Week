using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Interface;

namespace TeamSpartaDungeonGame.Content
{
    internal class Shop : IFramework
    {

        private bool IsExit;
        public Shop() { }


        public void Update()
        {

        }
        
        public void Render()
        {

        }

        public void Loop()
        {
            while(!IsExit)
            {
                Render();
                Update();
            }

        }
    }
}
