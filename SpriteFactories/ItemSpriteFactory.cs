using LegendofZelda.Interfaces;
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

                        return new PurpleGemstone(spriteSheet, (int)location.X, (int)location.Y);

                    case "OrangeGemstone":

                        return new OrangeGemstone(spriteSheet, (int)location.X, (int)location.Y);

                    case "PurpleTriangle":

                        return new PurpleTriangle(spriteSheet, (int)location.X, (int)location.Y);

                    case "OrangeTriangle":

                        return new OrangeTriangle(spriteSheet, (int)location.X, (int)location.Y);

                    case "OrangeMap":

                        return new OrangeMap(spriteSheet, (int)location.X, (int)location.Y);

                    case "SmallRedHeart":

                        return new SmallRedHeart(spriteSheet, (int)location.X, (int)location.Y);

                    case "SmallBlueHeart":

                        return new SmallBlueHeart(spriteSheet, (int)location.X, (int)location.Y);

                    case "BigHeart":

                        return new BigHeart(spriteSheet, (int)location.X, (int)location.Y);

                    case "Fairy":

                        return new Fairy(spriteSheet, (int)location.X, (int)location.Y); return new BackgroundBlock(spriteSheet);

                    case "Compass":

                        return new Compass(spriteSheet, (int)location.X, (int)location.Y);


                    case "Clock":

                        return new Clock(spriteSheet, (int)location.X, (int)location.Y);

                    case "Bow":

                        return new Bow(spriteSheet, (int)location.X, (int)location.Y);


                    case "Boomerang":

                        return new Boomerang(spriteSheet, (int)location.X, (int)location.Y);

                    case "Bomb":

                        return new Bomb(spriteSheet, (int)location.X, (int)location.Y);

                    default:

                        return null;
                }
            }

        }
}
