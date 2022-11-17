using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;

using System.Diagnostics;
using Sprint0;
using Sprites;

namespace HeadsUpDisplay
{
    public class Hud
    {
        public List<ISprite> sprites = new List<ISprite>();
        // For setting the positions of the heart sprites. 
        private int x;
        private int y;
        readonly private Vector2 heartOnePos, heartTwoPos, heartThreePos, backgroundPos;

        int bombCount, keyCount, gemstoneCount;
        ISprite bombCountText, keyCountText, gemstoneCountText;
        int mapCount;
        ISprite blueMap;
        ISprite red1, red2, red3;
        ISprite halfRed1, halfRed2, halfRed3;
        ISprite pink1, pink2, pink3;
        ISprite heart1, heart2, heart3;
        private ISprite throwableSprite;
        public ISprite ThrowableSprite { set => throwableSprite = value; }
        ISprite selectedBoomerang, selectedBomb, selectedFire, selectedArrow;
        float heartCount;

        public Hud(int xPos, int yPos)
        {
            x = xPos;
            y = yPos;
            int heartXPos = x + 540;
            int heartYPos = y + 106;
            int heartSpacing = 34;
            heartOnePos = new Vector2(heartXPos, heartYPos);
            heartTwoPos = new Vector2(heartXPos + heartSpacing, heartYPos);
            heartThreePos = new Vector2(heartXPos + heartSpacing * 2, heartYPos);
            backgroundPos = new Vector2(x, y);

            heartCount = 3;
            red1 = HudSpriteFactory.Instance.CreateSprite(heartOnePos, "RedHeartSprite");
            red2 = HudSpriteFactory.Instance.CreateSprite(heartTwoPos, "RedHeartSprite");
            red3 = HudSpriteFactory.Instance.CreateSprite(heartThreePos, "RedHeartSprite");

            halfRed1 = HudSpriteFactory.Instance.CreateSprite(heartOnePos, "HalfRedHeartSprite");
            halfRed2 = HudSpriteFactory.Instance.CreateSprite(heartTwoPos, "HalfRedHeartSprite");
            halfRed3 = HudSpriteFactory.Instance.CreateSprite(heartThreePos, "HalfRedHeartSprite");

            pink1 = HudSpriteFactory.Instance.CreateSprite(heartOnePos, "PinkHeartSprite");
            pink2 = HudSpriteFactory.Instance.CreateSprite(heartTwoPos, "PinkHeartSprite");
            pink3 = HudSpriteFactory.Instance.CreateSprite(heartThreePos, "PinkHeartSprite");

            heart1 = red1;
            heart2 = red2;
            heart3 = red3;
     
            blueMap = HudSpriteFactory.Instance.CreateSprite(new Vector2(x + 40, y + 55), "HudBlueMapSprite");
            sprites.Add(HudSpriteFactory.Instance.CreateSprite(backgroundPos, "hudBackground"));
            sprites.Add(HudSpriteFactory.Instance.CreateSprite(new Vector2(x + 472, y + 62), "LinkSwordSprite"));

            Vector2 hudSelectedItemLocation = new Vector2(420, 50);
            selectedBoomerang = HudSpriteFactory.Instance.CreateSprite(hudSelectedItemLocation, "HudBoomerangSprite");
            selectedBomb = HudSpriteFactory.Instance.CreateSprite(hudSelectedItemLocation, "HudBombSprite");
            selectedFire = HudSpriteFactory.Instance.CreateSprite(hudSelectedItemLocation, "HudFireSprite");
            selectedArrow = HudSpriteFactory.Instance.CreateSprite(hudSelectedItemLocation, "HudBowSprite");
            throwableSprite = selectedBoomerang;
        }

        public void Update()
        {
            bombCount = Link.Instance.inventory.getItemCount("bomb");
            bombCountText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(x + 300, y + 115), "X" + bombCount.ToString());
            keyCount = Link.Instance.inventory.getItemCount("key");
            keyCountText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(x + 300, y + 90), "X" + keyCount.ToString());
            gemstoneCount = Link.Instance.inventory.getItemCount("orange gemstone");
            gemstoneCountText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(x + 300, y + 40), "X" + gemstoneCount.ToString());
            blueMap.Update();
            heartCount = Link.Instance.health;
            mapCount = Link.Instance.inventory.getItemCount("orange map");

            switch (heartCount)
            {
                case 0:
                    heart1 = pink1;
                    heart2 = pink2;
                    heart3 = pink3;
                    break;
                case .5f:
                    heart1 = halfRed1;
                    heart2 = pink2;
                    heart3 = pink3;
                    break;
                case 1:              
                    heart1 = red1;
                    heart2 = pink2;
                    heart3 = pink3;          
                    break;
                case 1.5f:               
                    heart1 = red1;
                    heart2 = halfRed2;
                    heart3 = pink3;         
                    break;
                case 2:               
                    heart1 = red1;
                    heart2 = red2;
                    heart3 = pink3;            
                    break;
                case 2.5f:          
                    heart1 = red1;
                    heart2 = red2;
                    heart3 = halfRed3;      
                    break;
                case 3:      
                    heart1 = red1;
                    heart2 = red2;
                    heart3 = red3; 
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
            if (blueMap != null && mapCount > 0)
            {
                blueMap.Draw(_spriteBatch);
            }

            heart1.Draw(_spriteBatch);
            heart2.Draw(_spriteBatch);
            heart3.Draw(_spriteBatch);

        }

        public void switchProjectile(int type)
        {
            sprites.Remove(throwableSprite);
            switch (type)
            {
                case 0:
                    throwableSprite = selectedBoomerang;
                    break;
                case 1:
                    throwableSprite = selectedBomb;
                    break;
                case 2:
                    throwableSprite = selectedFire;           
                    break;
                case 3:
                    throwableSprite = selectedArrow;
                    break;
            }
            sprites.Add(throwableSprite);
        }
    }
}

