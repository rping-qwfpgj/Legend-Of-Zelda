using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Interfaces;
using System;

namespace Sprites
{
    public class LinkWalkingUpSprite : INonAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;
        
        private bool isDamaged;

        // Screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}


        public LinkWalkingUpSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.isDamaged = isDamaged;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 44); // Where to draw on screen
        }

            public void Update()
            {
                // Update frames
                currFrames += 100;

                // If frames are past max, reset to 0
                if (currFrames > maxFrames)
                {
                    currFrames = 0;
                }

                this.yPosition -= 2; // Remember that the Y's decrease as you move up the screen  in Monogame's coordinate system
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 44); // Where to draw on screen
        }      

            // NOTE: All of these source Rectangles are using placeholder values for now
            public void Draw(SpriteBatch spriteBatch)
            {
                // Create source and destination rectangles
                Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
               

                // Draw the first step of link walking up
                if (currFrames >= 0 && currFrames <= 1000)
                {
                    sourceRectangle = new Rectangle(71, 11, 12, 16);

                }
                else if (currFrames > 1000 && currFrames <= 2000) // Draw the 2nd step of link walking up
                {
                    sourceRectangle = new Rectangle(88, 11, 12, 16);
                }

            // Draw the sprite
            spriteBatch.Begin();
            if (isDamaged)
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f));
            }
            else
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            }
            spriteBatch.End();            
        }
         public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
            
        }

    public class LinkWalkingDownSprite : INonAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;

        public bool isDamaged;

        // Screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        public LinkWalkingDownSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.isDamaged = isDamaged;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 44); // Where to draw on screen
        }

        public void Update()
        {
            // Update frames
            currFrames += 100;

            // If frames are past max, reset to 0
            if (currFrames > maxFrames)
            {
                currFrames = 0;
            }

            this.yPosition += 2; // Remember that the Y's increases as you move down the screen  in Monogame's coordinate system
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 40, 44); // Where to draw on screen
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
           

            // Draw the first step of link walking down
            if (currFrames >= 0 && currFrames <= 1000)
            {
                sourceRectangle = new Rectangle(1, 11, 15, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 40, 44); 
            }
            else if (currFrames > 1000 && currFrames <= 2000) // Draw the 2nd step of link walking down
            {
                sourceRectangle = new Rectangle(19, 11, 13, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 34, 44);
            }

            // Draw the sprite
            spriteBatch.Begin();

            if (isDamaged)
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f));
            } else
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            }
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
    }

    public class LinkWalkingLeftSprite : INonAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;

        private bool isDamaged;

        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        public LinkWalkingLeftSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.isDamaged = isDamaged;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 44); // Where to draw on screen
        }

        public void Update()
        {
            // Update frames
            currFrames += 100;

            // If frames are past max, reset to 0
            if (currFrames > maxFrames)
            {
                currFrames = 0;
            }
            
            this.xPosition -= 2;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 40, 44); // Where to draw on screen
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
           

            // Draw the first step of link walking side to side
            if (currFrames >= 0 && currFrames <= 1000)
            {
                sourceRectangle = new Rectangle(35, 11, 15, 16);

            }
            else if (currFrames > 1000 && currFrames <= 2000) // Draw the 2nd step of link walking side to side
            {
                sourceRectangle = new Rectangle(52, 12, 14, 15);
            }

            // Draw the sprite
            spriteBatch.Begin();

            if (isDamaged)
            {
                // Must flip the sprite horizontally as the sprite sheet only has sprites for link moving right
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f), 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
            } else
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1); 
            }
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
    }

    public class LinkWalkingRightSprite : INonAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;
        private bool isDamaged;

        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}
       

        public LinkWalkingRightSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.isDamaged = isDamaged;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 44); // Where to draw on screen
        }

        public void Update()
        {
            // Update frames
            currFrames += 100;

            // If frames are past max, reset to 0
            if (currFrames > maxFrames)
            {
                currFrames = 0;
            }

            this.xPosition += 2;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 40, 44); // Where to draw on screen
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = sourceRectangle = new Rectangle(35, 11, 15, 16);
           

            // Draw the first step of link walking side to side
            if (currFrames >= 0 && currFrames <= 1000)
            {
                sourceRectangle = new Rectangle(35, 11, 15, 16);

            }
            else if (currFrames > 1000 && currFrames <= 2000) // Draw the 2nd step of link walking side to side
            {
                sourceRectangle = new Rectangle(52, 12, 14, 15);
            }

            // Draw the sprite
            spriteBatch.Begin();

            if (isDamaged)
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f));
            } else
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White); 
            }
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
    }
}

