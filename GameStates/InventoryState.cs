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
using SharpDX.Direct3D9;

namespace GameStates

{
    public class InventoryState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        int bombCount;
        ISprite bombCountText;
        int keyCount;
        ISprite keyCountText;
        int mapCount;
        int compassCount;
        int fairyCount;
        int gemstoneCount;
        ISprite gemstoneCountText;
        int triforceCount;
        int bowCount;
        ISprite boomerang = HudSpriteFactory.Instance.CreateSprite(new Vector2(412, 122), "HudBoomerangSprite");
        ISprite itemSelectionBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 0), "InventorySelectionSprite");
        ISprite mapDisplayBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 230), "MapDisplaySprite");
        ISprite hudBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 460), "hudBackground");
        ISprite cursor = HudSpriteFactory.Instance.CreateSprite(new Vector2(400, 122), "HudSelectionCursor");
        ISprite text = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(100, 100), "fucking hell");
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
            bombCountText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(300, 575), "X" + bombCount.ToString());
            keyCount = Link.Instance.inventory.getItemCount("key");
            keyCountText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(300, 550), "X" + keyCount.ToString());
            mapCount = Link.Instance.inventory.getItemCount("orange map");
            compassCount = Link.Instance.inventory.getItemCount("compass");
            fairyCount = Link.Instance.inventory.getItemCount("fairy");
            gemstoneCount = Link.Instance.inventory.getItemCount("orange gemstone");
            gemstoneCountText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(300, 500), "X" + gemstoneCount.ToString());

            triforceCount = Link.Instance.inventory.getItemCount("triforce");
            bowCount = Link.Instance.inventory.getItemCount("bow");
            cursor.Update();

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            
            itemSelectionBackground.Draw(_spriteBatch);
            mapDisplayBackground.Draw(_spriteBatch);
            hudBackground.Draw(_spriteBatch);
            cursor.Draw(_spriteBatch);
            text.Draw(_spriteBatch);

            for (int i = 0; i < 18; i++)
            {
                if (game.roomsGraph.Visited[i])
                {
                    MapPieceSpriteFactory.Instance.CreateMapPiece(new(0, 0), i).Draw(_spriteBatch);
                }

            }


                if (bombCountText != null)
            {
                bombCountText.Draw(_spriteBatch);
            }
            if (keyCountText != null)
            {
                keyCountText.Draw(_spriteBatch);
            }
            if (gemstoneCountText != null)
            {
                gemstoneCountText.Draw(_spriteBatch);
            }
            if (mapCount > 0)
            {
                ISprite map = ItemSpriteFactory.Instance.CreateItem(new Vector2(150, 135), "OrangeMap");
                map.Draw(_spriteBatch);
            }
            if (compassCount > 0)
            {
                ISprite compass = ItemSpriteFactory.Instance.CreateItem(new Vector2(150, 250), "Compass");
                compass.Draw(_spriteBatch);
            }
            boomerang.Draw(_spriteBatch);
            
            if (bowCount > 0)
            {
                ISprite bow = HudSpriteFactory.Instance.CreateSprite(new Vector2(460, 122), "HudBowSprite");
                bow.Draw(_spriteBatch);
            }
        }
    }
}

