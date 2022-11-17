using System;
using Interfaces;
using Sprint0;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;

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
            controller.gameState = new InventoryState(controller, game, game.hud);
        }
        public void GameOver()
        {
            controller.gameState = new GameOverState(controller, game);
        }
        public void Pause()
        {
            controller.gameState = new PauseState(controller, game);
        }
        public void WinGame()
        {
            controller.gameState = new WinGameState(controller, game);
        }
        
        public void Update()
        {
            Link.Instance.Update();
            game.mouseController.Update();
            game.collisionDetector.Update();
            game.keyboardController.Update();
            game.currentRoom.Update();
            game.hud.Update();            
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.currentRoom.Draw(_spriteBatch);
            Link.Instance.Draw(_spriteBatch);
            game.hud.Draw(_spriteBatch);
        }
    }
}

