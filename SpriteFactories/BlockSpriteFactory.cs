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

            int inventoryHeight= 150;
            switch (name)
            {
                case "StatueOneBlock":

                    return new StatueOneBlock(spriteSheet, (int)location.X, (int)location.Y+inventoryHeight);

                case "StatueTwoBlock":

                    return new StatueTwoBlock(spriteSheet, (int)location.X, (int)location.Y+inventoryHeight);

                case "PolkaDotBlock":

                    return new PolkaDotBlock(spriteSheet, (int)location.X, (int)location.Y+inventoryHeight);

                case "DepthBlock":

                    return new DepthBlock(spriteSheet, (int)location.X, (int)location.Y+inventoryHeight);


                case "PlainDarkBlueBlock":

                    return new PlainDarkBlueBlock(spriteSheet, (int)location.X, (int)location.Y+inventoryHeight);

                case "PlainBlackBlock":

                    return new PlainBlackBlock(spriteSheet, (int)location.X, (int)location.Y+inventoryHeight);

                case "PlainTurqoiseBlock":

                    return new PlainTurqoiseBlock(spriteSheet, (int)location.X, (int)location.Y+inventoryHeight);

                case "StairsBlock":

                    return new StairsBlock(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                case "VerticalBoundingBlock":

                    return new VerticalBoundingBlock(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                case "HorizontalBoundingBlock":

                    return new HorizontalBoundingBlock(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                case "BoundingBlock":

                    return new BoundingBlock(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                case "VerticalHalfBoundingBlock":

                    return new VerticalHalfBoundingBlock(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                case "HorizontalHalfBoundingBlock":

                    return new HorizontalHalfBoundingBlock(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                case "DepthPushableBlock":

                    return new DepthPushableBlock(spriteSheet, (int)location.X,(int)location.Y + inventoryHeight);

                default:

                    return null;
            }
        }

    }
}
