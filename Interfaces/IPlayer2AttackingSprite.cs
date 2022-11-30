using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
namespace LegendofZelda.Interfaces
{
    public interface IPlayer2AttackingSprite : ISprite
    {
        bool isAttacking();
        string getSide();
    }
}
