using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Link;
using Sprites;
using Sprint0;
using LegendofZelda.Interfaces;

namespace LegendofZelda.SpriteFactories
{
    public class BlockSpriteFactory : ISpriteFactory
    {

        private Texture2D spriteSheet;
        private readonly static BlockSpriteFactory instance = new();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private BlockSpriteFactory()
        {
        }

        public void loadContent(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("blocks");
        }

        public ISprite CreateBlock(Vector2 location, string name)
        {

            switch (name)
            {
                case "StatueOneBlock":

                    return new StatueOneBlock(spriteSheet, (int)location.X, (int)location.Y);

                case "StatueTwoBlock":

                    return new StatueTwoBlock(spriteSheet, (int)location.X, (int)location.Y);

                case "PolkaDotBlock":

                    return new PolkaDotBlock(spriteSheet, (int)location.X, (int)location.Y);

                case "DepthBlock":

                    return new DepthBlock(spriteSheet, (int)location.X, (int)location.Y);


                case "PlainDarkBlueBlock":

                    return new PlainDarkBlueBlock(spriteSheet, (int)location.X, (int)location.Y);

                case "PlainBlackBlock":

                    return new PlainBlackBlock(spriteSheet, (int)location.X, (int)location.Y);

                case "PlainTurqoiseBlock":

                    return new PlainTurqoiseBlock(spriteSheet, (int)location.X, (int)location.Y);

                case "StairsBlock":

                    return new StairsBlock(spriteSheet, (int)location.X, (int)location.Y);

                default:

                    return null;
            }
        }

    }
}
