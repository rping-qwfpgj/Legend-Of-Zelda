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
          
            if(enemy is Digdogger)
            {
                if (IsBoomerang(projectile))
                {
                    Digdogger digdogger = enemy as Digdogger;
                    digdogger.switchAction(Digdogger.DigdoggerActions.SmallStunned);
                }
            }
            else if (enemy is DodongoSprite)
            {
                if (IsBomb(projectile) && IsFacingCorrectDirection(enemy, side))
                {
                    enemy.TakeDamage(side);
                }
            } 
            else
            {
                enemy.TakeDamage(side);
            }
        }

        private static bool IsBomb(ILinkProjectile proj)
        {
            return proj is BombUpSprite || proj is BombDownSprite || proj is BombRightSprite || proj is BombLeftSprite;
        }

        private static bool IsBoomerang(ILinkProjectile projectile)
        {
            return projectile is BoomerangDownSprite || projectile is BoomerangLeftSprite
                || projectile is BoomerangRightSprite || projectile is BoomerangUpSprite;
        }

        private static bool IsFacingCorrectDirection(IEnemy enemy, string side)
        {
            DodongoSprite d =  enemy as DodongoSprite;
            switch(side)
            {
                case "top":
                    return d.CurrentDodongo is DodongoMovingUpSprite;
                case "bottom":
                    return d.CurrentDodongo is DodongoMovingDownSprite; 
                case "right":
                    return d.CurrentDodongo is DodongoMovingRightSprite;
                case "left":
                    return d.CurrentDodongo is DodongoMovingLeftSprite;
                default: 
                    return false;
            } 
        }
	}
}
