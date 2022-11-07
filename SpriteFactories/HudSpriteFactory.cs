using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Link;
using Sprites;
using Sprint0;
using LegendofZelda.Interfaces;

namespace LegendofZelda.SpriteFactories
{
    public class HudSpriteFactory : ISpriteFactory
    {

        private Texture2D spriteSheet;
        private readonly static HudSpriteFactory instance = new();
        private GraphicsDeviceManager graphics;

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

        public void loadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            spriteSheet = content.Load<Texture2D>("gamestates");
            this.graphics = graphics;
        }

        public ISprite CreateBackground(string name)
        {

            switch (name)
            {
                case "Hud":
                    return new HudSprite(spriteSheet);

                case "Background1":

                    return new Background1(spriteSheet);                

                default:

                    return null;
            }
        }

    }
}
