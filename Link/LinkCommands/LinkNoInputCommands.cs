
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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