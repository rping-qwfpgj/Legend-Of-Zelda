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
	public class LinkProjectileBlockHandler
	{		
		public LinkProjectileBlockHandler()
		{
		
		}

		public void handleCollision(ILinkProjectile projectile, IBlock block, string side)
		{
			// have the projectile set it's currFrame to its last frame of animation
			projectile.collide();
		}

        

	}
}
