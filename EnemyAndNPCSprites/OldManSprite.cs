using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class OldManSprite : IEnemy
    {

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }

        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        public OldManSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle sourceRectangle = new Rectangle(0, 0, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 64);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Vector2 getPosition()
        {
            return new Vector2(this.xPosition, this.yPosition);
        }
        
        public Rectangle GetHitbox()
        {
            // change this to destination rectangle
            return new Rectangle();
        }

        public void TakeDamage(string side)
        {

        }
    }
}

