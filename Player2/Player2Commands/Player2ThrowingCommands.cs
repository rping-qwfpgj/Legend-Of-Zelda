using LegendofZelda.Interfaces;
using LegendofZelda;

namespace Commands
{
    public class P2ThrowRightCommand : ICommand
    {
        public P2ThrowRightCommand()
        { 
        }
        public void Execute()
        {
            Link.Instance2.ThrowProjectile();
        }
    }
    public class P2ThrowLeftCommand : ICommand
    {
        public P2ThrowLeftCommand()
        {
        }
        public void Execute()
        {
            Link.Instance2.ThrowProjectile();
        }
    }
    public class P2ThrowUpCommand : ICommand
    {
        public P2ThrowUpCommand()
        {
        }
        public void Execute()
        {
            Link.Instance2.ThrowProjectile();
        }
    }
    public class P2ThrowDownCommand : ICommand
    {
        public P2ThrowDownCommand()
        {
        }
        public void Execute()
        {
            Link.Instance2.ThrowProjectile();
        }
    }
}






