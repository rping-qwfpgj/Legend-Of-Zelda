using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class NoneSprite : ILinkProjectile
    {
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        private bool isDone = true;
        public bool IsDone { get => isDone; }
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
            return new Rectangle(0,0,0,0);
        }

        public void collide()
        {
            // do nothing
        }

    }
}
