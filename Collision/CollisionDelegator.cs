using System;
using Interfaces;
using Microsoft.Xna.Framework;
using Sprint0;

namespace Collision
{
	public class CollisionDelegator
	{
        Link link;

        public CollisionDelegator(Link link) {
            this.link = link;
        }

		public void handleCollision(ISprite obj, ISprite otherObj)
		{
            if (obj is IEnemyProjectile) {
                IEnemyProjectile projectile = obj as IEnemyProjectile;
                if (otherObj is IBlock)
                {
                    IBlock block = otherObj as IBlock;
                    string side = determineSide(projectile, block);
                    EnemyProjectileBlockHandler.handleCollision(projectile, block, side);
                }
            } else if (obj is ILinkProjectile)
            {

            } else if (obj is IEnemy)
            {

            } else // obj is Link's sprite
            {

            }                                   			    
		}


        private string determineSide(ISprite obj, ISprite otherObj)
        {

            Rectangle objectRec = obj.getHitbox();
            Rectangle otherRec = otherObj.getHitbox();

            // return the side of the collision from the perspective of obj


            // first determine if top-bottom or left-right collision
            string type = "";
            Rectangle intersectionArea = Rectangle.Intersect(objectRec, otherRec);

            if (intersectionArea.Height < intersectionArea.Width)
            {
                type = "top-bottom";
            }
            else
            {
                type = "left-right";
            }

            // then get obj's position in relation to otherObj to return side

            if (type == "top-bottom")
            {
                if (objectRec.Location.Y < otherRec.Location.Y)
                {
                    return "bottom";
                }
                else
                {
                    return "top";
                }
            }
            else
            {
                if (objectRec.Location.X < otherRec.Location.X)
                {
                    return "right";
                }
                else
                {
                    return "left";
                }
            }

        }
    }
}