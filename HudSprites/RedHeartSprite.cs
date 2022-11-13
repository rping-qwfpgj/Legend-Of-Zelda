using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprites;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class RedHeartSprite : ISprite
    {
        private readonly Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private readonly int width = 7;
        private readonly int height = 8;


        public RedHeartSprite(Texture2D texture)
        {
            this.texture = texture;
            this.sourceRectangle = new(645, 117, width, height);
            this.destinationRectangle = new(543, 93, width*4, height*4);
        }

        public void Update()
        {
           
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public void setPos(int x, int y)
        {
            //this.DestinationRectangle.X = x;
            //this.DestinationRectangle.Y = y;
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

}