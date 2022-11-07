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
        private ISprite backgroundTexture;

        public Hud()
        {
            this.backgroundTexture = HudSpriteFactory.Instance.CreateBackground("Hud");
        }

        public void Update()
        {            
            
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            this.backgroundTexture.Draw(_spriteBatch);
        }

    }
}

