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

		public static void handleCollision(Link link, IEnemy enemy, string side, Room room, Game1 game)
		{
			
			if(link.currentLinkSprite is IAttackingSprite)
			{
                IAttackingSprite currLinkSprite = (IAttackingSprite)link.currentLinkSprite;
                
                     side = reverseSide(side);
                     enemy.TakeDamage(side);
                     
                    
                    /*
                     
                    */
                    /*
					 * for future:
					 * if enemy.health <= 0
					 * game/room.remove(enemy)
					 */
                
            } else
			{
                if(enemy is WallMasterSprite)
                {
                    game.currentRoomIndex = 0;
                    game.currentRoom = game.rooms[game.currentRoomIndex];
                } else { 
				    link.TakeDamage(side);
                }
                
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
                      
                 case "bottom":
                      return "top";
                      
                 case "left":
                      return "right";
                      
                 case "right":
                      return "left";
                      
                 default:
                      return "error no cases chosen";
                      
            }
		}

	}
}
