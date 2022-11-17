using LegendofZelda.Interfaces;
using GameStates;

namespace Commands
{
    public class InventoryCommand : ICommand
    {
        private GameStateController controller;

        public InventoryCommand(GameStateController controller)
        {
            this.controller = controller;
        }
        public void Execute()
        {

            if (this.controller.gameState is InventoryState)
            {
                this.controller.gameState.GamePlay();
            }
            else
            {
                this.controller.gameState.Inventory();
            }
        }
    }

}


