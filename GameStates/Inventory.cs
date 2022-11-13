using System;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
namespace GameStates
{
    public class InventoryState : IGameState
    {
        private GameStateController controller;
        public InventoryState(GameStateController controller)
        {
            this.controller = controller;
        }
        public void GamePlay()
        {
            
        }
        public void Inventory()
        {
            // Already in InventoryState
        }
        public void GameOver()
        {

        }
        public void Pause()
        {

        }
        public void WinGame()
        {

        }
        public void TransitionUp()
        {

        }
        public void TransitionDown()
        {

        }
        public void TransitionLeft()
        {

        }
        public void TransitionRight()
        {

        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}

