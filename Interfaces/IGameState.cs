using Microsoft.Xna.Framework.Graphics;

namespace Interfaces
{
    public interface IGameState
    {
        void GamePlay();
        void Inventory();
        void GameOver();
        void Pause();
        void WinGame();
        void TransitionUp();
        void TransitionDown();
        void TransitionLeft();
        void TransitionRight();
        void Update();
        void Draw(SpriteBatch spriteBatch);      
    }
}