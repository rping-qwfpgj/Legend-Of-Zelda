using GameStates;
using HeadsUpDisplay;
using LegendofZelda.Interfaces;
using SharpDX.MediaFoundation.DirectX;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commands
{
    public class WalkRightCommand : ICommand
    {

        private GameStateController controller;

        public WalkRightCommand(GameStateController controller)
        {
            this.controller = controller;
        }

        public void Execute()
        {
            if (controller.gameState is InventoryState)
            {

                var inventory = controller.gameState as InventoryState;
                var oldRect = inventory.cursor.DestinationRectangle;
                inventory.cursor.DestinationRectangle = new(oldRect.X+oldRect.Width, oldRect.Y, oldRect.Width, oldRect.Height);
            }
            else
            {
                Link.Instance.MoveRight();
            }
        }

    }

    public class WalkLeftCommand : ICommand
    {

        private GameStateController controller;
        public WalkLeftCommand(GameStateController controller)
        {
            this.controller = controller;
        }

        public void Execute()
        {
            if (this.controller.gameState is InventoryState)
            {
                var inventory = controller.gameState as InventoryState;
                var oldRect = inventory.cursor.DestinationRectangle;
                inventory.cursor.DestinationRectangle = new(oldRect.X - oldRect.Width, oldRect.Y, oldRect.Width, oldRect.Height);
            }
            else
            {
                Link.Instance.MoveLeft();
            }
        }
    }

    public class WalkUpCommand : ICommand
    {
        private GameStateController controller;

        public WalkUpCommand(GameStateController controller)
        {
            this.controller = controller;
        }

        public void Execute()
        {

            if (this.controller.gameState is InventoryState)
            {
                var inventory = controller.gameState as InventoryState;
                var oldRect = inventory.cursor.DestinationRectangle;
                inventory.cursor.DestinationRectangle = new(oldRect.X , oldRect.Y - oldRect.Height, oldRect.Width, oldRect.Height);
            }
            else
            {
                Link.Instance.MoveUp();
            }
        }

    }

    public class WalkDownCommand : ICommand
    {
        private GameStateController controller;

        public WalkDownCommand(GameStateController controller)
        {
             this.controller = controller;
        }

        public void Execute()
        {
            if (this.controller.gameState is InventoryState)
            {
                var inventory = controller.gameState as InventoryState;
                var oldRect = inventory.cursor.DestinationRectangle;
                inventory.cursor.DestinationRectangle = new(oldRect.X, oldRect.Y + oldRect.Height, oldRect.Width, oldRect.Height);
            }
            else
            {
                Link.Instance.MoveDown();
            }
            
        }

    }

    }

