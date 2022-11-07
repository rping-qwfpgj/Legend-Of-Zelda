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
using LegendofZelda.SpriteFactories;

namespace Collision
{
    public static class LinkProjectileEnemyHandler
	{		
		
		public static void handleCollision(ILinkProjectile projectile, IEnemy enemy, string side, Room room)
		{
            // have the projectile set it's currFrame to its last frame of animation
            projectile.collide();
            room.removeObject(projectile);
            enemy.TakeDamage(side);
            if (enemy is StalfosSprite)
            {
                StalfosSprite stalfos = enemy as StalfosSprite;
                if (stalfos.IsDead)
                {
                    ISprite item = stalfos.DropItem();
                    if (item != null)
                    {
                        room.AddObject(item);

                    }
                }

            }

        }

        

	}
}
