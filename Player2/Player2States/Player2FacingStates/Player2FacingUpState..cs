using LegendofZelda;
using Interfaces;
using LegendofZelda.SpriteFactories;

namespace States
{
    public class Player2FacingUpState : ILinkState
    {
        public Player2FacingUpState()
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
            Link.Instance2.UpdatePosition();
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance2.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance2.currentState = new Player2WalkingUpState();
        }
        public void MoveDown()
        {
            Link.Instance2.UpdatePosition();
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance2.currentPosition,
                    Link.Instance2.isDamaged);
            Link.Instance2.currentState = new Player2WalkingDownState();
        }
        public void MoveLeft()
        {
            Link.Instance2.UpdatePosition();
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(Link.Instance2.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance2.currentState = new Player2WalkingLeftState();
        }
        public void MoveRight()
        {
            Link.Instance2.UpdatePosition();
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(Link.Instance2.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance2.currentState = new Player2WalkingRightState();
        }
        public void NoInput()
        {
            // Don't need to do anything when already in facing state
        }
        public void Redraw()
        {
            Link.Instance2.UpdatePosition();
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(Link.Instance2.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "top";
        }
    }
}

