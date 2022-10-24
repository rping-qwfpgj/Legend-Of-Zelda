
using Interfaces;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using States;
using Sprint0;
using System.Diagnostics;
using LegendofZelda;

namespace Collision
{
    public class CollisionDelegator
	{   
        Link link;
        private Room room;
        public CollisionDelegator(Link link, Room room) {
            this.room = room;
            this.link = link;
        }

        // method which will assign the object pair to it's pairwise handler
        /*
         * 9 cases
         * 
         * player-enemy
         * player-block
         * enemyProjectile-block
         * player-projectile block
         * player-projectile enemy
         * player-enemyProjectile
         * enemy-block 
         * enemy-enemy
         * player-item
         */
		public void handleCollision(ISprite obj, ISprite otherObj)
		{
            string side = determineSide(obj, otherObj);
            
            if (obj is IEnemyProjectile) {
                IEnemyProjectile projectile = obj as IEnemyProjectile;
                if (otherObj is IBlock) // enemyProj - block
                {
                    IBlock block = otherObj as IBlock;
                    EnemyProjectileBlockHandler.handleCollision(projectile, block, side);
                }
                if (otherObj is IAttackingSprite || otherObj is INonAttackingSprite) // enemyProj - Link
                {
                    side = determineSide(otherObj, obj);
                    EnemyProjectileLinkHandler.handleCollision(projectile, this.link, side);
                }

            } else if (obj is ILinkProjectile)
            {
                ILinkProjectile linkProjectile = obj as ILinkProjectile;
                if(otherObj is IBlock)// linkProj - Block
                {
                    IBlock block = otherObj as IBlock;
                    LinkProjectileBlockHandler.handleCollision(linkProjectile, room);
                }else if (otherObj is IEnemy) // linkProj-enemy
                {
                    IEnemy enemy = otherObj as IEnemy;                    
                    LinkProjectileEnemyHandler.handleCollision(linkProjectile, enemy, side, this.room);
                }
            } else if (obj is IEnemy)
            {
                IEnemy enemy = obj as IEnemy;
                if(otherObj is IBlock) // enemy-block
                {
                    IBlock block = otherObj as IBlock;
                    Rectangle collisionRect = new Rectangle();
                    collisionRectangle(ref obj,  ref otherObj, ref collisionRect);
                    EnemyBlockHandler.handleCollision(enemy, block, side, collisionRect);
                }

                else if (otherObj is ILinkProjectile) // LinkProj - enemy
                {
                    ILinkProjectile linkProjectile = otherObj as ILinkProjectile;
                    LinkProjectileEnemyHandler.handleCollision(linkProjectile, enemy, side, room);

                }
                else if (otherObj is INonAttackingSprite || otherObj is IAttackingSprite) // Link-enemy # 2
                {
                    side = determineSide(otherObj, obj);
                    LinkEnemyHandler.handleCollision(this.link, enemy, side);
                }


            } else if(obj is INonAttackingSprite || obj is IAttackingSprite) // obj is Link's sprite
            {
                if(otherObj is IEnemy)// link enemy # 1
                {
                    IEnemy enemy = otherObj as IEnemy;
                    LinkEnemyHandler.handleCollision(this.link, enemy, side);

                } else if (otherObj is IBlock) // link block
                {

                    IBlock block = otherObj as IBlock;
                    Rectangle collisionRect = new();
                    collisionRectangle(ref obj, ref otherObj, ref collisionRect);
                    LinkBlockHandler.handleCollision(this.link, block, side, collisionRect);
                } else if(otherObj is IEnemyProjectile)
                {
                    IEnemyProjectile enemyProj = otherObj as IEnemyProjectile;
                    EnemyProjectileLinkHandler.handleCollision(enemyProj, this.link, side);
                } else if(otherObj is IItem)
                {
                    IItem item = otherObj as IItem;
                    LinkItemHandler.handleCollision(this.link, item, this.room);
                }

            }                   
                else if (obj is IBlock)
                {
                    side = determineSide(otherObj, obj);
                    IBlock block = obj as IBlock;
                    if(otherObj is INonAttackingSprite || otherObj is IAttackingSprite) // otherObj is Link: Link- block
                    {
                        Rectangle collisionRect = new Rectangle();
                        collisionRectangle (ref obj, ref this.link.currentLinkSprite, ref collisionRect);
                        LinkBlockHandler.handleCollision(this.link, block, side, collisionRect);
                    } else if (otherObj is IEnemyProjectile) // Enemy-Proj - block
                    {
                        IEnemyProjectile projectile = otherObj as IEnemyProjectile;
                        EnemyProjectileBlockHandler.handleCollision(projectile, block, side);
                    } else if (otherObj is ILinkProjectile) // LinkProj - block
                    {
                        ILinkProjectile projectile = otherObj as ILinkProjectile;
                        LinkProjectileBlockHandler.handleCollision(projectile, room);
                    } else if (otherObj is IEnemy) // Enemy - Block
                    {
                        IEnemy enemy = otherObj as IEnemy;
                        Rectangle collisionRect = new Rectangle();
                        collisionRectangle( ref obj,  ref otherObj, ref collisionRect);
                        EnemyBlockHandler.handleCollision(enemy, block, side, collisionRect);
                    }
                } /*else if (obj is IEnemyProjectile) 
                {
                    IEnemyProjectile projectile = obj as IEnemyProjectile;
                    if(otherObj is IAttackingSprite || otherObj is INonAttackingSprite) // enemyProj - Link
                    {
                        EnemyProjectileLinkHandler.handleCollision(projectile, this.link, side);
                    }
                } else */ if (obj is IItem) 
                {
                    IItem item = obj as IItem;
                    if(otherObj is IAttackingSprite || otherObj is INonAttackingSprite) // Link - Item
                    {
                        LinkItemHandler.handleCollision(this.link, item, this.room);
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