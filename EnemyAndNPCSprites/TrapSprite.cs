using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;
using Sprint0;
using System.Diagnostics;
using System.ComponentModel.Design.Serialization;

namespace Sprites
{
    public class TrapSprite : IEnemy
    {

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }

        // Determine what the trap should do depending on if link is within its vicinity
        private enum TrapStates {Sitting, MoveUp, MoveDown, MoveRight, MoveLeft};
        private TrapStates trapState;

        private Rectangle initialLocation;
        private Rectangle lastLocation;
        // Location on screen
        Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        public TrapSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            this.trapState = TrapStates.Sitting;
            this.initialLocation = this.destinationRectangle;
            this.lastLocation = this.lastLocation;
        }

        public void Update()
        {

            // Compare to link's position if its just sitting
            if(this.trapState == TrapStates.Sitting)
            {
                Vector2 linkLocation = Link.Instance.currentPosition;
               // Debug.WriteLine(linkLocation);
                //Debug.WriteLine("Trap " + this.xPosition);
                // Change to a new state by comparing link's position to the trap
                this.swapState(linkLocation);

                // If no longer sitting, change the final location
                if(this.trapState != TrapStates.Sitting)
                {
                    this.lastLocation = new Rectangle((int)linkLocation.X, (int)linkLocation.Y, 12, 16);
                }
            } else
            {
                // Change location based on the current state and last location
                TrapStates currState = this.trapState;

                if(currState == TrapStates.MoveUp)
                {
                    this.yPosition -= 1;
                    
                    
                } else if (currState == TrapStates.MoveDown)
                {
                    this.yPosition += 1;

                    
                } else if (currState == TrapStates.MoveLeft)
                {
                    this.xPosition -= 1;

                    
                } else if(currState == TrapStates.MoveRight)
                {
                    this.xPosition += 1;

                    
                }

                
            }



        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle sourceRectangle = new Rectangle(164, 59, 16, 16);
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();

            
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void TurnAround(string side)
        {

        }

        public void TakeDamage(string side)
        {

        }

        public ISprite DropItem()
        {
            return null;
        }

        private void swapState(Vector2 linkLocation)
        {
           int xRange = (int)Math.Abs(linkLocation.X - this.xPosition);
           int yRange = (int)Math.Abs(linkLocation.Y - this.YPosition);
           if(xRange <= 10 && linkLocation.Y < this.YPosition)
            {
                // hi
                this.trapState = TrapStates.MoveUp;
            } else if(xRange <= 10 && linkLocation.Y > this.YPosition)
            {
                this.trapState = TrapStates.MoveDown;
            } else if(linkLocation.X < this.xPosition && yRange <= 10)
            {
                this.trapState = TrapStates.MoveLeft;
            }  else if(linkLocation.X > this.xPosition && yRange <= 10)
            {
                this.trapState = TrapStates.MoveRight;
            } else
            {
                this.trapState = TrapStates.Sitting;
            }   
        }

        public void swapToOpposite()
        {
            // If at the last location, turn around
            if(this.yPosition <= lastLocation.Y)
            {
                this.trapState = TrapStates.MoveDown;
            } else if(this.yPosition >= lastLocation.Y)
            {
                this.trapState = TrapStates.MoveUp;
            } else if(this.xPosition >= lastLocation.X)
            {
                this.trapState = TrapStates.MoveLeft;
            } else if(this.xPosition <= lastLocation.X)
            {
                this.trapState = TrapStates.MoveRight;
            }

            // If back at the initial location, need to go back to sitting

        }
        public void Die()
        {

        }
    }
}

