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
using LegendofZelda.EnemyAndNPCSprites;
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
            room.removeObject(enemy);
            ISprite dyingAnimation = EnemyAndNPCSpriteFactory.Instance.CreateEnemyOrNPC(new Vector2((int)enemy.XPosition, (int)enemy.YPosition), "Dying");
            room.AddObject(dyingAnimation);
            
        }

        

	}
}
