using System;
using Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using LegendofZelda.Interfaces;
using LegendofZelda.SpriteFactories;

namespace GameStates

{
    public class TransitionLeftState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        public TransitionLeftState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
        }
        public void GamePlay()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(new(670, 390), false);
            controller.gameState = new GamePlayState(controller, game);
        }
     
        public void Pause()
        {
            controller.gameState = new PauseState(controller, game);
        }
      
        public void Update()
        {
            var background = game.currentRoom.Background as IBackground;
            background.Update();

            if (!background.IsTransitioning)
            {
                GamePlay();
            }

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.currentRoom.Draw(_spriteBatch);
            game.hud.Draw(_spriteBatch);
        }

        //all invalid states from the current state
        public void Inventory() { }
        public void GameOver() { }      
        public void WinGame() { }       
        public void TransitionUp() { }      
        public void TransitionDown() { }      
        public void TransitionLeft() { }
        public void TransitionRight() { }
        
    }
}

