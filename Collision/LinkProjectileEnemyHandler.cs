using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using Sprites;
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

            if(enemy is Digdogger && projectile is BoomerangDownSprite || projectile is BoomerangLeftSprite
                || projectile is BoomerangRightSprite || projectile is BoomerangUpSprite)
            {
                Digdogger digdogger = enemy as Digdogger;
                digdogger.switchAction(Digdogger.DigdoggerActions.SmallStunned);
            }
        }
	}
}
