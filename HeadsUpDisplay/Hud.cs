using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;
using LegendofZelda;
using Sprites;


namespace HeadsUpDisplay
{
    public class Hud
    {
        private List<ISprite> sprites = new List<ISprite>();
        // For setting the positions of the heart sprites. 
        readonly private int xPos = 543;
        readonly private int yPos = 93;
        readonly private int width = 35;

        public Hud()
        {   
            sprites.Add(HudSpriteFactory.Instance.CreateSprite("hudBackground"));

            ISprite red1 = HudSpriteFactory.Instance.CreateSprite("RedHeartSprite");
            RedHeartSprite redHeart1Sprite = red1 as RedHeartSprite;
            redHeart1Sprite.setPos(xPos, yPos);

            ISprite halfPink1 = HudSpriteFactory.Instance.CreateSprite("HalfPinkHeartSprite");
            HalfPinkHeartSprite halfPinkSprite1 = halfPink1 as HalfPinkHeartSprite;
            halfPinkSprite1.setPos(xPos, yPos);

            ISprite red2 = HudSpriteFactory.Instance.CreateSprite("RedHeartSprite");
            RedHeartSprite redHeart2Sprite = red2 as RedHeartSprite;
            redHeart2Sprite.setPos(xPos + width, yPos);

            ISprite red3 = HudSpriteFactory.Instance.CreateSprite("RedHeartSprite");
            RedHeartSprite redHeart3Sprite = red3 as RedHeartSprite;
            redHeart3Sprite.setPos(xPos + width*2, yPos);


            sprites.Add(HudSpriteFactory.Instance.CreateSprite("heartBlackSprite"));
            sprites.Add(halfPinkSprite1);
            sprites.Add(redHeart2Sprite);
            sprites.Add(redHeart3Sprite);            
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

