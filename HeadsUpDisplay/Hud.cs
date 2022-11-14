using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;
using LegendofZelda;
using Sprites;
using System.Diagnostics;
using Sprint0;



namespace HeadsUpDisplay
{
    public class Hud
    {
        private List<ISprite> sprites = new List<ISprite>();
        // For setting the positions of the heart sprites. 
        readonly private float heartXPos = 543;
        readonly private float heartYPos = 93;
        private int x;
        private int y;
        readonly private float heartSpacing = 34;

        readonly private Vector2 heartOnePos;
        readonly private Vector2 heartTwoPos;
        readonly private Vector2 heartThreePos;

        readonly private Vector2 backgroundPos;

        int bombCount;
        ISprite bombCountText;
        int keyCount;
        ISprite keyCountText;
        int gemstoneCount;
        ISprite gemstoneCountText;
        ISprite blueMap;
        ISprite red1;
        ISprite red2;
        ISprite red3;
        ISprite halfRed1;
        ISprite halfRed2;
        ISprite halfRed3;
        ISprite pink1;
        ISprite pink2;
        ISprite pink3;

        ISprite heart1; 
        ISprite heart2;
        ISprite heart3;



        float heartCount = 3;

        public Hud(int xPos, int yPos)
        {            
            this.x = xPos;
            this.y = yPos;
            this.heartXPos = this.x + 540;
            this.heartYPos = this.y + 106;
            heartOnePos = new Vector2(this.heartXPos, this.heartYPos);
            heartTwoPos = new Vector2(this.heartXPos + heartSpacing, this.heartYPos);
            heartThreePos = new Vector2(this.heartXPos + heartSpacing * 2, this.heartYPos);
            backgroundPos = new Vector2(this.x, this.y);

            red1 = HudSpriteFactory.Instance.CreateSprite(heartOnePos, "RedHeartSprite");                        
            red2 = HudSpriteFactory.Instance.CreateSprite(heartTwoPos, "RedHeartSprite");                        
            red3 = HudSpriteFactory.Instance.CreateSprite(heartThreePos, "RedHeartSprite");

            halfRed1 = HudSpriteFactory.Instance.CreateSprite(heartOnePos, "HalfRedHeartSprite");
            halfRed2 = HudSpriteFactory.Instance.CreateSprite(heartTwoPos, "HalfRedHeartSprite");
            halfRed3 = HudSpriteFactory.Instance.CreateSprite(heartThreePos, "HalfRedHeartSprite");

            pink1 = HudSpriteFactory.Instance.CreateSprite(heartOnePos, "PinkHeartSprite");
            pink2 = HudSpriteFactory.Instance.CreateSprite(heartTwoPos, "PinkHeartSprite");
            pink3 = HudSpriteFactory.Instance.CreateSprite(heartThreePos, "PinkHeartSprite");

            blueMap = HudSpriteFactory.Instance.CreateSprite(new Vector2(this.x + 40, this.y + 55), "HudBlueMapSprite");

            sprites.Add(HudSpriteFactory.Instance.CreateSprite(this.backgroundPos, "hudBackground"));            
            sprites.Add(HudSpriteFactory.Instance.CreateSprite(new Vector2(this.x + 472, this.y + 62), "LinkSwordSprite"));
            this.heart1 = red1;
            this.heart2 = red2;
            this.heart3 = red3;
            
            sprites.Add(red1);
            sprites.Add(red2);
            sprites.Add(red3);
        }

        public void Update()
        {
            bombCount = Link.Instance.inventory.getItemCount("bomb");
            bombCountText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(this.x + 300, this.y + 115), "X" + bombCount.ToString());
            keyCount = Link.Instance.inventory.getItemCount("key");
            keyCountText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(this.x + 300, this.y + 90), "X" + keyCount.ToString());
            gemstoneCount = Link.Instance.inventory.getItemCount("orange gemstone");
            gemstoneCountText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(this.x + 300, this.y + 40), "X" + gemstoneCount.ToString());
            blueMap.Update();
            float prevHeartCount = this.heartCount;
            this.heartCount = Link.Instance.health;
            
            switch (this.heartCount)
            {
                case 0:
                    sprites.Remove(this.heart1);
                    sprites.Remove(this.heart2);
                    sprites.Remove(this.heart3);
                    this.heart1 = pink1;
                    this.heart2 = pink2;
                    this.heart3 = pink3;
                    sprites.Add(this.heart1); 
                    sprites.Add(this.heart2);
                    sprites.Add(this.heart3);
                    break;
                case .5f:                    
                    sprites.Remove(this.heart1);
                    sprites.Remove(this.heart2);
                    sprites.Remove(this.heart3);
                    this.heart1 = halfRed1;
                    this.heart2 = pink2;
                    this.heart3 = pink3;
                    sprites.Add(this.heart1); 
                    sprites.Add(this.heart2);
                    sprites.Add(this.heart3);
                    break;
                case 1:
                    sprites.Remove(this.heart1);
                    sprites.Remove(this.heart2);
                    sprites.Remove(this.heart3);
                    this.heart1 = red1;
                    this.heart2 = pink2;
                    this.heart3 = pink3;
                    sprites.Add(this.heart1); 
                    sprites.Add(this.heart2);
                    sprites.Add(this.heart3);
                    break;
                case 1.5f:
                    sprites.Remove(this.heart1);
                    sprites.Remove(this.heart2);
                    sprites.Remove(this.heart3);
                    this.heart1 = red1;
                    this.heart2 = halfRed2;
                    this.heart3 = pink3;
                    sprites.Add(this.heart1); 
                    sprites.Add(this.heart2);
                    sprites.Add(this.heart3);
                    break;
                case 2:
                    sprites.Remove(this.heart1);
                    sprites.Remove(this.heart2);
                    sprites.Remove(this.heart3);
                    this.heart1 = red1;
                    this.heart2 = red2;
                    this.heart3 = pink3;
                    sprites.Add(this.heart1); 
                    sprites.Add(this.heart2);
                    sprites.Add(this.heart3);
                    break;
                case 2.5f:
                    sprites.Remove(this.heart1);
                    sprites.Remove(this.heart2);
                    sprites.Remove(this.heart3);
                    this.heart1 = red1;
                    this.heart2 = red2;
                    this.heart3 = halfRed3;
                    sprites.Add(this.heart1); 
                    sprites.Add(this.heart2);
                    sprites.Add(this.heart3);
                    break;
                case 3:
                    sprites.Remove(this.heart1);
                    sprites.Remove(this.heart2);
                    sprites.Remove(this.heart3);
                    this.heart1 = red1;
                    this.heart2 = red2;
                    this.heart3 = red3;
                    sprites.Add(this.heart1); 
                    sprites.Add(this.heart2);
                    sprites.Add(this.heart3);
                    break;
                default:
                    break;
            }

            
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            
            foreach (ISprite sprite in sprites)
            {                                
                    sprite.Draw(_spriteBatch);                               
            }
            if (bombCountText != null)
            {
                bombCountText.Draw(_spriteBatch);
            }
            if (keyCountText != null)
            {
                keyCountText.Draw(_spriteBatch);
            }
            if (gemstoneCountText != null)
            {
                gemstoneCountText.Draw(_spriteBatch);
            }
            if (blueMap != null)
            {
                blueMap.Draw(_spriteBatch);
            }
        }
    }
}

