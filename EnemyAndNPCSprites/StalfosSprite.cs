using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class StalfosSprite : IEnemy
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;
        private int direction = 1;
        private bool movingHorizontally = true;
        private bool movingVertically = false;

        private Rectangle destinationRectangle;

        public StalfosSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
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
        
            Rectangle sourceRectangle = new Rectangle(2, 59, 15, 16); 
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 60, 64); 

            spriteBatch.Begin();
            if ((currFrames / 100) % 2 != 0) {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            } else {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
            }
            spriteBatch.End();
    }

        public Rectangle getHitbox()
        {
            return this.destinationRectangle;
        }
    }
}

