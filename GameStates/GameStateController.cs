using System;

public class GameState
{
    GameState gamestate;
    public GameState()
    {
        this.gamestate = new GamePlayState();
    }
    public void GamePlay()
    {
        this.gamestate.GamePlay();
    }
    public void ItemSelection()
    {
        this.gamestate.ItemSelection();
    }
    public void GameOver()
    {
        this.gamestate.GameOver();
    }
    public void Pause()
    {
        this.gamestate.Pause();
    }
    public void WinGame()
    {
        this.gamestate.WinGame();
    }
    public void TransitionUp()
    {
        this.gamestate.TransitionUp();
    }
    public void TransitionDown()
    {
        this.gamestate.TransitionDown();
    }
    public void TransitionLeft()
    {
        this.gamestate.TransitionLeft();
    }
    public void TransitionRight()
    {
        this.gamestate.TransitionRight();
    }
}
