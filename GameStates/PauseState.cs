using System;
using Interfaces;
using Sprint0;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;


namespace GameStates

{
    public class PauseState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        public PauseState(GameStateController controller, Game1 game)
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
            this.controller.gameState = new InventoryState(this.controller, this.game   , game.hud);
        }
        public void GameOver()
        {
            this.controller.gameState = new GameOverState(this.controller, this.game);
        }
        public void Pause()
        {
            
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
            this.game.keyboardController.Update();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
        }
    }
}

