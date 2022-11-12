using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Link;
using Sprites;
using Sprint0;
using LegendofZelda.Interfaces;

namespace LegendofZelda.SpriteFactories
{
    public class BackgroundSpriteFactory : ISpriteFactory
    {

        private Texture2D spriteSheet;
        private readonly static BackgroundSpriteFactory instance = new();

        public static BackgroundSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private BackgroundSpriteFactory()
        {
        }

        public void loadContent(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("allbackgrounds");
        }

        public ISprite CreateBackground(string name)
        {
            var split= name.Split('d');
            return new Background(spriteSheet, int.Parse(split[1]));

        }

    }
}
