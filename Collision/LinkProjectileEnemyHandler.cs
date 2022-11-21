using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda;
using Sprites;
using System.Diagnostics;
using LegendofZelda;
using LegendofZelda.Interfaces;
using LegendofZelda.SpriteFactories;

namespace Collision
{
    public static class LinkProjectileEnemyHandler
	{		
		
		public static void handleCollision(ILinkProjectile projectile, IEnemy enemy, string side, Room room)
		{
            // have the projectile set it's currFrame to its last frame of animation
            projectile.collide();
            room.RemoveObject(projectile);
            enemy.TakeDamage(side);
        }
	}
}
