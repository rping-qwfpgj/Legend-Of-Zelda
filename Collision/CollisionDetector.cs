using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Interfaces;
using Sprites;
using LegendofZelda;

namespace Collision
{
	public class CollisionDetector
	{

		private Link currLink;
		private Room currRoom;
		private List<ISprite> objects;
		private List<ISprite> exclude;
		// private CollisionHandler handler;


		

		public CollisionDetector(Link link, List<ISprite> sprites, Room room)
		{
			this.currLink = link;
			// this.CollsionHandler handler = handler;

			// initialize room instance and also get the current collideable objects from it
			this.currRoom = room;
			this.objects = room.ReturnObjects();
			this.objects.add(currLink.currentLinkSprite);
			this.exclude = new List<ISprite>();

		}

		public bool detectCollision(ISprite obj, ISprite otherObj)
		{
			Rectangle objectRec = obj.getHitbox();
			Rectangle otherRec = otherObj.getHitbox();

			return objectRec.Intersects(otherRec);
		}

		string determineSide(ISprite obj, ISprite otherObj)
		{
		
			Rectangle objectRec = obj.getHitbox();
			Rectangle otherRec = otherObj.getHitbox();

			// "square square" test
			// return the side of the collision from the perspective of obj

			
			// first determine if top-bottom or left-right collision
			string type = "";
			Rectangle intersectionArea = Rectangle.Intersect(objectRec, otherRec);
			
			if(intersectionArea.Height < intersectionArea.Width)
			{
				type = "top-bottom";
			} else
			{
				type = "left-right";
			}

			// then get obj's position in relation to otherObj to return side

			if(type == "top-bottom")
			{
				if (objectRec.Location.Y < otherRec.Location.Y)
				{
					return "bottom";
				} else
				{
					return "top";
				}
			} else if (type == "left-right")
			{
				if (objectRec.Location.X < otherRec.Location.X)
				{
					return "right";
				} else
				{
					return "left";
				}
			}

		}

		/**
		 *  Update method will constantly be checking all objects for a collision
		 */
		public void update()
		{
			// refresh objects array with the current room's objects and add link in there
			this.objects = currRoom.ReturnObjects();
			objects.add(this.currLink);
			this.exclude = new List<ISprite>();

			
			foreach (ISprite obj in this.objects)
			{
				foreach (ISprite otherObj in this.objects)
				{
					if (obj == otherObj)
					{
						continue;
					}

					if (!exclude.contains(obj)) { // only check for collision if object is not in our blacklist (there may be a better way to do this?)
						if (detectCollision(obj, otherObj))
						{
							Console.WriteLine("collision detected!");
							// pass some stuff and let the handler handle it from here
						}
					}
				}
				// now that we've checked all the possible collision interactions with this object, we don't need to agian for now
				exclude.add(obj);
			}


		}





	}
}
