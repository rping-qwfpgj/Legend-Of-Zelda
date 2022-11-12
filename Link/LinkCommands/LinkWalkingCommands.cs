using LegendofZelda.Interfaces;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    public class WalkRightCommand : ICommand
    {
        

        public WalkRightCommand()
        {
            
        }

        public void Execute()
        {
            Link.Instance.MoveRight();
        }

    }

    public class WalkLeftCommand : ICommand
    {
        

        public WalkLeftCommand()
        {
            
        }

        public void Execute()
        {
            Link.Instance.MoveLeft();
        }
    }

    public class WalkUpCommand : ICommand
    {
        

        public WalkUpCommand()
        {
            
        }

        public void Execute()
        {
            Link.Instance.MoveUp();
        }

    }

    public class WalkDownCommand : ICommand
    {
        

        public WalkDownCommand()
        {
            
        }

        public void Execute()
        {
            Link.Instance.MoveDown();
        }

    }

    }

