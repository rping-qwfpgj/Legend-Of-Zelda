using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Sprites
{
    public class NoneSprite : ILinkProjectile
    {
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
        public Rectangle getHitbox()
        {
            return new Rectangle(0,0,1,1);
        }

    }
}
