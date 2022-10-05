
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Sprint0;

namespace Commands
{
    public class NoInputCommand : ICommand
    {
        private readonly Link link;

        public NoInputCommand(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.NoInput();
        }
    }
}