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
	public class EnemyProjectileLinkHandler
	{		
		public EnemyProjectileLinkHandler()
		{
		
		}

		public void handleCollision(IEnemyProjectile projectile, Link link, string side)
		{
            // have the projectile set it's currFrame to its last frame of animation
            // projectile.collide();
            link.TakeDamage();
			/*
			 * for future:
			 * if Link.health <= 0
			 * game over 
			 */
			
		}

        

	}
}
