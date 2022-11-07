using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class WallMasterSprite : IEnemy
    {// Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        private bool movingHorizontally = true;
        private bool movingVertically = false;

        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}
        public WallMasterSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 60, 60);
        }

        public void Update()
        {
           if (currFrames == maxFrames / 2)
            {
                direction *= -1;
                movingHorizontally = !movingHorizontally;
                movingVertically = !movingVertically;
            }
            if (currFrames == maxFrames)
            {
                currFrames = 0;
            } else
            {
                currFrames += 10;
            }
            
            if (movingVertically && !movingHorizontally)
            {
                if (this.yPosition < 0 || this.yPosition > 480) { direction *= -1; }
                this.yPosition += (1 * direction);
            }
            if (movingHorizontally && !movingVertically)
            {
                if (this.xPosition < 0 || this.xPosition > 800) { direction *= -1; }
                this.xPosition += (1 * direction);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // By default, draw the hand without the pinch
            Rectangle sourceRectangle = new Rectangle(393, 11, 16, 16);
            this.destinationRectangle = new((int)this.xPosition, (int)this.yPosition,60, 60);

            // Otherwise, have it pinch
            if (currFrames > 1000)
            {
                sourceRectangle = new Rectangle(410, 12, 14, 15);

            }

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Vector2 getPosition()
        {
            return new Vector2(this.xPosition, this.yPosition);
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void TakeDamage(string side)
        {

        }
    }
}

