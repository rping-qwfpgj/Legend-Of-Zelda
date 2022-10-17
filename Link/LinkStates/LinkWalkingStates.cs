using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Sprites;
using Sprint0;
using SpriteFactories;
using States;
using Interfaces;

namespace States
{
    public class LinkWalkingUpState : ILinkState
    {
        private Link link;

        public LinkWalkingUpState(Link link)
        {
            this.link = link;
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
            link.currentState = new LinkWalkingDownState(link);
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(link.currentPosition, link.isDamaged);

        }

        public void MoveLeft()
        {
            link.currentState = new LinkWalkingLeftState(link);
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(link.currentPosition, link.isDamaged);
        }

        public void MoveRight()
        {
            link.currentState = new LinkWalkingRightState(link);
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(link.currentPosition, link.isDamaged);

        }
        public void NoInput()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(link.currentPosition,
            link.isDamaged);
            link.currentState = new LinkFacingUpState(link);
        }

        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(link.currentPosition,
                    link.isDamaged);
        }
        public string Direction()
        {
            return "top";
        }

    }

    public class LinkWalkingDownState : ILinkState
    {
        private Link link;

        public LinkWalkingDownState(Link link)
        {
            this.link = link;
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
            link.currentState = new LinkWalkingDownState(link);
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(link.currentPosition, link.isDamaged);
        }

        public void MoveDown()
        {           
            // Already moving down
        }

        public void MoveLeft()
        {
            link.currentState = new LinkWalkingLeftState(link);
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(link.currentPosition, link.isDamaged);
        }

        public void MoveRight()
        {
            link.currentState = new LinkWalkingRightState(link);
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(link.currentPosition, link.isDamaged);

        }
        public void NoInput()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(link.currentPosition,
            link.isDamaged);
            link.currentState = new LinkFacingDownState(link);
        }

        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(link.currentPosition,
                    link.isDamaged);
        }
        public string Direction()
        {
            return "bottom";
        }
    }

    public class LinkWalkingLeftState : ILinkState
    {
        private Link link;

        public LinkWalkingLeftState(Link link)
        {
            this.link = link;
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
            link.currentState = new LinkWalkingUpState(link);
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(link.currentPosition, link.isDamaged);
        }

        public void MoveDown()
        {
            link.currentState = new LinkWalkingDownState(link);
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(link.currentPosition, link.isDamaged);

        }

        public void MoveLeft()
        {
            // Already moving left
        }

        public void MoveRight()
        {
            link.currentState = new LinkWalkingRightState(link);
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(link.currentPosition, link.isDamaged);

        }
        public void NoInput()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(link.currentPosition,
            link.isDamaged);
            link.currentState = new LinkFacingLeftState(link);
        }

        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(link.currentPosition,
                    link.isDamaged);
        }
        public string Direction()
        {
            return "left";
        }

    }

    public class LinkWalkingRightState : ILinkState
    {
        private Link link;


        public LinkWalkingRightState(Link link)
        {
            this.link = link;
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
            link.UpdatePosition();
            link.currentState = new LinkWalkingUpState(link);
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(link.currentPosition, link.isDamaged);
        }

        public void MoveDown()
        {
            link.UpdatePosition();
            link.currentState = new LinkWalkingDownState(link);
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(link.currentPosition, link.isDamaged);
        }

        public void MoveLeft()
        {
            link.UpdatePosition();
            link.currentState = new LinkWalkingLeftState(link);
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(link.currentPosition, link.isDamaged);
        }

        public void MoveRight()
        {
            // Already going right
        }

        public void NoInput()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(link.currentPosition,
            link.isDamaged);
            link.currentState = new LinkFacingRightState(link);
        }


        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(link.currentPosition,
                    link.isDamaged);
        }

        public string Direction()
        {
            return "right";
        }

    }

}
