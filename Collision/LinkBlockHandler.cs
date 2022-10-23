using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Sprites;
using LegendofZelda;
using LegendofZelda.Interfaces;
using System.Diagnostics;
using Interfaces;

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
					Debug.WriteLine(" case 2 Link-Block detected on side: " + side + " collision width = " + collisionRect.Width + " collision height: " + collisionRect.Height);
					
					link.currentPosition.X -= collisionRect.Width;
					link.currentLinkSprite.DestinationRectangle = new ((int)link.currentPosition.X, (int)link.currentPosition.Y, 40, 44);

                    break;
                default:
                    break;


			}

        }

	}
}
