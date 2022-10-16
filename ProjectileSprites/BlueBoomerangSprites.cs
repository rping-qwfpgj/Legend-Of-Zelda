﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Sprites
{

    public class BlueBoomerangUpSprite : ILinkProjectileSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private readonly int maxFrames = 1500;
        private Boolean done = false;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;

        // On screen location
        private Rectangle destinationRectangle;

        private static Vector2 CalculateOrigin(ref Rectangle sourceRectangle, ref Rectangle destinationRectangle)
        {
            Vector2 origin = new(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;
            return origin;
        }

        public BlueBoomerangUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }
        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                done = true;
                currFrames = maxFrames;
            }

            if (!done)
            {
                currFrames += 50;
                timingFrames += 10;

                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                //to change direction of BlueBoomerang
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
            Rectangle sourceRectangle = new(); // Store the current location on the spritesheet to get a sprite from
            Rectangle destinationRectangle = new(); // Where to draw on screen
            Rectangle frame1 = new(92, 189, 5, 8);
            Rectangle frame2 = new(100, 189, 8, 8);
            Rectangle frame3 = new(109,191, 8, 5);
            Vector2 origin;

            spriteBatch.Begin();
            //1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                sourceRectangle = frame1;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame3;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -90, origin, SpriteEffects.None, 0); spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 180, new Vector2(0, 0), SpriteEffects.None, 1);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame1;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame3;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                //reversed
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -270, origin, SpriteEffects.None, 0);
            }
            // Draw the sprite

            spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return this.destinationRectangle;
        }
    }



    public class BlueBoomerangDownSprite : ILinkProjectileSprite
    {

        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private readonly int maxFrames = 1500;
        private Boolean done = false;
        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;

        // On screen location
        private Rectangle destinationRectangle;

        private static Vector2 CalculateOrigin(ref Rectangle sourceRectangle, ref Rectangle destinationRectangle)
        {

            Vector2 origin = new(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;

            return origin;
        }

        public BlueBoomerangDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;

        }
       
        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                done = true;
                currFrames = maxFrames;
            }

            if (!done)
            {
                currFrames += 50;
                timingFrames += 10;

                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                //to change direction of BlueBoomerang
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
            Rectangle sourceRectangle = new(); // Store the current location on the spritesheet to get a sprite from
            Rectangle destinationRectangle = new(); // Where to draw on screen
            Rectangle frame1 = new (92, 189, 5, 8);
            Rectangle frame2 = new (100, 189, 8, 8);
            Rectangle frame3 = new(109, 191, 8, 5);
            Vector2 origin;

            spriteBatch.Begin();
            //1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                sourceRectangle = frame1;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame3;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -90, origin, SpriteEffects.None, 0); spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 180, new Vector2(0, 0), SpriteEffects.None, 1);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame1;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //6
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame3;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                //reversed
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -270, origin, SpriteEffects.None, 0);
            }
            // Draw the sprite

            spriteBatch.End();
        }
        
        public Rectangle getHitbox()
        {
            return this.destinationRectangle;
        }
    }


    public class BlueBoomerangRightSprite : ILinkProjectileSprite
    {

        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private readonly int maxFrames = 1500;
        private Boolean done = false;

        // Texture to take sprites from
        public Texture2D texture;
        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;

        // On screen location
        private Rectangle destinationRectangle;

        private static Vector2 CalculateOrigin(ref Rectangle sourceRectangle, ref Rectangle destinationRectangle)
        {

            Vector2 origin = new(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;

            return origin;
        }


        public BlueBoomerangRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public void Update()
        {

            if (timingFrames > maxFrames)
            {
                done = true;
                currFrames = maxFrames;
            }

            if (!done)
            {
                currFrames += 50;
                timingFrames += 10;

                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                //to change direction of BlueBoomerang
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
            Rectangle sourceRectangle = new(); // Store the current location on the spritesheet to get a sprite from
            Rectangle destinationRectangle = new(); // Where to draw on screen
            Rectangle frame1 = new (92, 189, 5, 8);
            Rectangle frame2 = new (100, 189, 8, 8);
            Rectangle frame3 = new (109, 191, 8, 5);
            Vector2 origin;

            spriteBatch.Begin();
            //1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                sourceRectangle = frame1;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame3;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -90, origin, SpriteEffects.None, 0); spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 180, new Vector2(0, 0), SpriteEffects.None, 1);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame1;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame3;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                //reversed
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -270, origin, SpriteEffects.None, 0);
            }
            // Draw the sprite

            spriteBatch.End();
        }
        public Rectangle getHitbox()
        {
            return this.destinationRectangle;
        }
    }


    public class BlueBoomerangLeftSprite : ILinkProjectileSprite
    {

        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private readonly int maxFrames = 1500;
        private Boolean done = false;

        // Texture to take sprites from
        public Texture2D texture;
        // X and Y positions of the sprite
        public float xPosition;
        public float yPosition;

        private Rectangle destinationRectangle;


        private static Vector2 CalculateOrigin(ref Rectangle sourceRectangle, ref Rectangle destinationRectangle)
        {

            Vector2 origin = new (sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;

            return origin;
        }

        public BlueBoomerangLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }


        public void Update()
        {

            if (timingFrames > maxFrames)
            {
                done = true;
                currFrames = maxFrames;
            }

            if (!done)
            {
                currFrames += 50;
                timingFrames += 10;

                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                //to change direction of BlueBoomerang
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
            Rectangle sourceRectangle = new(); // Store the current location on the spritesheet to get a sprite from
            Rectangle destinationRectangle = new(); // Where to draw on screen
            Rectangle frame1 = new(92, 189, 5, 8);
            Rectangle frame2 = new(100, 189, 8, 8);
            Rectangle frame3 = new(109, 191, 8, 5);
            Vector2 origin;

            spriteBatch.Begin();
            //1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                sourceRectangle = frame1;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame3;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -90, origin, SpriteEffects.None, 0); spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 180, new Vector2(0, 0), SpriteEffects.None, 1);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame1;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                //reversed
                sourceRectangle = frame3;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                //reversed
                sourceRectangle = frame2;
                destinationRectangle = new((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -270, origin, SpriteEffects.None, 0);
            }
            // Draw the sprite

            spriteBatch.End();
        }
        public Rectangle getHitbox()
        {
            return this.destinationRectangle;
        }
    }
}
