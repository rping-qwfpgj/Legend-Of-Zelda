using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
namespace LegendofZelda.Interfaces
{
    public interface ILinkAttackingSprite : ISprite
    {
        bool isAttacking();
        string getSide();
    }
}
