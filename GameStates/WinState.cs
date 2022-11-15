using System;
using Interfaces;
using Sprint0;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using Sprites;
using SharpDX.Direct2D1;

namespace GameStates

{
    public class WinGameState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        public WinGameState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWinning(Link.Instance.currentPosition);

        }
        public void GamePlay()
        {
            this.controller.gameState = new GamePlayState(this.controller, this.game);
        }
        public void Inventory()
        {
            this.controller.gameState = new InventoryState(this.controller, this.game   , game.hud);
            Debug.WriteLine("goofy ah");
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
            //LinkDyingSprite sprite = Link.Instance.currentLinkSprite as LinkDyingSprite;
            //if (!sprite.isComplete)
            //{
            //Link.Instance.Update();
            Link.Instance.game.currentRoom.Update();
            Link.Instance.currentLinkSprite.Update();
            //}

        }
        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch _spriteBatch)
        {
            //LinkWinningSprite sprite = Link.Instance.currentLinkSprite as LinkWinningSprite;
            //if (!sprite.isComplete)
            //{
            //Link.Instance.Draw(_spriteBatch);
            Link.Instance.game.currentRoom.Draw(_spriteBatch);
            Link.Instance.currentLinkSprite.Draw(_spriteBatch);
            //}
            //if (sprite.isComplete)
            //{
            //    ISprite gameOver = BackgroundSpriteFactory.Instance.GameOverScreen();
            //    gameOver.Draw(_spriteBatch);
            //}
        }
    }
}

