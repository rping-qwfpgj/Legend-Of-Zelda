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
using Microsoft.Xna.Framework;

namespace GameStates

{
    public class InventoryState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        int bombCount;
        int keyCount;
        int mapCount;
        int compassCount;
        int boomerangCount;
        int fairyCount;
        int gemstoneCount;
        int triforceCount;
        ISprite itemSelectionBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 0), "InventorySelectionSprite");
        ISprite mapDisplayBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 230), "MapDisplaySprite");
        ISprite hudBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 460), "hudBackground");

        public InventoryState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
        }
        public void GamePlay()
        {
            this.controller.gameState = new GamePlayState(this.controller, this.game);
        }
        public void Inventory()
        {
            
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
            this.controller.gameState = new TransitionRightState(this.controller, this.game);
        }
        public void Update()
        {
            bombCount = Link.Instance.inventory.getItemCount("bomb");
            keyCount = Link.Instance.inventory.getItemCount("orange gemstone");
            mapCount = Link.Instance.inventory.getItemCount("orange map");
            compassCount = Link.Instance.inventory.getItemCount("compass");
            boomerangCount = Link.Instance.inventory.getItemCount("boomerang");
            fairyCount = Link.Instance.inventory.getItemCount("fairy");
            gemstoneCount = Link.Instance.inventory.getItemCount("orange gemstone");
            triforceCount = Link.Instance.inventory.getItemCount("triforce");

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            itemSelectionBackground.Draw(_spriteBatch);
            mapDisplayBackground.Draw(_spriteBatch);
            hudBackground.Draw(_spriteBatch);
        }
    }
}

