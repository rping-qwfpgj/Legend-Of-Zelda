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

			if(block is BombableDoorBlock)
			{
				//BombableDoorBlock bombableDoor = block as BombableDoorBlock;
				//Vector2 newDoorPosition = new Vector2(bombableDoor.DestinationRectangle.X, bombableDoor.DestinationRectangle.Y - 10);
				//IBlock newDoor = (IBlock)BlockSpriteFactory.Instance.CreateBlock(newDoorPosition,"OpenDoorBlockTop");
				room.RemoveObject(block);
				//room.AddObject(newDoor);
				Debug.WriteLine("Reached");
			}
		}

	}
}
