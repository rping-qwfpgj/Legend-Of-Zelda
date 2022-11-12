using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Link;
using Sprites;
using Sprint0;
using LegendofZelda.Interfaces;
using LegendofZelda.Backgrounds;

namespace LegendofZelda.SpriteFactories
{
    public class HudSpriteFactory : ISpriteFactory
    {

        private Texture2D spriteSheet;
        private readonly static HudSpriteFactory instance = new();

        public static HudSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private HudSpriteFactory()
        {
        }


        public void loadContent(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("gamestates");
        }

        public ISprite CreateSprite(string name)
        {
            switch (name)
            {
                case "hudBackground":
                    return new HudBackgroundSprite(spriteSheet);

                case "Background1":

                    return new Background1(spriteSheet);                

                default:

                    return null;
            }
        }

    }
}
