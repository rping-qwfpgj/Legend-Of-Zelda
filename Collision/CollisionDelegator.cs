using System;
using Interfaces;

namespace Collision
{
	public class CollisionDelegator
	{
		public CollisionDelegator()
		{

		}

		public void handleCollision(ISprite obj, ISprite otherObj)
		{
			switch (obj)
			{
                case obj is IEnemyProjectile:
                    IEnemyProjevile newObj = obj as IEnemyProjectile;

                    // do something
                    break;
                case obj is ILinkProjectile:
                    // do something else
                    break;
                case obj is IEnemy:
                    // do another thing
                    break;
                default: // Case the sprite is Link's Sprite
                    // do something
                    break;                    	
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