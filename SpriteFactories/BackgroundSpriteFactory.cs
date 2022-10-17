using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Link;
using Interfaces;
using Sprites;
using Sprint0;

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

            switch (name)
            {
                case "Background0":

                    return new Background0(spriteSheet);

                case "Background1":

                    return new Background1(spriteSheet);

                case "Background2":

                    return new Background2(spriteSheet);

                case "Background3":

                    return new Background3(spriteSheet);

                case "Background4":

                    return new Background4(spriteSheet);

                case "Background5":

                    return new Background5(spriteSheet);

                case "Background6":

                    return new Background6(spriteSheet);

                case "Background7":

                    return new Background7(spriteSheet);

                case "Background8":

                    return new Background8(spriteSheet);

                case "Background9":

                    return new Background9(spriteSheet);

                case "Background10":

                    return new Background10(spriteSheet);

                case "Background11":

                    return new Background11(spriteSheet);

                case "Background12":

                    return new Background12(spriteSheet);

                case "Background13":

                    return new Background13(spriteSheet);

                case "Background14":

                    return new Background14(spriteSheet);

                case "Background15":

                    return new Background15(spriteSheet);

                case "Background16":

                    return new Background16(spriteSheet);

                case "Background17":

                    return new Background17(spriteSheet);

                case "Background18":

                    return new Background18(spriteSheet);

                default:

                    return null;
            }
        }

    }
}
