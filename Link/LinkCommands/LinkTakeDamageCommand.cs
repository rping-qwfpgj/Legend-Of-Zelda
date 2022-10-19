
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendofZelda.Interfaces;

namespace Sprint0
{
    public class TakeDamageCommand : ICommand
    {
        private readonly Link link;

        public TakeDamageCommand(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.TakeDamage();
        }
    }
}
