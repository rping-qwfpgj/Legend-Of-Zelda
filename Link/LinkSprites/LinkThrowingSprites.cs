using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Sprites
{
    public class LinkThrowingUpSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;

        private bool isDamaged;

        // Is current sprite done with one attack cycle
        private bool isAttack;

        // Screen location
        private Rectangle destinationRectangle;

        public LinkThrowingUpSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.isDamaged = isDamaged;
            this.isAttack = true;
        }

        public void Update()
        {
            // Update frames
            currFrames += 50;

            // If frames are past max, no longer attacking
            if (currFrames > maxFrames)
            {
                this.isAttack = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
          
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 4*16, 4*16); // Where to draw on screen

            // Draw the first step of link walking up
            if (currFrames >= 0 && currFrames <= maxFrames)
            {
                sourceRectangle = new Rectangle(141, 11, 16, 16);
            }

            // Draw the sprite
            spriteBatch.Begin();

            if (!isDamaged)
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            } else
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f));
            }
            spriteBatch.End();
        }

         public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public bool isAttacking()
        {
            return this.isAttack;
        }
    }
     
    public class LinkThrowingDownSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;

        private bool isDamaged;

        // Represents if sprite is currently in a attack cycle
        private bool isAttack;

        // Screen location
        private Rectangle destinationRectangle;

        public LinkThrowingDownSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.isDamaged = isDamaged;
            this.isAttack = true;
        }

        public void Update()
        {
            // Update frames
            currFrames += 50;

            // If frames are past max, done with the attacking cycle
            if (currFrames > maxFrames)
            {
                this.isAttack = false;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 60); // Where to draw on screen

            // Draw the first step of link walking up
            if (currFrames >= 0 && currFrames <= maxFrames)
            {
                sourceRectangle = new Rectangle(107, 11, 16, 15);

            }

            // Draw the sprite
            spriteBatch.Begin();
            if (!isDamaged)
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f));
            }
            spriteBatch.End();
        }

         public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public bool isAttacking()
        {
            return this.isAttack;
        }
    }

    public class LinkThrowingLeftSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;

        private bool isDamaged;

        // Represents if sprite is currently in an attacking cycle
        private bool isAttack;

        // Screen location
        private Rectangle destinationRectangle;

        public LinkThrowingLeftSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.isDamaged = isDamaged;
            this.isAttack = true;
        }

        public void Update()
        {
            // Update frames
            currFrames += 50;

            // If frames are past max, sprite is done attacking
            if (currFrames > maxFrames)
            {
                this.isAttack = false;
            }

        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 60, 60); // Where to draw on screen

            // Draw the first step of link walking up
            if (currFrames >= 0 && currFrames <= maxFrames)
            {
                sourceRectangle = new Rectangle(124, 12, 15, 15);

            } 

            // Draw the sprite
            spriteBatch.Begin();
            if (isDamaged)
            {
                // Must flip the sprite horizontally as the sprite sheet only has sprites for link moving right
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f), 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
            }
            else
            {
                // Must flip the sprite horizontally as the sprite sheet only has sprites for link moving right
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
            }
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public bool isAttacking()
        {
            return this.isAttack;
        }
    }

    public class LinkThrowingRightSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;

        private bool isDamaged;

        // Represents if sprite is in an attack cycle
        private bool isAttack;

        // Screen location
        private Rectangle destinationRectangle;
        public LinkThrowingRightSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.isDamaged = isDamaged;
            this.isAttack = true;
        }

        public void Update()
        {
            // Update frames
            currFrames += 50;

            // If frames are past max, done with attacking
            if (currFrames > maxFrames)
            {
                this.isAttack = false;
            }

        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 60, 60); // Where to draw on screen

            // Draw the first step of link walking up
            if (currFrames >= 0 && currFrames <= maxFrames)
            {
                sourceRectangle = new Rectangle(124, 12, 15, 15);

            }

            // Draw the sprite
            spriteBatch.Begin();
            if (!isDamaged)
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f));
            }
            spriteBatch.End();
        }

         public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public bool isAttacking()
        {
            return this.isAttack;
        }
    }
}

