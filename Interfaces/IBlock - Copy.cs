using Microsoft.Xna.Framework.Graphics;
using System;


namespace LegendofZelda.Interfaces
{
    public interface IBackground : ISprite
    {
        public void TransitionDirection(String direction);
    }
}
