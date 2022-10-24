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
    public static class EnemyBlockHandler
	{
		public static void handleCollision(IEnemy enemy, IBlock block, string side, Rectangle collisionRect)
		{
           
            switch (side)
            {
                case "top":
                    Debug.WriteLine("Enemy top has collided with block");
                    enemy.Direction = enemy.Direction * -1;                    
                    break;
                case "bottom":
                    Debug.WriteLine("Enemy bottom has collided with block");
                    enemy.Direction = enemy.Direction * -1;                    
                    break;
                case "left":
                    Debug.WriteLine("Enemy left has collided with block");
                    enemy.Direction = enemy.Direction * -1;
                    break;
                case "right":
                    Debug.WriteLine("Enemy right has collided with block");
                    enemy.Direction = enemy.Direction * -1;
                    break;
                default:
                    break;
            }
        }
        
	}
}
