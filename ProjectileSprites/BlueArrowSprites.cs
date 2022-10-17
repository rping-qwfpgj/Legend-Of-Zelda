using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Sprites
{
    public class BlueArrowUpSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 7000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;

        // On screen location
        private Rectangle destinationRectangle;

        public BlueArrowUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public void Update()
        {
            bool done = false;
            // Update frames
            if (!done)
            {
                currFrames += 100;
            }
            if (currFrames <= 6800)
            {
                this.yPosition -= 4;
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
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 5 * 4, 16 * 4); // Where to draw on screen

            // Draw the first step of link  up
            if (currFrames >= 0 && currFrames <= 6800)
            {
                sourceRectangle = new Rectangle(29, 185, 5, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 5 * 4, 16 * 4);

            }
            else if (currFrames >= 6800 && currFrames <= 7000)
            {
                sourceRectangle = new Rectangle(53, 189, 8, 8);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 8 * 4, 8 * 4);
            }

            // Draw the sprite
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 6800;
        }
    }

    public class BlueArrowDownSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 7000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;

        // On screen location
        private Rectangle destinationRectangle;

        public BlueArrowDownSprite(Texture2D texture, float xPosition, float yPosition)
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
                currFrames += 100;
            }
            if (currFrames <= 6800)
            {
                this.yPosition += 4;
            }
            if (currFrames >= maxFrames)
            {
                done = true;
            }
            currFrames = 0;
        }



        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 5 * 4, 16 * 4); // Where to draw on screen

            // Draw the first step of link  up
            if (currFrames >= 0 && currFrames <= 6800)
            {
                sourceRectangle = new Rectangle(29, 185, 5, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 5 * 4, 16 * 4);

            }
            else if (currFrames >= 6800 && currFrames <= 7000)
            {
                sourceRectangle = new Rectangle(53, 189, 8, 8);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 8 * 4, 8 * 4);
            }

            // Draw the sprite
            spriteBatch.Begin();
            spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically, 1);
            spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 6800;
        }
    }


    public class BlueArrowRightSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 7000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;

        // On screen location
        private Rectangle destinationRectangle;


        public BlueArrowRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public void Update()
        {
            bool done = false;
            // Update frames
            if (!done)
            {
                currFrames += 100;
            }
            if (currFrames <= 6800)
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
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 16 * 4, 5 * 4); // Where to draw on screen

            // Draw the first step of link  up
            if (currFrames >= 0 && currFrames <= 6800)
            {
                sourceRectangle = new Rectangle(36, 190, 16, 5);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 16 * 4, 5 * 4);

            }
            else if (currFrames >= 6800 && currFrames <= 7000)
            {
                sourceRectangle = new Rectangle(53, 189, 8, 8);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 8 * 4, 8 * 4);
            }

            // Draw the sprite
            spriteBatch.Begin();
            spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 6800;
        }
    }


    public class BlueArrowLeftSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 7000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;

        // On screen location
        private Rectangle destinationRectangle;

        public BlueArrowLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public void Update()
        {
            bool done = false;
            // Update frames
            if (!done)
            {
                currFrames += 100;
            }
            if (currFrames <= 6800)
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
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 16 * 4, 5 * 4); // Where to draw on screen

            // Draw the first step of link  up
            if (currFrames >= 0 && currFrames <= 6800)
            {
                sourceRectangle = new Rectangle(36, 190, 16, 5);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 16 * 4, 5 * 4);

            }
            else if (currFrames >= 6800 && currFrames <= 7000)
            {
                sourceRectangle = new Rectangle(53, 189, 8, 8);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 8 * 4, 8 * 4);
            }

            // Draw the sprite
            spriteBatch.Begin();
            spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
            spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 6800;
        }
    }
}


