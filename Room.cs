using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace LegendofZelda
{
    public class Room
    {
        private List<ISprite> sprites;
        private ISprite background;
        private SpriteBatch spriteBatch;
        
        public Room(List<ISprite> sprites, ISprite background,SpriteBatch spriteBatch )
        {
            this.sprites = sprites;
            this.background = background;
            this.spriteBatch = spriteBatch;
        }

        public void DrawBackground()
        {
            background.Draw(spriteBatch);
        }

        public void Draw()
        {
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
