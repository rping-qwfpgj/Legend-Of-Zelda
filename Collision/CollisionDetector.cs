using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Link;
using Interfaces;
using Sprites;

namespace Collision
{
	public class CollisionDetector
	{

		private Link currLink;
		private List<ISprite> objects;
		// private CollisionHandler handler;
		private Room currRoom;
		private List<ISprite> exclude;

		

		public CollisionDetector(Link link, List<ISprite> sprites, Room room)
		{
			this.currLink = link;
			// this.CollsionHandler handler = handler;
			// initialize room instance and also get the current collideable objects from it
			this.currRoom = room;
			this.objects = room.ReturnObjects();
			this.objects.add(currLink.getLinkSprite);
			this.exclude = new List<ISprite>();

		}

		public boolean detectCollision(ISprite obj, ISprite otherObj)
		{
			Rectangle objectRec = obj.getRectangle();
			Rectangle otherRec = otherObj.getRectangle();

			return objectRec.Intersects(otherRec);
		}

		// method to determine type of collision to pass to handler
		string determineSide(ISprite obj, ISprite otherObj)
		{
		
			// square square test
				// return the side of the collision from the perspective of obj

		}


		public void update()
		{
			// refresh objects array with the current room's objects and add link in there
			this.objects = currRoom.ReturnObjects();
			objects.add(this.currLink);

			
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
