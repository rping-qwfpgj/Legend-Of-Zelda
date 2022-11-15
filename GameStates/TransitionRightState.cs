using System;
using Interfaces;
using Sprint0;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using LegendofZelda.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using LegendofZelda.SpriteFactories;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GameStates

{
    public class TransitionRightState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
   
        public TransitionRightState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
        }
        public void GamePlay()
        {

            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(new(130, 395), false);
            this.controller.gameState = new GamePlayState(this.controller, this.game);
            
        }
        public void Inventory()
        {
            this.controller.gameState = new InventoryState(this.controller, this.game, game.hud);
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
            this.controller.gameState = new WinGameState(this.controller, this.game);
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
            
        }
        public void Update()
        {
            var background = this.game.currentRoom.Background as IBackground;
            background.Update();
            
            if (!background.IsTransitioning)
            {
                GamePlay();
            }
            
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            this.game.GraphicsDevice.Clear(Color.Black);
            this.game.currentRoom.Draw(_spriteBatch);
            this.game.hud.Draw(_spriteBatch);
        }

    }
}

