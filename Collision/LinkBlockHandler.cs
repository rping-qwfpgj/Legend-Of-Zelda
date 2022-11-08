using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Sprites;
using LegendofZelda;
using Commands;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Diagnostics;
using Interfaces;
using States;
using System.Windows.Forms;

namespace Collision
{
    public static class LinkBlockHandler
	{		
		
		public static void handleCollision(Link link, IBlock block, string side, Rectangle collisionRect)
		{ 

			switch (side)
			{
				case "top":
                    if(block is IPushableBlock)
                    {
                        IPushableBlock bloc = block as IPushableBlock;
                        bloc.Move("bottom");

                    } else { 
                        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkIdleWalkingSprite(link.currentPosition, link.isDamaged, side);
                        link.currentState = new LinkIdleWalkingUpState(link);
                        link.currentPosition.Y += collisionRect.Height;
                        link.currentLinkSprite.DestinationRectangle = new((int)link.currentPosition.X, (int)link.currentPosition.Y, 38, 40);
                    }
                    break;
				case "bottom":
                    if(block is IPushableBlock)
                    {
                        IPushableBlock bloc = block as IPushableBlock;
                        bloc.Move("top");
                    } else { 
                        link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkIdleWalkingSprite(link.currentPosition, link.isDamaged, side);
                        link.currentState = new LinkIdleWalkingDownState(link);
                        link.currentPosition.Y -= collisionRect.Height;
                        link.currentLinkSprite.DestinationRectangle = new((int)link.currentPosition.X, (int)link.currentPosition.Y, 38, 40);
                    }
                    break;
				case "left":
                    link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkIdleWalkingSprite(link.currentPosition, link.isDamaged, side);
                    link.currentState = new LinkIdleWalkingLeftState(link);
                    link.currentPosition.X += collisionRect.Width;
                    link.currentLinkSprite.DestinationRectangle = new((int)link.currentPosition.X, (int)link.currentPosition.Y, 38, 40);
                    break;
                case "right":
                    link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkIdleWalkingSprite(link.currentPosition, link.isDamaged, side);
					link.currentState = new LinkIdleWalkingRightState(link);
                    link.currentPosition.X -= collisionRect.Width;
					link.currentLinkSprite.DestinationRectangle = new((int)link.currentPosition.X, (int)link.currentPosition.Y, 38, 40);
                    
                    break;
                default:
                    break;


			}

        }

	}
}
