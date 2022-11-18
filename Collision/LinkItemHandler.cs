using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using Sprint0;
using Sprites;
using LegendofZelda;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using LegendofZelda.Items;
using LegendofZelda.SpriteFactories;

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
            room.RemoveObject(item);
            switch (item)
			{
				case SmallRedHeart:
                    Link.Instance.health += 1.0f;
					if(Link.Instance.health > Link.Instance.maxHealth)
					{
						Link.Instance.health = Link.Instance.maxHealth;
					}
					break;
				
				case BigHeart:
                    Link.Instance.health += 1.0f;
                    Link.Instance.maxHealth = 4;
                    if (Link.Instance.health > Link.Instance.maxHealth)
                    {
                        Link.Instance.health = Link.Instance.maxHealth;
                    }
                    
					break;

				case Fairy:
                    Link.Instance.health = Link.Instance.maxHealth;
					break;

				case Triforce:
                    Link.Instance.health = 4.0f;
					SoundFactory.Instance.CreateSoundEffect("Winning").Play();
					Link.Instance.game.gameStateController.gameState.WinGame();
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
			
		}        
	}
}
