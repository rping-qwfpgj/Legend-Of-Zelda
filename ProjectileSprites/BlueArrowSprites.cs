using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendofZelda.Interfaces;

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
        private int xPosition;
        private int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public BlueArrowUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            isDone = false;
        }

        public void Update()
        {
            // Update frames
            if (!(currFrames >= maxFrames))
            {
                currFrames += 100;
            }
            else
            {
                isDone = true;

            }
            if (currFrames <= 6800)
            {
                this.yPosition -= 4;
            }
            
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle(xPosition, yPosition, 5 * 4, 16 * 4); // Where to draw on screen

            // Draw the first step of link  up
            if (currFrames >= 0 && currFrames <= 6800)
            {
                sourceRectangle = new Rectangle(29, 185, 5, 16);
                this.destinationRectangle = new Rectangle(xPosition, yPosition, 5 * 4, 16 * 4);

            }
            else if (currFrames >= 6800 && currFrames <= 7000)
            {
                sourceRectangle = new Rectangle(53, 189, 8, 8);
                this.destinationRectangle = new Rectangle(xPosition, yPosition, 8 * 4, 8 * 4);
            }

            if (!isDone)
            {
                // Draw the sprite
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
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
        private int xPosition;
        private int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public BlueArrowDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            isDone = false;
        }

        public void Update()
        {
           
            if (!isDone)
            {
                currFrames += 100;
            }
            if (currFrames <= 6800)
            {
                this.yPosition += 4;
            }
            if (currFrames >= maxFrames)
            {
                isDone = true;
            }
            
        }


        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle(xPosition, yPosition, 5 * 4, 16 * 4); // Where to draw on screen

            // Draw the first step of link  up
            if (currFrames >= 0 && currFrames <= 6800)
            {
                sourceRectangle = new Rectangle(29, 185, 5, 16);
                this.destinationRectangle = new Rectangle(xPosition, yPosition, 5 * 4, 16 * 4);

            }
            else if (currFrames >= 6800 && currFrames <= 7000)
            {
                sourceRectangle = new Rectangle(53, 189, 8, 8);
                this.destinationRectangle = new Rectangle(xPosition, yPosition, 8 * 4, 8 * 4);
            }

            if (!isDone)
            {
                // Draw the sprite
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically, 1);
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
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
        private int xPosition;
        private int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public BlueArrowRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            isDone = false;
        }

        public void Update()
        {
            // Update frames
            if (!isDone)
            {
                currFrames += 100;
            }
            if (currFrames <= 6800)
            {
                this.xPosition += 4;
            }
            if (currFrames >= maxFrames)
            {
                isDone = true;
            }
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle(xPosition, yPosition, 16 * 4, 5 * 4); // Where to draw on screen

            // Draw the first step of link  up
            if (currFrames >= 0 && currFrames <= 6800)
            {
                sourceRectangle = new Rectangle(36, 190, 16, 5);
                this.destinationRectangle = new Rectangle(xPosition, yPosition, 16 * 4, 5 * 4);

            }
            else if (currFrames >= 6800 && currFrames <= 7000)
            {
                sourceRectangle = new Rectangle(53, 189, 8, 8);
                this.destinationRectangle = new Rectangle(xPosition, yPosition, 8 * 4, 8 * 4);
            }
            if (!isDone)
            {

                // Draw the sprite
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
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
        private int xPosition;
        private int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public BlueArrowLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            isDone = false;
        }

        public void Update()
        {
        
            // Update frames
            if (!isDone)
            {
                currFrames += 100;
            }
            if (currFrames <= 6800)
            {
                this.xPosition -= 4;
            }
            if (currFrames >= maxFrames)
            {
                isDone = true;
            }
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle(xPosition, yPosition, 16 * 4, 5 * 4); // Where to draw on screen

            // Draw the first step of link  up
            if (currFrames >= 0 && currFrames <= 6800)
            {
                sourceRectangle = new Rectangle(36, 190, 16, 5);
                this.destinationRectangle = new Rectangle(xPosition, yPosition, 16 * 4, 5 * 4);

            }
            else if (currFrames >= 6800 && currFrames <= 7000)
            {
                sourceRectangle = new Rectangle(53, 189, 8, 8);
                this.destinationRectangle = new Rectangle(xPosition, yPosition, 8 * 4, 8 * 4);
            }

            if (!isDone)
            {
                // Draw the sprite
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 6800;
        }

    }
}


