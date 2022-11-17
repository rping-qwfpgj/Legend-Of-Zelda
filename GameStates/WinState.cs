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
using Microsoft.Xna.Framework;

namespace GameStates

{
    public class WinGameState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        private ISprite text;
        private ISprite winGame;
        public WinGameState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWinning(Link.Instance.currentPosition);
            text = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(390, 250), "YAY!");
            winGame = BackgroundSpriteFactory.Instance.WinGameScreen();

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
            controller.gameState = new PauseState(controller, game);
        }
        public void WinGame()
        {
            
        }
        public void TransitionUp()
        {
            controller.gameState = new TransitionUpState(controller, game);
        }
        public void TransitionDown()
        {
            controller.gameState = new TransitionDownState(controller, game);
        }
        public void TransitionLeft()
        {
            controller.gameState = new TransitionLeftState(controller, game);
        }
        public void TransitionRight()
        {
            controller.gameState = new TransitionRightState(controller, game);
        }
        public void Update()
        {
            Link.Instance.game.currentRoom.Update();
            Link.Instance.Update();
            winGame.Update();
        }
        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch _spriteBatch)
        {
            Link.Instance.game.currentRoom.Draw(_spriteBatch);
            winGame.Draw(_spriteBatch);
            Link.Instance.Draw(_spriteBatch);
            text.Draw(_spriteBatch);
            
        }
    }
}

