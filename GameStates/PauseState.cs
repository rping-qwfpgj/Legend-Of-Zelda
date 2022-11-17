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
            controller.gameState = new GamePlayState(controller, game);
        }
        public void Inventory()
        {
            controller.gameState = new InventoryState(controller, game   , game.hud);
        }
        public void GameOver()
        {
            controller.gameState = new GameOverState(controller, game);
        }
        public void Pause()
        {
            
        }
        public void WinGame()
        {
            controller.gameState = new WinGameState(controller, game);
        }
        public void Update()
        {
            game.keyboardController.Update();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
        }
    }
}

