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
		private List<ISprite> alreadyChecked;
		private CollisionDelegator handler;
		
		
		public CollisionDetector(Link link, Room room)
		{
			this.currLink = link;
			this.handler = new CollisionDelegator(link);

			// initialize room instance and also get the current collideable objects from it
			this.currRoom = room;
			this.objects = room.ReturnObjects();
			this.objects.Add(currLink.currentLinkSprite);
			this.alreadyChecked = new List<ISprite>();
			this.handler = new CollisionDelegator(link);
		
		}

		public bool detectCollision(ISprite obj, ISprite otherObj)
		{
			Rectangle objectRec = obj.getHitbox();
			Rectangle otherRec = otherObj.getHitbox();

			return objectRec.Intersects(otherRec);
		}
		

		/*
		 *  Update method will constantly be checking all objects for a collision
		 */
		public void Update()
		{
			// refresh objects array with the current room's objects and add link in there
			this.objects = currRoom.ReturnObjects();
			this.objects.Add(this.currLink.currentLinkSprite);
			this.alreadyChecked.Clear();

			
			foreach (ISprite obj in this.objects)
			{
				foreach (ISprite otherObj in this.objects)
				{
					if (obj == otherObj)
					{
						continue;
					}

					if (!alreadyChecked.Contains(otherObj)) { // only check for collision if object has not already been compared to all other objects (there may be a better way to do this?)
						if (detectCollision(obj, otherObj))
						{
							Console.WriteLine("collision detected!");							
							this.handler.handleCollision(obj, otherObj);
							// pass some stuff and let the handler handle it from here
						}
					}
				}
				// now that we've checked all the possible collision interactions with this object, we don't need to agian for now
				this.alreadyChecked.Add(obj);

			}
            this.objects.Remove(this.currLink.currentLinkSprite);

        }





	}
}
