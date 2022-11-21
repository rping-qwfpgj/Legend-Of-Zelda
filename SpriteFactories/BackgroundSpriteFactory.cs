using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static LegendofZelda.Link;
using Sprites;
using LegendofZelda;
using LegendofZelda.Interfaces;
using LegendofZelda.Backgrounds;

namespace LegendofZelda.SpriteFactories
{
    public class BackgroundSpriteFactory : ISpriteFactory
    {

        private Texture2D spriteSheet;
        private Texture2D gameOverBackground;
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
            gameOverBackground = content.Load<Texture2D>("game_over");
        }

        public ISprite CreateBackground(string name)
        {
            var split= name.Split('d');
            return new Background(spriteSheet, int.Parse(split[1]));

        }

        public ISprite GameOverScreen()
        {
            return new GameOverScreen(gameOverBackground);
        }

        public ISprite WinGameScreen()
        {
            return new WinGameScreen(gameOverBackground);
        }

    }
}
