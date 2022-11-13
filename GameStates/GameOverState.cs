using System;
using Interfaces;
using Sprint0;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;


namespace GameStates

{
    public class GameOverState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        public GameOverState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
        }
        public void GamePlay()
        {
            
        }
        public void Inventory()
        {
            
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
            // add code for game over animation
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            // add code for game over animation
        }
    }
}

