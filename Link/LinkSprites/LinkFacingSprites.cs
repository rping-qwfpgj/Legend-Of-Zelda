using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Interfaces;

namespace Sprites
{
    public class LinkFacingUpSprite : INonAttackingSprite
    {
        // Texture to take sprites from
        private readonly Texture2D texture;

        // X and Y positions of the sprite
        private readonly float xPosition;
        private readonly float yPosition;

        private Color color = Color.White;

        // Get information about screen dimensions
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

        public LinkFacingUpSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;

            // Create source and destination rectangles
            sourceRectangle = new Rectangle(71, 11, 12, 16); // Store the current location on the spritesheet to get a sprite from
            destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 48, 64); // Where to draw on screen

            if (isDamaged)
            {
                color = Color.Lerp(Color.White, Color.Red, 0.3f);
            }
        }
        public void Update()
        {
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the sprite
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
            spriteBatch.End();
        }

         public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class LinkFacingDownSprite : INonAttackingSprite
    {
        // Texture to take sprites from
        private readonly Texture2D texture;

        // X and Y positions of the sprite
        private readonly float xPosition;
        private readonly float yPosition;

        private Color color = Color.White;

        // Get information about screen dimensions
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

        private bool isDamaged;

        public LinkFacingDownSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.isDamaged = isDamaged;

            // Create source and destination rectangles
            sourceRectangle = new Rectangle(1, 11, 15, 16); // Store the current location on the spritesheet to get a sprite from
            destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 60, 64); // Where to draw on screen

            if (isDamaged)
            {
                color = Color.Lerp(Color.White, Color.Red, 0.3f);
            }
        }
        public void Update()
        {
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the sprite
            spriteBatch.Begin();          
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);            
            spriteBatch.End();
        }

       public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }
    public class LinkFacingRightSprite : INonAttackingSprite
    {
        // Texture to take sprites from
        private readonly Texture2D texture;

        // X and Y positions of the sprite
        private readonly float xPosition;
        private readonly float yPosition;

        private Color color = Color.White;

        // Get information about screen dimensions
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

        public LinkFacingRightSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;

            // Create source and destination rectangles
            sourceRectangle = new Rectangle(35, 11, 15, 16); // Store the current location on the spritesheet to get a sprite from
            destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 60, 64); // Where to draw on screen

            if (isDamaged)
            {
                color = Color.Lerp(Color.White, Color.Red, 0.3f);
            }
        }
        public void Update()
        {
        }
        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the sprite
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class LinkFacingLeftSprite : INonAttackingSprite
    {
        // Texture to take sprites from
        private readonly Texture2D texture;

        // X and Y positions of the sprite
        private readonly float xPosition;
        private readonly float yPosition;

        private Color color = Color.White;

        // Get information about screen dimensions
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

        public LinkFacingLeftSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;

            // Create source and destination rectangles
            sourceRectangle = new Rectangle(35, 11, 15, 16); // Store the current location on the spritesheet to get a sprite from
            destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 60, 64); // Where to draw on screen

            if (isDamaged)
            {
                color = Color.Lerp(Color.White, Color.Red, 0.3f);
            }
        }
        public void Update()
        {
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the sprite
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);          
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }
}