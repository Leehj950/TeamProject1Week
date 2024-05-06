using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpartaDungeonGame.Interface
{
    internal interface IAction
    {

        public void Attack();
        public void Death();
        public float Critical();
        public void Dodge();
    }
}

