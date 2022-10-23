using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Sprites;
using LegendofZelda;
using LegendofZelda.Interfaces;

namespace Collision
{
    public static class EnemyBlockHandler
	{
		public static void handleCollision(IEnemy enemy, IBlock block, string side, Rectangle collisionRect)
		{
            switch (side)
            {
                case "top":
                    enemy.getHitbox();
                    // Get enemy sprite's location, subtract collisionRect.y height from it. 
                    // Change direction to down
                    break;
                case "bottom":
                    break;
                case "left":
                    break;
                case "right":
                    
                    break;
                default:
                    break;
            }
        }
	}
}
