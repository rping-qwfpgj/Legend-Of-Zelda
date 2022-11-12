using Microsoft.Xna.Framework.Graphics;
using System;


namespace LegendofZelda.Interfaces
{
    public interface IBackground : ISprite
    {
        public void SetTransitionDirection(String direction);
        public bool IsTransitioning { get; }
    }
}
