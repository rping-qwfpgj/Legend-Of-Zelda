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
        private List<ISprite> sprites;
        private ISprite backgroundSprite;
        private List<String> spriteStrings = "hudBackground", "X1Sprite";

        public Hud()
        {
            for(string spriteString in spriteStrings)
            {
                sprites.Add(HudSpriteFactory.Instance.CreateSprite(spriteString);
            }
            
        }

        public void Update()
        {            
            
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            for (ISprite sprite in sprites)
            {
                sprite.Draw(_spriteBatch);
            }
        }

    }
}

