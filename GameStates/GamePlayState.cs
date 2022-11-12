using System;

namespace Gamestates
{   
    public class GamePlayState : IGameState
    {
        public GamePlayState()
        {
            
        }
        void GamePlay(); // already in gameplaystate 
        void ItemSelection()
        {

        }
        void GameOver()
        {

        }
        void Pause();
        void WinGame();
        void TransitionUp();
        void TransitionDown();
        void TransitionLeft();
        void TransitionRight();
    }
}

