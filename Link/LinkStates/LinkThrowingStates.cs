using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using LegendofZelda.SpriteFactories;

namespace States
{
    public class LinkThrowingRightState : ILinkState
    {
        

        public LinkThrowingRightState()
        {
            
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
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingRightState();
        }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingRight(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "right";
        }
    }

    public class LinkThrowingLeftState : ILinkState
    {
        

     
        public LinkThrowingLeftState()
        {
            
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
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(Link.Instance.currentPosition,
            Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingLeftState();
        }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingLeft(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "left";
        }

    }
    public class LinkThrowingUpState : ILinkState
    {

        


        public LinkThrowingUpState()
        {
            
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
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(Link.Instance.currentPosition,
            Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingUpState();
        }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingUp(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "top";
        }

    }
    public class LinkThrowingDownState : ILinkState
    {

        

 
        public LinkThrowingDownState()
        {
            
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
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingDownState();
        }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingDown(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "bottom";
        }
    }
}
