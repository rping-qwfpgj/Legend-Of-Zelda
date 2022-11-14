using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Interfaces
{
    public interface ITransitionGameState: IGameState
    {
        void Update(GameTime time, TimeSpan startTime);
       
    }
}