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
        public void UsingItem();
        public int Critical();
        public void Dodge();
    }
}

