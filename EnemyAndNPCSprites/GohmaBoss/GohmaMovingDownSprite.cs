using System;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
namespace Sprites
{
	public class GohmaMovingDownSprite : IGohma
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
        private int currentFrame = 0;
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        private int damagedCounter;
        public GohmaMovingDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.sourceRectangle = new Rectangle(229, 105, 47, 16);
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 94, 32);
            this.damagedCounter = 0;
        }

        public void Update()
        {
            if (!isDamaged) { yPosition -= 1; }
            currentFrame++;
            destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 94, 32);
            if (isDamaged)
            {
                damagedCounter++;
                sourceRectangle = new Rectangle(52, 58, 16, 16);
                destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 32);
                if (damagedCounter > 60)
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
        public void PoofIn(SpriteBatch spriteBatch) { }
    }
}
