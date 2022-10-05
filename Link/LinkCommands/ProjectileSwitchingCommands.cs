using Interfaces;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Commands
{
    public class SwitchToBombCommand : ICommand
    {
        private readonly Link currLink;

        public SwitchToBombCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.throwable = Link.Throwables.Bomb;
        }

    }


    public class SwitchToBoomerangCommand : ICommand
    {
        private readonly Link currLink;

        public SwitchToBoomerangCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.throwable = Link.Throwables.Boomerang;
        }

    }

    public class SwitchToBlueBoomerangCommand : ICommand
    {
        private readonly Link currLink;

        public SwitchToBlueBoomerangCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.throwable = Link.Throwables.BlueBoomerang;
        }

    }

    public class SwitchToArrowCommand : ICommand
    {
        private readonly Link currLink;

        public SwitchToArrowCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.throwable = Link.Throwables.Arrow;
        }

    }
    public class SwitchToBlueArrowCommand : ICommand
    {
        private readonly Link currLink;

        public SwitchToBlueArrowCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.throwable = Link.Throwables.BlueArrow;
        }

    }

    public class SwitchToFireCommand : ICommand
    {
        private readonly Link currLink;

        public SwitchToFireCommand(Link currLink)
        {
            this.currLink = currLink;
        }

        public void Execute()
        {
            currLink.throwable = Link.Throwables.Fire;
        }

    }
}
