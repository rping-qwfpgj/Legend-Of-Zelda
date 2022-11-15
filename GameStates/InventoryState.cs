﻿using System;
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
        int mapCount;
        int compassCount;
        int fairyCount;
        int triforceCount;
        int bowCount;
        ISprite boomerang = HudSpriteFactory.Instance.CreateSprite(new Vector2(412, 122), "HudBoomerangSprite");
        ISprite bomb = HudSpriteFactory.Instance.CreateSprite(new Vector2(412+50, 122), "HudBombSprite");
        ISprite fire = HudSpriteFactory.Instance.CreateSprite(new Vector2(412+2*50, 122), "HudFireSprite");
        ISprite arrow = HudSpriteFactory.Instance.CreateSprite(new Vector2(412+3*50, 122), "HudBowSprite");

        ISprite boomerang1= HudSpriteFactory.Instance.CreateSprite(new Vector2(220, 122), "HudBoomerangSprite");
        ISprite bomb1 = HudSpriteFactory.Instance.CreateSprite(new Vector2(220, 122), "HudBombSprite");
        ISprite fire1 = HudSpriteFactory.Instance.CreateSprite(new Vector2(220, 122), "HudFireSprite");
        ISprite arrow1 = HudSpriteFactory.Instance.CreateSprite(new Vector2(220, 122), "HudBowSprite");

        ISprite boomerang2= HudSpriteFactory.Instance.CreateSprite(new Vector2(420, 50), "HudBoomerangSprite");
        ISprite bomb2 = HudSpriteFactory.Instance.CreateSprite(new Vector2(420, 50), "HudBombSprite");
        ISprite fire2= HudSpriteFactory.Instance.CreateSprite(new Vector2(420, 50), "HudFireSprite");
        ISprite arrow2 = HudSpriteFactory.Instance.CreateSprite(new Vector2(420, 50), "HudBowSprite");

        List<ISprite> actualHudSprites;
        List<ISprite> selectedItems;
        ISprite selectedItem;

        ISprite itemSelectionBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 0), "InventorySelectionSprite");
        ISprite mapDisplayBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 230), "MapDisplaySprite");
        //ISprite hudBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 460), "hudBackground");
        public ISprite cursor = HudSpriteFactory.Instance.CreateSprite(new Vector2(400, 122), "HudSelectionCursor");
      
        Hud hud = new Hud(0, 460);
        Hud actualHud;
        public InventoryState(GameStateController controller, Game1 game, Hud hud)
        {
            this.controller = controller;
            this.game = game;
            selectedItems = new List<ISprite>();
            selectedItems = new List<ISprite>();
            selectedItems.Add(boomerang1);
            selectedItems.Add(bomb1);
            selectedItems.Add(fire1);
            selectedItems.Add(arrow1);
            selectedItem = boomerang1;

            actualHudSprites = new();
            actualHudSprites.Add(boomerang2);
            actualHudSprites.Add(bomb2);
            actualHudSprites.Add(fire2);
            actualHudSprites.Add(arrow2);
     
            actualHud = hud;
        }
        public void GamePlay()
        {
            this.controller.gameState = new GamePlayState(this.controller, this.game);
        }
        public void Inventory()
        {
            //already in inventory state
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
            mapCount = Link.Instance.inventory.getItemCount("orange map");
            compassCount = Link.Instance.inventory.getItemCount("compass");
            fairyCount = Link.Instance.inventory.getItemCount("fairy");
            triforceCount = Link.Instance.inventory.getItemCount("triforce");
            bowCount = Link.Instance.inventory.getItemCount("bow");
            hud.Update();
            cursor.Update();
            this.game.keyboardController.Update();

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
                        actualHud.sprites.Remove(actualHud.throwableSprite);
                        actualHud.throwableSprite = actualHudSprites[i];
                        actualHud.sprites.Add(actualHud.throwableSprite);
                       
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

            bomb.Draw(_spriteBatch);
            arrow.Draw(_spriteBatch);
            boomerang.Draw(_spriteBatch);
            fire.Draw(_spriteBatch);
            selectedItem.Draw(_spriteBatch);

        }
    }
}







//ISprite text = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(100, 100), "fucking hell");