﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Interfaces;

namespace Sprites
{
    public class FireUpSprite : ISprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2500;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;

        public FireUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        // having boomeraing come back note:
        // pull initial position, once position hits inital plus certian amount, have position start decrementing rather than incrementing


        public void Update()
        {
           
            bool done = false;

            if (!done) { currFrames += 50; }

            if (currFrames <= 1500) { this.yPosition -= 4; }

            if (currFrames >= maxFrames) { done = true; }

            
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(191, 185, 16, 16); // fire
            Rectangle destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 16 * 4, 16 * 4); // Where to draw on screen

            // Draw the sprite
            spriteBatch.Begin();
            if(currFrames < maxFrames)
            {

                if ((currFrames/100) % 2 == 0) {
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
                }
                    
            }
          
            spriteBatch.End();
        }

        public Vector2 getPosition()
        {
            return new Vector2(this.xPosition, this.yPosition);
        }
    }

    public class FireRightSprite : ISprite
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2500;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition; 

        public FireRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public void Update()
        {
            bool done = false;

            if (!done)
            {
                currFrames += 50;
            }
            if (currFrames <= 1500)
            {
                this.xPosition += 4;
            }
            if (currFrames >= maxFrames) 
            { 
                done = true; 
            }

        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(191, 185, 16, 16); // fire
            Rectangle destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 16 * 4, 16 * 4); // Where to draw on screen

            // Draw the sprite
            spriteBatch.Begin();

            if (currFrames < maxFrames)
            {

                if ((currFrames / 100) % 2 == 0)
                {
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                } else
                {
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
                }
            }
            spriteBatch.End();
        }

        public Vector2 getPosition()
        {
            return new Vector2(this.xPosition, this.yPosition);
        }
    }

    public class FireDownSprite : ISprite
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2500;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;
        

        public FireDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public void Update()
        {
            bool done = false;

            if (!done)
            {
                currFrames += 50;
            }
            if (currFrames <= 1500)
            {
                this.yPosition += 4;
            }
            if (currFrames >= maxFrames)
            {
                done = true;
            }

        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(191, 185, 16, 16); // fire
            Rectangle destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 16 * 4, 16 * 4); // Where to draw on screen

            // Draw the sprite
            spriteBatch.Begin();
            if (currFrames < maxFrames)
            {
                if ((currFrames / 100) % 2 == 0)
                {
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
                }
            }
            spriteBatch.End();
        }

        public Vector2 getPosition()
        {
            return new Vector2(this.xPosition, this.yPosition);
        }
    }

    public class FireLeftSprite : ISprite
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2500;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;
     

        public FireLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public void Update()
        {
            bool done = false;

            if (!done)
            {
                currFrames += 50;
            }
            if (currFrames <= 1500)
            {
                this.xPosition -= 4;
            }
            if (currFrames >= maxFrames)
            {
                done = true;
            }

        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(191, 185, 16, 16); // fire
            Rectangle destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 16 * 4, 16 * 4); // Where to draw on screen

            // Draw the sprite
            spriteBatch.Begin();
            if (currFrames < maxFrames)
            {
                if (currFrames < maxFrames)
                {
                    if ((currFrames / 100) % 2 == 0)
                    {
                        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
                    }
                }
            }
            spriteBatch.End();
        }

        public Vector2 getPosition()
        {
            return new Vector2(this.xPosition, this.yPosition);
        }
    }
}
