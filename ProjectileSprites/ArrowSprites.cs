using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites
{
    public class ArrowUpSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private readonly int maxFrames = 3500;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public int xPosition;
        public int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone;}
        

        public ArrowUpSprite(Texture2D texture, float xPosition, float yPosition)
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
            if (currFrames <= 5*maxFrames/6)
            {
                this.yPosition -= 4;
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
            Rectangle sourceRectangle = new(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new(xPosition, yPosition, sourceRectangle.Width*2, sourceRectangle.Height*2); // Where to draw on screen

            // Draw the first step of link  up
            if (currFrames >= 0 && currFrames <= 5*maxFrames/6)
            {
                sourceRectangle = new Rectangle(3, 185, 5, 16);
                 this.destinationRectangle = new Rectangle(xPosition, yPosition, 5 * 4, 16 * 4);

            } else if (currFrames >= 5*maxFrames/6 && currFrames <= maxFrames)
            {
                sourceRectangle = new Rectangle(53, 189, 8, 8);
                 this.destinationRectangle = new Rectangle(xPosition, yPosition, 8 * 4, 8 * 4);
            }

            // Draw the sprite
            if (!isDone)
            {
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
            this.currFrames = 3200;
        }

     
    }

    public class ArrowDownSprite : ILinkProjectile
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
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public ArrowDownSprite(Texture2D texture, float xPosition, float yPosition)
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
            if (currFrames <= 3200)
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
            Rectangle sourceRectangle = new(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new(xPosition, yPosition, 5 * 4, 16 * 4); // Where to draw on screen

            // Draw the first step of link  up
            if (currFrames >= 0 && currFrames <= 3200)
            {
                sourceRectangle = new Rectangle(3, 185, 5, 16);
                this.destinationRectangle = new Rectangle(xPosition, yPosition, 5 * 4, 16 * 4);

            }
            else if (currFrames >= 3200 && currFrames <= 3500)
            {
                sourceRectangle = new Rectangle(53, 189, 8, 8);
                this.destinationRectangle = new Rectangle(xPosition, yPosition, 8 * 4, 8 * 4);
            }

            // Draw the sprite
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


    public class ArrowRightSprite : ILinkProjectile
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
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public ArrowRightSprite(Texture2D texture, float xPosition, float yPosition)
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
            // Create source and destination rectangles
            Rectangle sourceRectangle = new(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new(xPosition, yPosition, 16 * 4, 5 * 4); // Where to draw on screen

            // Draw the first step of link  up
            if (currFrames >= 0 && currFrames <= 3200)
            {
                sourceRectangle = new(10, 190, 16, 5);
                this.destinationRectangle = new(xPosition, yPosition, 16 * 4, 5 * 4);

            }
            else if (currFrames >= 3200 && currFrames <= 3500)
            {
                sourceRectangle = new(53, 189, 8, 8);
                this.destinationRectangle = new(xPosition, yPosition, 8 * 4, 8 * 4);
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
            this.currFrames = 3200;
        }

       
    }


    public class ArrowLeftSprite : ILinkProjectile
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
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public ArrowLeftSprite(Texture2D texture, float xPosition, float yPosition)
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
            if (currFrames <= 3200)
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
            Rectangle sourceRectangle = new(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new(xPosition, yPosition, 16 * 4, 5 * 4); // Where to draw on screen

            // Draw the first step of link  up
            if (currFrames >= 0 && currFrames <= 3200)
            {
                sourceRectangle = new Rectangle(10, 190, 16, 5);
                this.destinationRectangle = new Rectangle(xPosition, yPosition, 16 * 4, 5 * 4);

            }
            else if (currFrames >= 3200 && currFrames <= 3500)
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
            this.currFrames = 3200;
        }

    }
}

