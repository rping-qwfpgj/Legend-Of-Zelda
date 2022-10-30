using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;
using System;
using System.Collections.Generic;

namespace Sprites
{
    public class KeeseSprite : IEnemy
    {
        // Keep track of frames
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
        //private bool movingHorizontally = true;
        //private bool movingVertically = false;

        // On screen position
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        // Handles getting enemy movement to be randomized
        Random random = new Random();
        public enum Directions { UP, RIGHT, LEFT, DOWN};
        List<Directions>  directions = new List<Directions>{Directions.UP, Directions.RIGHT, Directions.LEFT, Directions.DOWN};
        Directions currDirection; 

        public KeeseSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.currDirection = directions[random.Next(0,directions.Count)];

        }

        public void Update()
        {
            if (random.Next(0, maxFrames) <= (maxFrames/50))
            {
                 this.currDirection = directions[random.Next(0,directions.Count)];
            }
            if (currFrames == maxFrames)
            {
                currFrames = 0;
            }
            else
            {
                currFrames += 10;
            }

            if (currDirection == Directions.UP)
            {
                this.yPosition -= 1;
            }
            else if (currDirection == Directions.LEFT)
            {
                this.xPosition -= 1;
            } else if (currDirection == Directions.RIGHT)
            {
                this.xPosition += 1;
            } else // Direction is down
            {
                this.yPosition += 1;
            }
             


        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle sourceRectangle;
            

            spriteBatch.Begin();
            if ((currFrames / 100) % 2 != 0)
            {
                sourceRectangle = new Rectangle(183, 15, 16, 8);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 32);
            }
            else
            {
                sourceRectangle = new Rectangle(203, 15, 10, 10);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 40, 40);
            }
            spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
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

