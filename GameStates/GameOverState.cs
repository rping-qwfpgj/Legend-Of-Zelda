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
        private int count = 1;
        int resetCounter = 0;
        //ISprite dyingSprite = LinkSpriteFactory.Instance.CreateLinkDying(Link.Instance.currentPosition);
        public GameOverState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkDying(Link.Instance.currentPosition);
            //Link.Instance.currentLinkSprite = dyingSprite;
            //Debug.WriteLine(Link.Instance.currentLinkSprite);
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
            //if (count > 0)
            //{
            //Link.Instance.currentLinkSprite = dyingSprite;
            //    count--;
            //}
            LinkDyingSprite sprite = Link.Instance.currentLinkSprite as LinkDyingSprite;
            if (sprite != null)
            {
                if (!sprite.isComplete)
                {
                    //Link.Instance.Update();
                    sprite.Update();
                    //Link.Instance.game.currentRoom.Background.Update();
                }
                
            }
            resetCounter++;

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            //Debug.WriteLine(Link.Instance.currentLinkSprite);
            LinkDyingSprite sprite = Link.Instance.currentLinkSprite as LinkDyingSprite;
            if (sprite != null)
            {
                if (!sprite.isComplete)
                {
                    //Link.Instance.Draw(_spriteBatch);
                    Link.Instance.game.currentRoom.Background.Draw(_spriteBatch);
                    sprite.Draw(_spriteBatch);

                }
                if (sprite.isComplete)
                {
                    ISprite gameOver = BackgroundSpriteFactory.Instance.GameOverScreen();
                    gameOver.Draw(_spriteBatch);
                    
                }
            }
            if (resetCounter > 180)
            {
                Link.Instance.Reset();
            }

        }
    }
}

