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
				room.RemoveObject(block);
			}
		}

	}
}
