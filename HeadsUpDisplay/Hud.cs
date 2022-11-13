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
        // For setting the positions of the heart sprites. 
        readonly private int xPos = 543;
        readonly private int yPos = 93;
        readonly private int width = 7;

        public Hud()
        {       
            sprites.Add(HudSpriteFactory.Instance.CreateSprite("hudBackground"));

            //ISprite redHeart1Sprite = HudSpriteFactory.Instance.CreateSprite("RedHeartSprite");
            //redHeart1Sprite.setPos(xPos, yPos);
            //ISprite redHeart2Sprite = HudSpriteFactory.Instance.CreateSprite("RedHeartSprite");
            //redHeart1Sprite.setPos(xPos + width, yPos);
            //ISprite redHeart3Sprite = HudSpriteFactory.Instance.CreateSprite("RedHeartSprite");
            //redHeart1Sprite.setPos(xPos + 2*width, yPos);
            //sprites.Add(redHeart1Sprite);
            //sprites.Add(redHeart1Sprite);
            //sprites.Add(redHeart1Sprite);
            
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

