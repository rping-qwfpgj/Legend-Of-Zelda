using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Sprint0;
using Sprites;
using Interfaces;
using SpriteFactories;


namespace States
{
    public class LinkAttackRightState : ILinkState
    {
        private Link link;

        public LinkAttackRightState(Link link)
        {
            this.link = link;
        }

        public void Attack()
        {
            // already attacking
        }

        public void ThrowProjectile()
        {
            // cant throw while attacking
        }

        public void MoveUp()
        {
            // can't move while attacking
        }

        public void MoveDown()
        {
            // can't move while attacking
        }

        public void MoveLeft()
        {
            // can't move while attacking
        }

        public void MoveRight()
        {
            // can't move while attacking
        }

        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(link.currentPosition,
                    link.isDamaged);
        }
        public void NoInput() 
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(link.currentPosition, 
                link.isDamaged);
            link.currentState = new LinkFacingRightState(link);
        }
        public string Direction()
        {
            return "right";
        }

    }


    public class LinkAttackLeftState : ILinkState
    {
        private Link link;

        public LinkAttackLeftState(Link link)
        {
            this.link = link;
        }
        public void Attack(){ }

        public void ThrowProjectile() { }

        public void MoveUp() { }

        public void MoveDown() { }

        public void MoveLeft() { }

        public void MoveRight() { }

        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(link.currentPosition,
                    link.isDamaged);
        }
        
        public void NoInput() {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(link.currentPosition,
                link.isDamaged);
            link.currentState = new LinkFacingLeftState(link);
        }
        public string Direction()
        {
            return "left";
        }
    }

    public class LinkAttackUpState : ILinkState
    {
        private Link link;


        public LinkAttackUpState(Link link)
        {
            this.link = link;
        }

        public void Attack() { }

        public void ThrowProjectile() { }

        public void MoveUp() { }

        public void MoveDown() { }

        public void MoveLeft() { }

        public void MoveRight() { }

        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(link.currentPosition,
                    link.isDamaged);
        }
        public void NoInput() {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(link.currentPosition,
                    link.isDamaged);
            link.currentState = new LinkFacingUpState(link);
        }
        public string Direction()
        {
            return "top";
        }
    }



    public class LinkAttackDownState : ILinkState
    {
        private Link link;


        public LinkAttackDownState(Link link)
        {
            this.link = link;
        }

        public void Attack() { }

        public void ThrowProjectile() { }

        public void MoveUp() { }

        public void MoveDown() { }

        public void MoveLeft() { }

        public void MoveRight() { }

        public void Redraw()
        {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(link.currentPosition,
                    link.isDamaged);
        }
        public void NoInput() {
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(link.currentPosition,
            link.isDamaged);
            link.currentState = new LinkFacingDownState(link);
        }
        public string Direction()
        {
            return "bottom";
        }

    }
}
