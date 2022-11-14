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
using System.Runtime.CompilerServices;
using LegendofZelda.Blocks;
using LegendofZelda.SpriteFactories;

namespace Collision
{
    public static class LinkProjectileBlockHandler
	{		

		public static void handleCollision(ILinkProjectile projectile, IBlock block, Room room)
		{
			projectile.collide();
			room.RemoveObject(projectile);

			if(block is BombableDoorBlock && (projectile is BombDownSprite || projectile is BombLeftSprite | projectile is BombRightSprite || projectile is BombUpSprite )) { 
			{
				room.RemoveObject(block);

				// Need to remove the bombable wall on the other side
				int roomToEdit;
				switch (Link.Instance.game.currentRoomIndex) { 
						case 4:
							roomToEdit = 7;
							break;
						case 7:
							roomToEdit = 4;
							break;
						case 6:
							roomToEdit = 10;
							break;
						case 10:
							roomToEdit = 6;
							break;
						default:
							roomToEdit = 0;
							break;
				}

				// Get the room 
				List<ISprite> otherRoomSprites = Link.Instance.game.rooms[roomToEdit].sprites;

				foreach (var sprite in otherRoomSprites)
					{
						if(sprite is BombableDoorBlock)
						{
							otherRoomSprites.Remove(sprite);
							break;
						}
					}

				


				
			}

		}

	}
}
}
