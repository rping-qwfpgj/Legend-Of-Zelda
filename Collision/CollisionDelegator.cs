using System;
using Interfaces;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System.Diagnostics;
using Sprint0;

namespace Collision
{
    public class CollisionDelegator
	{   
        Link link;

        public CollisionDelegator(Link link) {
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
         * 
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

            } else if (obj is ILinkProjectile)// linkProj - Block
            {
                ILinkProjectile linkProjectile = obj as ILinkProjectile;
                if(otherObj is IBlock)
                {
                    IBlock block = otherObj as IBlock;
                    LinkProjectileBlockHandler.handleCollision(linkProjectile, block, side);
                }else if (otherObj is IEnemy) // linkProj-enemy
                {
                    IEnemy enemy = otherObj as IEnemy;                    
                    LinkProjectileEnemyHandler.handleCollision(linkProjectile, enemy, side);
                }
            } else if (obj is IEnemy)
            {
                IEnemy enemy0 = obj as IEnemy;                
                if(otherObj is IBlock) // enemy-block
                {
                    IBlock block = otherObj as IBlock; 
                    EnemyBlockHandler.handleCollision(enemy0, block, side);
                } else if (otherObj is IEnemy) // enemy-enemy
                {
                    IEnemy enemy1 = otherObj as IEnemy;                    
                    EnemyEnemyHandler.handleCollision(enemy0, enemy1, side);
                }
            } else if(obj is INonAttackingSprite || obj is IAttackingSprite) // obj is Link's sprite
            {
                if(otherObj is IEnemy)// link enemy
                {
                    IEnemy enemy = otherObj as IEnemy;
                    LinkEnemyHandler.handleCollision(this.link, enemy, side);
                } else if (otherObj is IBlock) // link block
                {
                    this.link.currentLinkSprite = LinkSpriteFactory.Instance.createLinkIdleWalkingSprite(this.link.currentPosition, this.link.isDamaged, this.side);
                   
                    IBlock block = otherObj as IBlock;
                    Rectangle collisionRect = new Rectangle();
                    collisionRectangle( ref obj,  ref otherObj, ref collisionRect);
                    LinkBlockHandler.handleCollision(this.link, block, side, collisionRect);
                }
            } else 
            {                   
                side = determineSide(otherObj, obj);
                if(obj is IEnemy)
                {   
                    IEnemy enemy = obj as IEnemy;
                    if(otherObj is ILinkProjectile) // LinkProj - enemy
                    {
                        ILinkProjectile linkProjectile = otherObj as ILinkProjectile;
                        LinkProjectileEnemyHandler.handleCollision(linkProjectile, enemy, side);

                    }else if (obj is INonAttackingSprite || obj is IAttackingSprite) // Link enemy
                    {
                        LinkEnemyHandler.handleCollision(this.link, enemy, side);
                    }

                } else if (obj is IBlock)
                {
                    IBlock block = obj as IBlock;
                    if(otherObj is INonAttackingSprite || otherObj is IAttackingSprite) // otherObj is Link: Link- block
                    {

                        this.link.currentLinkSprite = LinkSpriteFactory.Instance.createLinkIdleWalking(this.link.currentPosition, this.isDamaged, side);
                        
                        Rectangle collisionRect = new Rectangle();
                        collisionRectangle (ref obj, ref this.link.currentLinkSprite, ref collisionRect);
                        LinkBlockHandler.handleCollision(this.link, block, side, collisionRect);
                    } else if (otherObj is IEnemyProjectile) // Enemy-Proj - block
                    {
                        IEnemyProjectile projectile = otherObj as IEnemyProjectile;
                        EnemyProjectileBlockHandler.handleCollision(projectile, block, side);
                    } else if (otherObj is ILinkProjectile) // LinkProj - block
                    {
                        ILinkProjectile projectile = obj as ILinkProjectile;
                        LinkProjectileBlockHandler.handleCollision(projectile, block, side);
                    } else if (otherObj is IEnemy) // Enemy - Block
                    {
                        IEnemy enemy = otherObj as IEnemy;
                        EnemyBlockHandler.handleCollision(enemy, block, side);
                    }
                } else if (obj is IEnemyProjectile) 
                {
                    IEnemyProjectile projectile = obj as IEnemyProjectile;
                    if(otherObj is IAttackingSprite || otherObj is INonAttackingSprite) // enemyProj - Link
                    {
                        EnemyProjectileLinkHandler.handleCollision(projectile, this.link, side);
                    }
                } else if (obj is IItem) 
                {
                    IItem item = obj as IItem;
                    if(otherObj is IAttackingSprite || otherObj is INonAttackingSprite) // Link - Item
                    {
                        LinkItemHandler.handleCollision(this.link, item, side);
                    }
                }
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

        private void collisionRectangle(ref ISprite obj, ref ISprite otherObj, ref Rectangle collisionRect)
        {
            Rectangle rectangle1 = obj.getHitbox();
            Rectangle rectangle2 = otherObj.getHitbox();
            Rectangle.Intersect(ref rectangle1, ref rectangle2, out collisionRect);
        }
    }
}