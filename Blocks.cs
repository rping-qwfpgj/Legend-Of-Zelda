using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprites;
using Interfaces;

//
namespace Sprint0
{
    public class PlainTurqoiseBlock : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 16;
        private int height = 16;

        public PlainTurqoiseBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(3, 11, width, height);
            this.destinationRectangle = new Rectangle(xPos, yPos, width * 4, height * 4);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class DepthBlock : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 16;
        private int height = 16;

        public DepthBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(20, 11, width, height);
            this.destinationRectangle = new Rectangle(xPos, yPos, width * 4, height * 4);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class StatueOneBlock : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 16;
        private int height = 16;

        public StatueOneBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(37, 11, width, height);
            this.destinationRectangle = new Rectangle(xPos, yPos, width * 4, height * 4);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class StatueTwoBlock : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 16;
        private int height = 16;

        public StatueTwoBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(54, 11, width, height);
            this.destinationRectangle = new Rectangle(xPos, yPos, width * 4, height * 4);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class PlainBlackBlock : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 16;
        private int height = 16;

        public PlainBlackBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(3, 28, width, height);
            this.destinationRectangle = new Rectangle(xPos, yPos, width * 4, height * 4);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class PolkaDotBlock : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 16;
        private int height = 16;

        public PolkaDotBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(20, 28, width, height);
            this.destinationRectangle = new Rectangle(xPos, yPos, width * 4, height * 4);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class PlainDarkBlueBlock : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 16;
        private int height = 16;

        public PlainDarkBlueBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(37, 28, width, height);
            this.destinationRectangle = new Rectangle(xPos, yPos, width * 4, height * 4);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class StairsBlock : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 16;
        private int height = 16;

        public StairsBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(54, 28, width, height);
            this.destinationRectangle = new Rectangle(xPos, yPos, width * 4, height * 4);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class BricksBlock : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 16;
        private int height = 16;

        public BricksBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(3, 45, width, height);
            this.destinationRectangle = new Rectangle(xPos, yPos, width * 4, height * 4);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class StripedBlock : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 16;
        private int height = 16;

        public StripedBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(20, 45, width, height);
            this.destinationRectangle = new Rectangle(xPos, yPos, width * 4, height * 4);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    //public class Block : ISprite
    //{
    //    private Texture2D texture;

    //    public int currentBlockNum;
    //    private Rectangle sourceRectangle;
    //    private Rectangle destinationRectangle;

    //    public Block(Texture2D blockTexture)
    //    {
    //        this.texture = blockTexture;
    //        this.currentBlockNum = 0;
    //        this.sourceRectangle = new Rectangle(3, 11, 16, 16);
    //        this.destinationRectangle = new Rectangle(50, 50, 64, 64);

    //    }

    //    public void Reset()
    //    {
    //        this.currentBlockNum = 0;
    //    }

    //    public void Update()
    //    {
    //        switch (currentBlockNum)
    //        {
    //            case 0:
    //                sourceRectangle = new Rectangle(3, 11, 16, 16);
    //                break;
    //            case 1:
    //                sourceRectangle = new Rectangle(20, 11, 16, 16);
    //                break;
    //            case 2:
    //                sourceRectangle = new Rectangle(37, 11, 16, 16);
    //                break;
    //            case 3:
    //                sourceRectangle = new Rectangle(54, 11, 16, 16);
    //                break;
    //            case 4:
    //                sourceRectangle = new Rectangle(3, 28, 16, 16);
    //                break;
    //            case 5:
    //                sourceRectangle = new Rectangle(20, 28, 16, 16);
    //                break;
    //            case 6:
    //                sourceRectangle = new Rectangle(37, 28, 16, 16);
    //                break;
    //            case 7:
    //                sourceRectangle = new Rectangle(54, 28, 16, 16);
    //                break;
    //            case 8:
    //                sourceRectangle = new Rectangle(3, 45, 16, 16);
    //                break;
    //            case 9:
    //                sourceRectangle = new Rectangle(20, 45, 16, 16);
    //                break;
    //            default:
    //                break;
    //        }
    //    }

    //    public void Draw(SpriteBatch _spriteBatch)
    //    {
    //        _spriteBatch.Begin();
    //        _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
    //        _spriteBatch.End();
    //    }

    //    public Vector2 getPosition()
    //    {
    //        return new Vector2(50, 50);
    //    }
    //}
}
