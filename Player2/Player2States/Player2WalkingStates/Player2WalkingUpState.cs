using LegendofZelda;
using Interfaces;
using LegendofZelda.SpriteFactories;

namespace States
{
    public class Player2WalkingUpState : ILinkState
    {
        public Player2WalkingUpState()
        {
        }

        //Invalid states from the current state
        public void Attack() { }
        public void ThrowProjectile() { }
        public void MoveUp() { }

        public void MoveDown()
        {
            Link.Instance2.UpdatePosition();
            Link.Instance2.currentState = new Player2WalkingDownState();
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance2.currentPosition, Link.Instance2.isDamaged);
        }
        public void MoveLeft()
        {
            Link.Instance2.UpdatePosition();
            Link.Instance2.currentState = new Player2WalkingLeftState();
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(Link.Instance2.currentPosition, Link.Instance2.isDamaged);
        }
        public void MoveRight()
        {
            Link.Instance2.UpdatePosition();
            Link.Instance2.currentState = new Player2WalkingRightState();
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(Link.Instance2.currentPosition, Link.Instance2.isDamaged);
        }
        public void NoInput()
        {
            Link.Instance2.UpdatePosition();
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(Link.Instance2.currentPosition,
            Link.Instance2.isDamaged);
            Link.Instance2.currentState = new Player2FacingUpState();
        }
        public void Redraw()
        {
            Link.Instance2.UpdatePosition();
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance2.currentPosition,
                    Link.Instance2.isDamaged);
        }
        public string Direction()
        {
            return "top";
        }
    }
}
