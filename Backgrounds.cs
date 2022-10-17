using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprites;
using Interfaces;


namespace Sprint0
{
    public class Background0 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 16;
        private int height = 16;

        public PlainTurqoiseBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(3, 11, width, height);
            this.destinationRectangle = new Rectangle(xPos, yPos, width * 4, height * 4);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }