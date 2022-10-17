using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;


namespace LegendofZelda.SpriteFactories
{
   
        public class ItemSpriteFactory : ISpriteFactory
        {

            private Texture2D spriteSheet;
            private readonly static ItemSpriteFactory instance = new();

            public static ItemSpriteFactory Instance
            {
                get
                {
                    return instance;
                }
            }
            private ItemSpriteFactory()
            {
            }

            public void loadContent(ContentManager content)
            {
                spriteSheet = content.Load<Texture2D>("itemsandweapons");
            }

            public ISprite CreateItem(Vector2 location, string name)
            {

                switch (name)
                {
                    case "PurpleGemstone":

                        return new StatueOneBlock(spriteSheet, (int)location.X, (int)location.Y);

                    case "OrangeGemstone":

                        return new StatueTwoBlock(spriteSheet, (int)location.X, (int)location.Y);

                    case "PurpleTriangle":

                        return new PolkaDotBlock(spriteSheet, (int)location.X, (int)location.Y);

                    case "OrangeTriangle":

                        return new DepthBlock(spriteSheet, (int)location.X, (int)location.Y);

                    case "OrangeMap":

                        return new BackgroundBlock(spriteSheet);

                    case "SmallRedHeart":

                        return new BackgroundBlock(spriteSheet);

                    case "SmallBlueHeart":

                        return new BackgroundBlock(spriteSheet);

                    case "BigHeart":

                        return new BackgroundBlock(spriteSheet);

                case "Fairy":

                    return new BackgroundBlock(spriteSheet);

                case "Compass":

                    return new BackgroundBlock(spriteSheet);


                case "CLock":

                    return new BackgroundBlock(spriteSheet);

                case "Bow":

                    return new BackgroundBlock(spriteSheet);


                case "Boomerang":

                    return new BackgroundBlock(spriteSheet);

                case "Bomb":

                    return new BackgroundBlock(spriteSheet);

                default:

                        return null;
                }
            }

        }
}
