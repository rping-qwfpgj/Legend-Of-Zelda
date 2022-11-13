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

        public void Attack()
        {
            // Can't attack while moving
        }

        public void ThrowProjectile()
        {
            // Can't throw while moving
        }

        public void MoveUp()
        {
            // Already walking
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

        public void Attack()
        {
            // Can't attack while moving
        }

        public void ThrowProjectile()
        {
            // Can't throw while moving
        }

        public void MoveUp()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingUpState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance.currentPosition, Link.Instance.isDamaged);
        }

        public void MoveDown()
        {           
            // Already moving down
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

        public void Attack()
        {
            // Can't attack while moving
        }

        public void ThrowProjectile()
        {
            // Can't throw while moving
        }

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
            // Already moving left
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

        public void Attack()
        {
            // Can't attack
        }

        public void ThrowProjectile()
        {
            // Can't throw
        }

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

        public void MoveRight()
        {
            // Already going right
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
