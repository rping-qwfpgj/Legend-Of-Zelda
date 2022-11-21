using Microsoft.Xna.Framework;
using System;

namespace Interfaces
{
    public interface ITransitionGameState: IGameState
    {
        void Update(GameTime time, TimeSpan startTime);
    }
}