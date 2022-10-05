
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sprint0;
using Interfaces;

namespace Commands
{

    public class AttackCommand : ICommand
    {
        private readonly Link currLink;

        public AttackCommand(Link link)
        {
            this.currLink = link;
        }

        public void Execute()
        {
            currLink.Attack();
        }

    }


}
