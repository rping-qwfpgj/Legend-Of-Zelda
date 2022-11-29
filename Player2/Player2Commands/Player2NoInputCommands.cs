using LegendofZelda.Interfaces;
using LegendofZelda;

namespace Commands
{
    public class Player2NoInputCommand : ICommand
    {
        public Player2NoInputCommand()
        {
        }
        public void Execute()
        {
            Link.Instance2.NoInput();
        }
    }
}