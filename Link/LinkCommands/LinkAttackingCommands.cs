

using Sprint0;
using LegendofZelda.Interfaces;

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
