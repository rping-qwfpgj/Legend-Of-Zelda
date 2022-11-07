using Microsoft.Xna.Framework;
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
    public class PlainTurqoiseBlock : INonBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class DepthBlock : INonBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class StatueOneBlock : INonBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class StatueTwoBlock : INonBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class PlainBlackBlock : INonBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class PolkaDotBlock : INonBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class PlainDarkBlueBlock : INonBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class StairsBlock : INonBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class BricksBlock : INonBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

    public class StripedBlock : INonBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }


    public class BackgroundBlock : INonBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }


    public class BoundingBlock : IBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White*0.00f);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

    }

    public class VerticalBoundingBlock : IBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White*0.00f);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

    }

    

    public class HorizontalBoundingBlock : IBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White * 0.00f);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

    }

    public class VerticalHalfBoundingBlock : IBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White * 0.00f);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

    }

    public class HorizontalHalfBoundingBlock : IBoundingBlock
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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White * 0.00f);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

    }

    public class DepthPushableBlock: IPushableBlock
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

        public DepthPushableBlock(Texture2D blockTexture, int x, int y)
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

        public void Move(string side)
        {
            switch(side)
            {
                case "top":
                    this.yPos += 2;
                    this.destinationRectangle = new(this.xPos, this.yPos, destinationWidth, destinationHeight);
                    break;
                case "bottom":
                    this.yPos -= 2;
                    this.destinationRectangle = new(this.xPos, this.yPos, destinationWidth, destinationHeight);
                    break;
                case "left":
                    this.xPos += 2;
                    this.destinationRectangle = new(this.xPos, this.yPos, destinationWidth, destinationHeight);
                    break;
                case "right":
                    this.xPos -= 2;
                    this.destinationRectangle = new(this.xPos, this.yPos, destinationWidth, destinationHeight);
                    break;
                default:
                    break;
            }
        }
    }
    public class LockedDoorBlock : IBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private static int sourceWidth = 32;
        private static int sourceHeight = 22;
        private Rectangle[] sourceRectangles = {new Rectangle(103, 21, 32, 22), new Rectangle(115, 44, 22, 31), new Rectangle(103, 77, 22, 32), new Rectangle(103, 110, 32, 22)};
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int direction;
        private int xPos;
        private int yPos;
        private int destinationWidth = sourceWidth * 3;
        private int destinationHeight = sourceHeight * 3;

        public LockedDoorBlock(Texture2D doorTexture, int x, int y, int direction)
        {
            this.texture = doorTexture;
            this.xPos = x;
            this.yPos = y;
            this.direction = direction;
            // for source rectangles 0 = top, 1 = left, 2 = right, 3 = bottom
            this.sourceRectangle = sourceRectangles[direction];

            if(direction == 0 || direction == 3)
              this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
            else
              this.destinationRectangle = new Rectangle(xPos, yPos, destinationHeight, destinationWidth);
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
        public String getSide()
        {
            switch (this.direction) { 
                case 0:
                    return "top";
                case 1:
                    return "left";
                case 2: 
                    return "right";
                case 3:
                     return "bottom";
                default:
                     return "INVALID DIRECTION NUM PASSED";
            
            }
        }

    }

        public class PuzzleDoorBlock : IBlock
        {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private static int sourceWidth = 30;
        private static int sourceHeight = 18;
        private Rectangle[] sourceRectangles = {new Rectangle(136, 25, 32, 18), new Rectangle(150, 44, 18, 32), new Rectangle(136, 77, 18, 32), new Rectangle(136, 110, 32, 18)};
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int direction;
        private int xPos;
        private int yPos;
        private int destinationWidth = sourceWidth * 3;
        private int destinationHeight = sourceHeight * 3;

     public PuzzleDoorBlock(Texture2D doorTexture, int x, int y, int direction)
     {
            this.texture = doorTexture;
            this.xPos = x;
            this.yPos = y;
            this.direction = direction;
            // for source rectangles 0 = top, 1 = left, 2 = right, 3 = bottom
            this.sourceRectangle = sourceRectangles[direction];

            if(direction == 0 || direction == 3)
              this.destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
            else
              this.destinationRectangle = new Rectangle(xPos, yPos, destinationHeight, destinationWidth);
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
        public String getSide()
        {
            switch (this.direction) { 
                case 0:
                    return "top";
                case 1:
                    return "left";
                case 2: 
                    return "right";
                case 3:
                     return "bottom";
                default:
                     return "INVALID DIRECTION NUM PASSED";
            }
        }
    }


}

  
