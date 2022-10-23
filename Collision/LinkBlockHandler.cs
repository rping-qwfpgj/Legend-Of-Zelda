using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Sprites;
using LegendofZelda;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Diagnostics;
using Interfaces;

namespace Collision
{
    public static class LinkBlockHandler
	{		
		
		public static void handleCollision(Link link, IBlock block, string side, Rectangle collisionRect)
		{ 
			//link.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkIdleWalkingSprite(link.currentPosition, link.isDamaged, side);
			//Debug.WriteLine("Link-Block detected on side: " + side + " collision width = " + collisionRect.Width + " collision height: " + collisionRect.Height);
			switch (side)
			{
				case "top":
					link.currentPosition.Y += collisionRect.Height;
					if(link.currentLinkSprite is IAttackingSprite)
					{
						IAttackingSprite attackingSprite = (IAttackingSprite)link.currentLinkSprite;
						attackingSprite.DestinationRectangle = new ((int)link.currentPosition.X, (int)link.currentPosition.Y, 40, 44);
					} else
					{
						INonAttackingSprite nonAttackingSprite = (INonAttackingSprite)link.currentLinkSprite;
						nonAttackingSprite.DestinationRectangle = new ((int)link.currentPosition.X, (int)link.currentPosition.Y, 40, 44);
					}
					break;
				case "bottom":
					link.currentPosition.Y -= collisionRect.Height;
					if(link.currentLinkSprite is IAttackingSprite)
					{
						IAttackingSprite attackingSprite = (IAttackingSprite)link.currentLinkSprite;
						attackingSprite.DestinationRectangle = new ((int)link.currentPosition.X, (int)link.currentPosition.Y, 40, 44);
					} else
					{
						INonAttackingSprite nonAttackingSprite = (INonAttackingSprite)link.currentLinkSprite;
						nonAttackingSprite.DestinationRectangle = new ((int)link.currentPosition.X, (int)link.currentPosition.Y, 40, 44);
					}
                    break;
				case "left":
					link.currentPosition.X += collisionRect.Width;
					if(link.currentLinkSprite is IAttackingSprite)
					{
						IAttackingSprite attackingSprite = (IAttackingSprite)link.currentLinkSprite;
						attackingSprite.DestinationRectangle = new ((int)link.currentPosition.X, (int)link.currentPosition.Y, 40, 44);
					} else
					{
						INonAttackingSprite nonAttackingSprite = (INonAttackingSprite)link.currentLinkSprite;
						nonAttackingSprite.DestinationRectangle = new ((int)link.currentPosition.X, (int)link.currentPosition.Y, 40, 44);
					}
                    break;
                case "right":
					
					link.currentPosition.X -= collisionRect.Width;
					if(link.currentLinkSprite is IAttackingSprite)
					{
						IAttackingSprite attackingSprite = (IAttackingSprite)link.currentLinkSprite;
						attackingSprite.DestinationRectangle = new ((int)link.currentPosition.X, (int)link.currentPosition.Y, 40, 44);
					} else
					{
						INonAttackingSprite nonAttackingSprite = (INonAttackingSprite)link.currentLinkSprite;
						nonAttackingSprite.DestinationRectangle = new ((int)link.currentPosition.X, (int)link.currentPosition.Y, 40, 44);
					}
					

                    break;
                default:
                    break;


			}

        }

	}
}
