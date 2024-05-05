using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TeamSpartaDungeonGame.Interface;

namespace TeamSpartaDungeonGame.Content
{
    internal class RestArea : IFramework
    {
        private bool isExit;
        public void Update()
        {

        }

        public void Render()
        {

        }

        public void Loop()
        {
            while (!isExit) 
            {
                Render();
                Update();
            }
        }
    }
}
