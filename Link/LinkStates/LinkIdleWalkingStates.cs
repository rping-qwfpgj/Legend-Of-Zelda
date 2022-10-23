﻿using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Sprites;
using Sprint0;
using States;
using Interfaces;
using LegendofZelda.SpriteFactories;

namespace States
{
    public class LinkIdleWalkingUpState : ILinkState
    {
        private Link link;

        public LinkIdleWalkingUpState(Link link)
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
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(link.currentPosition,
                    link.isDamaged);
        }
        public string Direction()
        {
            return "top";
        }

    }

    public class LinkIdleWalkingDownState : ILinkState
    {
        private Link link;

        public LinkIdleWalkingDownState(Link link)
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
            
        }

        public void MoveDown()
        {           
            // Already moving down
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
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(link.currentPosition,
                    link.isDamaged);
        }
        public string Direction()
        {
            return "bottom";
        }
    }

    public class LinIdlekWalkingLeftState : ILinkState
    {
        private Link link;

        public LinIdlekWalkingLeftState(Link link)
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
            
        }

        public void MoveDown()
        {
            

        }

        public void MoveLeft()
        {
            // Already moving left
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
            link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(link.currentPosition,
                    link.isDamaged);
        }
        public string Direction()
        {
            return "left";
        }

    }

    public class LinkIdleWalkingRightState : ILinkState
    {
        private Link link;


        public LinkIdleWalkingRightState(Link link)
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
            
        }

        public void MoveDown()
        {
           
        }

        public void MoveLeft()
        {
            
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