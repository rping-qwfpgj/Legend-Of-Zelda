using LegendofZelda.Interfaces;
using LegendofZelda;

namespace Commands
{
    public class ThrowRightCommand : ICommand
    {
        public ThrowRightCommand()
        { 
        }
        public void Execute()
        {
            Link.Instance.ThrowProjectile();
        }
    }
    public class ThrowLeftCommand : ICommand
    {
        public ThrowLeftCommand()
        {
        }
        public void Execute()
        {
            Link.Instance.ThrowProjectile();
        }
    }
    public class ThrowUpCommand : ICommand
    {
        public ThrowUpCommand()
        {
        }
        public void Execute()
        {
            Link.Instance.ThrowProjectile();
        }
    }
    public class ThrowDownCommand : ICommand
    {
        public ThrowDownCommand()
        {
        }
        public void Execute()
        {
            Link.Instance.ThrowProjectile();
        }
    }
}






