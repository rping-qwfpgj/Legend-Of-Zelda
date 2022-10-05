using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Sprint0;

namespace Commands
{

    public class ThrowRightCommand : ICommand
    {
        private readonly Link currLink;

        public ThrowRightCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.ThrowProjectile();
        }

    }

    public class ThrowLeftCommand : ICommand
    {
        private readonly Link currLink;

        public ThrowLeftCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.ThrowProjectile();
        }

    }

    public class ThrowUpCommand : ICommand
    {
        private readonly Link currLink;

        public ThrowUpCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.ThrowProjectile();
        }

    }

    public class ThrowDownCommand : ICommand
    {
        private readonly Link currLink;

        public ThrowDownCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.ThrowProjectile();
        }

    }
}






