using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class BombUpSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        

        public BombUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition-64;
        }

        public void Update()
        {
            Boolean done = false;
            // Update frames
            if (!done)
            {
                currFrames += 100;
            }

            if (currFrames > maxFrames)
            {
                done = true;
            }

        
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 64); // Where to draw on screen

            if (currFrames >= 0 && currFrames <= 1400)
            {
                sourceRectangle = new Rectangle(129, 185, 8, 14);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 64);

            }
            else if (currFrames >= 1400 && currFrames <= 1600)
            {
                sourceRectangle = new Rectangle(138, 185, 16, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);


            }

            else if (currFrames >= 1600 && currFrames <= 1800)
            {
                sourceRectangle = new Rectangle(155, 185, 16, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);


            }

            else if (currFrames >= 1800 && currFrames <= 2000)
            {
                sourceRectangle = new Rectangle(172, 185, 16, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);
            }

            // Draw the sprite
            spriteBatch.Begin();
            spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 1800;
        }
    }


    public class BombDownSprite : ILinkProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;
        
        private Rectangle destinationRectangle;

        public BombDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition+64;
        }

        public void Update()
        {
            Boolean done = false;
            // Update frames
            if (!done)
            {
                currFrames += 100;
            }

            if (currFrames > maxFrames)
            {
                done = true;
            }



        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 64); // Where to draw on screen

            if (currFrames >= 0 && currFrames <= 1400)
            {
                sourceRectangle = new Rectangle(129, 185, 8, 14);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 64);

            }
            else if (currFrames >= 1400 && currFrames <= 1600)
            {
                sourceRectangle = new Rectangle(138, 185, 16, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);


            }

            else if (currFrames >= 1600 && currFrames <= 1800)
            {
                sourceRectangle = new Rectangle(155, 185, 16, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);


            }

            else if (currFrames >= 1800 && currFrames <= 2000)
            {
                sourceRectangle = new Rectangle(172, 185, 16, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);
            }

            // Draw the sprite
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 1800;
        }
    }


    public class BombRightSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        
        public BombRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition+32;
            this.yPosition = yPosition;
        }

        public void Update()
        {
            Boolean done = false;
            // Update frames
            if (!done)
            {
                currFrames += 100;
            }

            if (currFrames > maxFrames)
            {
                done = true;
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 64); // Where to draw on screen


            if (currFrames >= 0 && currFrames <= 1400)
            {
                sourceRectangle = new Rectangle(129, 185, 8, 14);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 64);

            }
            else if (currFrames >= 1400 && currFrames <= 1600)
            {
                sourceRectangle = new Rectangle(138, 185, 16, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);


            }

            else if (currFrames >= 1600 && currFrames <= 1800)
            {
                sourceRectangle = new Rectangle(155, 185, 16, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);


            }

            else if (currFrames >= 1800 && currFrames <= 2000)
            {
                sourceRectangle = new Rectangle(172, 185, 16, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);
            }

            // Draw the sprite
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 1800;
        }
    }


    public class BombLeftSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        

        public BombLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition-32;
            this.yPosition = yPosition;
        }

        public void Update()
        {
            Boolean done = false;
            // Update frames
            if (!done)
            {
                currFrames += 100;
            }

            if (currFrames > maxFrames)
            {
                done = true;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 64); // Where to draw on screen

            // Draw the first step of link walking up
            if (currFrames >= 0 && currFrames <= 1400)
            {
                sourceRectangle = new Rectangle(129, 185, 8, 14);

            }
            else if (currFrames >= 1400 && currFrames <= 1600)
            {
                sourceRectangle = new Rectangle(138, 185, 16, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);


            }

            else if (currFrames >= 1600 && currFrames <= 1800)
            {
                sourceRectangle = new Rectangle(155, 185, 16, 16);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);


            }

            else if (currFrames >= 1800 && currFrames <= 2000)
            {
                sourceRectangle = new Rectangle(172, 185, 16, 16);
                this.destinationRectangle  = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);
            }

           

    

            // Draw the sprite
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 1800;
        }
    }


}

