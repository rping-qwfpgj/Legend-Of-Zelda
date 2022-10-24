using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class NoneSprite : ILinkProjectile
    {
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        public NoneSprite()
        {
            //do nothing, aka no sprite is drawn when link does not have projectile
        }
        public void Update()
        {
            //do nothing
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           //do Nothing
        }
        public Rectangle GetHitbox()
        {
            return new Rectangle(0,0,1,1);
        }

        public void collide()
        {
            // do nothing
        }

    }
}
