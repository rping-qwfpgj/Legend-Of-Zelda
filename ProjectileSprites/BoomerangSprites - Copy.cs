using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class BlueBoomerangUpSprite : ILinkProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public int xPosition;
        public int yPosition;
       
        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
   
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        private Vector2 CalculateOrigin(ref Rectangle currentFrame, ref Rectangle destinationRectangle)
        {
            Vector2 origin = new Vector2(currentFrame.Width / 2, currentFrame.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;
            return origin;
        }
        public BlueBoomerangUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
        }

        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                currFrames = maxFrames + 20;
            }
            else
            {
                currFrames += 25;
                timingFrames += 10;

                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                //to change direction of BlueBoomerang
                if (timingFrames <= maxFrames / 2)
                {
                    this.yPosition -= 2;
                }
                else if (timingFrames < maxFrames)
                {
                    this.yPosition += 2;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle currentFrame = new(); // Store the current location on the spritesheet to get a sprite from
            Rectangle frame1 = new(92, 189, 5, 8);
            Rectangle frame2 = new(100, 189, 8, 8);
            Rectangle frame3 = new(109, 191, 8, 5);
            Vector2 origin;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            //1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                currentFrame = frame1;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen

                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 3 * maxFrames / 8)
            {
                currentFrame = frame3;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -90, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {
  
                currentFrame = frame1;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen 
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //6
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {
                currentFrame= frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                //reversed
                currentFrame= frame3;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width*2, currentFrame.Height*2); 
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                //reversed
                currentFrame= frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2);
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -270, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            // Draw the sprite

            spriteBatch.End();
        }
        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            maxFrames = timingFrames * 2;
        }
    }



    public class BlueBoomerangDownSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public int xPosition;
        public int yPosition;

        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        private Vector2 CalculateOrigin(ref Rectangle currentFrame, ref Rectangle destinationRectangle)
        {

            Vector2 origin = new Vector2(currentFrame.Width / 2, currentFrame.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;

            return origin;
        }
        public BlueBoomerangDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;

        }
        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                currFrames = maxFrames + 20;
            }
            else
            {
                currFrames += 25;
                timingFrames += 10;

                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                //to change direction of BlueBoomerang
                if (timingFrames <= maxFrames / 2)
                {
                    this.yPosition += 2;

                }
                else if (timingFrames < maxFrames)
                {
                    this.yPosition -= 2;
                }
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle currentFrame = new(); // Store the current location on the spritesheet to get a sprite from
            Rectangle frame1 = new(92, 189, 5, 8);
            Rectangle frame2 = new(100, 189, 8, 8);
            Rectangle frame3 = new(109, 191, 8, 5);
            Vector2 origin;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            //1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                currentFrame = frame1;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen

                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 3 * maxFrames / 8)
            {
                currentFrame = frame3;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -90, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {

                currentFrame = frame1;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //6
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {

                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                currentFrame = frame3;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2);
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2);
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -270, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            // Draw the sprite

            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            maxFrames = timingFrames * 2;

        }
    }

        public class BlueBoomerangRightSprite : ILinkProjectile
        {

            // Keep track of frames
            private int currFrames = 0;
            private int timingFrames = 0;
            private int maxFrames = 1000;

            // Texture to take sprites from
            public Texture2D texture;

            // X and Y positions of the sprite
            public int xPosition;
            public int yPosition;
   
            // On screen location
            private Rectangle destinationRectangle = new Rectangle();
            public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

            private Vector2 CalculateOrigin(ref Rectangle currentFrame, ref Rectangle destinationRectangle)
            {
                Vector2 origin = new Vector2(currentFrame.Width / 2, currentFrame.Height / 2);
                destinationRectangle.X += destinationRectangle.Width / 2;
                destinationRectangle.Y += destinationRectangle.Height / 2;
                return origin;
            }

            public BlueBoomerangRightSprite(Texture2D texture, float xPosition, float yPosition)
            {
                this.texture = texture;
                this.xPosition = (int)xPosition;
                this.yPosition = (int)yPosition;
            }

        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                currFrames = maxFrames + 20;
            }
            else
            {

                currFrames += 25;
                timingFrames += 10;

                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                //to change direction of BlueBoomerang
                if (timingFrames <= maxFrames / 2)
                {
                    this.xPosition += 2;

                }
                else if (timingFrames < maxFrames)
                {
                    this.xPosition -= 2;
                }
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle currentFrame = new(); // Store the current location on the spritesheet to get a sprite from
            Rectangle frame1 = new(92, 189, 5, 8);
            Rectangle frame2 = new(100, 189, 8, 8);
            Rectangle frame3 = new(109, 191, 8, 5);
            Vector2 origin;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            //1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                currentFrame = frame1;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen

                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 3 * maxFrames / 8)
            {
                currentFrame = frame3;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -90, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {
                currentFrame = frame1;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //6
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                currentFrame = frame3;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2);
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2);
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -270, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            // Draw the sprite

            spriteBatch.End();
        }
        public Rectangle GetHitbox()
            {
                return this.destinationRectangle;
            }
            public void collide()
            {
                maxFrames = timingFrames * 2;

        
            }
        }


    public class BlueBoomerangLeftSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public int xPosition;
        public int yPosition;
       

        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private Vector2 CalculateOrigin(ref Rectangle currentFrame, ref Rectangle destinationRectangle)
        {

            Vector2 origin = new Vector2(currentFrame.Width / 2, currentFrame.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;

            return origin;
        }
        public BlueBoomerangLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
        }


        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                currFrames = maxFrames + 20;
            }
            else
            {

                currFrames += 25;
                timingFrames += 10;

                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                //to change direction of BlueBoomerang
                if (timingFrames <= maxFrames / 2)
                {
                    this.xPosition -= 2;

                }
                else if (timingFrames < maxFrames)
                {
                    this.xPosition += 2;
                }
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle currentFrame = new(); // Store the current location on the spritesheet to get a sprite from
            Rectangle frame1 = new(92, 189, 5, 8);
            Rectangle frame2 = new(100, 189, 8, 8);
            Rectangle frame3 = new(109, 191, 8, 5);
            Vector2 origin;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            //1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                currentFrame = frame1;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen

                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 3 * maxFrames / 8)
            {
                currentFrame = frame3;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -90, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {

                currentFrame = frame1;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //6
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                currentFrame = frame3;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2);
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                currentFrame = frame2;
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2);
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -270, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);

            }
      
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
            {
                return this.destinationRectangle;
            }

            public void collide()
            {
                maxFrames = timingFrames * 2;

            }
        }
    }

