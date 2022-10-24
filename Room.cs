using Interfaces;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;
using Sprites;

namespace LegendofZelda
{
    public class Room
    {
        public List<ISprite> sprites;
        private ISprite background;

        public Room(List<ISprite> sprites, ISprite background)
        {
            this.sprites = sprites;
            this.background = background;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            foreach (var sprite in sprites)
            {
                // If the object is not link, then don't draw him, will cause multiple links
                if(!(sprite is IAttackingSprite) && !(sprite is INonAttackingSprite)) { 
                    sprite.Draw(spriteBatch);
                }
            }
        }

        public void Update()
        {
           foreach (var sprite in sprites)
            {
                sprite.Update();
            }

        }

        public List<ISprite> ReturnObjects()
        {
            List<ISprite> copyOfSprites = new List<ISprite>(sprites);
            return copyOfSprites;
        }

        public void removeObject(ISprite sprite)
        { 
            sprites.Remove(sprite);
        }

        public void AddObject(ISprite sprite)
        {
            sprites.Add(sprite);
        }

    }
}
