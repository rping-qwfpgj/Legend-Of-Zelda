using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Sprites;
using LegendofZelda;
using System.Diagnostics;
using LegendofZelda.Interfaces;
using SharpDX.Direct2D1;

namespace Collision
{
    public class CollisionDetector
	{

		private Link currLink;
		private Game1 currGame;
		private List<ISprite> objects;
		private List<ISprite> alreadyChecked;
		private CollisionDelegator handler;
		private Room currRoom;
		
		public CollisionDetector(Link link, Room room, Game1 game)
		{
			this.currGame = game;
			this.currLink = link;

			// initialize room instance and also get the current collideable objects from it
			this.currRoom = room;
			this.objects = room.ReturnObjects();
			this.alreadyChecked = new List<ISprite>();
			this.handler = new CollisionDelegator(link, room, game);
			
		
		}

		public bool detectCollision(ISprite obj, ISprite otherObj)
		{
			Rectangle objectRec = obj.GetHitbox();
			Rectangle otherRec = otherObj.GetHitbox();

			return objectRec.Intersects(otherRec);
		}
		

		/*
		 *  Update method will constantly be checking all objects for a collision
		 */
		public void Update()
		{	
			this.currRoom = this.currGame.currentRoom;
			this.handler = new CollisionDelegator(this.currLink, currRoom, this.currGame);
			// refresh objects array with the current room's objects and add link in there
			this.objects = currRoom.ReturnObjects();
            
            ISprite currLinkSprite = this.currLink.currentLinkSprite;
            this.objects.Add(currLinkSprite);
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
							//Debug.WriteLine(i + "collision detected!");
							//i++; //used to check that debug is working
							
                            this.handler.handleCollision(obj, otherObj);
							// pass some stuff and let the handler handle it from here
						}
					}
				}
				// now that we've checked all the possible collision interactions with this object, we don't need to agian for now
				this.alreadyChecked.Add(obj);
			}
           this.objects.Remove(currLinkSprite);

        }





	}
}
