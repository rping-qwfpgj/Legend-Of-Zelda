using System;
using System.Linq.Expressions;
using Sprint0;
using Interfaces;
using States;
using LegendofZelda.SpriteFactories;
using LegendofZelda;

namespace States
{
    public class LinkFacingUpState : ILinkState
    {
        private Link link;
 

        public LinkFacingUpState(Link link)
        {
            this.link = link;
        }
        public void Attack()
        {                        
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkAttackingUp(link.currentPosition, 
                    link.isDamaged);
            link.currentState = new LinkAttackUpState(link);       
        }
        public void ThrowProjectile()
        {
            
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingUp(link.currentPosition,
                    link.isDamaged);
            link.currentState = new LinkThrowingUpState(link);
            var projectileSprite = ProjectileSpriteFactory.Instance.CreateThrowableUp(link.currentPosition, link.throwable, link);
            link.currentProjectiles.Add(projectileSprite);
            link.game.currentRoom.AddObject(projectileSprite);
            
        }

        public void MoveUp()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(link.currentPosition,
                    link.isDamaged);
            link.currentState = new LinkWalkingUpState(link);
        }

        public void MoveDown()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(link.currentPosition,
                    link.isDamaged);
            link.currentState = new LinkWalkingDownState(link);
        }

        public void MoveLeft()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(link.currentPosition,
                    link.isDamaged);
            link.currentState = new LinkWalkingLeftState(link);

        }

        public void MoveRight()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(link.currentPosition,
                    link.isDamaged);
            link.currentState = new LinkWalkingRightState(link);

        }
        public void NoInput()
        {
            // Don't need to do anything when already in facing state
        }
        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(link.currentPosition,
                    link.isDamaged);
        }
        public string Direction()
        {
            return "top";
        }
    }


    public class LinkFacingDownState : ILinkState
    {
        private Link link;

        public LinkFacingDownState(Link link)
        {
            this.link = link;
        }
        public void Attack()
        {
                link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkAttackingDown(link.currentPosition,
                    link.isDamaged);
                link.currentState = new LinkAttackDownState(link);            
        }

        public void ThrowProjectile()
        {            
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingDown(link.currentPosition,
                    link.isDamaged);
            link.currentState = new LinkThrowingDownState(link);
            var projectileSprite = ProjectileSpriteFactory.Instance.CreateThrowableDown(link.currentPosition, link.throwable, link);
            link.currentProjectiles.Add(projectileSprite);
            link.game.currentRoom.AddObject(projectileSprite);
        }

        public void MoveUp()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(link.currentPosition,
                    link.isDamaged);
            link.currentState = new LinkWalkingUpState(link);
        }

        public void MoveDown()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(link.currentPosition,
                    link.isDamaged);
            link.currentState = new LinkWalkingDownState(link);
        }

        public void MoveLeft()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(link.currentPosition,
                    link.isDamaged);
            link.currentState = new LinkWalkingLeftState(link);

        }

        public void MoveRight()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(link.currentPosition,
                    link.isDamaged);
            link.currentState = new LinkWalkingRightState(link);

        }
        public void NoInput()
        {
            // Don't need to do anything when already in facing state
        }

        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(link.currentPosition,
                    link.isDamaged);
        }
        public string Direction()
        {
            return "bottom";
        }
    }

}

public class LinkFacingRightState : ILinkState
{
    private Link link;

    public LinkFacingRightState(Link link)
    {
        this.link = link;
    }

    public void Attack()
    {            
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkAttackingRight(link.currentPosition,
                link.isDamaged);
        link.currentState = new LinkAttackRightState(link);
        
    }

    public void ThrowProjectile()
    {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingRight(link.currentPosition,
               link.isDamaged);
            link.currentState = new LinkThrowingRightState(link);
        var projectileSprite = ProjectileSpriteFactory.Instance.CreateThrowableRight(link.currentPosition, link.throwable, link);
        link.currentProjectiles.Add(projectileSprite);
        link.game.currentRoom.AddObject(projectileSprite);

    }

    public void MoveUp()
    {
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(link.currentPosition,
                link.isDamaged);
        link.currentState = new LinkWalkingUpState(link);
    }

    public void MoveDown()
    {
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(link.currentPosition,
                link.isDamaged);
        link.currentState = new LinkWalkingDownState(link);
    }

    public void MoveLeft()
    {
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(link.currentPosition,
                link.isDamaged);
        link.currentState = new LinkWalkingLeftState(link);

    }

    public void MoveRight()
    {
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(link.currentPosition,
                link.isDamaged);
        link.currentState = new LinkWalkingRightState(link);

    }
    public void NoInput()
    {
        // Don't need to do anything when already in facing state
    }

    public void Redraw()
    {
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(link.currentPosition,
                link.isDamaged);
    }
    public string Direction()
    {
        return "right";
    }
}




public class LinkFacingLeftState : ILinkState
{
    private Link link;

    public LinkFacingLeftState(Link link)
    {
        this.link = link;
    }
    public void Attack()
    {
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkAttackingLeft(link.currentPosition,
                link.isDamaged);
        link.currentState = new LinkAttackLeftState(link);
        
    }

    public void ThrowProjectile()
    {
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingLeft(link.currentPosition,
                link.isDamaged);
        link.currentState = new LinkThrowingLeftState(link);
        var projectileSprite = ProjectileSpriteFactory.Instance.CreateThrowableLeft(link.currentPosition, link.throwable, link);
        link.currentProjectiles.Add(projectileSprite);
        link.game.currentRoom.AddObject(projectileSprite);
    }
    public void MoveUp()
    {
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(link.currentPosition,
        link.isDamaged);
        link.currentState = new LinkWalkingUpState(link);
    }
    public void MoveDown()
    {
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(link.currentPosition,
        link.isDamaged);
        link.currentState = new LinkWalkingDownState(link);
    }

    public void MoveLeft()
    {
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(link.currentPosition,
        link.isDamaged);
        link.currentState = new LinkWalkingLeftState(link);
    }

    public void MoveRight()
    {
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(link.currentPosition,
                link.isDamaged);
        link.currentState = new LinkWalkingRightState(link);

    }
    public void NoInput()
    {
        // Don't need to do anything when already in facing state
    }

    public void Redraw()
    {
        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(link.currentPosition,
                link.isDamaged);
    }
    public string Direction()
    {
      return "left";
    }
}




