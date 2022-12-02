
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Sprites
{
    public class DigdoggerGoingUpSprite : IDigdogger
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }

        private int currentFrame = 0;
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        private int damagedCounter;
        public DigdoggerGoingUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.sourceRectangle = new Rectangle(198, 58, 28, 32);
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            this.damagedCounter = 0;
        }

        public void Update()
        {
            if (!isDamaged) { yPosition -= 1; }
            currentFrame++;
            destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            if (isDamaged)
            {
                damagedCounter++;
                sourceRectangle = new Rectangle(52, 58, 16, 16);
                destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 32);
                if (damagedCounter > 240)
                {
                    damagedCounter = 0;
                    isDamaged = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
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

        public void TurnAround(string side)
        {
        }

        public void TakeDamage(string side)
        {
        }
        public ISprite DropItem()
        {
            return null;
        }
        public void Die()
        {
        }
    }

    public class DigdoggerGoingDownSprite : IDigdogger
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        private int currentFrame;
        private int damagedCounter;

        public DigdoggerGoingDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.sourceRectangle = new Rectangle(198, 58, 28, 32);
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            this.damagedCounter = 0;
        }

        public void Update()
        {
            if (!isDamaged) { yPosition += 1; }
            destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            currentFrame++;
            if (isDamaged)
            {
                damagedCounter++;
                sourceRectangle = new Rectangle(18, 58, 16, 16);
                destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 32);
                if (damagedCounter > 120)
                {
                    damagedCounter = 0;
                    isDamaged = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
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
        public void TurnAround(string side)
        {
        }
        public void TakeDamage(string side)
        {
        }
        public ISprite DropItem()
        {
            return null;
        }
        public void Die()
        {
        }
    }
    public class DigdoggerGoingRightSprite : IDigdogger
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        int currentFrame = 0;

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        private int damagedCounter;

        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }

        public DigdoggerGoingRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.sourceRectangle = new Rectangle(264, 58, 28, 32);
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 56, 30);
            this.damagedCounter = 0;
        }
        public void Update()
        {
            if (!isDamaged) { xPosition += 1; }
            currentFrame++;
            if (isDamaged)
            {
                damagedCounter++;
                sourceRectangle = new Rectangle(135, 58, 32, 16);
                destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 32);
                if (damagedCounter > 120)
                {
                    damagedCounter = 0;
                    isDamaged = false;
                }
            }
            else
            {
                if ((currentFrame / 10) % 2 == 0)
                {
                    sourceRectangle = new Rectangle(69, 59, 28, 15);
                    destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 56, 30);
                }
                else
                {
                    sourceRectangle = new Rectangle(102, 58, 28, 16);
                    destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 56, 32);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
        public void TurnAround(string side)
        {
        }
        public void TakeDamage(string side)
        {
        }
        public ISprite DropItem()
        {
            return null;
        }
        public void Die()
        {
        }
    }

    public class DigdoggerGoingLeftSprite : IDigdogger
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        int currentFrame = 0;
        private int damagedCounter;

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        public DigdoggerGoingLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.sourceRectangle = new Rectangle(297, 58, 28, 32);
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            this.damagedCounter = 0;
        }

        public void Update()
        {
            if (!isDamaged) { xPosition -= 1; }
            currentFrame++;
            if (isDamaged)
            {
                damagedCounter++;
                sourceRectangle = new Rectangle(297, 58, 32, 16);
                destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 32);
                if (damagedCounter > 120)
                {
                    damagedCounter = 0;
                    isDamaged = false;
                }
            }
            else
            {
                if ((currentFrame / 10) % 2 == 0)
                {
                    sourceRectangle = new Rectangle(69, 59, 28, 15);
                    destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 56, 30);
                }
                else
                {
                    sourceRectangle = new Rectangle(102, 58, 28, 16);
                    destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 56, 32);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
            spriteBatch.End();
        }
        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
        public void TurnAround(string side)
        {
        }
        public void TakeDamage(string side)
        {
        }
        public ISprite DropItem()
        {
            return null;
        }
        public void Die()
        {
        }
    }

    public class DigdoggerSmallStunnedSprite : IDigdogger
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        int currentFrame = 0;
        private int damagedCounter;

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        public DigdoggerSmallStunnedSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.sourceRectangle = new Rectangle(361, 58, 16, 16);
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 39, 48);
            this.damagedCounter = 0;
        }

        public void Update()
        {
            
            currentFrame++;
            if (isDamaged)
            {
                damagedCounter++;
                
               
                if (damagedCounter > 120)
                {
                    damagedCounter = 0;
                    isDamaged = false;
                }
            }
                destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 32);
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
            spriteBatch.End();
        }
        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
        public void TurnAround(string side)
        {
        }
        public void TakeDamage(string side)
        {
        }
        public ISprite DropItem()
        {
            return null;
        }
        public void Die()
        {
        }
    }

}

