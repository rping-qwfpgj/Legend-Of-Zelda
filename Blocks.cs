﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprites;
using LegendofZelda.Interfaces;

namespace Sprint0
{
    public class PlainTurqoiseBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private readonly int sourceWidth = 16;
        private readonly int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public PlainTurqoiseBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(3, 11, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class DepthBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public DepthBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(20, 11, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class StatueOneBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public StatueOneBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(37, 11, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class StatueTwoBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public StatueTwoBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(54, 11, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class PlainBlackBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public PlainBlackBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(3, 28, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class PolkaDotBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public PolkaDotBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(20, 28, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class PlainDarkBlueBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 15;
        private int sourceHeight = 15;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public PlainDarkBlueBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(38, 29, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class StairsBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public StairsBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(54, 28, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class BricksBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public BricksBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(3, 45, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class StripedBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public StripedBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(20, 45, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }


    public class BackgroundBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public BackgroundBlock(Texture2D blockTexture)
        {
            this.texture = blockTexture;
            this.sourceRectangle = new Rectangle(20, 45, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(0, 0, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }


    public class BoundingBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public BoundingBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(3, 28, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

    }

    public class VerticalBoundingBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 392;

        public VerticalBoundingBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(3, 28, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

    }

    

    public class HorizontalBoundingBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 700;
        private int destinationHeight = 44;

        public HorizontalBoundingBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(3, 28, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

    }

    public class VerticalHalfBoundingBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 170;

        public VerticalHalfBoundingBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(3, 28, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

    }

    public class HorizontalHalfBoundingBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 315;
        private int destinationHeight = 44;

        public HorizontalHalfBoundingBlock(Texture2D blockTexture, int x, int y)
        {
            this.texture = blockTexture;
            this.xPos = x;
            this.yPos = y;
            this.sourceRectangle = new Rectangle(3, 28, sourceWidth, sourceHeight);
            this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
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

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

    }

}

  
