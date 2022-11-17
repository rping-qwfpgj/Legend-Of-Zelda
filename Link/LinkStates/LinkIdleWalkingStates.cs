using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Sprites;
using Sprint0;
using States;
using Interfaces;
using LegendofZelda.SpriteFactories;

namespace States
{
    public class LinkIdleWalkingUpState : ILinkState
    {
        

        public LinkIdleWalkingUpState()
        {
            
        }

        //Invalid states from the current state
        public void Attack() { }
        public void ThrowProjectile() { }
        public void MoveUp() { }
        
        public void MoveDown()
        {

            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingDownState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance.currentPosition, Link.Instance.isDamaged);
        }

        public void MoveLeft()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingLeftState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(Link.Instance.currentPosition, Link.Instance.isDamaged);
        }

        public void MoveRight()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingRightState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(Link.Instance.currentPosition, Link.Instance.isDamaged);

        }
        public void NoInput()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(Link.Instance.currentPosition,
            Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingUpState();
        }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "top";
        }

    }

    public class LinkIdleWalkingDownState : ILinkState
    {
        

        public LinkIdleWalkingDownState()
        {
            
        }

        //Invalid states from the current state
        public void Attack() { }
        public void ThrowProjectile() { }
        public void MoveDown() { }

        public void MoveUp()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingUpState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance.currentPosition, Link.Instance.isDamaged);
        }

        public void MoveLeft()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingLeftState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(Link.Instance.currentPosition, Link.Instance.isDamaged);
        }

        public void MoveRight()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingRightState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(Link.Instance.currentPosition, Link.Instance.isDamaged);

        }
        public void NoInput()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(Link.Instance.currentPosition,
            Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingDownState();
        }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "bottom";
        }
    }

    public class LinkIdleWalkingLeftState : ILinkState
    {
        

        public LinkIdleWalkingLeftState()
        {
            
        }

        //Invalid states from the current state
        public void Attack() { }
        public void ThrowProjectile() { }
        public void MoveLeft() { }
      
        public void MoveUp()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingUpState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance.currentPosition, Link.Instance.isDamaged);
        }

        public void MoveDown()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingDownState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance.currentPosition, Link.Instance.isDamaged);

        }

        public void MoveRight()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingRightState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(Link.Instance.currentPosition, Link.Instance.isDamaged);

        }
        public void NoInput()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(Link.Instance.currentPosition,
            Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingLeftState();
        }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "left";
        }

    }

    public class LinkIdleWalkingRightState : ILinkState
    {
       
        public LinkIdleWalkingRightState()
        {
            
        }

        //Invalid states from the current state
        public void Attack() { }
        public void ThrowProjectile() { }
        public void MoveRight() { }

        public void MoveUp()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingUpState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance.currentPosition, Link.Instance.isDamaged);
        }

        public void MoveDown()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingDownState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance.currentPosition, Link.Instance.isDamaged);
        }

        public void MoveLeft()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingLeftState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(Link.Instance.currentPosition, Link.Instance.isDamaged);
        }

        public void NoInput()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(Link.Instance.currentPosition,
            Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingRightState();
        }


        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }

        public string Direction()
        {
            return "right";
        }

    }

}
