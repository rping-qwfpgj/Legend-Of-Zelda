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

		public static void handleCollision(IEnemyProjectile projectile, IBlock block, string side, Room room)
		{
			//have the projectile set it's currFrame to its last frame of animation
			//Debug.WriteLine("Collision detected/n");
			projectile.collide();
			room.RemoveObject(projectile);
			
		}        
	}
}
