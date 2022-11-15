using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class LinkAttackUpSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        private Texture2D texture;
        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // to know whether or not to dye sprite red.
        private bool isDamaged;

        // Represents if the sprite has done one full attack cycle
        private bool isAttack;

        public string side = "top";

        // Where this will be drawn on screen
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;
        public Rectangle DestinationRectangle { get => new Rectangle(destinationRectangle.X-(destinationRectangle.Width/2), destinationRectangle.Y-(destinationRectangle.Height/2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value;}
        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkAttackUpSprite(Texture2D texture, float xPos, float yPos, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = (int)xPos;
            this.yPosition = (int)yPos;
            this.isDamaged = isDamaged;
            this.isAttack = true;
            sourceRectangles = new List<Rectangle>();
            sourceRectangles.Add(new Rectangle(1, 109, 16, 16));
            sourceRectangles.Add(new Rectangle(18, 97, 16, 28));
            sourceRectangles.Add(new Rectangle(37, 98, 12, 27));
            sourceRectangles.Add(new Rectangle(54, 106, 12, 19));
            currentFrameIndex = 0;
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

            // Frame logic
            if(currFrames >= 0 && currFrames <= maxFrames/4)
            {
                currentFrameIndex = 0;
            } 
            else if (currFrames > currFrames/4 && currFrames <= 2*maxFrames/4)
            {
                currentFrameIndex = 1;
            } 
            else if (currFrames > 2*maxFrames/4 && currFrames <= 3*maxFrames/4)
            {
                currentFrameIndex = 2;
            } 
            else if (currFrames > 3*maxFrames/4 && currFrames <= maxFrames)
            {
                currentFrameIndex = 3;
            }

            Rectangle currentFrame = sourceRectangles[currentFrameIndex];
            destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen

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

        public bool isAttacking()
        {
            return this.isAttack;
        }

        public string getSide()
        {
            return this.side;
        }
    }


    public class LinkAttackDownSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        public Texture2D texture;
        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // to know whether or not to dye sprite red.
        private bool isDamaged;

        // Is this sprite currently in its attacking cycle
        private bool isAttack;

        public string side = "bottom";

        // Location on screen
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;
        public Rectangle DestinationRectangle { get => new Rectangle(destinationRectangle.X-(destinationRectangle.Width/2), destinationRectangle.Y-(destinationRectangle.Height/2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value;}
        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkAttackDownSprite(Texture2D texture, float xPos, float yPos, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = (int)xPos;
            this.yPosition = (int)yPos;
            this.isDamaged = isDamaged;
            this.isAttack = true;
            sourceRectangles = new List<Rectangle>();
            sourceRectangles.Add(new Rectangle(1, 47, 16, 15));
            sourceRectangles.Add(new Rectangle(18, 47, 16, 27));
            sourceRectangles.Add(new Rectangle(35, 47, 15, 23));
            sourceRectangles.Add(new Rectangle(53, 47, 13, 19));
            currentFrameIndex = 0;
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

            // Frame logic
            if (currFrames >= 0 && currFrames <= maxFrames / 4)
            {
                currentFrameIndex = 0;
            }
            else if (currFrames > currFrames / 4 && currFrames <= 2 * maxFrames / 4)
            {
                currentFrameIndex = 1;
            }
            else if (currFrames > 2 * maxFrames / 4 && currFrames <= 3 * maxFrames / 4)
            {
                currentFrameIndex = 2;
            }
            else if (currFrames > 3 * maxFrames / 4 && currFrames <= maxFrames)
            {
                currentFrameIndex = 3;
            }

            Rectangle currentFrame = sourceRectangles[currentFrameIndex];
            destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen

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
            return destinationRectangle;
        }

        public bool isAttacking()
        {
            return this.isAttack;
        }

         public string getSide()
        {
            return this.side;
        }
    }

    public class LinkAttackLeftSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // to know whether or not to dye sprite red.
        private bool isDamaged;

        // Represents if sprite is in its attack cycle 
        private bool isAttack;

        public string side = "left";

        // Location on screen
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;
        public Rectangle DestinationRectangle { get => new Rectangle(destinationRectangle.X-(destinationRectangle.Width/2), destinationRectangle.Y-(destinationRectangle.Height/2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value;}
        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkAttackLeftSprite(Texture2D texture, float xPos, float yPos, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = (int)xPos;
            this.yPosition = (int)yPos;
            this.isDamaged = isDamaged;
            this.isAttack = true;
            sourceRectangles = new List<Rectangle>();
            sourceRectangles.Add(new Rectangle(1, 78, 15, 15));
            sourceRectangles.Add(new Rectangle(18, 78, 27, 15));
            sourceRectangles.Add(new Rectangle(46, 78, 23, 15));
            sourceRectangles.Add(new Rectangle(70, 77, 19, 16));
            currentFrameIndex = 0;
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

            // Frame logic
            if (currFrames >= 0 && currFrames <= maxFrames / 4)
            {
                currentFrameIndex = 0;
            }
            else if (currFrames > currFrames / 4 && currFrames <= 2 * maxFrames / 4)
            {
                currentFrameIndex = 1;
            }
            else if (currFrames > 2 * maxFrames / 4 && currFrames <= 3 * maxFrames / 4)
            {
                currentFrameIndex = 2;
            }
            else if (currFrames > 3 * maxFrames / 4 && currFrames <= maxFrames)
            {
                currentFrameIndex = 3;
            }

            Rectangle currentFrame = sourceRectangles[currentFrameIndex];
            destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen

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

        public bool isAttacking()
        {
            return this.isAttack;
        }

        public string getSide()
        {
            return this.side;
        }
    }

    public class LinkAttackRightSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        private Texture2D texture;
        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // to know whether or not to dye sprite red.
        private bool isDamaged;

        // Represents if sprite is in its attacking loop
        private bool isAttack;

        public string side = "right";

        // On screen location

        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;

        public Rectangle DestinationRectangle { get => new Rectangle(destinationRectangle.X-(destinationRectangle.Width/2), destinationRectangle.Y-(destinationRectangle.Height/2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value;}
        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkAttackRightSprite(Texture2D texture, float xPos, float yPos, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = (int)xPos;
            this.yPosition = (int)yPos;
            this.isDamaged = isDamaged;
            this.isAttack = true;
            sourceRectangles = new List<Rectangle>();
            sourceRectangles.Add(new Rectangle(1, 78, 15, 15));
            sourceRectangles.Add(new Rectangle(18, 78, 27, 15));
            sourceRectangles.Add(new Rectangle(46, 78, 23, 15));
            sourceRectangles.Add(new Rectangle(70, 77, 19, 16));
            currentFrameIndex = 0;
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

        public void Draw(SpriteBatch spriteBatch)
        {

            // Frame logic
            if (currFrames >= 0 && currFrames <= maxFrames / 4)
            {
                currentFrameIndex = 0;
            }
            else if (currFrames > currFrames / 4 && currFrames <= 2 * maxFrames / 4)
            {
                currentFrameIndex = 1;
            }
            else if (currFrames > 2 * maxFrames / 4 && currFrames <= 3 * maxFrames / 4)
            {
                currentFrameIndex = 2;
            }
            else if (currFrames > 3 * maxFrames / 4 && currFrames <= maxFrames)
            {
                currentFrameIndex = 3;
            }

            Rectangle currentFrame = sourceRectangles[currentFrameIndex];
            destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen

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
            return destinationRectangle;
        }

        public bool isAttacking()
        {
            return this.isAttack;
        }
         public string getSide()
        {
            return this.side;
        }
    }
  }

