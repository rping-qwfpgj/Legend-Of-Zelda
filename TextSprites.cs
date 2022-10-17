using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using Interfaces;

namespace Sprites
{
    public class TextSprite: ISprite
    {
        // Needed for for drawing at a location on the screen
        public GraphicsDeviceManager graphics;

        // Font to use
        public SpriteFont font;

        // Text to produce
        public string text;

        public TextSprite(GraphicsDeviceManager graphics,SpriteFont font, string text)
        {
            this.graphics = graphics;
            this.font = font;
            this.text = text;
        }

        public void Update()
        {
            // Only drawing once, no need for anything here
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Where to position the font
            Vector2 fontPosition = new Vector2(graphics.PreferredBackBufferWidth / 3, graphics.PreferredBackBufferHeight / 3);

            // Get the origin of the font to center it
            Vector2 fontOrigin = font.MeasureString(text) / 2;

            // Draw the text
            spriteBatch.Begin();
            spriteBatch.DrawString(font, text, fontPosition, Color.Black, 0, fontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.End();

        }

        public Rectangle getHitbox()
        {
            throw new NotImplementedException();
        }        
    }
}
