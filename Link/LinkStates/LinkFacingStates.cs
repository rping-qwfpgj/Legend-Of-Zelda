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
        
 

        public LinkFacingUpState()
        {
            
        }
        public void Attack()
        {                        
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkAttackingUp(Link.Instance.currentPosition, 
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkAttackUpState();       
        }
        public void ThrowProjectile()
        {
            
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingUp(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkThrowingUpState();
            var projectileSprite = ProjectileSpriteFactory.Instance.CreateThrowableUp(Link.Instance.currentPosition, Link.Instance.throwable, Link.Instance);
            Link.Instance.currentProjectiles.Add(projectileSprite);
            Link.Instance.game.currentRoom.AddObject(projectileSprite);
            
        }

        public void MoveUp()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkWalkingUpState();
        }

        public void MoveDown()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkWalkingDownState();
        }

        public void MoveLeft()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkWalkingLeftState();

        }

        public void MoveRight()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkWalkingRightState();

        }
        public void NoInput()
        {
            // Don't need to do anything when already in facing state
        }
        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "top";
        }
    }


    public class LinkFacingDownState : ILinkState
    {
        

        public LinkFacingDownState()
        {
            
        }
        public void Attack()
        {
                Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkAttackingDown(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
                Link.Instance.currentState = new LinkAttackDownState();            
        }

        public void ThrowProjectile()
        {            
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingDown(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkThrowingDownState();
            var projectileSprite = ProjectileSpriteFactory.Instance.CreateThrowableDown(Link.Instance.currentPosition, Link.Instance.throwable, Link.Instance);
            Link.Instance.currentProjectiles.Add(projectileSprite);
            Link.Instance.game.currentRoom.AddObject(projectileSprite);
        }

        public void MoveUp()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkWalkingUpState();
        }

        public void MoveDown()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkWalkingDownState();
        }

        public void MoveLeft()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkWalkingLeftState();

        }

        public void MoveRight()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkWalkingRightState();

        }
        public void NoInput()
        {
            // Don't need to do anything when already in facing state
        }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "bottom";
        }
    }

}

public class LinkFacingRightState : ILinkState
{
    

    public LinkFacingRightState()
    {
        
    }

    public void Attack()
    {            
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkAttackingRight(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
        Link.Instance.currentState = new LinkAttackRightState();
        
    }

    public void ThrowProjectile()
    {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingRight(Link.Instance.currentPosition,
               Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkThrowingRightState();
        var projectileSprite = ProjectileSpriteFactory.Instance.CreateThrowableRight(Link.Instance.currentPosition, Link.Instance.throwable, Link.Instance);
        Link.Instance.currentProjectiles.Add(projectileSprite);
        Link.Instance.game.currentRoom.AddObject(projectileSprite);

    }

    public void MoveUp()
    {
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
        Link.Instance.currentState = new LinkWalkingUpState();
    }

    public void MoveDown()
    {
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
        Link.Instance.currentState = new LinkWalkingDownState();
    }

    public void MoveLeft()
    {
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
        Link.Instance.currentState = new LinkWalkingLeftState();

    }

    public void MoveRight()
    {
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
        Link.Instance.currentState = new LinkWalkingRightState();

    }
    public void NoInput()
    {
        // Don't need to do anything when already in facing state
    }

    public void Redraw()
    {
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
    }
    public string Direction()
    {
        return "right";
    }
}




public class LinkFacingLeftState : ILinkState
{
    

    public LinkFacingLeftState()
    {
        
    }
    public void Attack()
    {
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkAttackingLeft(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
        Link.Instance.currentState = new LinkAttackLeftState();
        
    }

    public void ThrowProjectile()
    {
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingLeft(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
        Link.Instance.currentState = new LinkThrowingLeftState();
        var projectileSprite = ProjectileSpriteFactory.Instance.CreateThrowableLeft(Link.Instance.currentPosition, Link.Instance.throwable, Link.Instance);
        Link.Instance.currentProjectiles.Add(projectileSprite);
        Link.Instance.game.currentRoom.AddObject(projectileSprite);
    }
    public void MoveUp()
    {
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance.currentPosition,
        Link.Instance.isDamaged);
        Link.Instance.currentState = new LinkWalkingUpState();
    }
    public void MoveDown()
    {
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance.currentPosition,
        Link.Instance.isDamaged);
        Link.Instance.currentState = new LinkWalkingDownState();
    }

    public void MoveLeft()
    {
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(Link.Instance.currentPosition,
        Link.Instance.isDamaged);
        Link.Instance.currentState = new LinkWalkingLeftState();
    }

    public void MoveRight()
    {
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
        Link.Instance.currentState = new LinkWalkingRightState();

    }
    public void NoInput()
    {
        // Don't need to do anything when already in facing state
    }

    public void Redraw()
    {
        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
    }
    public string Direction()
    {
      return "left";
    }
}




