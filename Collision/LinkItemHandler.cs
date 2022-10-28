using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Sprites;
using LegendofZelda;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;

namespace Collision
{
    public static class LinkItemHandler
	{		
		static LinkItemHandler()
		{
		}
		public static void handleCollision(Link link, IItem item, Room room, Game1 game)
		{
			SoundEffect itemPickup = game.Content.Load<SoundEffect>("item_pickup");
			itemPickup.Play();
			room.removeObject(item);
		}        
	}
}
