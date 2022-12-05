using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static LegendofZelda.Link;
using Sprites;
using LegendofZelda;
using LegendofZelda.Interfaces;
using LegendofZelda.Blocks;

namespace LegendofZelda.SpriteFactories
{
    public class BlockSpriteFactory : ISpriteFactory
    {

        private Texture2D spriteSheet;
        private Texture2D doorSpriteSheet;
        private Texture2D whiteDoorSpriteSheet;
        private Texture2D fireTexture;
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
            fireTexture = content.Load<Texture2D>("LinkandProjectileSprites");
            doorSpriteSheet = content.Load<Texture2D>("doors");
            whiteDoorSpriteSheet = content.Load<Texture2D>("WhiteDoors");
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

                case "DepthBlock":

                    return new DepthBlock(spriteSheet, (int)location.X, (int)location.Y+inventoryHeight);

                case "PlainDarkBlueBlock":

                    return new PlainDarkBlueBlock(spriteSheet, (int)location.X, (int)location.Y+inventoryHeight);

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

                case "LockedDoorBlockTop":

                    return new LockedDoorBlock(doorSpriteSheet,350,22 + inventoryHeight, 0);
                
                case "LockedDoorBlockLeft":

                    return new LockedDoorBlock(doorSpriteSheet, 33, 195 + inventoryHeight, 1);

                case "LockedDoorBlockRight":

                    return new LockedDoorBlock(doorSpriteSheet, 702, 200 + inventoryHeight, 2);

                case "LockedDoorBlockBottom":

                    return new LockedDoorBlock(doorSpriteSheet, 350, 395 + inventoryHeight, 3);

                case "PuzzleDoorBlockTop":

                    return new PuzzleDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + inventoryHeight, 0);
                
                case "PuzzleDoorBlockLeft":

                    return new PuzzleDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + inventoryHeight, 1);

                case "PuzzleDoorBlockRight":

                    return new PuzzleDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + inventoryHeight, 2);

                case "PuzzleDoorBlockBottom":

                    return new PuzzleDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + inventoryHeight, 3);

                case "OpenDoorBlockTop":

                    return new OpenDoorBlock(doorSpriteSheet, 350, 15 + inventoryHeight, 0);
                
                case "OpenDoorBlockLeft":

                    return new OpenDoorBlock(doorSpriteSheet,32, 199+ inventoryHeight, 1);
                
                case "OpenDoorBlockRight":

                    return new OpenDoorBlock(doorSpriteSheet, 700, 200 + inventoryHeight, 2);
                
                case "OpenDoorBlockBottom":

                    return new OpenDoorBlock(doorSpriteSheet, 350, 400 + inventoryHeight, 3);

                case "BombableDoorBlockTop":

                    return new BombableDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y+inventoryHeight, 0);
                
                case "BombableDoorBlockLeft":

                    return new BombableDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + inventoryHeight, 1);
                
                case "BombableDoorBlockRight":

                    return new BombableDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + inventoryHeight, 2);
                
                case "BombableDoorBlockBottom":

                    return new BombableDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + inventoryHeight, 3);

                case "LockedWhiteDoorBlockTop":

                    return new LockedDoorBlock(whiteDoorSpriteSheet, 350, 22 + inventoryHeight, 0);
                
                case "LockedWhiteDoorBlockLeft":

                    return new LockedDoorBlock(whiteDoorSpriteSheet, 33, 195 + inventoryHeight, 1);

                case "LockedWhiteDoorBlockRight":

                    return new LockedDoorBlock(whiteDoorSpriteSheet, 702, 200 + inventoryHeight, 2);

                case "LockedWhiteDoorBlockBottom":

                    return new LockedDoorBlock(whiteDoorSpriteSheet, 350, 395 + inventoryHeight, 3);
                
                case "Fire":

                    return new Fire(fireTexture, location.X, location.Y + inventoryHeight);

                case "StairsBlock":

                    return new StairsBlock(doorSpriteSheet, (int)location.X, (int)location.Y + inventoryHeight, 2);

                default:

                    return null;
            }
        }

    }
}
