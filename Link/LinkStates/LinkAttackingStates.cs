using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Sprint0;
using Sprites;
using Interfaces;
using LegendofZelda.SpriteFactories;

namespace States
{
    public class LinkAttackRightState : ILinkState
    {
       
        public LinkAttackRightState()
        {
            
        }

        //Invalid states from the current state
        public void Attack() { }
        public void ThrowProjectile() { }
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public void NoInput() 
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(Link.Instance.currentPosition, 
                Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingRightState();
        }
        public string Direction()
        {
            return "right";
        }

    }


    public class LinkAttackLeftState : ILinkState
    {
        public LinkAttackLeftState()
        {
            
        }

        //Invalid states from the current state
        public void Attack() { }
        public void ThrowProjectile() { }
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        
        public void NoInput() {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingLeftState();
        }
        public string Direction()
        {
            return "left";
        }
    }

    public class LinkAttackUpState : ILinkState
    {
        public LinkAttackUpState()
        {
            
        }

        //Invalid states from the current state
        public void Attack() { }
        public void ThrowProjectile() { }
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public void NoInput() {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingUpState();
        }
        public string Direction()
        {
            return "top";
        }
    }



    public class LinkAttackDownState : ILinkState
    {

        public LinkAttackDownState()
        {
            
        }

        //Invalid states from the current state
        public void Attack() { }
        public void ThrowProjectile() { }
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public void NoInput() {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(Link.Instance.currentPosition,
            Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingDownState();
        }
        public string Direction()
        {
            return "bottom";
        }

    }
}
