using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Link;
using Interfaces;
using Sprites;
using Sprint0;

namespace SpriteFactories
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
            spriteSheet = content.Load<Texture2D>("BlockSprites");
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
             
                default:
                    return null;
            }
        }

    }
}
