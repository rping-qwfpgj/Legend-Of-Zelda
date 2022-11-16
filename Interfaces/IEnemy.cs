using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;


namespace LegendofZelda.Interfaces
{
    public interface IEnemy:ISprite
    {
        void TakeDamage(string side);
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public int Direction { get; set; }
        void TurnAround(string side);
        public bool IsDead { get; set; }
        public bool DyingComplete { get; set; }
        ISprite DropItem();
      
    }
}
