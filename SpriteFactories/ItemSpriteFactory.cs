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
            private Texture2D fireTexture;
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
            fireTexture = content.Load<Texture2D>("LinkandProjectileSprites");
            }

            public ISprite CreateItem(Vector2 location, string name)
            {

            int inventoryHeight = 150;
                switch (name)

                {
                    case "PurpleGemstone":

                        return new PurpleGemstone(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                    case "OrangeGemstone":

                        return new OrangeGemstone(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                    case "Triforce":

                        return new Triforce(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                    case "OrangeMap":

                        return new OrangeMap(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                    case "SmallRedHeart":

                        return new SmallRedHeart(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                    case "SmallBlueHeart":

                        return new SmallBlueHeart(spriteSheet, (int)location.X, (int)location.Y+inventoryHeight);

                    case "BigHeart":

                        return new BigHeart(spriteSheet, (int)location.X, (int)location.Y+inventoryHeight);

                    case "Fairy":

                        return new Fairy(spriteSheet, (int)location.X, (int)location.Y+inventoryHeight); 

                    case "Compass":

                        return new Compass(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                    case "Clock":

                        return new Clock(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                    case "Bow":

                        return new Bow(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                    case "Boomerang":

                        return new Boomerang(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                    case "Bomb":

                        return new Bomb(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                    case "Fire":

                        return new Fire(fireTexture, location.X, location.Y + inventoryHeight);

                    case "Key":

                        return new Key(spriteSheet, (int)location.X, (int)location.Y + inventoryHeight);

                default:

                        return null;
                }
            }

        }
}
