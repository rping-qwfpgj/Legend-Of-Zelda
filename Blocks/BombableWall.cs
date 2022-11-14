using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;

namespace LegendofZelda.Blocks
{
    public class BombableDoorBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private static int sourceWidth = 32;
        private static int sourceHeight = 32;
        private Rectangle[] sourceRectangles = { new Rectangle(37, 11, 32, 32), new Rectangle(37, 44, 32, 32), new Rectangle(37, 77, 32, 32), new Rectangle(37, 110, 32, 32) };
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int direction;
        private int xPos;
        private int yPos;
        private int destinationWidth = sourceWidth * 2;
        private int destinationHeight = sourceHeight * 2;

        public BombableDoorBlock(Texture2D doorTexture, int x, int y, int direction)
        {
            texture = doorTexture;
            xPos = x;
            yPos = y;
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


