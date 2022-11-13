using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;
using LegendofZelda;


namespace HeadsUpDisplay
{
    public class Hud
    {
        private List<ISprite> sprites = new List<ISprite>();
        private List<string> spriteStrings = new List<string> { "hudBackground" };
        public Hud()
        {
            ISprite background = HudSpriteFactory.Instance.CreateSprite("hudBackground");
            sprites.Add(background);
            //foreach (string spriteString in spriteStrings)
            //{
            //    ISprite currSprite = HudSpriteFactory.Instance.CreateSprite(spriteString);
            //    sprites.Add(currSprite);
            //}
        }

        public void Update()
        {            
            
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (ISprite sprite in sprites)
            {
                sprite.Draw(_spriteBatch);
            }
        }
    }
}

