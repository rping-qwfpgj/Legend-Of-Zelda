using LegendofZelda;
using Interfaces;
using LegendofZelda.SpriteFactories;

namespace States
{
    public class Player2WalkingDownState : ILinkState
    {
        public Player2WalkingDownState()
        {

        }

        //Invalid states from the current state
        public void Attack() { }
        public void ThrowProjectile() { }
        public void MoveDown() { }

        public void MoveUp()
        {
            Link.Instance2.UpdatePosition();
            Link.Instance2.currentState = new Player2WalkingUpState();
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance2.currentPosition, Link.Instance2.isDamaged);
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
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(Link.Instance2.currentPosition,
            Link.Instance2.isDamaged);
            Link.Instance2.currentState = new Player2FacingDownState();
        }
        public void Redraw()
        {
            Link.Instance2.UpdatePosition();
            Link.Instance2.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance2.currentPosition,
                    Link.Instance2.isDamaged);
        }
        public string Direction()
        {
            return "bottom";
        }
    }
}
