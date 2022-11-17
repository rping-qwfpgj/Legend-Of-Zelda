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
using System.Collections.Generic;
using HeadsUpDisplay;

namespace GameStates

{
    public class InventoryState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        int mapCount, compassCount, bowCount;

        ISprite boomerang, bomb, fire, arrow;
        ISprite selectedBoomerang, selectedBomb, selectedFire, selectedArrow;

        List<ISprite> selectedItems;
        ISprite selectedItem;

        ISprite itemSelectionBackground;
        ISprite mapDisplayBackground;
        public ISprite cursor;

        Hud hud;
        Hud inGameHud;
        public InventoryState(GameStateController controller, Game1 game, Hud inGameHud)
        {

            this.controller = controller;
            this.game = game;
            this.inGameHud = inGameHud;
            hud = new Hud(0, 460);
          
            boomerang = HudSpriteFactory.Instance.CreateSprite(new Vector2(412, 122), "HudBoomerangSprite");
            bomb = HudSpriteFactory.Instance.CreateSprite(new Vector2(412 + 50, 122), "HudBombSprite");
            fire = HudSpriteFactory.Instance.CreateSprite(new Vector2(412 + 2 * 50, 122), "HudFireSprite");
            arrow = HudSpriteFactory.Instance.CreateSprite(new Vector2(412 + 3 * 50, 122), "HudBowSprite");

            Vector2 selectedItemLocation = new(220, 122);

            selectedBoomerang = HudSpriteFactory.Instance.CreateSprite(selectedItemLocation, "HudBoomerangSprite");
            selectedBomb = HudSpriteFactory.Instance.CreateSprite(selectedItemLocation, "HudBombSprite");
            selectedFire = HudSpriteFactory.Instance.CreateSprite(selectedItemLocation, "HudFireSprite");
            selectedArrow = HudSpriteFactory.Instance.CreateSprite(selectedItemLocation, "HudBowSprite");

            itemSelectionBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 0), "InventorySelectionSprite");
            mapDisplayBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 230), "MapDisplaySprite");
            cursor = HudSpriteFactory.Instance.CreateSprite(new Vector2(400, 122), "HudSelectionCursor");

            selectedItems = new();
            selectedItems.Add(selectedBoomerang);
            selectedItems.Add(selectedBomb);
            selectedItems.Add(selectedFire);
            selectedItems.Add(selectedArrow);

            selectedItem = selectedBoomerang;

        }
        public void GamePlay()
        {
            controller.gameState = new GamePlayState(controller, game);
        }
        public void Update()
        {
            mapCount = Link.Instance.inventory.getItemCount("orange map");
            compassCount = Link.Instance.inventory.getItemCount("compass");
            bowCount = Link.Instance.inventory.getItemCount("bow");
            cursor.Update();
            game.keyboardController.Update();

            List<Link.Throwables> inventoryItems = new();
            inventoryItems.Add(Link.Throwables.Boomerang);
            inventoryItems.Add(Link.Throwables.Bomb);
            inventoryItems.Add(Link.Throwables.Fire);
            inventoryItems.Add(Link.Throwables.Arrow);
            var newRect = cursor.DestinationRectangle;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if ((newRect.X == 400 + (i * newRect.Width)) && (newRect.Y == 122 + (j * newRect.Height)))
                    {
                        Link.Instance.throwable = inventoryItems[i];
                        selectedItem = selectedItems[i];
                        inGameHud.switchProjectile(i);
                    }
                }
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            
            itemSelectionBackground.Draw(_spriteBatch);
            mapDisplayBackground.Draw(_spriteBatch);
            hud.Draw(_spriteBatch);
            cursor.Draw(_spriteBatch);

            bomb.Draw(_spriteBatch);
            arrow.Draw(_spriteBatch);
            boomerang.Draw(_spriteBatch);
            fire.Draw(_spriteBatch);
            selectedItem.Draw(_spriteBatch);

            for (int i = 0; i < 18; i++)
            {
                if (game.roomsGraph.Visited[i])
                {
                    MapPieceSpriteFactory.Instance.CreateMapPiece(new(0, 0), i).Draw(_spriteBatch);
                }
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
         
            if (bowCount > 0)
            {
                ISprite bow = HudSpriteFactory.Instance.CreateSprite(new Vector2(460, 122), "HudBowSprite");
                bow.Draw(_spriteBatch);
            }
        }

        //all invalid states from the current state
        public void Inventory() { }
        public void GameOver() { }
        public void WinGame() { }
        public void TransitionUp() { }
        public void TransitionDown() { }
        public void TransitionLeft() { }
        public void TransitionRight() { }
        public void Pause() { }
       
    }
}

//ISprite text = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(100, 100), "fucking hell");