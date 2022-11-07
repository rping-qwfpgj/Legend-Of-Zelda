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
using Interfaces;

namespace Collision
{
    public static class EnemyBlockHandler
	{
		public static void handleCollision(IEnemy enemy, IBlock block, string side, Rectangle collisionRect)
		{
           if((enemy is WallMasterSprite) && (block is IBoundingBlock)) {
                // do nothing
            } else if ((enemy is KeeseSprite) && (block is INonBoundingBlock))
            {
                // do nothing
            } else { 
            if(true)
                {
                enemy.TurnAround(side);
                switch (side)
                {
                    case "top":
                        enemy.YPosition += (collisionRect.Height);
                        enemy.DestinationRectangle = new((int)enemy.XPosition, (int)enemy.YPosition, 30, 32);
                        //enemy.Direction = enemy.Direction * -1;
                        break;
                    case "bottom":
                        enemy.YPosition -= collisionRect.Height;
                        enemy.DestinationRectangle = new((int)enemy.XPosition, (int)enemy.YPosition, 30, 32);
                         //enemy.Direction = enemy.Direction * -1;
                        break;
                    case "left":
                        enemy.XPosition += collisionRect.Width;
                        enemy.DestinationRectangle = new((int)enemy.XPosition, (int)enemy.YPosition, 30, 32);
                        //enemy.Direction = enemy.Direction * -1;
                        break;
                    case "right":
                        enemy.XPosition -= collisionRect.Width;
                        enemy.DestinationRectangle = new((int)enemy.XPosition, (int)enemy.YPosition, 30, 32);
                        //enemy.Direction = enemy.Direction * -1;
                        break;
                    default:
                        break;
                }
            }
          }
        }
        
	}
}
