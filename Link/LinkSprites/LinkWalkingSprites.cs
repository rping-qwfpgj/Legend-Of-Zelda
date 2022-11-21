﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.Interfaces;

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
        private int xPosition;
        private int yPosition;
     
        private bool isDamaged;

        // Screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;
        private Rectangle currentFrame;
        public Rectangle DestinationRectangle {
            get => new Rectangle(destinationRectangle.X-(destinationRectangle.Width/2), destinationRectangle.Y-(destinationRectangle.Height/2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value;
        }
        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkWalkingUpSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            this.isDamaged = isDamaged;
            sourceRectangles = new List<Rectangle>();
            sourceRectangles.Add(new Rectangle(71, 11, 12, 16));
            sourceRectangles.Add(new Rectangle(88, 11, 12, 16));
            currentFrameIndex = 0;
            currentFrame = new();
        }

        public void Update()
        {                                        
            currFrames += 100;

            // If frames are past max, reset to 0
            if (currFrames > maxFrames)
            {
                currFrames = 0;
            }
            this.yPosition -= 2;  
        }      

       
        public void Draw(SpriteBatch spriteBatch)
        {
                
            // Create source and destination rectangles
            if (currFrames >= 0 && currFrames <= maxFrames / 2)
            {
                currentFrameIndex = 0;
            }
            else if (currFrames > maxFrames / 2 && currFrames <= maxFrames) // Draw the 2nd step of link walking up
            {
                currentFrameIndex = 1;
            }

            currentFrame = sourceRectangles[currentFrameIndex];
            destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width*2, currentFrame.Height*2); // Where to draw on screen

            // Draw the sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if (isDamaged)
            {
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.Lerp(Color.White, Color.Red, 0.3f), 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);     
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
        private int xPosition;
        private int yPosition;

        public bool isDamaged;

        // Screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;
        public Rectangle DestinationRectangle {get => new Rectangle(destinationRectangle.X-(destinationRectangle.Width/2), destinationRectangle.Y-(destinationRectangle.Height/2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value;}
        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkWalkingDownSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            this.isDamaged = isDamaged;
            sourceRectangles = new List<Rectangle>();
            sourceRectangles.Add(new Rectangle(1, 11, 15, 16));
            sourceRectangles.Add(new Rectangle(19, 11, 13, 16));
            currentFrameIndex = 0;
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            // Create source and destination rectangles
            if (currFrames >= 0 && currFrames <= maxFrames / 2)
            {
                currentFrameIndex = 0;
            }
            else if (currFrames > maxFrames / 2 && currFrames <= maxFrames) // Draw the 2nd step of link walking up
            {
                currentFrameIndex = 1;
            }

            Rectangle currentFrame = sourceRectangles[currentFrameIndex];
            destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen


            // Draw the sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if (isDamaged)
            {
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.Lerp(Color.White, Color.Red, 0.3f), 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
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
        private int xPosition;
        private int yPosition;

        private bool isDamaged;

        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;
        public Rectangle DestinationRectangle {get => new Rectangle(destinationRectangle.X-(destinationRectangle.Width/2), destinationRectangle.Y-(destinationRectangle.Height/2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value;}
        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkWalkingLeftSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            this.isDamaged = isDamaged;
            sourceRectangles = new List<Rectangle>();
            sourceRectangles.Add(new Rectangle(35, 11, 15, 16));
            sourceRectangles.Add(new Rectangle(52, 12, 14, 15));
            currentFrameIndex = 0;
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
          
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {

            // Create source and destination rectangles
            if (currFrames >= 0 && currFrames <= maxFrames / 2)
            {
                currentFrameIndex = 0;
            }
            else if (currFrames > maxFrames / 2 && currFrames <= maxFrames) // Draw the 2nd step of link walking up
            {
                currentFrameIndex = 1;
            }

            Rectangle currentFrame = sourceRectangles[currentFrameIndex];
            destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen


            // Draw the sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if (isDamaged)
            {
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.Lerp(Color.White, Color.Red, 0.3f), 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.FlipHorizontally, 1);

            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.FlipHorizontally, 1);
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
        private int xPosition;
        private int yPosition;
        private bool isDamaged;

        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;
        public Rectangle DestinationRectangle
        {
            get => new Rectangle(destinationRectangle.X - (destinationRectangle.Width / 2), destinationRectangle.Y - (destinationRectangle.Height / 2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value;
        }

        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkWalkingRightSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            this.isDamaged = isDamaged;
            sourceRectangles = new List<Rectangle>();
            sourceRectangles.Add(new Rectangle(35, 11, 15, 16));
            sourceRectangles.Add(new Rectangle(52, 12, 14, 15));
            currentFrameIndex = 0;
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
         
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {

            // Create source and destination rectangles
            if (currFrames >= 0 && currFrames <= maxFrames / 2)
            {
                currentFrameIndex = 0;
            }
            else if (currFrames > maxFrames / 2 && currFrames <= maxFrames) // Draw the 2nd step of link walking up
            {
                currentFrameIndex = 1;
            }

            Rectangle currentFrame = sourceRectangles[currentFrameIndex];
            destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
            

            // Draw the sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if (isDamaged)
            {
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.Lerp(Color.White, Color.Red, 0.3f), 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {

            
            return this.destinationRectangle;
        }
    }
}

