using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Security.Cryptography.X509Certificates;
using Interfaces;

namespace Sprites
{
    public class LinkAttackUpSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;
        // X and Y positions of the sprite
        private float xPos;
        private float yPos;

        // to know whether or not to dye sprite red.
        private bool isDamaged;

        // Represents if the sprite has done one full attack cycle
        private bool isAttack;

        // Where this will be drawn on screen
        private Rectangle destinationRectangle;

        public LinkAttackUpSprite(Texture2D texture, float xPos, float yPos, bool isDamaged)
        {
            this.texture = texture;
            this.xPos = xPos;
            this.yPos = yPos;
            this.isDamaged = isDamaged;
            this.isAttack = true;
        }

        public void Update()
        {
            // Update frames
            currFrames += 35;

            // If frames are past max,no longer attacking
            if (currFrames >= maxFrames)
            {
                this.isAttack = false;
            }

        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(1, 109, 16, 16); // Store the current location on the spritesheet to get a sprite from
            Rectangle destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos, 64, 64); // Where to draw on screen

            // Frame logic
            if(currFrames >= 0 && currFrames <= 500)
            {
                sourceRectangle = new Rectangle(1, 109, 16, 16);
                destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos, 64, 64);
            } else if (currFrames > 500 && currFrames <= 1000)
            {
                sourceRectangle = new Rectangle(18, 97, 16, 28);
                destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos - 48, 64, 112); // Y position is current rectangle height - inital rectangle's height
            } else if (currFrames > 1000 && currFrames <= 1500)
            {
                sourceRectangle = new Rectangle(37, 98, 12, 27);
                destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos - 44, 48, 108);
            } else if (currFrames > 1500 && currFrames <= 2000)
            {
                sourceRectangle = new Rectangle(54, 106, 12, 19);
                destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos -12, 48, 76);
            }

            spriteBatch.Begin();
            if (isDamaged)
            {                
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f));
            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            spriteBatch.End();
        }
         public Rectangle getHitbox()
        {
            return this.destinationRectangle;
        }

        public bool isAttacking()
        {
            return this.isAttack;
        }
    }


    public class LinkAttackDownSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        public Texture2D texture;
        // X and Y positions of the sprite
        private float xPos;
        private float yPos;

        // to know whether or not to dye sprite red.
        private bool isDamaged;

        // Is this sprite currently in its attacking cycle
        private bool isAttack;

        // Location on screen
        private Rectangle destinationRectangle;

        public LinkAttackDownSprite(Texture2D texture, float xPos, float yPos, bool isDamaged)
        {
            this.texture = texture;
            this.xPos = xPos;
            this.yPos = yPos;
            this.isDamaged = isDamaged;
            this.isAttack = true;
        }

        public void Update()
        {
            // Update frames
            currFrames += 35;

            // If frames are past max,no longer attacking
            if (currFrames >= maxFrames)
            {
                this.isAttack = false;
            }
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(1, 47, 16, 15); // Store the current location on the spritesheet to get a sprite from
            Rectangle destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos, 64, 64); // Where to draw on screen

            // Frame logic
            if (currFrames >= 0 && currFrames <= 500)
            {
                sourceRectangle = new Rectangle(1, 47, 16, 15);
                destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos, 64, 60); 
            }
            else if (currFrames > 500 && currFrames <= 1000)
            {
                sourceRectangle = new Rectangle(18, 47, 16, 27);
                destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos + 48, 64, 108); // Y position = yPos +(currRectangle height - originalRectangle height)
            }
            else if (currFrames > 1000 && currFrames <= 1500)
            {
                sourceRectangle = new Rectangle(35, 47, 15, 23);
                destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos + 32 , 60, 92);
            }
            else if (currFrames > 1500 && currFrames <= 2000)
            {
                sourceRectangle = new Rectangle(53, 47, 13, 19);
                destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos + 16, 52, 76); 
            }
            
            spriteBatch.Begin();
            if (isDamaged)
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f));
            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }

        public bool isAttacking()
        {
            return this.isAttack;
        }
    }

    public class LinkAttackLeftSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPos;
        private float yPos;

        // to know whether or not to dye sprite red.
        private bool isDamaged;

        // Represents if sprite is in its attack cycle 
        private bool isAttack;

        // Location on screen
        private Rectangle destinationRectangle;

        public LinkAttackLeftSprite(Texture2D texture, float xPos, float yPos, bool isDamaged)
        {
            this.texture = texture;
            this.xPos = xPos;
            this.yPos = yPos;
            this.isDamaged = isDamaged;
            this.isAttack = true;
        }

        public void Update()
        {
            // Update frames
            currFrames += 35;

            // If frames are past max,no longer attacking
            if (currFrames >= maxFrames)
            {
                this.isAttack = false;
            }

        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(1, 78, 15, 15); // Store the current location on the spritesheet to get a sprite from
            Rectangle destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos, 64, 64); // Where to draw on screen

            // Frame logic
            if (currFrames >= 0 && currFrames <= 500)
            {
                sourceRectangle = new Rectangle(1, 78, 15, 15);
                destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos, 60, 60); 
            }
            else if (currFrames > 500 && currFrames <= 1000)
            {
                sourceRectangle = new Rectangle(18, 78, 27, 15);
                destinationRectangle = new Rectangle((int)this.xPos - 48, (int)this.yPos, 108, 60); // xPos = xPos - (currRectangleWidth - originalRectangleWidth)
            }
            else if (currFrames > 1000 && currFrames <= 1500)
            {
                sourceRectangle = new Rectangle(46, 78, 23, 15);
                destinationRectangle = new Rectangle((int)this.xPos - 32, (int)this.yPos, 92, 60);
            }
            else if (currFrames > 1500 && currFrames <= 2000)
            {
                sourceRectangle = new Rectangle(70, 77, 19, 16);
                destinationRectangle = new Rectangle((int)this.xPos - 16, (int)this.yPos, 76, 64); 
            }

            spriteBatch.Begin();
            if (isDamaged)
            {
                // Must flip the sprite horizontally as the sprite sheet only has sprites for link moving right
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f), 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
            }
            else
            {
                // Must flip the sprite horizontally as the sprite sheet only has sprites for link moving right
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
            }
            spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }

        public bool isAttacking()
        {
            return this.isAttack;
        }
    }

    public class LinkAttackRightSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;
        // X and Y positions of the sprite
        private float xPos;
        private float yPos;

        // to know whether or not to dye sprite red.
        private bool isDamaged;

        // Represents if sprite is in its attacking loop
        private bool isAttack;

        // On screen location
        private Rectangle destinationRectangle;

        public LinkAttackRightSprite(Texture2D texture, float xPos, float yPos, bool isDamaged)
        {
            this.texture = texture;
            this.xPos = xPos;
            this.yPos = yPos;
            this.isDamaged = isDamaged;
            this.isAttack = true;
        }
        public void Update()
        {
            // Update frames
            currFrames += 35;

            // If frames are past max, no longer attacking
            if (currFrames >= maxFrames)
            {
                this.isAttack = false;
            }
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(-1, 47, 16, 15); // Store the current location on the spritesheet to get a sprite from
            Rectangle destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos, 64, 64); // Where to draw on screen

            // Frame logic
            if (currFrames >= 0 && currFrames <= 500)
            {
                sourceRectangle = new Rectangle(-1, 78, 15, 15);
                destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos, 60, 60); 
            }
            else if (currFrames > 500 && currFrames <= 1000)
            {
                sourceRectangle = new Rectangle(18, 78, 27, 15);
                destinationRectangle = new Rectangle((int)this.xPos + 48, (int)this.yPos, 108, 60);  // xPos = xPos + (currRectangleWidth - originalRectangleWidth)
            }
            else if (currFrames > 1000 && currFrames <= 1500)
            {
                sourceRectangle = new Rectangle(46, 78, 23, 15);
                destinationRectangle = new Rectangle((int)this.xPos + 32, (int)this.yPos, 92, 60);
            }
            else if (currFrames > 1500 && currFrames <= 2000)
            {
                sourceRectangle = new Rectangle(70, 77, 19, 16);
                destinationRectangle = new Rectangle((int)this.xPos + 16, (int)this.yPos, 76, 64);
            }

            spriteBatch.Begin();
            if (isDamaged)
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f));
            } else
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }

        public bool isAttacking()
        {
            return this.isAttack;
        }
    }
  }

