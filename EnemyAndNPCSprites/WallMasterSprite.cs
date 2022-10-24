using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class WallMasterSprite : IEnemy
    {
        // Keep attack
        int currFrames = 0;
        int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }

        // On screen location
        public Rectangle destinationRectangle;
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
            currFrames++;

            if(currFrames < 500)
            {
                this.xPosition += 1;
            } else if(currFrames >= 500 && currFrames < 1000)
            {
                this.yPosition += 1;
            } else if(this.currFrames >= 1000 && this.currFrames <  1500)
            {
                this.xPosition -= 1;
            } else
            {
                this.yPosition -= 1;
            }

            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 60, 60);

            // Reset frames when at max
            if(currFrames == maxFrames)
            {
                currFrames = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // By default, draw the hand without the pinch
            Rectangle sourceRectangle = new Rectangle(393, 11, 16, 16);

            // Otherwise, have it pinch
            if (currFrames > 2000)
            {
                sourceRectangle = new Rectangle(410, 12, 14, 15);

            }

            spriteBatch.Begin();
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

