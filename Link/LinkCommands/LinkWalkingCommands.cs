using LegendofZelda.Interfaces;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    public class WalkRightCommand : ICommand
    {
        private readonly Link currLink;

        public WalkRightCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.MoveRight();
        }

    }

    public class WalkLeftCommand : ICommand
    {
        private readonly Link currLink;

        public WalkLeftCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.MoveLeft();
        }
    }

    public class WalkUpCommand : ICommand
    {
        private readonly Link currLink;

        public WalkUpCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.MoveUp();
        }

    }

    public class WalkDownCommand : ICommand
    {
        private readonly Link currLink;

        public WalkDownCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.MoveDown();
        }

    }

    }

