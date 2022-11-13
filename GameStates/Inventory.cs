using System;
using Interfaces;
using Sprint0;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;


namespace GameStates

{
    public class InventoryState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        public InventoryState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
        }
        public void GamePlay()
        {
            this.controller.gameState = new GamePlayState(this.controller, this.game);
        }
        public void Inventory()
        {
            
        }
        public void GameOver()
        {
            this.controller.gameState = new GameOverState(this.controller, this.game);
        }
        public void Pause()
        {
            this.controller.gameState = new PauseState(this.controller, this.game);
        }
        public void WinGame()
        {
            this.controller.gameState = new WinGameState(this.controller, this.game);
        }
        public void TransitionUp()
        {
            this.controller.gameState = new TransitionUpState(this.controller, this.game);
        }
        public void TransitionDown()
        {
            this.controller.gameState = new TransitionDownState(this.controller, this.game);
        }
        public void TransitionLeft()
        {
            this.controller.gameState = new TransitionLeftState(this.controller, this.game);
        }
        public void TransitionRight()
        {
            this.controller.gameState = new TransitionRightState(this.controller, this.game);
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
        public void Draw(SpriteBatch _spriteBatch)
        {
            this.game.GraphicsDevice.Clear(Color.Black);
            this.game.currentRoom.Draw(_spriteBatch);
            Link.Instance.Draw(_spriteBatch);
            this.game.hud.Draw(_spriteBatch);
        }
    }
}

