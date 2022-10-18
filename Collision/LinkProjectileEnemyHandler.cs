using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Interfaces;
using Sprites;
using LegendofZelda;

namespace Collision
{
	public static class LinkProjectileEnemyHandler
	{		
		
		public static void handleCollision(ILinkProjectile projectile, IEnemy enemy, string side)
		{
            // have the projectile set it's currFrame to its last frame of animation
            projectile.collide();
            // enemy.TakeDamage();
			/*
			 * for future:
			 * if enemy.health <= 0
			 * game/room.remove(enemy)
			 */
			
		}

        

	}
}
