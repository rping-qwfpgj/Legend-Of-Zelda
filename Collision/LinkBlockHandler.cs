using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Interfaces;
using Sprites;
using LegendofZelda;

namespace Collision
{
	public static class LinkBlockHandler
	{		
		
		public static void handleCollision(Link link, IBlock block, string side, Rectangle collisionRect)
		{ 
			switch (side)
			{
				case "top":
					link.currentPosition.Y += collisionRect.Height;
					break;
				case "bottom":
					link.currentPosition.Y -= collisionRect.Height;
                    break;
				case "left":
					link.currentPosition.X += collisionRect.Width;
                    break;
                case "right":
					link.currentPosition.X -= collisionRect.Width;
                    break;
                default:
                    break;


			}

        }

	}
}
