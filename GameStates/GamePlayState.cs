using System;
using Interfaces;
namespace GameStates
{   
    public class GamePlayState : IGameState
    {
        private GameStateController controller;
        public GamePlayState(GameStateController controller)
        {
            this.controller = controller;
        }
        public void GamePlay()
        {
             // Already in gameplay state
        }
        public void Inventory()
        {
            this.controller.gamestate = new InventoryState(this.controller);
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
    }
}

