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
using LegendofZelda.Items;

namespace Collision
{
    public static class LinkItemHandler
	{		
		static LinkItemHandler()
		{
		}
		public static void handleCollision(IItem item, Room room, Game1 game)
		{
			SoundEffect itemPickup = game.Content.Load<SoundEffect>("item_pickup");
			itemPickup.Play();
			if (item is SmallRedHeart)
			{
				Link.Instance.health += 1.0f;
			}
			if (item is Fairy)
			{
				Link.Instance.health = 3.0f;
			}
			/*
			if (item is Triforce)
			{
                Link.Instancehealth = 4.0f;
            }
			*/
			room.RemoveObject(item);
		}        
	}
}
