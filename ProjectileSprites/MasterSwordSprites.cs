using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprites
{
    public class MasterSwordUpSprite : ILinkProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private readonly int maxFrames = 1600;
        private int timingCounter = 0;
        private int maxTime = 4800;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public int xPosition;
        public int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        Rectangle sourceRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        //private master sword sprite - create from projectile factory

        public MasterSwordUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition - 30;
            isDone = false;
            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(1, 154, 7, 16));
            sourceRectangles.Add(new Rectangle(36, 154, 7, 16));
            sourceRectangles.Add(new Rectangle(71, 154, 7, 16));
            sourceRectangles.Add(new Rectangle(106, 154, 7, 16));
        }

        public void Update()
        {

            // Update frames
            if (!isDone)
            {
                timingCounter++;
                if (timingCounter >= maxTime)
                {
                    isDone = true;
                }
                currFrames += 50;
                this.yPosition -= 1;
                if ((currFrames / 100) % 4 == 0)
                {
                    sourceRectangle = sourceRectangles[0];
                } else if ((currFrames / 100) % 4 == 1)
                {
                    sourceRectangle = sourceRectangles[1];
                } else if ((currFrames / 100) % 4 == 2)
                {
                    sourceRectangle = sourceRectangles[2];
                } else if ((currFrames / 100) % 4 == 0)
                {
                    sourceRectangle = sourceRectangles[3];
                } else if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }
            }
            //else, master sword explosion sprite.update()
            

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isDone)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
            //else, master sword explosion sprite.draw()

        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = maxFrames;
        }


    }

    public class MasterSwordDownSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private readonly int maxFrames = 3500;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;

        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public MasterSwordDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            isDone = false;
            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(1, 154, 7, 16));
            sourceRectangles.Add(new Rectangle(36, 154, 7, 16));
            sourceRectangles.Add(new Rectangle(71, 154, 7, 16));
            sourceRectangles.Add(new Rectangle(106, 154, 7, 16));

        }

        public void Update()
        {

            if (!isDone)
            {
                currFrames += 100;
            }
            if (currFrames <= 3200)
            {
                this.yPosition += 4;
            }
            if (currFrames >= maxFrames)
            {
                isDone = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle sourceRectangle = new Rectangle();

            if (currFrames >= 0 && currFrames <= 8 * maxFrames / 9)
            {
                sourceRectangle = sourceRectangles[0];
                destinationRectangle = new Rectangle(xPosition, yPosition, (int)((float)sourceRectangle.Width * 2.5), (int)((float)sourceRectangle.Height * 2.5));
            }
            else if (currFrames >= 8 * maxFrames / 9 && currFrames <= maxFrames)
            {
                sourceRectangle = sourceRectangles[1];
                destinationRectangle = new Rectangle(xPosition, yPosition, (int)((float)sourceRectangle.Width * 2.5), (int)((float)sourceRectangle.Height * 2.5));
            }

            if (!isDone)
            {

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
            this.currFrames = 3200;
        }

    }


    public class MasterSwordRightSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private readonly int maxFrames = 3500;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;
        public bool isDamaged;

        // On screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;

        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public MasterSwordRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            isDone = false;
            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(10, 159, 16, 7));
            sourceRectangles.Add(new Rectangle(45, 159, 16, 7));
            sourceRectangles.Add(new Rectangle(80, 159, 16, 7));
            sourceRectangles.Add(new Rectangle(115, 159, 16, 7));

        }

        public void Update()
        {

            // Update frames
            if (!isDone)
            {
                currFrames += 100;
            }
            if (currFrames <= 3200)
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

            Rectangle sourceRectangle = new Rectangle();

            if (currFrames >= 0 && currFrames <= 8 * maxFrames / 9)
            {
                sourceRectangle = sourceRectangles[0];
                destinationRectangle = new Rectangle(xPosition, yPosition, (int)((float)sourceRectangle.Width * 2.5), (int)((float)sourceRectangle.Height * 2.5));
            }
            else if (currFrames >= 8 * maxFrames / 9 && currFrames <= maxFrames)
            {
                sourceRectangle = sourceRectangles[1];
                destinationRectangle = new Rectangle(xPosition, yPosition, (int)((float)sourceRectangle.Width * 2.5), (int)((float)sourceRectangle.Height * 2.5));
            }

            if (!isDone)
            {

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
            this.currFrames = 3200;
        }


    }


    public class MasterSwordLeftSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private readonly int maxFrames = 3500;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;

        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public MasterSwordLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition - 30;
            this.yPosition = (int)yPosition;
            isDone = false;
            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(10, 159, 16, 7));
            sourceRectangles.Add(new Rectangle(45, 159, 16, 7));
            sourceRectangles.Add(new Rectangle(80, 159, 16, 7));
            sourceRectangles.Add(new Rectangle(115, 159, 16, 7));
        }

        public void Update()
        {

            // Update frames
            if (!isDone)
            {
                currFrames += 100;
            }
            if (currFrames <= 3200)
            {
                this.xPosition -= 4;
            }
            if (currFrames >= maxFrames)
            {
                isDone = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle sourceRectangle = new Rectangle();

            if (currFrames >= 0 && currFrames <= 8 * maxFrames / 9)
            {
                sourceRectangle = sourceRectangles[0];
                destinationRectangle = new Rectangle(xPosition, yPosition, (int)((float)sourceRectangle.Width * 2.5), (int)((float)sourceRectangle.Height * 2.5));
            }
            else if (currFrames >= 8 * maxFrames / 9 && currFrames <= maxFrames)
            {
                sourceRectangle = sourceRectangles[1];
                destinationRectangle = new Rectangle(xPosition, yPosition, (int)((float)sourceRectangle.Width * 2.5), (int)((float)sourceRectangle.Height * 2.5));
            }

            if (!isDone)
            {

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
            this.currFrames = 3200;
        }

    }
}

