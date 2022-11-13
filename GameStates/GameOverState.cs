using System;
using Interfaces;
using Sprint0;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using LegendofZelda.SpriteFactories;
using Sprites;
using LegendofZelda.Interfaces;
using System.Diagnostics;

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
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkDying(Link.Instance.currentPosition);
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
            LinkDyingSprite sprite = Link.Instance.currentLinkSprite as LinkDyingSprite;
            if (!sprite.isComplete)
            {
                Link.Instance.Update();
            }

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            LinkDyingSprite sprite = Link.Instance.currentLinkSprite as LinkDyingSprite;
            if (!sprite.isComplete)
            {
                Link.Instance.Draw(_spriteBatch);
            }
            if (sprite.isComplete)
            {
                ISprite gameOver = BackgroundSpriteFactory.Instance.GameOverScreen();
                gameOver.Draw(_spriteBatch);
            }
        }
    }
}

