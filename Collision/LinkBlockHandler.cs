using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Sprites;
using LegendofZelda;
using LegendofZelda.Blocks;
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
		
		public static void handleCollision( IBlock block, Room currRoom, string side, Rectangle collisionRect)
		{ 

			switch (side)
			{
				case "top":
                    if(block is IPushableBlock)
                    {
                        IPushableBlock bloc = block as IPushableBlock;
                        bloc.Move("bottom");
                    } else if ((block is LockedDoorBlock || block is PuzzleDoorBlock) && Link.Instance.inventory.getItemCount("key") > 0){
                        currRoom.RemoveObject(block);
                        Link.Instance.inventory.removeItem("key");
                    }else if(!(block is OpenDoorBlock)) { 
                        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkIdleWalkingSprite(Link.Instance.currentPosition, Link.Instance.isDamaged, side);
                        Link.Instance.currentState = new LinkIdleWalkingUpState();
                        Link.Instance.currentPosition.Y += collisionRect.Height;
                        Link.Instance.currentLinkSprite.DestinationRectangle = new((int)Link.Instance.currentPosition.X, (int)Link.Instance.currentPosition.Y, 38, 40);
                    }
                    break;
				case "bottom":
                    if(block is IPushableBlock)
                    {
                        IPushableBlock bloc = block as IPushableBlock;
                        bloc.Move("top");
                    } else if ((block is LockedDoorBlock || block is PuzzleDoorBlock) && Link.Instance.inventory.getItemCount("key") > 0){
                        currRoom.RemoveObject(block);
                        Link.Instance.inventory.removeItem("key");
                    } else if(!(block is OpenDoorBlock)) { 
                        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkIdleWalkingSprite(Link.Instance.currentPosition, Link.Instance.isDamaged, side);
                        Link.Instance.currentState = new LinkIdleWalkingDownState();
                        Link.Instance.currentPosition.Y -= collisionRect.Height;
                        Link.Instance.currentLinkSprite.DestinationRectangle = new((int)Link.Instance.currentPosition.X, (int)Link.Instance.currentPosition.Y, 38, 40);
                    }
                    break;
				case "left":
                     if ((block is LockedDoorBlock || block is PuzzleDoorBlock) && Link.Instance.inventory.getItemCount("key") > 0){
                        currRoom.RemoveObject(block);
                        Link.Instance.inventory.removeItem("key");
                    } else if(!(block is OpenDoorBlock)) { 
                        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkIdleWalkingSprite(Link.Instance.currentPosition, Link.Instance.isDamaged, side);
                        Link.Instance.currentState = new LinkIdleWalkingLeftState();
                        Link.Instance.currentPosition.X += collisionRect.Width;
                        Link.Instance.currentLinkSprite.DestinationRectangle = new((int)Link.Instance.currentPosition.X, (int)Link.Instance.currentPosition.Y, 38, 40);
                    }
                    break;
                case "right":
                    if ((block is LockedDoorBlock || block is PuzzleDoorBlock) && Link.Instance.inventory.getItemCount("key") > 0){
                        currRoom.RemoveObject(block);
                        Link.Instance.inventory.removeItem("key");
                    } else if(!(block is OpenDoorBlock)) { 
                        Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkIdleWalkingSprite(Link.Instance.currentPosition, Link.Instance.isDamaged, side);
					    Link.Instance.currentState = new LinkIdleWalkingRightState();
                        Link.Instance.currentPosition.X -= collisionRect.Width;
					    Link.Instance.currentLinkSprite.DestinationRectangle = new((int)Link.Instance.currentPosition.X, (int)Link.Instance.currentPosition.Y, 38, 40);
                    }
                    break;
                default:
                    break;


			}

        }

	}
}
