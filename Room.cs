using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace LegendofZelda
{
    public class Room
    {
        private List<ISprite> sprites;
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
                sprite.Draw(spriteBatch);
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
            return sprites;
        }
    }
}
