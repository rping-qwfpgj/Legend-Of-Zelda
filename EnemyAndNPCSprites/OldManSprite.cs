using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Interfaces;
using System;

namespace Sprites
{
    public class OldManSprite : IEnemySprite
    {

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;
        
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

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Vector2 getPosition()
        {
            return new Vector2(this.xPosition, this.yPosition);
        }
    }
}

