using System;
using Interfaces;
using Sprint0;
namespace GameStates

{   
    public class GamePlayState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        public GamePlayState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
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
        public void Update()
        {
            Link.Instance.Update();
            this.game.mouseController.Update();
            this.game.collisionDetector.Update();
            this.game.keyboardController.Update();
            this.game.currentRoom.Update();
            this.game.hud.Update();            
        }
        public void Draw()
        {

        }
    }
}

