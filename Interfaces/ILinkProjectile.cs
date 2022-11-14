using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;


namespace LegendofZelda.Interfaces
{
    public interface ILinkProjectile : ISprite
    {
        void collide();
        public bool IsDone { get; }
    }
}
