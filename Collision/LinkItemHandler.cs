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
            Link.Instance.inventory.addItem(item);
            switch (item)
			{
				case SmallRedHeart:
                    Link.Instance.health += 1.0f;
					break;

				case Fairy:
                    Link.Instance.health = 3.0f;
					break;

				case Triforce:
                    Link.Instance.health = 4.0f;  
					// trigger the win game state
                    break;

				case OrangeMap:
                   // display the map (make it not transparent)
					break;

				case Bow:
					// let link shoot arrows
					break;

				case Compass:
					// display the red dot on the map
					break;
                default:
					break;

            }
			/*
			if (item is SmallRedHeart)
			{
				Link.Instance.health += 1.0f;
			}
			if (item is Fairy)
			{
				Link.Instance.health = 3.0f;
			}
			
			if (item is Triforce)
			{
                Link.Instancehealth = 4.0f;
            }
			*/
			room.RemoveObject(item);
		}        
	}
}
