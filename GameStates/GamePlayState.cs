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
            this.controller.gameState = new InventoryState(this.controller);
            Debug.WriteLine("goofy ah");
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
        public void Draw(SpriteBatch _spriteBatch)
        {
            this.game.GraphicsDevice.Clear(Color.Black);
            this.game.currentRoom.Draw(_spriteBatch);
            Link.Instance.Draw(_spriteBatch);
            this.game.hud.Draw(_spriteBatch);
        }
    }
}

