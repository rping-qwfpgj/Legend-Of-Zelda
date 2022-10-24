using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class BoomerangUpSprite : ILinkProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;
        private Boolean done = false;

        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        private Vector2 CalculateOrigin(ref Rectangle sourceRectangle, ref Rectangle destinationRectangle)
        {

            Vector2 origin = new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;

            return origin;
        }
        public BoomerangUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                currFrames = maxFrames + 20;
            }
            else
            {
                currFrames += 50;
                timingFrames += 10;

                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                //to change direction of boomerang
                if (timingFrames <= maxFrames / 2)
                {
                    this.yPosition -= 5;
                }
                else if (timingFrames < maxFrames)
                {
                    this.yPosition += 5;
                }
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4); // Where to draw on screen
            Rectangle frame1 = new Rectangle(65, 189, 5, 8);
            Rectangle frame2 = new Rectangle(73, 189, 8, 8);
            Rectangle frame3 = new Rectangle(82, 191, 8, 5);
            Vector2 origin;

            spriteBatch.Begin();
            //1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                sourceRectangle = frame1;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 3 * maxFrames / 8)
            {
                sourceRectangle = frame3;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -90, origin, SpriteEffects.None, 0); spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 180, new Vector2(0, 0), SpriteEffects.None, 1);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame1;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //6
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame2;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame3;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                //reversed
                sourceRectangle = frame2;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -270, origin, SpriteEffects.None, 0);
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



    public class BoomerangDownSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;
        private Boolean done = false;

        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        private Vector2 CalculateOrigin(ref Rectangle sourceRectangle, ref Rectangle destinationRectangle)
        {

            Vector2 origin = new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;

            return origin;
        }
        public BoomerangDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;

        }
        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                currFrames = maxFrames + 20;
            }
            else
            {

                currFrames += 50;
                timingFrames += 10;

                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                //to change direction of boomerang
                if (timingFrames <= maxFrames / 2)
                {
                    this.yPosition += 5;

                }
                else if (timingFrames < maxFrames)
                {
                    this.yPosition -= 5;
                }
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
            Rectangle frame1 = new Rectangle(65, 189, 5, 8);
            Rectangle frame2 = new Rectangle(73, 189, 8, 8);
            Rectangle frame3 = new Rectangle(82, 191, 8, 5);
            Vector2 origin;

            spriteBatch.Begin();
            //1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                sourceRectangle = frame1;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 3 * maxFrames / 8)
            {
                sourceRectangle = frame3;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -90, origin, SpriteEffects.None, 0); spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 180, new Vector2(0, 0), SpriteEffects.None, 1);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame1;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame2;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame3;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                //reversed
                sourceRectangle = frame2;
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -270, origin, SpriteEffects.None, 0);
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

        public class BoomerangRightSprite : ILinkProjectile
        {

            // Keep track of frames
            private int currFrames = 0;
            private int timingFrames = 0;
            private int maxFrames = 1000;

            // Texture to take sprites from
            public Texture2D texture;

            // X and Y positions of the sprite
            public float xPosition;
            public float yPosition;
            private Boolean done = false;

            // On screen location
            private Rectangle destinationRectangle = new Rectangle();
            public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

            private Vector2 CalculateOrigin(ref Rectangle sourceRectangle, ref Rectangle destinationRectangle)
            {
                Vector2 origin = new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
                destinationRectangle.X += destinationRectangle.Width / 2;
                destinationRectangle.Y += destinationRectangle.Height / 2;
                return origin;
            }

            public BoomerangRightSprite(Texture2D texture, float xPosition, float yPosition)
            {
                this.texture = texture;
                this.xPosition = xPosition;
                this.yPosition = yPosition;
            }

        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                currFrames = maxFrames + 20;
            }
            else
            {

                currFrames += 50;
                timingFrames += 10;

                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                //to change direction of boomerang
                if (timingFrames <= maxFrames / 2)
                {
                    this.xPosition += 5;

                }
                else if (timingFrames < maxFrames)
                {
                    this.xPosition -= 5;
                }
            }

        }


        public void Draw(SpriteBatch spriteBatch)
            {
                // Create source and destination rectangles
                Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4); // Where to draw on screen
                Rectangle frame1 = new Rectangle(65, 189, 5, 8);
                Rectangle frame2 = new Rectangle(73, 189, 8, 8);
                Rectangle frame3 = new Rectangle(82, 191, 8, 5);
                Vector2 origin;

                spriteBatch.Begin();
                //1
                if (currFrames >= 0 && currFrames <= maxFrames / 8)
                {
                    sourceRectangle = frame1;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                }
                //2
                else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
                {
                    sourceRectangle = frame2;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                }
                //3
                else if (currFrames > 2 * maxFrames / 8 && currFrames <= 3 * maxFrames / 8)
                {
                    sourceRectangle = frame3;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                }
                //4
                else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
                {
                    sourceRectangle = frame2;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -90, origin, SpriteEffects.None, 0); spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 180, new Vector2(0, 0), SpriteEffects.None, 1);

                }
                //5
                else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
                {
                    //reversed
                    sourceRectangle = frame1;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
                }
                //
                else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
                {
                    //reversed
                    sourceRectangle = frame2;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
                }
                //7
                else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
                {
                    //reversed
                    sourceRectangle = frame3;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
                }
                //8
                else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
                {
                    //reversed
                    sourceRectangle = frame2;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -270, origin, SpriteEffects.None, 0);
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


    public class BoomerangLeftSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;
        private Boolean done = false;

        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private Vector2 CalculateOrigin(ref Rectangle sourceRectangle, ref Rectangle destinationRectangle)
        {

            Vector2 origin = new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;

            return origin;
        }
        public BoomerangLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }


        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                currFrames = maxFrames + 20;
            }
            else
            {

                currFrames += 50;
                timingFrames += 10;

                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                //to change direction of boomerang
                if (timingFrames <= maxFrames / 2)
                {
                    this.xPosition -= 5;

                }
                else if (timingFrames < maxFrames)
                {
                    this.xPosition += 5;
                }
            }

        }
    


            public void Draw(SpriteBatch spriteBatch)
            {
                // Create source and destination rectangles
                Rectangle sourceRectangle = new Rectangle(); // Store the current location on the spritesheet to get a sprite from
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4); // Where to draw on screen
                Rectangle frame1 = new Rectangle(65, 189, 5, 8);
                Rectangle frame2 = new Rectangle(73, 189, 8, 8);
                Rectangle frame3 = new Rectangle(82, 191, 8, 5);
                Vector2 origin;

                spriteBatch.Begin();
                //1
                if (currFrames >= 0 && currFrames <= maxFrames / 8)
                {
                    sourceRectangle = frame1;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                }
                //2
                else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
                {
                    sourceRectangle = frame2;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                }
                //3
                else if (currFrames > 2 * maxFrames / 8 && currFrames <= 3 * maxFrames / 8)
                {
                    sourceRectangle = frame3;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                }
                //4
                else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
                {
                    sourceRectangle = frame2;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -90, origin, SpriteEffects.None, 0); spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 180, new Vector2(0, 0), SpriteEffects.None, 1);

                }
                //5
                else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
                {
                    //reversed
                    sourceRectangle = frame1;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
                }
                //
                else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
                {
                    //reversed
                    sourceRectangle = frame2;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
                }
                //7
                else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
                {
                    //reversed
                    sourceRectangle = frame3;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
                }
                //8
                else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
                {
                    //reversed
                    sourceRectangle = frame2;
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, -270, origin, SpriteEffects.None, 0);
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
    }

