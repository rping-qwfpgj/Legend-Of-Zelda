using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendofZelda.Interfaces;
using Sprint0;

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






