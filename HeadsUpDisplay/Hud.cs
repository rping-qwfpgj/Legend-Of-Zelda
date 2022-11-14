﻿using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;
using LegendofZelda;
using Sprites;
using System.Diagnostics;



namespace HeadsUpDisplay
{
    public class Hud
    {
        private List<ISprite> sprites = new List<ISprite>();
        // For setting the positions of the heart sprites. 
        readonly private float xPos = 543;
        readonly private float yPos = 93;
        readonly private float heartSpacing = 30;

        readonly private Vector2 heartOnePos;
        readonly private Vector2 heartTwoPos;
        readonly private Vector2 heartThreePos;

        readonly private Vector2 backgroundPos = new Vector2(20, -19);

        public Hud()
        {

            heartOnePos = new Vector2(xPos, yPos);
            heartTwoPos = new Vector2(xPos + heartSpacing, yPos);
            heartThreePos = new Vector2(xPos + heartSpacing*2, yPos);
            
            ISprite red1 = HudSpriteFactory.Instance.CreateSprite(heartOnePos, "RedHeartSprite");                        
            ISprite red2 = HudSpriteFactory.Instance.CreateSprite(heartTwoPos, "RedHeartSprite");                        
            ISprite red3 = HudSpriteFactory.Instance.CreateSprite(heartThreePos, "RedHeartSprite");                        
            
            sprites.Add(HudSpriteFactory.Instance.CreateSprite(this.backgroundPos, "hudBackground"));
            
            sprites.Add(HudSpriteFactory.Instance.CreateSprite(heartOnePos, "LinkSwordSprite"));
            sprites.Add(red1);
            sprites.Add(red2);
            sprites.Add(red3);
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

