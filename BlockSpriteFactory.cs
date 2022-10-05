//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using sprites;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sprint0
//{
//    public class BlockSpriteFactory : ISpriteFactory
//    {
//        private Texture2D spriteSheet;
//        private static BlockSpriteFactory instance = new BlockSpriteFactory();
//        private Rectangle sourceRectangle;
//        private Rectangle destinationRectangle = new Rectangle(50, 50, 64, 64);

//        public static BlockSpriteFactory Instance
//        {
//            get
//            {
//                return instance;
//            }
//        }
//        private BlockSpriteFactory()
//        {
//        }

//        public void loadContent(ContentManager content)
//        {
//            spriteSheet = content.Load<Texture2D>("blocks");

//        }

//        public void Initialize(Texture2D spriteSheet)
//        {
//            this.spriteSheet = spriteSheet;
//        }

//        public ISprite CreateBlock(int blockNum)
//        {
//            switch (blockNum)
//            {
//                case 0:
//                    sourceRectangle = new Rectangle(3, 11, 16, 16);
//                    return new BlockZero(spriteSheet, sourceRectangle, destinationRectangle);
//                    break;
//                default:
//            }

//        }
//    }
//}


//switch (currentBlockNum)
//{
//    case 0:
//        sourceRectangle = new Rectangle(3, 11, 16, 16);
//        break;
//    case 1:
//        sourceRectangle = new Rectangle(20, 11, 16, 16);
//        break;
//    case 2:
//        sourceRectangle = new Rectangle(37, 11, 16, 16);
//        break;
//    case 3:
//        sourceRectangle = new Rectangle(54, 11, 16, 16);
//        break;
//    case 4:
//        sourceRectangle = new Rectangle(3, 28, 16, 16);
//        break;
//    case 5:
//        sourceRectangle = new Rectangle(20, 28, 16, 16);
//        break;
//    case 6:
//        sourceRectangle = new Rectangle(37, 28, 16, 16);
//        break;
//    case 7:
//        sourceRectangle = new Rectangle(54, 28, 16, 16);
//        break;
//    case 8:
//        sourceRectangle = new Rectangle(3, 45, 16, 16);
//        break;
//    case 9:
//        sourceRectangle = new Rectangle(20, 45, 16, 16);
//        break;
//    default:
//        break;
//}