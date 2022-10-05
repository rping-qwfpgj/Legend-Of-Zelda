using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpriteFactories;
using Interfaces;

namespace States
{
    public class LinkThrowingRightState : ILinkState
    {
        private Link link;

        public LinkThrowingRightState(Link link)
        {
            this.link = link;
        }

        public void Attack()
        {
            // Can't attack while throwing
        }

        public void ThrowProjectile()
        {
            // Can't throw twice
        }

        public void MoveUp()
        {
            // Can't move while throwing
        }

        public void MoveDown()
        {            
        }

        public void MoveLeft()
        {            
        }

        public void MoveRight()
        {            
        }
        public void NoInput()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(link.currentPosition,
                link.isDamaged);
            link.currentState = new LinkFacingRightState(link);
        }

        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingRight(link.currentPosition,
                    link.isDamaged);
        }
    }

    public class LinkThrowingLeftState : ILinkState
    {
        private Link link;

     
        public LinkThrowingLeftState(Link link)
        {
            this.link = link;
        }

        public void Attack()
        {
            // Can't attack while throwing
        }

        public void ThrowProjectile()
        {
            // Can't throw twice
        }

        public void MoveUp()
        {
            // Can't move while throwing
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }
        public void NoInput()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(link.currentPosition,
            link.isDamaged);
            link.currentState = new LinkFacingLeftState(link);
        }

        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingLeft(link.currentPosition,
                    link.isDamaged);
        }

    }
    public class LinkThrowingUpState : ILinkState
    {

        private Link link;


        public LinkThrowingUpState(Link link)
        {
            this.link = link;
        }
        public void Attack()
        {
            // Can't attack while throwing
        }

        public void ThrowProjectile()
        {
            // Can't throw twice
        }

        public void MoveUp()
        {
            // Can't move while throwing
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }
        public void NoInput()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(link.currentPosition,
            link.isDamaged);
            link.currentState = new LinkFacingUpState(link);
        }

        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingUp(link.currentPosition,
                    link.isDamaged);
        }

    }
    public class LinkThrowingDownState : ILinkState
    {

        private Link link;

 
        public LinkThrowingDownState(Link link)
        {
            this.link = link;
        }

        public void Attack()
        {
            // Can't attack while throwing
        }

        public void ThrowProjectile()
        {
            // Can't throw twice
        }

        public void MoveUp()
        {
            // Can't move while throwing
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }
        public void NoInput()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(link.currentPosition,
                link.isDamaged);
            link.currentState = new LinkFacingDownState(link);
        }

        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingDown(link.currentPosition,
                    link.isDamaged);
        }

    }
}
