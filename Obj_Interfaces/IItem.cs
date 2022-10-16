using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;


namespace Interfaces
{
    public interface IItem: ISprite
    {
        new void Draw(SpriteBatch spriteBatch);
        new void Update();
        new Rectangle getHitbox();
    }
}
