namespace Interfaces
{
    public interface IGameState
    {
        void ItemSelection();
        void GameOver();
        void Pause();
        void WinGame();
        void TransitionUp();
        void TransitionDown();
        void TransitionLeft();
        void TransitionRight();        
    }
}