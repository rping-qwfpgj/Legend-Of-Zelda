using LegendofZelda.Interfaces;
using Sprint0;

namespace Commands
{
    public class NoInputCommand : ICommand
    {
        public NoInputCommand()
        {
        }
        public void Execute()
        {
            Link.Instance.NoInput();
        }
    }
}