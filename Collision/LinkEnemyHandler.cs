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

namespace Collision
{
    public static class LinkEnemyHandler
	{		

		public static void handleCollision(Link link, IEnemy enemy, string side)
		{

			if(link.currentLinkSprite is IAttackingSprite)
			{
                IAttackingSprite currLinkSprite = (IAttackingSprite)link.currentLinkSprite;
                if (currLinkSprite.isAttacking() && link.currentState.Direction() == side )
                {
                    // enemy.TakeDamage(); // may need to change this to whatever name Tuhin gives takeDamage method in enemy class
                    /*
					 * for future:
					 * if enemy.health <= 0
					 * game/room.remove(enemy)
					 */
                }
            } else
			{
				link.TakeDamage();
                /*
				 * for future:
				 * if Link.health <= 0
				 * game over 
				 */
            }
        }

	}
}
