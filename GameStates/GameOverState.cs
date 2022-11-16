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

namespace GameStates

{
    public class GameOverState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        int resetCounter = 0;
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
            this.game.hud.Update();
            LinkDyingSprite sprite = Link.Instance.currentLinkSprite as LinkDyingSprite;
            if (sprite != null)
            {
                if (!sprite.isComplete)
                {
                    sprite.Update();
                }
            }
            resetCounter++;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            this.game.hud.Draw(_spriteBatch);
            LinkDyingSprite sprite = Link.Instance.currentLinkSprite as LinkDyingSprite;
            if (sprite != null)
            {
                if (!sprite.isComplete)
                {
                    Link.Instance.game.currentRoom.Background.Draw(_spriteBatch);
                    sprite.Draw(_spriteBatch);
                }
                if (sprite.isComplete)
                {
                    ISprite gameOver = BackgroundSpriteFactory.Instance.GameOverScreen();
                    gameOver.Draw(_spriteBatch);
                }
            }
            if (resetCounter > 210)
            {
                Link.Instance.Reset();
            }
        }
    }
}

