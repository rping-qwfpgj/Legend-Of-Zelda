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

            ISprite red1 = HudSpriteFactory.Instance.CreateSprite(heartOnePos, "RedHeartSprite");                        
            ISprite red2 = HudSpriteFactory.Instance.CreateSprite(heartTwoPos, "RedHeartSprite");                        
            ISprite red3 = HudSpriteFactory.Instance.CreateSprite(heartThreePos, "RedHeartSprite");
            blueMap = HudSpriteFactory.Instance.CreateSprite(new Vector2(this.x + 40, this.y + 55), "HudBlueMapSprite");

            sprites.Add(HudSpriteFactory.Instance.CreateSprite(this.backgroundPos, "hudBackground"));
            
            sprites.Add(HudSpriteFactory.Instance.CreateSprite(new Vector2(this.x + 465, this.y + 65), "LinkSwordSprite"));
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

