
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
        

        public TakeDamageCommand()
        {
            
        }

        public void Execute()
        {
            Link.Instance.TakeDamage();
        }
    }
}
