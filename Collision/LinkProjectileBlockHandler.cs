using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Sprint0;
using Sprites;
using LegendofZelda;
using LegendofZelda.Interfaces;

namespace Collision
{
    public static class LinkProjectileBlockHandler
	{		

		public static void handleCollision(ILinkProjectile projectile, IBlock block, string side)
		{
			// have the projectile set it's currFrame to its last frame of animation
			projectile.collide();
		}

        

	}
}
