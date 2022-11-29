using GameStates;
using LegendofZelda.Interfaces;
using LegendofZelda;

namespace Commands
{
    public class P2WalkRightCommand : ICommand
    {
        private GameStateController controller;
        public P2WalkRightCommand(GameStateController controller)
        {
            this.controller = controller;
        }
        public void Execute()
        {
          Link.Instance2.MoveRight();
            
        }
    }

    public class P2WalkLeftCommand : ICommand
    {
        private GameStateController controller;
        public P2WalkLeftCommand(GameStateController controller)
        {
            this.controller = controller;
        }
        public void Execute()
        {
                Link.Instance2.MoveLeft();
            
        }
    }

    public class P2WalkUpCommand : ICommand
    {
        private GameStateController controller;
        public P2WalkUpCommand(GameStateController controller)
        {
            this.controller = controller;
        }
        public void Execute()
        {
          Link.Instance2.MoveUp();
            
        }
    }

    public class P2WalkDownCommand : ICommand
    {
        private GameStateController controller;

        public P2WalkDownCommand(GameStateController controller)
        {
             this.controller = controller;
        }
    public void Execute()
    {
        Link.Instance2.MoveDown();
        
    }
}
}

