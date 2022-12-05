﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;

namespace LegendofZelda.Blocks
{
    public class OpenWhiteDoorBlock : IBlock
    {
        private Texture2D texture;
        
        private static int sourceWidth = 32;
        private static int sourceHeight = 22;
        private int destinationWidth = sourceWidth * 3;
        private int destinationHeight = sourceHeight * 3;

        private Rectangle[] sourceRectangles = { 
            new Rectangle(70, 21, sourceWidth, sourceHeight), 
            new Rectangle(70, 44, sourceHeight, sourceWidth), 
            new Rectangle(70, 77, sourceHeight, sourceWidth), 
            new Rectangle(70, 110, sourceWidth, sourceHeight) };
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        
        private int direction;
        private int xPos;
        private int yPos;
        
        public OpenWhiteDoorBlock(Texture2D doorTexture, int x, int y, int direction)
        {
            texture = doorTexture;
            switch (direction){
                case 0:
                    xPos = 350;
                    yPos = 15;
                    break;
                case 1:
                    xPos = 32;
                    yPos = 199;
                    break;
                case 2:
                    xPos = 700;
                    yPos = 200;
                    break;
                case 3:
                    xPos = 350;
                    yPos = 400;
                    break;
            }
            this.direction = direction;
            // for source rectangles 0 = top, 1 = left, 2 = right, 3 = bottom
            sourceRectangle = sourceRectangles[direction];

            if (direction == 0 || direction == 3)
                destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
            else
                destinationRectangle = new Rectangle(xPos, yPos, destinationHeight, destinationWidth);
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
        public string getSide()
        {
            switch (direction)
            {
                case 0:
                    return "top";
                case 1:
                    return "left";
                case 2:
                    return "right";
                case 3:
                    return "bottom";
                default:
                    return "INVALID DIRECTION NUM PASSED";
            }
        }
    }
}


