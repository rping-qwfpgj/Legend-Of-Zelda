
using Interfaces;
using LegendofZelda.Interfaces;
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
            string side = determineSide(obj, otherObj);

            if (obj is IEnemyProjectile) {
                IEnemyProjectile projectile = obj as IEnemyProjectile;
                if (otherObj is IBlock)
                {
                    IBlock block = otherObj as IBlock;
                    EnemyProjectileBlockHandler.handleCollision(projectile, block, side);
                }

            } else if (obj is ILinkProjectile)
            {
                ILinkProjectile linkProjectile = obj as ILinkProjectile;
                if(otherObj is IBlock)
                {
                    IBlock block = otherObj as IBlock;
                    LinkProjectileBlockHandler.handleCollision(linkProjectile, block, side);
                }else if (otherObj is IEnemy)
                {
                    IEnemy enemy = otherObj as IEnemy;                    
                    LinkProjectileEnemyHandler.handleCollision(linkProjectile, enemy, side);
                }
            } else if (obj is IEnemy)
            {
                IEnemy enemy0 = obj as IEnemy;                
                if(otherObj is IBlock)
                {
                    IBlock block = otherObj as IBlock; 
                    EnemyBlockHandler.handleCollision(enemy0, block, side);
                } else if (otherObj is IEnemy)
                {
                    IEnemy enemy1 = otherObj as IEnemy;                    
                    EnemyEnemyHandler.handleCollision(enemy0, enemy1, side);
                }
            } else if(obj is INonAttackingSprite || obj is IAttackingSprite) // obj is Link's sprite
            {
                if(otherObj is IEnemy)
                {
                    IEnemy enemy = otherObj as IEnemy;
                    LinkEnemyHandler.handleCollision(this.link, enemy, side);
                } else if (otherObj is IBlock)
                {
                    IBlock block = otherObj as IBlock;
                    Rectangle collisionRect = new();
                    collisionRectangle(ref obj, ref otherObj, ref collisionRect);
                    LinkBlockHandler.handleCollision(this.link, block, side, collisionRect);
                }
            } else 
            {   
                side = determineSide(otherObj, obj);
                if(otherObj is IEnemy)
                {   
                    IEnemy enemy = otherObj as IEnemy;
                    if(obj is ILinkProjectile)
                    {
                        ILinkProjectile linkProjectile = obj as ILinkProjectile;
                        LinkProjectileEnemyHandler.handleCollision(linkProjectile, enemy, side);

                    }else if (obj is INonAttackingSprite || obj is IAttackingSprite)
                    {

                    }

                } else if (otherObj is IBlock)
                {

                } else if (otherObj is IEnemyProjectile)
                {

                } else if (otherObj is IItem)
                {

                }
            }                                                                        
		}

        private string determineSide(ISprite obj, ISprite otherObj)
        {

            Rectangle objectRec = obj.GetHitbox();
            Rectangle otherRec = otherObj.GetHitbox();

            // return the side of the collision from the perspective of obj


            // first determine if top-bottom or left-right collision
            string type;
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

        private void collisionRectangle(ref ISprite obj, ref ISprite otherObj, ref Rectangle collisionRect)
        {
            Rectangle rectangle1 = obj.GetHitbox();
            Rectangle rectangle2 = otherObj.GetHitbox();
            Rectangle.Intersect(ref rectangle1, ref rectangle2, out collisionRect);
        }
    }
}