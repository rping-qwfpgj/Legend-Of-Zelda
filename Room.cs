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
        
        public Room(List<ISprite> sprites)
        {
            this.sprites = sprites;
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
