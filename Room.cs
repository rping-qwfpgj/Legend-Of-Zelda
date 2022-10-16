using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

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

        public void Initialize()
        {

            foreach (var sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }

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
