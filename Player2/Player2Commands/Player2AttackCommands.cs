using LegendofZelda;
using LegendofZelda.Interfaces;

namespace Commands
{
    public class P2AttackCommand : ICommand
    {
        public P2AttackCommand()
        {
        }
        public void Execute()
        {
            Link.Instance2.Attack();
        }
    }
}
