using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpartaDungeonGame.Interface
{
    internal interface IFramework
    {
        public void Update();
        public void Render();
        public void Loop();
    }
}
