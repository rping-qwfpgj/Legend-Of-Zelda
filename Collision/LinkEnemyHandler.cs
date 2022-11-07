using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Interfaces;
using Sprites;

using LegendofZelda;
using LegendofZelda.Interfaces;
using System.Diagnostics;
using LegendofZelda.SpriteFactories;

namespace Collision
{
    public static class LinkEnemyHandler
	{		

		public static void handleCollision(Link link, IEnemy enemy, string side, Room room)
		{
			
			if(link.currentLinkSprite is IAttackingSprite)
			{
                IAttackingSprite currLinkSprite = (IAttackingSprite)link.currentLinkSprite;
                if (currLinkSprite.isAttacking() && link.currentState.Direction() == side )
                { 
                     side = reverseSide(side);
                     enemy.TakeDamage(side);
                     
                    
                    /*
                     
                    */
                    /*
					 * for future:
					 * if enemy.health <= 0
					 * game/room.remove(enemy)
					 */
                }
            } else
			{
				link.TakeDamage(side);
                /*
				 * for future:
				 * if Link.health <= 0
				 * game over 
				 */
            }
        }


        private static string reverseSide(string side)
		{
            // if enemy is to take damage, reverse side so that collision is from their perspective rather than link's
			switch(side)
            {
                 case "top":
                      return "bottom";
                      break;
                 case "bottom":
                      return "top";
                      break;
                 case "left":
                      return "right";
                      break;
                 case "right":
                      return "left";
                      break;
                 default:
                      return "error no cases chosen";
                      break;
            }
		}

	}
}
