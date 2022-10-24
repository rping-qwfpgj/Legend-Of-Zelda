using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Sprites;
using LegendofZelda;
using LegendofZelda.Interfaces;

namespace Collision
{
    public static class LinkItemHandler
	{		
		static LinkItemHandler()
		{
		}
		public static void handleCollision(Link link, IItem item, Room room)
		{
			room.removeObject(item);
		}        
	}
}
