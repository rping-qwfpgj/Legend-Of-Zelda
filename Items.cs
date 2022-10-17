﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Interfaces;

namespace Sprint0
{

    public class PurpleGemstone : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 8;
        private int height = 16;

        public PurpleGemstone(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(72, 16, width, height);
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

    public class OrangeGemstone : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 8;
        private int height = 16;

        public OrangeGemstone(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(72, 0, width, height);
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

    public class PurpleTriangle : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 10;
        private int height = 10;

        public PurpleTriangle(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(275,19, width, height);
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

    public class OrangeTriangle : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 10;
        private int height = 10;

        public OrangeTriangle(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(275, 3, width, height);
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


    public class OrangeMap : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 9;
        private int height = 16;

        public OrangeMap(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(88, 0, width, height);
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

    public class SmallRedHeart : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 7;
        private int height = 8;

        public SmallRedHeart(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(0, 0, width, height);
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

    public class SmallBlueHeart : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 7;
        private int height = 8;

        public SmallBlueHeart(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(0, 8, width, height);
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

    public class BigHeart : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 13;
        private int height = 13;

        public BigHeart(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(25, 1, width, height);
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

    public class Fairy : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 8;
        private int height = 16;

        public Fairy(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(40, 0, width, height);
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

    public class Compass : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 11;
        private int height = 12;

        public Compass(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(258, 1, width, height);
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

    public class Clock : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 11;
        private int height = 16;

        public Clock(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(58, 0, width, height);
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

    public class Bow : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 8;
        private int height = 16;

        public Bow(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(144, 0, width, height);
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

    public class Boomerang : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 5;
        private int height = 8;

        public Boomerang(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(129, 3, width, height);
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

    public class Bomb : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        private int yPos;
        private int width = 8;
        private int height = 16;

        public Bomb(Texture2D itemTexture, int x, int y)
        {
            this.texture = itemTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(136, 0, width, height);
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


    //public class Item : ISprite
    //{
    //    private Texture2D texture;

    //    public int currentItemNum;
    //    private Rectangle sourceRectangle;
    //    private Rectangle destinationRectangle;

    //    public Item(Texture2D itemTexture)
    //    {
    //        this.texture = itemTexture;
    //        this.currentItemNum = 0;
    //        this.sourceRectangle = new Rectangle(72, 16, 10, 16);
    //        this.destinationRectangle = new Rectangle(250, 250, 40, 64);

    //    }

    //    public void Reset()
    //    {
    //        this.currentItemNum = 0;
    //    }

    //    public void Update()
    //    {
    //        switch (currentItemNum)
    //        {
    //            case 0: //purple gemstone
    //                sourceRectangle = new Rectangle(72, 16, 8, 16);
    //                destinationRectangle = new Rectangle(250, 250, 32, 64);
    //                break;
    //            case 1: //orange gemstone
    //                sourceRectangle = new Rectangle(72, 0, 8, 16);
    //                destinationRectangle = new Rectangle(250, 250, 32, 64);
    //                break;
    //            case 2: //purple triangle
    //                sourceRectangle = new Rectangle(275, 19, 10, 10);
    //                destinationRectangle = new Rectangle(250, 250, 40, 40);
    //                break;
    //            case 3: //orange triangle
    //                sourceRectangle = new Rectangle(275, 3, 10, 10);
    //                destinationRectangle = new Rectangle(250, 250, 40, 40);
    //                break;
    //            case 4: //orange paper thing
    //                sourceRectangle = new Rectangle(88, 0, 9, 16);
    //                destinationRectangle = new Rectangle(250, 250, 36, 66);
    //                break;
    //            case 5: //small red heart
    //                sourceRectangle = new Rectangle(0, 0, 7, 8);
    //                destinationRectangle = new Rectangle(250, 250, 28, 32);
    //                break;
    //            case 6: //small blue heart
    //                sourceRectangle = new Rectangle(0, 8, 7, 8);
    //                destinationRectangle = new Rectangle(250, 250, 28, 32);
    //                break;
    //            case 7: //big heart
    //                sourceRectangle = new Rectangle(25, 1, 13, 13);
    //                destinationRectangle = new Rectangle(250, 250, 52, 52);
    //                break;
    //            case 8: //fairy
    //                sourceRectangle = new Rectangle(40, 0, 8, 16);
    //                destinationRectangle = new Rectangle(250, 250, 32, 64);
    //                break;
    //            case 9: //compass
    //                sourceRectangle = new Rectangle(258, 1, 11, 12);
    //                destinationRectangle = new Rectangle(250, 250, 44, 48);
    //                break;
    //            case 10: //clock
    //                sourceRectangle = new Rectangle(58, 0, 11, 16);
    //                destinationRectangle = new Rectangle(250, 250, 44, 64);
    //                break;
    //            case 11: //bow
    //                sourceRectangle = new Rectangle(144, 0, 8, 16);
    //                destinationRectangle = new Rectangle(250, 250, 32, 64);
    //                break;
    //            case 12: //boomerang
    //                sourceRectangle = new Rectangle(129, 3, 5, 8);
    //                destinationRectangle = new Rectangle(250, 250, 20, 32);
    //                break;
    //            case 13: //bomb
    //                sourceRectangle = new Rectangle(136, 0, 8, 16);
    //                destinationRectangle = new Rectangle(250, 250, 32, 64);
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