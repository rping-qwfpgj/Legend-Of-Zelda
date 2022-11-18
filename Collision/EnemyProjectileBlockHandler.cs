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

namespace Collision
{
    public static class EnemyProjectileBlockHandler
	{		
		static EnemyProjectileBlockHandler()
		{
			
		}

		public static void handleCollision(IEnemyProjectile projectile, Room room)
		{
			projectile.collide();
			room.RemoveObject(projectile);
		}        
	}
}
