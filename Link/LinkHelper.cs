using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;
using GameStates;
using System.Windows.Forms;

namespace LegendofZelda
{
    public class LinkHelper
    {         
        //Fields
        public ISprite currentLinkSprite;
        public ILinkState currentState;
        public Vector2 currentPosition;
        

        public bool isDamaged;
        public int isDamagedCounter;

        private string side;

        
        public LinkHelper(Vector2 currentPosition, bool isDamaged, int isDamagedCounter)
        {
            this.currentPosition = currentPosition;

            currentState = new LinkFacingUpState();
            currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(currentPosition, isDamaged);
            

            this.isDamagedCounter = isDamagedCounter;
            this.isDamaged = isDamaged;
        }
        

        public void TakeKnockBack()
        {            
            // This can be refactored using a decorator pattern
            if (this.isDamaged)
            {   
                this.isDamagedCounter++;

                // Take knockback for the first x frames
                if(this.isDamagedCounter < 10)
                {
                    int knockbackDistance = 5;
                    switch(this.side)
                    {
                    case "top":
                        this.currentPosition.Y += knockbackDistance;
                        if(this.currentPosition.Y < 238) { 
                            this.currentPosition.Y = 300;
                            this.isDamagedCounter = 10;
                        }
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 24, 32);
                        break;
                    case "bottom":
                        this.currentPosition.Y -= knockbackDistance;
                        if(this.currentPosition.Y > 542 - currentLinkSprite.DestinationRectangle.Height) { 
                            this.currentPosition.Y = 542 - currentLinkSprite.DestinationRectangle.Height;
                            this.isDamagedCounter = 10;
                        }
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 24, 32);
                        break;
                    case "left":
                        this.currentPosition.X += knockbackDistance;
                        if(this.currentPosition.X < 100) { 
                            this.currentPosition.X = 100;
                            this.isDamagedCounter = 10;
                        }
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 24, 32);                        
                        break;
                    case "right":
                        this.currentPosition.X -= knockbackDistance;
                        if(this.currentPosition.X > 700 - currentLinkSprite.DestinationRectangle.Width) { 
                            this.currentPosition.X = 700 - currentLinkSprite.DestinationRectangle.Width;
                            this.isDamagedCounter = 10;
                        }
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 24, 32);
                        break;
                    default:
                    break;
                    }
                    this.UpdatePosition();
                }
                
                if (this.isDamagedCounter > 120)
                {
                    this.isDamagedCounter = 0;
                    this.isDamaged = false;
                    this.UpdatePosition();
                    this.currentState.Redraw();
                }
            }
        }               
    }
}