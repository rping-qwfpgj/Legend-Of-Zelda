using Sprint0;
using LegendofZelda.Interfaces;

namespace Commands
{
    public class AttackCommand : ICommand
    {
        public AttackCommand()
        {    
        }
        public void Execute()
        {
            Link.Instance.Attack();
        }
    }
}
