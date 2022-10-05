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
    public class NoneSprite : ISprite
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
        public Vector2 getPosition()
        {
            return new Vector2(0, 0);
        }

    }
}
