using System;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Sprites
{
    public class GoriyaSprite : IEnemy
    {
        private IEnemy currentGoriya;
        private int counter = 0;
        private int speed = 50;
        private IEnemy movingUp;
        private IEnemy movingDown;
        private IEnemy movingRight;
        private IEnemy movingLeft;
        private IEnemy throwingRight;
        private IEnemy throwingLeft;
        private IEnemy throwingUp;
        private IEnemy throwingDown;

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        private int prevdirection = 1;
        private Texture2D texture;
        private float xPos;
        private float yPos;
        private Rectangle destinationRectangle = new Rectangle(1,1,0,0);
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        public GoriyaSprite(Texture2D texture, float xPosition, float yPosition)
        {   
            this.texture = texture;
            this.xPos = xPosition;
            this.yPos = yPosition;
            currentGoriya = new GoriyaMovingDownSprite(texture, xPosition, yPosition);
        }

        public void Update()
        {
            if(prevdirection != direction)
            {
                prevdirection = direction;
                if(currentGoriya is GoriyaMovingRightSprite)
                {
                    currentGoriya = new GoriyaMovingLeftSprite(this.texture, this.xPos, this.yPos);
                } else if(currentGoriya is GoriyaMovingLeftSprite)
                {
                    currentGoriya = new GoriyaMovingRightSprite(this.texture, this.xPos, this.yPos);
                } else if(currentGoriya is GoriyaMovingUpSprite)
                {
                    currentGoriya = new GoriyaMovingDownSprite(this.texture, this.xPos, this.yPos);
                } else if (currentGoriya is GoriyaMovingDownSprite)
                {
                    currentGoriya = new GoriyaMovingUpSprite(this.texture, this.xPos, this.yPos);
                }
            }
            
            currentGoriya.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentGoriya.Draw(spriteBatch);
        }

        public Rectangle GetHitbox()
        {
          Rectangle hitbox = currentGoriya.GetHitbox();

          if(hitbox == null)
            {
                return this.destinationRectangle;
            } else
            {
                return hitbox;
            }            
        }

        public void TakeDamage(string side)
        {
            currentGoriya.TakeDamage(side);
        }
    }

    public class GoriyaMovingUpSprite : IEnemy
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }

        private int currentFrame = 0; 

        public GoriyaMovingUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
        }

        public void Update()
        {
            yPosition -= 1;
            sourceRectangle = new Rectangle(241, 11, 13, 16);
            destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            currentFrame++;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            if ((currentFrame / 10) % 2 == 0)
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            }


            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void TakeDamage(string side)
        {
            switch(side)
            {
                case "top":
                    this.yPosition += 5;
                    break;
                case "bottom":
                    this.yPosition -= 5;
                    break;
                case "left":
                    this.xPosition += 5;
                    break;
                case "right":
                    this.xPosition -=5;
                    break;
                default:
                    break;
            }
        }
   }

    public class GoriyaMovingDownSprite : IEnemy
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}
        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }


        private int currentFrame;

        public GoriyaMovingDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
        }

        public void Update()
        {
            yPosition += 1;
            sourceRectangle = new Rectangle(224, 11, 13, 16);
            destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            currentFrame++;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if ((currentFrame / 10) % 2 == 0)
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            }

            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void TakeDamage(string side)
        {
            switch(side)
            {
                case "top":
                    this.yPosition += 5;
                    break;
                case "bottom":
                    this.yPosition -= 5;
                    break;
                case "left":
                    this.xPosition += 5;
                    break;
                case "right":
                    this.xPosition -=5;
                    break;
                default:
                    break;
            }
        }
    }

    public class GoriyaMovingRightSprite : IEnemy
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}
        int currentFrame = 0;


       // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }

        public GoriyaMovingRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
        }
        public void Update()
        {
            xPosition += 1;
            currentFrame++;
            if ((currentFrame / 10) % 2 == 0)
            {
                sourceRectangle = new Rectangle(257, 11, 13, 16);
                destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            }
            else
            {
                sourceRectangle = new Rectangle(275, 12, 14, 15);
                destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void TakeDamage(string side)
        {
            switch(side)
            {
                case "top":
                    this.yPosition += 5;
                    break;
                case "bottom":
                    this.yPosition -= 5;
                    break;
                case "left":
                    this.xPosition += 5;
                    break;
                case "right":
                    this.xPosition -=5;
                    break;
                default:
                    break;
            }
        }

    }

    public class GoriyaMovingLeftSprite : IEnemy
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}
        int currentFrame = 0;


        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }

        public GoriyaMovingLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
        }

        public void Update()
        {

            xPosition -= 1;

            currentFrame++;
            if ((currentFrame / 10) % 2 == 0)
            {
                sourceRectangle = new Rectangle(257, 11, 13, 16);
                destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 39, 48);
            }
            else
            {
                sourceRectangle = new Rectangle(275, 12, 14, 15);
                destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 39, 48);
            }


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void TakeDamage(string side)
        {
            switch(side)
            {
                case "top":
                    this.yPosition += 5;
                    break;
                case "bottom":
                    this.yPosition -= 5;
                    break;
                case "left":
                    this.xPosition += 5;
                    break;
                case "right":
                    this.xPosition -=5;
                    break;
                default:
                    break;
            }
        }
    }

    /* ------- THROWING SPRITES -------*/

    public class GoriyaThrowingRightSprite : IEnemy
    {
       
        private int goriyaFrames = 0;

        private Rectangle goriyaSourceRectangle;
        private Rectangle goriyaDestinationRectangle;
        public Rectangle DestinationRectangle { get => goriyaDestinationRectangle; set => goriyaDestinationRectangle = value;}

       // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }

        // Boomerang that will be thrown
        public BoomerangGoingRightSprite rightBoomerang;

        // Texture to take sprites from
        private Texture2D texture;


  
        public GoriyaThrowingRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.goriyaDestinationRectangle =  new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            rightBoomerang = new BoomerangGoingRightSprite(texture, (int)xPosition, (int)yPosition);

        }

        public void Update()
        {
            goriyaFrames++;
            this.rightBoomerang.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if ((goriyaFrames / 10) % 2 == 0)
            {
                goriyaSourceRectangle = new Rectangle(257, 11, 13, 16);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            }
            else
            {
                goriyaSourceRectangle = new Rectangle(275, 12, 14, 15);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            }

            spriteBatch.Draw(texture, goriyaDestinationRectangle, goriyaSourceRectangle, Color.White);
            this.rightBoomerang.Draw(spriteBatch);

            
        }

        public Rectangle GetHitbox()
        {
            return this.goriyaDestinationRectangle;
        }

        public void TakeDamage(string side)
        {
            switch(side)
            {
                case "top":
                    this.yPosition += 5;
                    break;
                case "bottom":
                    this.yPosition -= 5;
                    break;
                case "left":
                    this.xPosition += 5;
                    break;
                case "right":
                    this.xPosition -=5;
                    break;
                default:
                    break;
            }
        }

    }

    public class GoriyaThrowingLeftSprite : IEnemy
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

       
        private Rectangle goriyaSourceRectangle;
        private Rectangle goriyaDestinationRectangle;
        public Rectangle DestinationRectangle { get => goriyaDestinationRectangle; set => goriyaDestinationRectangle = value;}

       // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }

        // Texture to take sprites from
        private Texture2D texture;

        // Boomerang that will be thrown
        public BoomerangGoingLeftSprite leftBoomerang;
        
        public GoriyaThrowingLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.goriyaDestinationRectangle =  new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            leftBoomerang = new BoomerangGoingLeftSprite(texture, (int)xPosition, (int)yPosition);
        }

        public void Update()
        {
            currFrames += 101;
            
            if (currFrames >= maxFrames)
            {
                currFrames = 0;
            }

            this.leftBoomerang.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if ((currFrames / 10) % 2 == 0)
            {
                goriyaSourceRectangle = new Rectangle(257, 11, 13, 16);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            }
            else
            {
                goriyaSourceRectangle = new Rectangle(275, 12, 14, 15);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            }


            spriteBatch.Draw(texture, goriyaDestinationRectangle, goriyaSourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            this.leftBoomerang.Draw(spriteBatch);
            
           
        }

        public Rectangle GetHitbox()
        {
            return this.goriyaDestinationRectangle;
        }

        public void TakeDamage(string side)
        {
            switch(side)
            {
                case "top":
                    this.yPosition += 5;
                    break;
                case "bottom":
                    this.yPosition -= 5;
                    break;
                case "left":
                    this.xPosition += 5;
                    break;
                case "right":
                    this.xPosition -=5;
                    break;
                default:
                    break;
            }
        }

    }

    public class GoriyaThrowingDownSprite : IEnemy
    {
        // Keep track of frames
        private int goriyaFrames = 0;

        private Rectangle goriyaSourceRectangle;
        private Rectangle goriyaDestinationRectangle;
        public Rectangle DestinationRectangle { get => goriyaDestinationRectangle; set => goriyaDestinationRectangle = value;}

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }


        // Texture to take sprites from
        private Texture2D texture;
        // X and Y positions of the sprite

        // Boomerang to throw 
        public BoomerangGoingDownSprite downBoomerang;

        public GoriyaThrowingDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.goriyaDestinationRectangle =  new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            downBoomerang = new BoomerangGoingDownSprite(texture, (int)xPosition, (int)yPosition);
        }

        public void Update()
        {
            goriyaFrames++;
            this.downBoomerang.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if ((goriyaFrames / 10) % 2 == 0)
            {
                goriyaSourceRectangle = new Rectangle(224, 11, 13, 16);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
                spriteBatch.Draw(texture, goriyaDestinationRectangle, goriyaSourceRectangle, Color.White);
            }
            else
            {
                goriyaSourceRectangle = new Rectangle(224, 11, 13, 16);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
                spriteBatch.Draw(texture, goriyaDestinationRectangle, goriyaSourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);

            }

            this.downBoomerang.Draw(spriteBatch);

            
        }

        public Rectangle GetHitbox()
        {
            return this.goriyaDestinationRectangle;
        }

        public void TakeDamage(string side)
        {
            switch(side)
            {
                case "top":
                    this.yPosition += 5;
                    break;
                case "bottom":
                    this.yPosition -= 5;
                    break;
                case "left":
                    this.xPosition += 5;
                    break;
                case "right":
                    this.xPosition -=5;
                    break;
                default:
                    break;
            }
        }

    }

    public class GoriyaThrowingUpSprite : IEnemy
    {
        private int goriyaFrames = 0;

        private Rectangle goriyaSourceRectangle;
        private Rectangle goriyaDestinationRectangle;
        public Rectangle DestinationRectangle { get => goriyaDestinationRectangle; set => goriyaDestinationRectangle = value;}

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }

        // Texture to take sprites from
        private Texture2D texture;

        // Boomerang to throw
        public BoomerangGoingUpSprite upBoomerang;

        public GoriyaThrowingUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.goriyaDestinationRectangle =  new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            upBoomerang = new BoomerangGoingUpSprite(texture, (int)xPosition, (int)yPosition);
        }

        public void Update()
        {
            goriyaFrames++;
            this.upBoomerang.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if ((goriyaFrames / 10) % 2 == 0)
            {
                goriyaSourceRectangle = new Rectangle(241, 11, 13, 16);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
                spriteBatch.Draw(texture, goriyaDestinationRectangle, goriyaSourceRectangle, Color.White);
            }
            else
            {
                goriyaSourceRectangle = new Rectangle(241, 11, 13, 16);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
                spriteBatch.Draw(texture, goriyaDestinationRectangle, goriyaSourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);

            }


            this.upBoomerang.Draw(spriteBatch);

            
        }

        public Rectangle GetHitbox()
        {
            return this.goriyaDestinationRectangle;
        }

        public void TakeDamage(string side)
        {
            switch(side)
            {
                case "top":
                    this.yPosition += 5;
                    break;
                case "bottom":
                    this.yPosition -= 5;
                    break;
                case "left":
                    this.xPosition += 5;
                    break;
                case "right":
                    this.xPosition -=5;
                    break;
                default:
                    break;
            }
        }

    }

    /*---------- BOOMERANG SPRITES ----------*/

    public class BoomerangGoingRightSprite: IEnemyProjectile
    {
            // Keep track of frames
            private int currFrames = 0;
            private int timingFrames = 0;
            private int maxFrames = 2000;

            // Keep track of where to get a sprite off the spritesheet and the on screen location
            private Rectangle sourceRectangle;
            private Rectangle destinationRectangle;
            public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

            // The 3 frames of the boomerang's animation
            private Rectangle frame1 = new Rectangle(291, 15, 5, 8);
            private Rectangle frame2 = new Rectangle(299, 15, 8, 8);
            private Rectangle frame3 = new Rectangle(308, 17, 8, 5);

            private int xBoomerangPosition;
            private int yBoomerangPosition;

            private Vector2 origin; // Center of the boomerange, needed to properly rotate it in animation

            // Texture to take sprites from
            private Texture2D texture;

            public BoomerangGoingRightSprite(Texture2D texture, float xPosition, float yPosition)
            {
                this.texture = texture;
                this.xBoomerangPosition = (int)xPosition;
                this.yBoomerangPosition = (int)yPosition;
            }

            private Vector2 CalculateOrigin(ref Rectangle sourceRectangle, ref Rectangle destinationRectangle)
            {
                Vector2 origin = new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
                destinationRectangle.X += destinationRectangle.Width / 2;
                destinationRectangle.Y += destinationRectangle.Height / 2;
                return origin;
            }

            public void Update()
            {
                if (timingFrames > maxFrames)
                {
                    timingFrames = 0;
                }

                currFrames += 100;
                timingFrames += 30;
                
                if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }

                if (timingFrames <= maxFrames / 2)
                {
                    xBoomerangPosition += 5;
                }
                else if (timingFrames < maxFrames)
                {
                    xBoomerangPosition -= 5;
                }
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                

                // 1
                if (currFrames >= 0 && currFrames <= maxFrames / 8)
                {
                    sourceRectangle = frame1;
                    destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

                }
                //2
                else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
                {
                    sourceRectangle = frame2;
                    destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

                }
                //3
                else if (currFrames > 2 * maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
                {
                    sourceRectangle = frame3;
                    destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                }
                //4
                else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
                {
                    sourceRectangle = frame2;
                    destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -90, origin, SpriteEffects.None, 0);

                }
                //5
                else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
                {
                    sourceRectangle = frame1;
                    destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
                }
                //6
                else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
                {
                    sourceRectangle = frame2;
                    destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
                }
                //7
                else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
                {
                    sourceRectangle = frame3;
                    destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
                }
                //8
                else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
                {
                    sourceRectangle = frame2;
                    destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -270, origin, SpriteEffects.None, 0);
                }
                spriteBatch.End();
            }

            public Rectangle GetHitbox()
            {
                return this.destinationRectangle;
            }
    }

    public class BoomerangGoingLeftSprite : IEnemyProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private int maxFrames = 2000;

        // Keep track of where to get a sprite off the spritesheet and the on screen location
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        // The 3 frames of the boomerang's animation
        private Rectangle frame1 = new Rectangle(291, 15, 5, 8);
        private Rectangle frame2 = new Rectangle(299, 15, 8, 8);
        private Rectangle frame3 = new Rectangle(308, 17, 8, 5);

        private int xBoomerangPosition;
        private int yBoomerangPosition;

        private Vector2 origin; // Center of the boomerange, needed to properly rotate it in animation

        // Texture to take sprites from
        private Texture2D texture;

        public BoomerangGoingLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xBoomerangPosition = (int)xPosition;
            this.yBoomerangPosition = (int)yPosition;
        }

        private Vector2 CalculateOrigin(ref Rectangle sourceRectangle, ref Rectangle destinationRectangle)
        {
            Vector2 origin = new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;
            return origin;
        }

        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                timingFrames = 0;
            }

            currFrames += 100;
            timingFrames += 30;

            if (currFrames >= maxFrames)
            {
                currFrames = 0;
            }

            if (timingFrames <= maxFrames / 2)
            {
                xBoomerangPosition -= 5;
            }
            else if (timingFrames < maxFrames)
            {
                xBoomerangPosition += 5;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            

            // 1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                sourceRectangle = frame1;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame3;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -90, origin, SpriteEffects.None, 0);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {
                sourceRectangle = frame1;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //6
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                sourceRectangle = frame3;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                sourceRectangle = frame2;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -270, origin, SpriteEffects.None, 0);
            }
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
    }

    public class BoomerangGoingUpSprite : IEnemyProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private int maxFrames = 2000;

        // Keep track of where to get a sprite off the spritesheet and the on screen location
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        // The 3 frames of the boomerang's animation
        private Rectangle frame1 = new Rectangle(291, 15, 5, 8);
        private Rectangle frame2 = new Rectangle(299, 15, 8, 8);
        private Rectangle frame3 = new Rectangle(308, 17, 8, 5);

        private int xBoomerangPosition;
        private int yBoomerangPosition;

        private Vector2 origin; // Center of the boomerange, needed to properly rotate it in animation

        // Texture to take sprites from
        private Texture2D texture;

        public BoomerangGoingUpSprite(Texture2D texture, int xPosition, int yPosition)
        {
            this.texture = texture;
            this.xBoomerangPosition = xPosition;
            this.yBoomerangPosition = yPosition;
        }

        private Vector2 CalculateOrigin(ref Rectangle sourceRectangle, ref Rectangle destinationRectangle)
        {
            Vector2 origin = new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;
            return origin;
        }

        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                timingFrames = 0;
            }

            currFrames += 100;
            timingFrames += 30;

            if (currFrames >= maxFrames)
            {
                currFrames = 0;
            }

            if (timingFrames <= maxFrames / 2)
            {
                yBoomerangPosition -= 5;
            }
            else if (timingFrames < maxFrames)
            {
                yBoomerangPosition += 5;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();

            // 1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                sourceRectangle = frame1;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame3;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -90, origin, SpriteEffects.None, 0);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {
                sourceRectangle = frame1;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //6
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                sourceRectangle = frame3;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                sourceRectangle = frame2;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -270, origin, SpriteEffects.None, 0);
            }
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
    }

    public class BoomerangGoingDownSprite : IEnemyProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int timingFrames = 0;
        private int maxFrames = 2000;

        // Keep track of where to get a sprite off the spritesheet and the on screen location
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        // The 3 frames of the boomerang's animation
        private Rectangle frame1 = new Rectangle(291, 15, 5, 8);
        private Rectangle frame2 = new Rectangle(299, 15, 8, 8);
        private Rectangle frame3 = new Rectangle(308, 17, 8, 5);

        private int xBoomerangPosition;
        private int yBoomerangPosition;

        private Vector2 origin; // Center of the boomerange, needed to properly rotate it in animation

        // Texture to take sprites from
        private Texture2D texture;

        public BoomerangGoingDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xBoomerangPosition = (int)xPosition;
            this.yBoomerangPosition = (int)yPosition;
        }

        private Vector2 CalculateOrigin(ref Rectangle sourceRectangle, ref Rectangle destinationRectangle)
        {
            Vector2 origin = new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            destinationRectangle.X += destinationRectangle.Width / 2;
            destinationRectangle.Y += destinationRectangle.Height / 2;
            return origin;
        }

        public void Update()
        {
            if (timingFrames > maxFrames)
            {
                timingFrames = 0;
            }

            currFrames += 100;
            timingFrames += 30;

            if (currFrames >= maxFrames)
            {
                currFrames = 0;
            }

            if (timingFrames <= maxFrames / 2)
            {
                yBoomerangPosition += 5;
            }
            else if (timingFrames < maxFrames)
            {
                yBoomerangPosition -= 5;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();

            // 1
            if (currFrames >= 0 && currFrames <= maxFrames / 8)
            {
                sourceRectangle = frame1;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

            }
            //2
            else if (currFrames > maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

            }
            //3
            else if (currFrames > 2 * maxFrames / 8 && currFrames <= 2 * maxFrames / 8)
            {
                sourceRectangle = frame3;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            //4
            else if (currFrames > 3 * maxFrames / 8 && currFrames <= 4 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -90, origin, SpriteEffects.None, 0);

            }
            //5
            else if (currFrames > 4 * maxFrames / 8 && currFrames <= 5 * maxFrames / 8)
            {
                sourceRectangle = frame1;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //6
            else if (currFrames > 5 * maxFrames / 8 && currFrames <= 6 * maxFrames / 8)
            {
                sourceRectangle = frame2;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //7
            else if (currFrames > 6 * maxFrames / 8 && currFrames <= 7 * maxFrames / 8)
            {
                sourceRectangle = frame3;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -180, origin, SpriteEffects.None, 0);
            }
            //8
            else if (currFrames > 7 * maxFrames / 8 && currFrames < maxFrames)
            {
                sourceRectangle = frame2;
                destinationRectangle = new Rectangle(xBoomerangPosition, yBoomerangPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                origin = CalculateOrigin(ref sourceRectangle, ref destinationRectangle);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, -270, origin, SpriteEffects.None, 0);
            }
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
    }
}

