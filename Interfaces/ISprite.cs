using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace LegendofZelda.Interfaces
{
    public interface ISprite
    {
        void Draw(SpriteBatch spriteBatch);
        void Update();
        Rectangle GetHitbox();
    }
}
